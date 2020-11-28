using System;
using System.IO;
using ActivityMonitor;
using ActivityMonitorML.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestActivityMonitor
{
  [TestClass]
  public class UnitTestMainForm
  {
    bool fallWarningSet = false;
    bool fallDetectedSet = false;

    [TestMethod]
    public void TestConstructor()
    {
      MainForm main = new MainForm(true);
    }

    /// <summary>
    /// Test that SerialInputWork works with testSerialShort.txt and that each method call changes serialInputRow
    /// </summary>
    [TestMethod]
    public void TestSerialInputRow()
    {
      TestSerialPort.inputFile = @"../../testSerialShort.txt";
      MainForm main = new MainForm(true);
      main.SerialInputWork("unitTestData.txt");
      Assert.AreEqual(0, main.GetSerialInputRow()[0]);
      Assert.AreEqual(234, main.GetSerialInputRow()[4]);
      main.SerialInputWork("unitTestData.txt");
      Assert.AreEqual(267, main.GetSerialInputRow()[0]);
      Assert.AreEqual(256, main.GetSerialInputRow()[1]);
      Assert.AreEqual(234, main.GetSerialInputRow()[4]);
      main.SerialInputWork("unitTestData.txt");
      Assert.AreEqual(267, main.GetSerialInputRow()[0]);
      Assert.AreEqual(233, main.GetSerialInputRow()[4]);
      main.SerialInputWork("unitTestData.txt");
      Assert.AreEqual(267, main.GetSerialInputRow()[0]);
      Assert.AreEqual(257, main.GetSerialInputRow()[1]);
      Assert.AreEqual(233, main.GetSerialInputRow()[4]);
    }

    [TestMethod]
    public void TestDoMachineLearning()
    {
      TestSerialPort.inputFile = @"../../testSerialInput.txt";
      MainForm main = new MainForm(true);
      Assert.IsFalse(main.IsTraining());

      main.labelCountDown.Text = "Training";
      main.trainingItem = MainForm.MLTraining.SLEEPING;

      Assert.IsTrue(main.IsTraining());

      string testDataFile = "unitTestData.txt";
      if (File.Exists(testDataFile))
      {
        File.Delete(testDataFile);
      }

      for (int i = 0; i < 10; i++)
      {
        main.SerialInputWork(testDataFile);
        main.secondCounter++;
      }

      Assert.IsTrue(File.Exists(testDataFile));

      string[] fileLines = File.ReadAllLines(testDataFile);

      //4 because 10 tries, where first 2 filles the previous line 
      Assert.AreEqual(4, fileLines.Length);
      Assert.AreEqual(((int)MainForm.MLTraining.SLEEPING).ToString(), fileLines[0][0].ToString());
    }

    [TestMethod]
    public void TestDetectMovingDown()
    {
      Assert.IsFalse(ML.DetectMovingDown(null));

      var notD1 = new int[32] { -1, -1, -3, -15, -1, 1, 0, -1, -1, 1, -10, -18, 0, 0, 1, 0, 0, -1, -7, 0, 7, 0, 1, 1, 0, -1, 0, -1, 0, 0, 1, 0 };
      var notD2 = new int[32] { 0, 1, 1, 2, 0, -1, 0, 0, 0, 1, 18, 23, -2, -1, -1, -1, 0, 1, 7, -12, -10, -1, 0, 0, 0, -1, 1, 0, -1, -1, -1, 1 };
      var notD3 = new int[32] { 0, 0, 0, 1, 12, 24, 2, 1, 1, 0, 0, 3, -20, 29, 4, 1, 0, 0, -3, 3, -10, 9, 2, 1, 0, 0, 0, 0, 0, 1, 1, 0 };

      Assert.IsFalse(ML.DetectMovingDown(notD1));
      Assert.IsFalse(ML.DetectMovingDown(notD2));
      Assert.IsFalse(ML.DetectMovingDown(notD3));

      var movD1 = new int[32] { 0, -1, -2, -9, 0, -1, 0, -1, -1, -2, -12, -22, 0, 0, 0, 0, 0, 0, -6, 3, 5, 1, 0, 0, -1, 0, -1, 0, 0, 0, 0, 0 };
      var movD2 = new int[32] { 0, 0, 0, 1, -12, 24, 2, 1, 1, 0, 0, 3, -20, 29, 4, 1, 0, 0, -3, 3, 10, 9, 2, 1, 0, 0, 0, 0, 0, 1, 1, 0 };
      var movD3 = new int[32] { 0, 1, 1, 2, 0, -1, 0, 0, 0, 1, 18, 23, -2, -1, -1, -1, 0, 1, 7, -12, -10, -1, -2, 0, 0, -1, 1, 0, -1, -1, 20, 1 };

      Assert.IsTrue(ML.DetectMovingDown(movD1));
      Assert.IsTrue(ML.DetectMovingDown(movD2));
      Assert.IsTrue(ML.DetectMovingDown(movD3));
    }

    [TestMethod]
    public void TestUpdateSleeping()
    {
      const int MINUTES_IN_DAY = 1440;
      MainForm main = new MainForm(true);
      main.isSleepingVector = new int[MINUTES_IN_DAY];

      main.UpdateSleeping(true, 100, "");

      Assert.AreEqual(1, main.isSleepingVector[100]);

      //Check awake warning
      for (int i = 0; i < MINUTES_IN_DAY * (MainForm.SLEEP_EXP_THRESHOLD + 1); i++)
      {
        //6 days of sleeping
        main.UpdateSleeping(true, i % MINUTES_IN_DAY, "");
      }
      main.awakeWarningCounter = 0;
      //Every not sleeping update makes awake warning counter rise by 6
      main.UpdateSleeping(false, 1, "");
      main.UpdateSleeping(false, 2, "");
      Assert.AreEqual(MainForm.SLEEP_EXP_THRESHOLD, main.isSleepingVector[1]);
      Assert.AreEqual((MainForm.SLEEP_EXP_THRESHOLD + 1) * 2, main.awakeWarningCounter);

      //Check sleep warning
      for (int i = 0; i < MINUTES_IN_DAY * (MainForm.AWAKE_EXP_THRESHOLD + MainForm.SLEEP_EXP_THRESHOLD + 1); i++)
      {
        //11 days of not sleeping
        main.UpdateSleeping(false, i % MINUTES_IN_DAY, "");
      }
      main.sleepWarningCounter = 0;
      //Every sleeping update makes sleep warning counter rise by 6
      main.UpdateSleeping(true, 1, "");
      main.UpdateSleeping(true, 2, "");
      Assert.AreEqual(-MainForm.AWAKE_EXP_THRESHOLD, main.isSleepingVector[1]);
      Assert.AreEqual((MainForm.AWAKE_EXP_THRESHOLD + 1) * 2, main.sleepWarningCounter);

      //Check max sleeping vector value 
      for (int i = 0; i < 100; i++)
      {
        main.UpdateSleeping(true, 0, "");
      }
      Assert.AreEqual(MainForm.MAX_VAL_FOR_MINUTE, main.isSleepingVector[0]);
      for (int i = 0; i < 100; i++)
      {
        main.UpdateSleeping(false, 10, "");
      }
      Assert.AreEqual(-MainForm.MAX_VAL_FOR_MINUTE, main.isSleepingVector[10]);
    }

    void FallWarning()
    {
      fallWarningSet = true;
    }

    void FallDetected()
    {
      fallDetectedSet = true;
    }

    void FallNotDetected()
    {

    }

    [TestMethod]
    public void TestFallDetection()
    {
      //Test null
      FallDetection fallDetection = new FallDetection(null, null, null);
      fallDetection.DoFallDetection(new ModelOutput(), null);

      fallDetection = new FallDetection(FallWarning, FallDetected, FallNotDetected);
      ModelOutput modelOutput = new ModelOutput();

      Assert.IsFalse(fallWarningSet);

      var movD1 = new int[32] { 0, -1, -2, -9, 0, -1, 0, -1, -1, -2, -12, -22, 0, 0, 0, 0, 0, 0, -6, 3, 5, 1, 0, 0, -1, 0, -1, 0, 0, 0, 0, 0, };
      modelOutput.Score = new float[5] { 0.0F, 0.2F, 0.3F, 0.0F, 0.6F };
      //Fall detected as we are moving down and fall detection is detected
      fallDetection.DoFallDetection(modelOutput, movD1);

      Assert.IsTrue(fallWarningSet);
      Assert.IsFalse(fallDetectedSet);

      for (int i = 0; i < 10; i++)
      {
        fallDetection.DoFallDetection(modelOutput, movD1);
      }
      Assert.IsTrue(fallDetectedSet);

      fallWarningSet = false;
      fallDetectedSet = false;

      modelOutput.Score = new float[5] { 0.0F, 0.2F, 0.3F, 0.0F, 0.4F };
      //Below 50% fall detection
      fallDetection.DoFallDetection(modelOutput, movD1);

      var notD3 = new int[32] { 0, 0, 0, 1, 12, 24, 2, 1, 1, 0, 0, 3, -20, 29, 4, 1, 0, 0, -3, 3, -10, 9, 2, 1, 0, 0, 0, 0, 0, 1, 1, 0 };
      modelOutput.Score = new float[5] { 0.0F, 0.2F, 0.3F, 0.0F, 0.7F };
      //Not moving down
      fallDetection.DoFallDetection(modelOutput, notD3);

      Assert.IsFalse(fallWarningSet);
      Assert.IsFalse(fallDetectedSet);
    }
  }
}
