using ActivityMonitorML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityMonitor
{
  public class FallDetection
  {
    /// <summary>
    /// Raised when falling is detected
    /// </summary>
    public delegate void FallWarning();
    /// <summary>
    /// Raised if falling is detected and within 10 seconds no movement
    /// </summary>
    public delegate void FallDetected();
    /// <summary>
    /// Raised if fall detection warning is removed
    /// </summary>
    public delegate void FallNotDetected();

    FallWarning fallWarning;
    FallDetected fallDetected;
    FallNotDetected fallNotDetected;
    bool fallRegistered = false;
    int getUpCounter = 0;

    public FallDetection(FallWarning warning, FallDetected detected, FallNotDetected notDetected)
    {
      fallWarning = warning;
      fallDetected = detected;
      fallNotDetected = notDetected;
    }

    /// <summary>
    /// Check if event score is above 50%
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
    private bool GetEvent(float score)
    {
      float percent = score * 100;

      return percent > 50;
    }

    public void DoFallDetection(ModelOutput modelOutput, int[] mRow)
    {
      if (ML.DetectMovingDown(mRow) && (modelOutput.Prediction == 4))
      {
        fallRegistered = true;
        fallWarning();
      }

      if(fallRegistered)
      {
        getUpCounter++;
      }
      if (getUpCounter > 1)
      {
        if (GetEvent(modelOutput.Score[1]) || GetEvent(modelOutput.Score[2]) || GetEvent(modelOutput.Score[3]))
        {
          fallNotDetected();
          fallRegistered = false;
          getUpCounter = 0;
        }
        else if (getUpCounter == 10)
        {
          //Fall detected raise alarm
          fallDetected();
        }
      }
    }
  }
}
