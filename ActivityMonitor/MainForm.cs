using ActivityMonitorML.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ActivityMonitor
{
  public partial class MainForm : Form
  {
    enum MatrixType
    {
      BlackAndWhite,
      Colored,
      Numeric
    };
    const int MINUTES_IN_DAY = 1440;
    const int SENSOR_COLUMS = 4;
    public enum MLTraining
    {
      EMPTY_ROOM = 0,
      MOVING = 1,
      TV = 2,
      SLEEPING = 3,
      FALLING = 4,
      NOT_TRAINING = 0xFF
    };

    int[] serialInputRow = new int[32];
    BackgroundWorker serialInputWorker;
    ISerialPort serialPort;
    bool stopReading = false;
    bool ignoreFirstReadError = true;
    public int secondCounter = 0;
    public int minuteCounter = 0;
    int[] previousInputRow = null;
    int[] movementRow = null;
    public MLTraining trainingItem = MLTraining.NOT_TRAINING;
    Timer countdownTimer = new Timer();
    bool askOnceForNewTraining = true;
    int trainingRowCount = 0;
    DateTime previousEndTime = DateTime.MinValue;

    //Sleep handling
    public int[] isSleepingVector;
    int dayCount = 0;
    int awakeWarningCount = 0;
    int sleepWarningCount = 0;
    public const int AWAKE_WARNING = 600;
    public const int SLEEP_WARNING = 600;
    public const int MAX_VAL_FOR_MINUTE = 10;
    public const int SLEEP_EXP_THRESHOLD = 5;
    public const int AWAKE_EXP_THRESHOLD = 5;
    public int sleepWarningCounter = 0;
    public int awakeWarningCounter = 0;
    bool mlPredicting = false;
    bool sleepMonitoring = false;
    decimal[] minuteSleepScores = new decimal[60];
    FallDetection fallDetection;
    bool isEmailConfigured = false;

    public MainForm(bool isUnitTest)
    {
      InitializeComponent();
      logToolStripMenuItem.Checked = textBoxLog.Visible = Properties.Settings.Default.ShowLog;
      inputToolStripMenuItem.Checked = Properties.Settings.Default.OpenInput;
      dataRowToolStripMenuItem.Checked = Properties.Settings.Default.MovementRow;
      sleepGraphToolStripMenuItem.Checked = chart1.Visible = Properties.Settings.Default.SleepGraphVisible;
      temperatureToolStripMenuItem.Checked = groupBoxTemperature.Visible = Properties.Settings.Default.TemperatureVisible;
      mLPredictionToolStripMenuItem.Checked = groupBoxPrediction.Visible = Properties.Settings.Default.MLPredictionVisible;
      OpenSerialPort(isUnitTest);
      mlPredicting = groupBoxPrediction.Visible;
      if (string.IsNullOrEmpty(Properties.Settings.Default.ReceiverEmail))
      {
        AddInfo("Fall detection e-mails not configured. They can be set in Settings->General");
      }
    }

    private void SetUpFallDetection()
    {
      if (!(string.IsNullOrEmpty(Properties.Settings.Default.ReceiverEmail) ||
          string.IsNullOrEmpty(Properties.Settings.Default.SenderPassword) ||
          string.IsNullOrEmpty(Properties.Settings.Default.SenderGmail)))
      {
        isEmailConfigured = true;
      }

      if (fallDetection == null)
      {
        fallDetection = new FallDetection(FallWarning, FallDetected, FallNotDetected);
      }
    }

    private void FallWarning()
    {
      AddInfo("Fall detected. Waiting 10s for person to get up");
    }

    private void Sendwarning(string text)
    {
      AddInfo("Sending alarm to " + Properties.Settings.Default.ReceiverEmail);
      try
      {
        /*EmailSender.SendWarning(Properties.Settings.Default.SenderGmail,
                                Properties.Settings.Default.SenderPassword,
                                Properties.Settings.Default.ReceiverEmail,
                                "Fall detected");*/
      }
      catch (Exception ex)
      {
        AddInfo("Error sending e-mail: " + ex.Message);
      }
    }

    private void FallDetected()
    {
      AddInfo("Fall detected. Raise alarm");

      if (isEmailConfigured)
      {
        AddInfo("Sending alarm to " + Properties.Settings.Default.ReceiverEmail);
        Sendwarning("Fall detected");
      }
    }

    private void FallNotDetected()
    {
      AddInfo("Fall NOT detected. No alarm");
    }

    private void OpenSerialPort(bool isUnitTest)
    {
      try
      {
        if (isUnitTest)
        {
          serialPort = new TestSerialPort();
        }
        else
        {
          serialPort = new SerialPortImpl();
        }
        serialPort.Open("COM" + Properties.Settings.Default.ComPort, 115200);
        AddInfo("Opened COM" + Properties.Settings.Default.ComPort);
        stopReading = false;
        if (!isUnitTest)
        {
          serialInputWorker = new BackgroundWorker();
          serialInputWorker.DoWork += SerialInputWorker_DoWork;
          serialInputWorker.RunWorkerAsync();
          startToolStripMenuItem.Text = "Stop";
        }
      }
      catch (Exception ex)
      {
        AddInfo("Failed to open COM" + Properties.Settings.Default.ComPort + ": " + ex.Message);
      }
    }

    private void ShowMLPrediction(ModelOutput mlOutput)
    {
      Invoke((MethodInvoker)delegate ()
      {
        labelPrediction.Text = ((MLTraining)(int)mlOutput.Prediction).ToString();
      });
      Invoke((MethodInvoker)delegate ()
      {
        decimal value = (decimal)Math.Round(mlOutput.Score[0] * 100, 1);
        lPEmpty.Text = "Empty: " + value + " %";
      });
      Invoke((MethodInvoker)delegate ()
      {
        decimal value = (decimal)Math.Round(mlOutput.Score[1] * 100, 1);
        lPMoving.Text = "Moving: " + value + " %";
      });
      Invoke((MethodInvoker)delegate ()
      {
        decimal value = (decimal)Math.Round(mlOutput.Score[2] * 100, 1);
        lPTV.Text = "TV: " + value + " %";
      });
      Invoke((MethodInvoker)delegate ()
      {
        decimal value = (decimal)Math.Round(mlOutput.Score[3] * 100, 1);
        minuteSleepScores[DateTime.Now.Second] = value;
        lPSleeping.Text = "Sleeping: " + value + " %";
      });
      Invoke((MethodInvoker)delegate ()
      {
        decimal value = (decimal)Math.Round(mlOutput.Score[4] * 100, 1);
        lPFalling.Text = "Falling: " + value + " %";
      });
      //AddInfo("P: " + labelPrediction.Text);
      //AddInfo(lPEmpty.Text + " " + lPMoving.Text + " " + lPTV.Text + " " + lPSleeping.Text + " " + lPFalling.Text);
    }

    private int[] CalibratedInputRow(int[] inputRow)
    {
      int[] calibratedRow = new int[32];

      int roomTemp = Test.DataHandling.GetRoomTemp(inputRow);

      for (int i = 0; i < 32; i++)
      {
        calibratedRow[i] = inputRow[i] - roomTemp;
      }

      return calibratedRow;
    }

    /// <summary>
    /// Called once in a second
    /// </summary>
    /// <param name="inputRow"></param>
    private void DoMachineLearning(int[] inputRow, string file, bool isPredicting)
    {
      try
      {
        if (previousInputRow == null)
        {
          previousInputRow = new int[32];

          inputRow.CopyTo(previousInputRow, 0);
          return;
        }
        DateTime dtNow = DateTime.Now;

        movementRow = new int[32];
        for (int i = 0; i < 32; i++)
        {
          movementRow[i] = inputRow[i] - previousInputRow[i];
        }
        if (Properties.Settings.Default.MovementRow)
        {
          AddInfo(string.Join(",", movementRow));
        }

        inputRow.CopyTo(previousInputRow, 0);

        if (isPredicting)
        {
          SetUpFallDetection();
          ModelOutput modelOutput = ML.Predict(CalibratedInputRow(inputRow), movementRow);
          ShowMLPrediction(modelOutput);
          fallDetection.DoFallDetection(modelOutput, movementRow);
        }
        else if (trainingItem != MLTraining.FALLING || ML.DetectMovingDown(movementRow))
        {
          if (trainingItem == MLTraining.FALLING)
          {
            AddInfo("Moving down detected");
          }
          File.AppendAllText(file, (int)trainingItem + "\t" + string.Join("\t", CalibratedInputRow(inputRow)) + "\t" + string.Join("\t", movementRow) + Environment.NewLine);
        }
      }
      catch (Exception ex)
      {
        AddInfo("Error training: " + ex.Message);
      }
    }

    private bool IsPredicting()
    {
      return mlPredicting;
    }

    private void SleepMonitoring()
    {
      DateTime dt = DateTime.Now;
      if (dt.Minute != minuteCounter)
      {
        minuteCounter = dt.Minute;
        //AddInfo("Average " + minuteSleepScores.Average());
        UpdateSleeping(minuteSleepScores.Average() > 50, GetMinutes(dt), dt.ToShortDateString());

        Invoke((MethodInvoker)delegate ()
        {
          UpdateSleepingChart();
        });
      }
    }

    public void SerialInputWork(string file)
    {
      string serialLine = serialPort.ReadLine();

      if (serialLine.StartsWith("I2C"))
      {
        if (Properties.Settings.Default.RawInput)
        {
          AddInfo(serialLine);
          File.AppendAllText(Properties.Settings.Default.MockSerialData, serialLine);
        }
        string[] splittedRow = serialLine.Split(' ');
        int pos = int.Parse(serialLine.ElementAt(3).ToString());
        pos = pos ^ 1;          // IC2 no 1 is on left side

        for (int i = 0; i < SENSOR_COLUMS; i++)
        {
          for (int j = 0; j < SENSOR_COLUMS; j++)
          {
            int l = (((i + 1) * SENSOR_COLUMS - 1 - j) << 1) + 3;
            serialInputRow[((i << 1) + pos) * SENSOR_COLUMS + j] = int.Parse(splittedRow[l], NumberStyles.AllowHexSpecifier) + (int.Parse(splittedRow[l + 1], NumberStyles.AllowHexSpecifier) << 8);
          }
        }

        if (pos == 0)
        {
          if (Properties.Settings.Default.OpenInput)
          {
            AddInfo(string.Join(",", serialInputRow));
          }
          DateTime dtNow = DateTime.Now;
          if (dtNow.Second != secondCounter)
          {
            secondCounter = dtNow.Second;
            if (IsTraining())
            {
              DoMachineLearning(serialInputRow, file, false);
            }

            if (IsPredicting())
            {
              DoMachineLearning(serialInputRow, string.Empty, true);
            }
            if (sleepMonitoring)
            {
              SleepMonitoring();
            }

            if (temperatureToolStripMenuItem.Checked)
            {
              GetTemperatures(serialInputRow);
            }

            for (int i = 0; i < SENSOR_COLUMS; i++)
            {
              for (int j = 0; j < (SENSOR_COLUMS * 2); j++)
              {
                UpdateMatrix(MatrixType.BlackAndWhite, j, i, serialInputRow[i * 8 + j]);
                UpdateMatrix(MatrixType.Colored, j, i, serialInputRow[i * 8 + j]);
                UpdateMatrix(MatrixType.Numeric, j, i, serialInputRow[i * 8 + j]);
              }
            }
          }
        }
      }
    }

    private void SerialInputWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      while (!stopReading)
      {
        try
        {
          SerialInputWork(Properties.Settings.Default.TestDataFile);
        }
        catch (Exception ex)
        {
          if (ignoreFirstReadError)
          {
            ignoreFirstReadError = false;
          }
          else
          {
            AddInfo("Error reading: " + ex.Message);
          }
        }
      }
      serialPort.Close();
    }

    private delegate void UpdateGuiDelegate(string text);
    private void AddInfo(string text)
    {
      if (InvokeRequired)
      {
        Invoke(new UpdateGuiDelegate(AddInfo), text);
      }
      else
      {
        string logLine = Utilities.GetTimeString() + ": " + text + Environment.NewLine;
        textBoxLog.Text += logLine;
        textBoxLog.SelectionStart = textBoxLog.Text.Length;
        textBoxLog.ScrollToCaret();
      }
    }

    private void InitTableLayout(MatrixType type, TableLayoutPanel panel)
    {
      tlpNumeric.Visible = false;
      tlpColor.Visible = false;
      tlpBlackWhite.Visible = false;

      if (panel.Controls.Count == 0)
      {
        for (int i = 0; i < SENSOR_COLUMS; i++)
        {
          for (int j = 0; j < SENSOR_COLUMS * 2; j++)
          {
            Label label = new Label();
            label.Name = "ID:" + j + i;
            panel.Controls.Add(label, j, i);
          }
        }
      }

      if (type == MatrixType.BlackAndWhite)
      {
        tlpBlackWhite.Visible = true;
      }
      else if (type == MatrixType.Colored)
      {
        tlpColor.Visible = true;
      }
      else if (type == MatrixType.Numeric)
      {
        tlpNumeric.Visible = true;
      }
    }

    private delegate void UpdateMatrixDelegate(MatrixType matrix, int column, int row, int value);

    private void UpdateMatrix(MatrixType matrix, int column, int row, int value)
    {
      if (InvokeRequired)
      {
        Invoke(new UpdateMatrixDelegate(UpdateMatrix), matrix, column, row, value);
      }
      else
      {
        if (matrix == MatrixType.BlackAndWhite && tlpBlackWhite.Visible == true)
        {
          foreach (Control control in tlpBlackWhite.Controls)
          {
            Label iconLabel = control as Label;
            if (iconLabel != null && iconLabel.Name.Equals("ID:" + column + row))
            {
              if (value > 250)
              {
                iconLabel.BackColor = Color.Black;
              }
              else
              {
                iconLabel.BackColor = Color.White;
              }
            }
          }
        }
        else if (matrix == MatrixType.Colored && tlpColor.Visible == true)
        {
          foreach (Control control in tlpColor.Controls)
          {
            Label iconLabel = control as Label;
            if (iconLabel != null && iconLabel.Name.Equals("ID:" + column + row))
            {
              iconLabel.BackColor = Utilities.GetColor(value);
            }
          }
        }
        else if (matrix == MatrixType.Numeric && tlpNumeric.Visible == true)
        {
          foreach (Control control in tlpNumeric.Controls)
          {
            Label iconLabel = control as Label;
            if (iconLabel != null && iconLabel.Name.Equals("ID:" + column + row))
            {
              iconLabel.Text = value.ToString();
            }
          }
        }
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (serialPort != null)
      {
        serialPort.Close();
      }
      Application.Exit();
    }

    private void logToolStripMenuItem_Click(object sender, EventArgs e)
    {
      textBoxLog.Visible = !textBoxLog.Visible;
      logToolStripMenuItem.Checked = textBoxLog.Visible;
      Properties.Settings.Default.ShowLog = logToolStripMenuItem.Checked;
      Properties.Settings.Default.Save();
    }

    private void generalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Form settings = new SettingsForm();
      if (DialogResult.OK == settings.ShowDialog())
      {
        AddInfo("Settings saved");
      }
    }

    private void inputToolStripMenuItem_Click(object sender, EventArgs e)
    {
      inputToolStripMenuItem.Checked = !inputToolStripMenuItem.Checked;
      Properties.Settings.Default.OpenInput = inputToolStripMenuItem.Checked;
      Properties.Settings.Default.Save();
    }

    private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InitTableLayout(MatrixType.BlackAndWhite, tlpBlackWhite);
    }

    private void coloredToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InitTableLayout(MatrixType.Colored, tlpColor);
    }

    private void numbersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InitTableLayout(MatrixType.Numeric, tlpNumeric);
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.DefaultExt = "txt";
      saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
      saveFileDialog.FileName = "Log.txt";
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        File.AppendAllText(saveFileDialog.FileName, textBoxLog.Text);
      }
    }

    private void startToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (serialPort == null || !serialPort.IsOpen)
      {
        OpenSerialPort(false);
      }
      else
      {
        stopReading = true;
        trainingItem = MLTraining.NOT_TRAINING;
        startToolStripMenuItem.Text = "Start";
      }
    }

    private void StartTraining(MLTraining trainingType)
    {
      if (askOnceForNewTraining)
      {
        DialogResult dR = MessageBox.Show("Do you want create new learning (Yes)? Or add to the old one (No)", "INFO", MessageBoxButtons.YesNoCancel);
        try
        {
          if (dR == DialogResult.Yes)
          {
            string dataFile = Properties.Settings.Default.TestDataFile;
            if (File.Exists(dataFile))
            {
              File.Delete(dataFile);
            }
            for (int i = 0; i < 65; i++)
            {
              File.AppendAllText(dataFile, i.ToString() + "\t");
            }
            File.AppendAllText(dataFile, Environment.NewLine);
          }
          StartCountDownTimer();
          if (dR == DialogResult.Cancel)
          {
            trainingItem = MLTraining.NOT_TRAINING;
            return;
          }
        }
        catch (Exception ex)
        {
          AddInfo("Error: " + ex.Message);
        }
      }
      askOnceForNewTraining = false;
      trainingItem = trainingType;
      labelCountDown.Text = "Starting in 3";
      trainingRowCount = 0;
      groupBoxTraining.Visible = true;
      labelTrainingType.Text = trainingType.ToString();
    }

    private void emptyRoomToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StartTraining(MLTraining.EMPTY_ROOM);
    }

    private void StartCountDownTimer()
    {
      countdownTimer.Interval = 1000;
      countdownTimer.Tick += CountdownTimer_Tick;
      countdownTimer.Start();
    }

    public bool IsTraining()
    {
      return labelCountDown.Text.StartsWith("Training") && trainingItem != MLTraining.NOT_TRAINING;
    }

    private void CountdownTimer_Tick(object sender, EventArgs e)
    {
      if (labelCountDown.Text == "Starting in 3")
      {
        Invoke((MethodInvoker)delegate ()
        {
          labelCountDown.Text = "Starting in 2";
        });
      }
      else if (labelCountDown.Text == "Starting in 2")
      {
        Invoke((MethodInvoker)delegate ()
        {
          labelCountDown.Text = "Starting in 1";
        });
      }
      else if (labelCountDown.Text == "Starting in 1")
      {
        Invoke((MethodInvoker)delegate ()
        {
          labelCountDown.Text = "Training";
        });
      }
      else if (labelCountDown.Text.StartsWith("Training"))
      {
        Invoke((MethodInvoker)delegate ()
        {
          labelCountDown.Text = "Training row " + ++trainingRowCount;
        });
      }
      else
      {
        Invoke((MethodInvoker)delegate ()
        {
          labelCountDown.Text = "-";
        });
      }
    }

    private void dataRowToolStripMenuItem_Click(object sender, EventArgs e)
    {
      dataRowToolStripMenuItem.Checked = !dataRowToolStripMenuItem.Checked;
      Properties.Settings.Default.MovementRow = dataRowToolStripMenuItem.Checked;
      Properties.Settings.Default.Save();
    }

    private void personMovingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StartTraining(MLTraining.MOVING);
    }

    private void personWatchingTVToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StartTraining(MLTraining.TV);
    }

    private void personSleepingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StartTraining(MLTraining.SLEEPING);
    }

    private void btnPauseTraining_Click(object sender, EventArgs e)
    {
      if (btnPauseTraining.Text == "Pause")
      {
        trainingItem = MLTraining.NOT_TRAINING;
        btnPauseTraining.Text = "Continue";
        countdownTimer.Stop();
      }
      else
      {
        if (labelTrainingType.Text == MLTraining.EMPTY_ROOM.ToString())
        {
          trainingItem = MLTraining.EMPTY_ROOM;
        }
        else if (labelTrainingType.Text == MLTraining.MOVING.ToString())
        {
          trainingItem = MLTraining.MOVING;
        }
        else if (labelTrainingType.Text == MLTraining.TV.ToString())
        {
          trainingItem = MLTraining.TV;
        }
        else if (labelTrainingType.Text == MLTraining.SLEEPING.ToString())
        {
          trainingItem = MLTraining.SLEEPING;
        }
        else if (labelTrainingType.Text == MLTraining.FALLING.ToString())
        {
          trainingItem = MLTraining.FALLING;
        }
        btnPauseTraining.Text = "Pause";
        countdownTimer.Start();
      }
    }

    private void btnEndTraining_Click(object sender, EventArgs e)
    {
      trainingItem = MLTraining.NOT_TRAINING;
      labelCountDown.Text = "-";
      labelTrainingType.Text = "-";
      groupBoxTraining.Visible = false;

      AddInfo("Training ended. Test data contains " + File.ReadAllLines(Properties.Settings.Default.TestDataFile).Length + " lines");
    }

    private void rawInputToolStripMenuItem_Click(object sender, EventArgs e)
    {
      rawInputToolStripMenuItem.Checked = !rawInputToolStripMenuItem.Checked;
      Properties.Settings.Default.RawInput = rawInputToolStripMenuItem.Checked;
      Properties.Settings.Default.Save();
    }

    public int[] GetSerialInputRow()
    {
      return serialInputRow;
    }

    private void sleepGraphToolStripMenuItem_Click(object sender, EventArgs e)
    {
      chart1.Visible = !chart1.Visible;
      sleepGraphToolStripMenuItem.Checked = chart1.Visible;
      Properties.Settings.Default.SleepGraphVisible = chart1.Visible;
      Properties.Settings.Default.Save();
    }

    public void UpdateSleeping(bool isSleeping, int minuteInDay, string date)
    {
      //AddInfo("Minute: " + minuteInDay + ", isSleeping: " + isSleeping);
      if (isSleeping && isSleepingVector[minuteInDay] < -AWAKE_EXP_THRESHOLD)
      {
        sleepWarningCounter += Math.Abs(isSleepingVector[minuteInDay]);
        //AddInfo("Not expected to sleep at " + minuteInDay + ", " + isSleepingVector[minuteInDay] + ", sleepWarningCounter=" + sleepWarningCounter);
      }
      else if (!isSleeping && isSleepingVector[minuteInDay] > SLEEP_EXP_THRESHOLD)
      {
        awakeWarningCounter += isSleepingVector[minuteInDay];
        //AddInfo("Not expected to be awake at " + minuteInDay + ", " + isSleepingVector[minuteInDay]);
      }
      else
      {
        awakeWarningCounter = 0;
        sleepWarningCounter = 0;
      }
      if (awakeWarningCounter > AWAKE_WARNING)
      {
        AddInfo("Awake warning at " + minuteInDay + " count " + ++awakeWarningCount + " date: " + date);
        awakeWarningCounter = 0;
      }

      if (sleepWarningCounter > SLEEP_WARNING)
      {
        AddInfo("Sleep warning at " + minuteInDay + " count " + ++sleepWarningCount + " date: " + date);
        if (isEmailConfigured)
        {
          AddInfo("Sending alarm to " + Properties.Settings.Default.ReceiverEmail);
          Sendwarning("Sleep warning");
        }
        sleepWarningCounter = 0;
      }

      if (isSleeping)
      {
        if (isSleepingVector[minuteInDay] < MAX_VAL_FOR_MINUTE)
        {
          isSleepingVector[minuteInDay] += 1;
        }
      }
      else
      {
        if (isSleepingVector[minuteInDay] > -MAX_VAL_FOR_MINUTE)
        {
          isSleepingVector[minuteInDay] -= 1;
        }
      }
    }

    private int GetMinutes(DateTime dt)
    {
      return dt.Hour * 60 + dt.Minute;
    }

    private void UpdateSleepingChart()
    {
      chart1.ResetAutoValues();
      chart1.Series.Clear();
      var series1 = new Series
      {
        Name = "Sleeping",
        Color = Color.Red,
        IsVisibleInLegend = false,
        IsXValueIndexed = true,
        ChartType = SeriesChartType.Line
      };

      chart1.Series.Add(series1);

      for (int i = 0; i < MINUTES_IN_DAY; i++)
      {
        series1.Points.AddXY(i, isSleepingVector[i]);
      }
      chart1.Invalidate();
    }

    private void GarminSleepHandler(string file)
    {
      var fileInfo = new FileInfo(file);
      if (fileInfo.Length < 1000)
      {
        //File too smal to contain sleep data
        return;
      }

      string[] sleepData = new string[MINUTES_IN_DAY];

      var json = JObject.Parse(File.ReadAllText(file));
      var dailySleepDTO = json["dailySleepDTO"];
      //AddInfo("Date: " + (string)dailySleepDTO["calendarDate"] + ", Sleep time: " + string.Format("{0:0.00} h", (float)dailySleepDTO["sleepTimeSeconds"] / 3600) + ", Awake time: " + string.Format("{0:0.00} min", (float)dailySleepDTO["awakeSleepSeconds"] / 60));
      // AddInfo("Sleep time: " + string.Format("{0:0.00} h", (float)dailySleepDTO["sleepTimeSeconds"] / 3600));
      //AddInfo("Awake time: " + string.Format("{0:0.00} min", (float)dailySleepDTO["awakeSleepSeconds"] / 60));

      var sleepMovements = json["sleepMovement"];
      List<float> sleepLevels = new List<float>();
      DateTime endTime = DateTime.MinValue;

      //Fill in time after previous end and new sleep start
      if (previousEndTime != DateTime.MinValue)
      {
        for (int i = GetMinutes(previousEndTime); i < GetMinutes((DateTime)sleepMovements[0]["startGMT"]); i++)
        {
          UpdateSleeping(false, i, (string)dailySleepDTO["calendarDate"]);
        }
      }

      foreach (var movement in sleepMovements)
      {
        DateTime startTime = (DateTime)movement["startGMT"];

        endTime = (DateTime)movement["endGMT"];
        previousEndTime = endTime;
        //AddInfo("Start: " + (string)movement["startGMT"] + ", End: " + (string)movement["endGMT"] + ", Level: " + (string)movement["activityLevel"]);

        float sleepLevel = (float)movement["activityLevel"];
        sleepLevels.Add(sleepLevel);
        UpdateSleeping(sleepLevel < 4, GetMinutes(startTime), (string)dailySleepDTO["calendarDate"]);
      }
      // AddInfo("Sleep End: " + endTime);
      UpdateSleepingChart();
      dayCount++;
    }

    private void garminDataToolStripMenuItem_Click(object sender, EventArgs e)
    {
      isSleepingVector = new int[MINUTES_IN_DAY];
      sleepGraphToolStripMenuItem.Checked = chart1.Visible = true;
      Properties.Settings.Default.SleepGraphVisible = chart1.Visible;
      Properties.Settings.Default.Save();

      string[] garminFiles;

      var fbd = new FolderBrowserDialog();

      fbd.Description = "Please select folder for Garming sleep data";
      DialogResult result = fbd.ShowDialog();

      if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
      {
        garminFiles = Directory.GetFiles(fbd.SelectedPath);

        AddInfo("Garming files found: " + garminFiles.Length.ToString());
      }
      else
      {
        return;
      }

      for (int i = 0; i < garminFiles.Length; i++)
      {
        try
        {
          GarminSleepHandler(garminFiles[i]);
        }
        catch (Exception ex)
        {
          AddInfo("Garmnin parse error: " + ex.Message + ":" + ex.StackTrace);
        }
        Application.DoEvents();
      }
      AddInfo("Day count " + dayCount + ", Awake warning count " + awakeWarningCount + ", Sleep warning count " + sleepWarningCount);
    }

    private void GetTemperatures(int[] inputRow)
    {
      Invoke((MethodInvoker)delegate ()
      {
        labelTMin.Text = "Min: " + inputRow.Min() / 10 + " °C";
      });
      Invoke((MethodInvoker)delegate ()
      {
        labelTAvg.Text = "Avg: " + inputRow.Average() / 10 + " °C";
      });
      Invoke((MethodInvoker)delegate ()
      {
        labelTMax.Text = "Max: " + inputRow.Max() / 10 + " °C";
      });
      Invoke((MethodInvoker)delegate ()
      {
        labelTMax.Text = "Room: " + Test.DataHandling.GetRoomTemp(inputRow) / 10 + " °C";
      });
    }

    private void temperatureToolStripMenuItem_Click(object sender, EventArgs e)
    {
      groupBoxTemperature.Visible = !groupBoxTemperature.Visible;
      temperatureToolStripMenuItem.Checked = groupBoxTemperature.Visible;
      Properties.Settings.Default.SleepGraphVisible = groupBoxTemperature.Visible;
      Properties.Settings.Default.Save();
    }

    private void mLPredictionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      groupBoxPrediction.Visible = !groupBoxPrediction.Visible;
      mLPredictionToolStripMenuItem.Checked = groupBoxPrediction.Visible;
      Properties.Settings.Default.MLPredictionVisible = groupBoxPrediction.Visible;
      Properties.Settings.Default.Save();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Form about = new About();
      about.ShowDialog();
    }

    private void fallingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StartTraining(MLTraining.FALLING);
    }

    private void mLNETPredictionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      groupBoxPrediction.Visible = true;
      mLPredictionToolStripMenuItem.Checked = groupBoxPrediction.Visible;
      Properties.Settings.Default.MLPredictionVisible = groupBoxPrediction.Visible;
      Properties.Settings.Default.Save();
      mlPredicting = true;
    }

    private void liveMonitoringToolStripMenuItem_Click(object sender, EventArgs e)
    {
      isSleepingVector = new int[MINUTES_IN_DAY];
      sleepMonitoring = true;
      mlPredicting = true;
      groupBoxPrediction.Visible = true;
    }

    private void convertTempToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Title = "Please select input data file";

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        Random random = new Random(42);
        Test.DataHandling.IncreaseTemp(ofd.FileName, 20, random);
        AddInfo("Done");
      }
    }

    private void predictionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Title = "Please select ML input data file";
      int counter = 0;
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        var predictionList = Test.DataHandling.GetPredictions(ofd.FileName);

        foreach (var prediciton in predictionList)
        {
          string scores = prediciton.Score[0].ToString("0.00") + "," + prediciton.Score[1].ToString("0.00") + "," + prediciton.Score[2].ToString("0.00") + "," + prediciton.Score[3].ToString("0.00") + "," + prediciton.Score[4].ToString("0.00");
          AddInfo(++counter + ", Prediciton: " + prediciton.Prediction + ", Scores: " + scores);
        }
        AddInfo("Done");
      }
    }

    private void roomTempToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Title = "Please select ML input data file";
      int counter = 0;
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        var predictionList = Test.DataHandling.GetRoomTemp(ofd.FileName);

        foreach (var temp in predictionList)
        {
          AddInfo(++counter + ", room temp: " + temp);
        }
        AddInfo("Done");
      }
    }

    private void calibrateRoomTempToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Title = "Please select ML input data file to calibrate";

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        Test.DataHandling.UseCalibratedRoomTemp(ofd.FileName);

        AddInfo("Done");
      }
    }
  }
}
