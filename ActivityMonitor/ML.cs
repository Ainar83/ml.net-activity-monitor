using ActivityMonitorML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityMonitor
{
  /// <summary>
  /// Machine learning related methods
  /// </summary>
  public class ML
  {
    const int SENSOR_COLUMS = 4;
    public static bool DetectMovingDown(int[] mRow)
    {
      int FALLING_THRESHOLD = Properties.Settings.Default.FallingThreshold;

      if (mRow == null)
      {
        return false;
      }

      for (int i = 1; i < SENSOR_COLUMS; i++)
      {
        for (int j = 0; j < (SENSOR_COLUMS * 2); j++)
        {
          if (mRow[i * 8 + j] - mRow[((i - 1) * 8) + j] > FALLING_THRESHOLD && mRow[((i - 1) * 8) + j] < -1)
          {
            return true;
          }
        }
      }
      return false;
    }

    public static ModelOutput Predict(int[] inputRow, int[] movInput)
    {
      ModelInput mlInput = new ModelInput();

      //mlInput.Col0 = inputRow[0]; Result
      mlInput.Col1 = inputRow[0];
      mlInput.Col2 = inputRow[1];
      mlInput.Col3 = inputRow[2];
      mlInput.Col4 = inputRow[3];
      mlInput.Col5 = inputRow[4];
      mlInput.Col6 = inputRow[5];
      mlInput.Col7 = inputRow[6];
      mlInput.Col8 = inputRow[7];
      mlInput.Col9 = inputRow[8];
      mlInput.Col10 = inputRow[9];
      mlInput.Col11 = inputRow[10];
      mlInput.Col12 = inputRow[11];
      mlInput.Col13 = inputRow[12];
      mlInput.Col14 = inputRow[13];
      mlInput.Col15 = inputRow[14];
      mlInput.Col16 = inputRow[15];
      mlInput.Col17 = inputRow[16];
      mlInput.Col18 = inputRow[17];
      mlInput.Col19 = inputRow[18];
      mlInput.Col20 = inputRow[19];
      mlInput.Col21 = inputRow[20];
      mlInput.Col22 = inputRow[21];
      mlInput.Col23 = inputRow[22];
      mlInput.Col24 = inputRow[23];
      mlInput.Col25 = inputRow[24];
      mlInput.Col26 = inputRow[25];
      mlInput.Col27 = inputRow[26];
      mlInput.Col28 = inputRow[27];
      mlInput.Col29 = inputRow[28];
      mlInput.Col30 = inputRow[29];
      mlInput.Col31 = inputRow[30];
      mlInput.Col32 = inputRow[31];

      mlInput.Col33 = movInput[0];
      mlInput.Col34 = movInput[1];
      mlInput.Col35 = movInput[2];
      mlInput.Col36 = movInput[3];
      mlInput.Col37 = movInput[4];
      mlInput.Col38 = movInput[5];
      mlInput.Col39 = movInput[6];
      mlInput.Col40 = movInput[7];
      mlInput.Col41 = movInput[8];
      mlInput.Col42 = movInput[9];
      mlInput.Col43 = movInput[10];
      mlInput.Col44 = movInput[11];
      mlInput.Col45 = movInput[12];
      mlInput.Col46 = movInput[13];
      mlInput.Col47 = movInput[14];
      mlInput.Col48 = movInput[15];
      mlInput.Col49 = movInput[16];
      mlInput.Col50 = movInput[17];
      mlInput.Col51 = movInput[18];
      mlInput.Col52 = movInput[19];
      mlInput.Col53 = movInput[20];
      mlInput.Col54 = movInput[21];
      mlInput.Col55 = movInput[22];
      mlInput.Col56 = movInput[23];
      mlInput.Col57 = movInput[24];
      mlInput.Col58 = movInput[25];
      mlInput.Col59 = movInput[26];
      mlInput.Col60 = movInput[27];
      mlInput.Col61 = movInput[28];
      mlInput.Col62 = movInput[29];
      mlInput.Col63 = movInput[30];
      mlInput.Col64 = movInput[31];

      ModelOutput result = ConsumeModel.Predict(mlInput);
      return result;
    }
  }
}
