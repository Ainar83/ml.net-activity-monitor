namespace ActivityMonitor
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rawInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.dataRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.inputTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.blackAndWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.coloredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.numbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sleepGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.temperatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mLPredictionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mLNETLearningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.emptyRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.personMovingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.personWatchingTVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.personSleepingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fallingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sleepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.garminDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.liveMonitoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mLNETPredictionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.convertTempToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.predictionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.roomTempToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.resetToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.textBoxLog = new System.Windows.Forms.TextBox();
      this.tlpNumeric = new System.Windows.Forms.TableLayoutPanel();
      this.tlpColor = new System.Windows.Forms.TableLayoutPanel();
      this.tlpBlackWhite = new System.Windows.Forms.TableLayoutPanel();
      this.btnPauseTraining = new System.Windows.Forms.Button();
      this.groupBoxTraining = new System.Windows.Forms.GroupBox();
      this.btnEndTraining = new System.Windows.Forms.Button();
      this.labelTrainingType = new System.Windows.Forms.Label();
      this.labelCountDown = new System.Windows.Forms.Label();
      this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.groupBoxTemperature = new System.Windows.Forms.GroupBox();
      this.labelTRoom = new System.Windows.Forms.Label();
      this.labelTMax = new System.Windows.Forms.Label();
      this.labelTAvg = new System.Windows.Forms.Label();
      this.labelTMin = new System.Windows.Forms.Label();
      this.groupBoxPrediction = new System.Windows.Forms.GroupBox();
      this.labelPrediction = new System.Windows.Forms.Label();
      this.lPFalling = new System.Windows.Forms.Label();
      this.lPSleeping = new System.Windows.Forms.Label();
      this.lPTV = new System.Windows.Forms.Label();
      this.lPMoving = new System.Windows.Forms.Label();
      this.lPEmpty = new System.Windows.Forms.Label();
      this.calibrateRoomTempToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.groupBoxTraining.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
      this.groupBoxTemperature.SuspendLayout();
      this.groupBoxPrediction.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(813, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // startToolStripMenuItem
      // 
      this.startToolStripMenuItem.Name = "startToolStripMenuItem";
      this.startToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
      this.startToolStripMenuItem.Text = "Start";
      this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
      this.saveToolStripMenuItem.Text = "Save log";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logToolStripMenuItem,
            this.rawInputToolStripMenuItem,
            this.inputToolStripMenuItem,
            this.dataRowToolStripMenuItem,
            this.inputTableToolStripMenuItem,
            this.sleepGraphToolStripMenuItem,
            this.temperatureToolStripMenuItem,
            this.mLPredictionToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // logToolStripMenuItem
      // 
      this.logToolStripMenuItem.Name = "logToolStripMenuItem";
      this.logToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.logToolStripMenuItem.Text = "Log";
      this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
      // 
      // rawInputToolStripMenuItem
      // 
      this.rawInputToolStripMenuItem.Name = "rawInputToolStripMenuItem";
      this.rawInputToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.rawInputToolStripMenuItem.Text = "Raw input";
      this.rawInputToolStripMenuItem.Click += new System.EventHandler(this.rawInputToolStripMenuItem_Click);
      // 
      // inputToolStripMenuItem
      // 
      this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
      this.inputToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.inputToolStripMenuItem.Text = "Input";
      this.inputToolStripMenuItem.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
      // 
      // dataRowToolStripMenuItem
      // 
      this.dataRowToolStripMenuItem.Name = "dataRowToolStripMenuItem";
      this.dataRowToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.dataRowToolStripMenuItem.Text = "Movement row";
      this.dataRowToolStripMenuItem.Click += new System.EventHandler(this.dataRowToolStripMenuItem_Click);
      // 
      // inputTableToolStripMenuItem
      // 
      this.inputTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackAndWhiteToolStripMenuItem,
            this.coloredToolStripMenuItem,
            this.numbersToolStripMenuItem});
      this.inputTableToolStripMenuItem.Name = "inputTableToolStripMenuItem";
      this.inputTableToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.inputTableToolStripMenuItem.Text = "Input table";
      // 
      // blackAndWhiteToolStripMenuItem
      // 
      this.blackAndWhiteToolStripMenuItem.Name = "blackAndWhiteToolStripMenuItem";
      this.blackAndWhiteToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
      this.blackAndWhiteToolStripMenuItem.Text = "Black and white";
      this.blackAndWhiteToolStripMenuItem.Click += new System.EventHandler(this.blackAndWhiteToolStripMenuItem_Click);
      // 
      // coloredToolStripMenuItem
      // 
      this.coloredToolStripMenuItem.Name = "coloredToolStripMenuItem";
      this.coloredToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
      this.coloredToolStripMenuItem.Text = "Colored";
      this.coloredToolStripMenuItem.Click += new System.EventHandler(this.coloredToolStripMenuItem_Click);
      // 
      // numbersToolStripMenuItem
      // 
      this.numbersToolStripMenuItem.Name = "numbersToolStripMenuItem";
      this.numbersToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
      this.numbersToolStripMenuItem.Text = "Numbers";
      this.numbersToolStripMenuItem.Click += new System.EventHandler(this.numbersToolStripMenuItem_Click);
      // 
      // sleepGraphToolStripMenuItem
      // 
      this.sleepGraphToolStripMenuItem.Name = "sleepGraphToolStripMenuItem";
      this.sleepGraphToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.sleepGraphToolStripMenuItem.Text = "Sleep graph";
      this.sleepGraphToolStripMenuItem.Click += new System.EventHandler(this.sleepGraphToolStripMenuItem_Click);
      // 
      // temperatureToolStripMenuItem
      // 
      this.temperatureToolStripMenuItem.Name = "temperatureToolStripMenuItem";
      this.temperatureToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.temperatureToolStripMenuItem.Text = "Temperature";
      this.temperatureToolStripMenuItem.Click += new System.EventHandler(this.temperatureToolStripMenuItem_Click);
      // 
      // mLPredictionToolStripMenuItem
      // 
      this.mLPredictionToolStripMenuItem.Name = "mLPredictionToolStripMenuItem";
      this.mLPredictionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.mLPredictionToolStripMenuItem.Text = "ML Prediction";
      this.mLPredictionToolStripMenuItem.Click += new System.EventHandler(this.mLPredictionToolStripMenuItem_Click);
      // 
      // modeToolStripMenuItem
      // 
      this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mLNETLearningToolStripMenuItem,
            this.sleepToolStripMenuItem,
            this.mLNETPredictionToolStripMenuItem,
            this.testToolStripMenuItem});
      this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
      this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
      this.modeToolStripMenuItem.Text = "Mode";
      // 
      // mLNETLearningToolStripMenuItem
      // 
      this.mLNETLearningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyRoomToolStripMenuItem,
            this.personMovingToolStripMenuItem,
            this.personWatchingTVToolStripMenuItem,
            this.personSleepingToolStripMenuItem,
            this.fallingToolStripMenuItem});
      this.mLNETLearningToolStripMenuItem.Name = "mLNETLearningToolStripMenuItem";
      this.mLNETLearningToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.mLNETLearningToolStripMenuItem.Text = "ML Learning";
      // 
      // emptyRoomToolStripMenuItem
      // 
      this.emptyRoomToolStripMenuItem.Name = "emptyRoomToolStripMenuItem";
      this.emptyRoomToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
      this.emptyRoomToolStripMenuItem.Text = "Empty room";
      this.emptyRoomToolStripMenuItem.Click += new System.EventHandler(this.emptyRoomToolStripMenuItem_Click);
      // 
      // personMovingToolStripMenuItem
      // 
      this.personMovingToolStripMenuItem.Name = "personMovingToolStripMenuItem";
      this.personMovingToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
      this.personMovingToolStripMenuItem.Text = "Person moving";
      this.personMovingToolStripMenuItem.Click += new System.EventHandler(this.personMovingToolStripMenuItem_Click);
      // 
      // personWatchingTVToolStripMenuItem
      // 
      this.personWatchingTVToolStripMenuItem.Name = "personWatchingTVToolStripMenuItem";
      this.personWatchingTVToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
      this.personWatchingTVToolStripMenuItem.Text = "Person watching TV";
      this.personWatchingTVToolStripMenuItem.Click += new System.EventHandler(this.personWatchingTVToolStripMenuItem_Click);
      // 
      // personSleepingToolStripMenuItem
      // 
      this.personSleepingToolStripMenuItem.Name = "personSleepingToolStripMenuItem";
      this.personSleepingToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
      this.personSleepingToolStripMenuItem.Text = "Person sleeping";
      this.personSleepingToolStripMenuItem.Click += new System.EventHandler(this.personSleepingToolStripMenuItem_Click);
      // 
      // fallingToolStripMenuItem
      // 
      this.fallingToolStripMenuItem.Name = "fallingToolStripMenuItem";
      this.fallingToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
      this.fallingToolStripMenuItem.Text = "Falling";
      this.fallingToolStripMenuItem.Click += new System.EventHandler(this.fallingToolStripMenuItem_Click);
      // 
      // sleepToolStripMenuItem
      // 
      this.sleepToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.garminDataToolStripMenuItem,
            this.liveMonitoringToolStripMenuItem});
      this.sleepToolStripMenuItem.Name = "sleepToolStripMenuItem";
      this.sleepToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.sleepToolStripMenuItem.Text = "Sleep";
      // 
      // garminDataToolStripMenuItem
      // 
      this.garminDataToolStripMenuItem.Name = "garminDataToolStripMenuItem";
      this.garminDataToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
      this.garminDataToolStripMenuItem.Text = "Garmin data";
      this.garminDataToolStripMenuItem.Click += new System.EventHandler(this.garminDataToolStripMenuItem_Click);
      // 
      // liveMonitoringToolStripMenuItem
      // 
      this.liveMonitoringToolStripMenuItem.Name = "liveMonitoringToolStripMenuItem";
      this.liveMonitoringToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
      this.liveMonitoringToolStripMenuItem.Text = "Live monitoring";
      this.liveMonitoringToolStripMenuItem.Click += new System.EventHandler(this.liveMonitoringToolStripMenuItem_Click);
      // 
      // mLNETPredictionToolStripMenuItem
      // 
      this.mLNETPredictionToolStripMenuItem.Name = "mLNETPredictionToolStripMenuItem";
      this.mLNETPredictionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.mLNETPredictionToolStripMenuItem.Text = "ML Prediction";
      this.mLNETPredictionToolStripMenuItem.Click += new System.EventHandler(this.mLNETPredictionToolStripMenuItem_Click);
      // 
      // testToolStripMenuItem
      // 
      this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertTempToolStripMenuItem,
            this.predictionToolStripMenuItem,
            this.roomTempToolStripMenuItem,
            this.calibrateRoomTempToolStripMenuItem});
      this.testToolStripMenuItem.Name = "testToolStripMenuItem";
      this.testToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.testToolStripMenuItem.Text = "Test";
      // 
      // convertTempToolStripMenuItem
      // 
      this.convertTempToolStripMenuItem.Name = "convertTempToolStripMenuItem";
      this.convertTempToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
      this.convertTempToolStripMenuItem.Text = "Convert temp";
      this.convertTempToolStripMenuItem.Click += new System.EventHandler(this.convertTempToolStripMenuItem_Click);
      // 
      // predictionToolStripMenuItem
      // 
      this.predictionToolStripMenuItem.Name = "predictionToolStripMenuItem";
      this.predictionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
      this.predictionToolStripMenuItem.Text = "Prediction";
      this.predictionToolStripMenuItem.Click += new System.EventHandler(this.predictionToolStripMenuItem_Click);
      // 
      // roomTempToolStripMenuItem
      // 
      this.roomTempToolStripMenuItem.Name = "roomTempToolStripMenuItem";
      this.roomTempToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
      this.roomTempToolStripMenuItem.Text = "Room temp";
      this.roomTempToolStripMenuItem.Click += new System.EventHandler(this.roomTempToolStripMenuItem_Click);
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.resetToDefaultToolStripMenuItem});
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.settingsToolStripMenuItem.Text = "Settings";
      // 
      // generalToolStripMenuItem
      // 
      this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
      this.generalToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
      this.generalToolStripMenuItem.Text = "General";
      this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
      // 
      // resetToDefaultToolStripMenuItem
      // 
      this.resetToDefaultToolStripMenuItem.Name = "resetToDefaultToolStripMenuItem";
      this.resetToDefaultToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
      this.resetToDefaultToolStripMenuItem.Text = "Reset to default";
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // textBoxLog
      // 
      this.textBoxLog.Location = new System.Drawing.Point(11, 443);
      this.textBoxLog.Margin = new System.Windows.Forms.Padding(2);
      this.textBoxLog.Multiline = true;
      this.textBoxLog.Name = "textBoxLog";
      this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBoxLog.Size = new System.Drawing.Size(791, 118);
      this.textBoxLog.TabIndex = 2;
      // 
      // tlpNumeric
      // 
      this.tlpNumeric.AutoSize = true;
      this.tlpNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tlpNumeric.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tlpNumeric.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.tlpNumeric.ColumnCount = 8;
      this.tlpNumeric.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tlpNumeric.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tlpNumeric.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tlpNumeric.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tlpNumeric.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tlpNumeric.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tlpNumeric.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tlpNumeric.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
      this.tlpNumeric.Location = new System.Drawing.Point(521, 41);
      this.tlpNumeric.Margin = new System.Windows.Forms.Padding(2);
      this.tlpNumeric.Name = "tlpNumeric";
      this.tlpNumeric.RowCount = 4;
      this.tlpNumeric.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpNumeric.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpNumeric.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpNumeric.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpNumeric.Size = new System.Drawing.Size(282, 85);
      this.tlpNumeric.TabIndex = 33;
      this.tlpNumeric.Visible = false;
      // 
      // tlpColor
      // 
      this.tlpColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tlpColor.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.tlpColor.ColumnCount = 8;
      this.tlpColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
      this.tlpColor.Location = new System.Drawing.Point(346, 41);
      this.tlpColor.Margin = new System.Windows.Forms.Padding(2);
      this.tlpColor.Name = "tlpColor";
      this.tlpColor.RowCount = 4;
      this.tlpColor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpColor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpColor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpColor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpColor.Size = new System.Drawing.Size(160, 84);
      this.tlpColor.TabIndex = 32;
      this.tlpColor.Visible = false;
      // 
      // tlpBlackWhite
      // 
      this.tlpBlackWhite.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.tlpBlackWhite.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.tlpBlackWhite.ColumnCount = 8;
      this.tlpBlackWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpBlackWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpBlackWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpBlackWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpBlackWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpBlackWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpBlackWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tlpBlackWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
      this.tlpBlackWhite.Location = new System.Drawing.Point(169, 41);
      this.tlpBlackWhite.Margin = new System.Windows.Forms.Padding(2);
      this.tlpBlackWhite.Name = "tlpBlackWhite";
      this.tlpBlackWhite.RowCount = 4;
      this.tlpBlackWhite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpBlackWhite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpBlackWhite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpBlackWhite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tlpBlackWhite.Size = new System.Drawing.Size(160, 84);
      this.tlpBlackWhite.TabIndex = 31;
      this.tlpBlackWhite.Visible = false;
      // 
      // btnPauseTraining
      // 
      this.btnPauseTraining.Location = new System.Drawing.Point(6, 116);
      this.btnPauseTraining.Name = "btnPauseTraining";
      this.btnPauseTraining.Size = new System.Drawing.Size(57, 23);
      this.btnPauseTraining.TabIndex = 34;
      this.btnPauseTraining.Text = "Pause";
      this.btnPauseTraining.UseVisualStyleBackColor = true;
      this.btnPauseTraining.Click += new System.EventHandler(this.btnPauseTraining_Click);
      // 
      // groupBoxTraining
      // 
      this.groupBoxTraining.Controls.Add(this.btnEndTraining);
      this.groupBoxTraining.Controls.Add(this.labelTrainingType);
      this.groupBoxTraining.Controls.Add(this.labelCountDown);
      this.groupBoxTraining.Controls.Add(this.btnPauseTraining);
      this.groupBoxTraining.Location = new System.Drawing.Point(12, 41);
      this.groupBoxTraining.Name = "groupBoxTraining";
      this.groupBoxTraining.Size = new System.Drawing.Size(135, 154);
      this.groupBoxTraining.TabIndex = 35;
      this.groupBoxTraining.TabStop = false;
      this.groupBoxTraining.Text = "ML Training";
      this.groupBoxTraining.Visible = false;
      // 
      // btnEndTraining
      // 
      this.btnEndTraining.Location = new System.Drawing.Point(72, 116);
      this.btnEndTraining.Name = "btnEndTraining";
      this.btnEndTraining.Size = new System.Drawing.Size(57, 23);
      this.btnEndTraining.TabIndex = 37;
      this.btnEndTraining.Text = "End";
      this.btnEndTraining.UseVisualStyleBackColor = true;
      this.btnEndTraining.Click += new System.EventHandler(this.btnEndTraining_Click);
      // 
      // labelTrainingType
      // 
      this.labelTrainingType.AutoSize = true;
      this.labelTrainingType.Location = new System.Drawing.Point(29, 37);
      this.labelTrainingType.Name = "labelTrainingType";
      this.labelTrainingType.Size = new System.Drawing.Size(10, 13);
      this.labelTrainingType.TabIndex = 36;
      this.labelTrainingType.Text = "-";
      // 
      // labelCountDown
      // 
      this.labelCountDown.AutoSize = true;
      this.labelCountDown.Location = new System.Drawing.Point(29, 77);
      this.labelCountDown.Name = "labelCountDown";
      this.labelCountDown.Size = new System.Drawing.Size(10, 13);
      this.labelCountDown.TabIndex = 35;
      this.labelCountDown.Text = "-";
      // 
      // chart1
      // 
      chartArea1.Name = "ChartArea1";
      this.chart1.ChartAreas.Add(chartArea1);
      legend1.Name = "Legend1";
      this.chart1.Legends.Add(legend1);
      this.chart1.Location = new System.Drawing.Point(169, 130);
      this.chart1.Name = "chart1";
      series1.ChartArea = "ChartArea1";
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      this.chart1.Series.Add(series1);
      this.chart1.Size = new System.Drawing.Size(481, 300);
      this.chart1.TabIndex = 36;
      this.chart1.Text = "chart1";
      this.chart1.Visible = false;
      // 
      // groupBoxTemperature
      // 
      this.groupBoxTemperature.Controls.Add(this.labelTRoom);
      this.groupBoxTemperature.Controls.Add(this.labelTMax);
      this.groupBoxTemperature.Controls.Add(this.labelTAvg);
      this.groupBoxTemperature.Controls.Add(this.labelTMin);
      this.groupBoxTemperature.Location = new System.Drawing.Point(662, 144);
      this.groupBoxTemperature.Name = "groupBoxTemperature";
      this.groupBoxTemperature.Size = new System.Drawing.Size(140, 129);
      this.groupBoxTemperature.TabIndex = 37;
      this.groupBoxTemperature.TabStop = false;
      this.groupBoxTemperature.Text = "Temperature";
      this.groupBoxTemperature.Visible = false;
      // 
      // labelTRoom
      // 
      this.labelTRoom.AutoSize = true;
      this.labelTRoom.Location = new System.Drawing.Point(7, 101);
      this.labelTRoom.Name = "labelTRoom";
      this.labelTRoom.Size = new System.Drawing.Size(58, 13);
      this.labelTRoom.TabIndex = 3;
      this.labelTRoom.Text = "Room: - °C";
      // 
      // labelTMax
      // 
      this.labelTMax.AutoSize = true;
      this.labelTMax.Location = new System.Drawing.Point(7, 84);
      this.labelTMax.Name = "labelTMax";
      this.labelTMax.Size = new System.Drawing.Size(50, 13);
      this.labelTMax.TabIndex = 2;
      this.labelTMax.Text = "Max: - °C";
      // 
      // labelTAvg
      // 
      this.labelTAvg.AutoSize = true;
      this.labelTAvg.Location = new System.Drawing.Point(7, 61);
      this.labelTAvg.Name = "labelTAvg";
      this.labelTAvg.Size = new System.Drawing.Size(49, 13);
      this.labelTAvg.TabIndex = 1;
      this.labelTAvg.Text = "Avg: - °C";
      // 
      // labelTMin
      // 
      this.labelTMin.AutoSize = true;
      this.labelTMin.Location = new System.Drawing.Point(7, 37);
      this.labelTMin.Name = "labelTMin";
      this.labelTMin.Size = new System.Drawing.Size(47, 13);
      this.labelTMin.TabIndex = 0;
      this.labelTMin.Text = "Min: - °C";
      // 
      // groupBoxPrediction
      // 
      this.groupBoxPrediction.Controls.Add(this.labelPrediction);
      this.groupBoxPrediction.Controls.Add(this.lPFalling);
      this.groupBoxPrediction.Controls.Add(this.lPSleeping);
      this.groupBoxPrediction.Controls.Add(this.lPTV);
      this.groupBoxPrediction.Controls.Add(this.lPMoving);
      this.groupBoxPrediction.Controls.Add(this.lPEmpty);
      this.groupBoxPrediction.Location = new System.Drawing.Point(11, 219);
      this.groupBoxPrediction.Name = "groupBoxPrediction";
      this.groupBoxPrediction.Size = new System.Drawing.Size(134, 178);
      this.groupBoxPrediction.TabIndex = 38;
      this.groupBoxPrediction.TabStop = false;
      this.groupBoxPrediction.Text = "ML Prediction";
      this.groupBoxPrediction.Visible = false;
      // 
      // labelPrediction
      // 
      this.labelPrediction.AutoSize = true;
      this.labelPrediction.Location = new System.Drawing.Point(30, 26);
      this.labelPrediction.Name = "labelPrediction";
      this.labelPrediction.Size = new System.Drawing.Size(10, 13);
      this.labelPrediction.TabIndex = 5;
      this.labelPrediction.Text = "-";
      // 
      // lPFalling
      // 
      this.lPFalling.AutoSize = true;
      this.lPFalling.Location = new System.Drawing.Point(7, 153);
      this.lPFalling.Name = "lPFalling";
      this.lPFalling.Size = new System.Drawing.Size(46, 13);
      this.lPFalling.TabIndex = 4;
      this.lPFalling.Text = "Falling: -";
      // 
      // lPSleeping
      // 
      this.lPSleeping.AutoSize = true;
      this.lPSleeping.Location = new System.Drawing.Point(7, 126);
      this.lPSleeping.Name = "lPSleeping";
      this.lPSleeping.Size = new System.Drawing.Size(57, 13);
      this.lPSleeping.TabIndex = 3;
      this.lPSleeping.Text = "Sleeping: -";
      // 
      // lPTV
      // 
      this.lPTV.AutoSize = true;
      this.lPTV.Location = new System.Drawing.Point(6, 103);
      this.lPTV.Name = "lPTV";
      this.lPTV.Size = new System.Drawing.Size(33, 13);
      this.lPTV.TabIndex = 2;
      this.lPTV.Text = "TV: - ";
      // 
      // lPMoving
      // 
      this.lPMoving.AutoSize = true;
      this.lPMoving.Location = new System.Drawing.Point(6, 81);
      this.lPMoving.Name = "lPMoving";
      this.lPMoving.Size = new System.Drawing.Size(51, 13);
      this.lPMoving.TabIndex = 1;
      this.lPMoving.Text = "Moving: -";
      // 
      // lPEmpty
      // 
      this.lPEmpty.AutoSize = true;
      this.lPEmpty.Location = new System.Drawing.Point(6, 56);
      this.lPEmpty.Name = "lPEmpty";
      this.lPEmpty.Size = new System.Drawing.Size(45, 13);
      this.lPEmpty.TabIndex = 0;
      this.lPEmpty.Text = "Empty: -";
      // 
      // calibrateRoomTempToolStripMenuItem
      // 
      this.calibrateRoomTempToolStripMenuItem.Name = "calibrateRoomTempToolStripMenuItem";
      this.calibrateRoomTempToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
      this.calibrateRoomTempToolStripMenuItem.Text = "Calibrate room temp";
      this.calibrateRoomTempToolStripMenuItem.Click += new System.EventHandler(this.calibrateRoomTempToolStripMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(813, 572);
      this.Controls.Add(this.groupBoxPrediction);
      this.Controls.Add(this.groupBoxTemperature);
      this.Controls.Add(this.chart1);
      this.Controls.Add(this.groupBoxTraining);
      this.Controls.Add(this.tlpNumeric);
      this.Controls.Add(this.tlpColor);
      this.Controls.Add(this.tlpBlackWhite);
      this.Controls.Add(this.textBoxLog);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Text = "Activity Monitor";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.groupBoxTraining.ResumeLayout(false);
      this.groupBoxTraining.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
      this.groupBoxTemperature.ResumeLayout(false);
      this.groupBoxTemperature.PerformLayout();
      this.groupBoxPrediction.ResumeLayout(false);
      this.groupBoxPrediction.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem inputTableToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem blackAndWhiteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem coloredToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem numbersToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mLNETLearningToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
    private System.Windows.Forms.TextBox textBoxLog;
    private System.Windows.Forms.ToolStripMenuItem resetToDefaultToolStripMenuItem;
    private System.Windows.Forms.TableLayoutPanel tlpNumeric;
    private System.Windows.Forms.TableLayoutPanel tlpColor;
    private System.Windows.Forms.TableLayoutPanel tlpBlackWhite;
    private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem emptyRoomToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem personMovingToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem personWatchingTVToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem personSleepingToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem fallingToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem dataRowToolStripMenuItem;
    private System.Windows.Forms.Button btnPauseTraining;
    private System.Windows.Forms.GroupBox groupBoxTraining;
    private System.Windows.Forms.Label labelTrainingType;
    public System.Windows.Forms.Label labelCountDown;
    private System.Windows.Forms.Button btnEndTraining;
    private System.Windows.Forms.ToolStripMenuItem rawInputToolStripMenuItem;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private System.Windows.Forms.ToolStripMenuItem sleepGraphToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sleepToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem garminDataToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem liveMonitoringToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem temperatureToolStripMenuItem;
    private System.Windows.Forms.GroupBox groupBoxTemperature;
    private System.Windows.Forms.Label labelTMax;
    private System.Windows.Forms.Label labelTAvg;
    private System.Windows.Forms.Label labelTMin;
    private System.Windows.Forms.GroupBox groupBoxPrediction;
    private System.Windows.Forms.Label lPMoving;
    private System.Windows.Forms.Label lPEmpty;
    private System.Windows.Forms.Label lPTV;
    private System.Windows.Forms.Label lPSleeping;
    private System.Windows.Forms.Label labelPrediction;
    private System.Windows.Forms.Label lPFalling;
    private System.Windows.Forms.ToolStripMenuItem mLNETPredictionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mLPredictionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem convertTempToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem predictionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem roomTempToolStripMenuItem;
    private System.Windows.Forms.Label labelTRoom;
    private System.Windows.Forms.ToolStripMenuItem calibrateRoomTempToolStripMenuItem;
  }
}

