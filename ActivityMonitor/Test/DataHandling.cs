using ActivityMonitorML.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityMonitor.Test
{
  public class DataHandling
  {
    public static void IncreaseTemp(string file, int tempChange, Random random)
    {
      var filelines = File.ReadAllLines(file);
      string outputFile = "testDataTempChange" + tempChange + ((random != null) ? "_random" : "") + ".txt";
      List<string> outputFileLines = new List<string>();
      foreach (var line in filelines)
      {
        if (string.IsNullOrWhiteSpace(line))
        {
          continue;
        }
        List<string> outputLine = new List<string>();
        var splittedLine = line.Split('\t');

        if (splittedLine.Length != 65)
        {
          throw new Exception("Unsupported length=" + splittedLine.Length);
        }

        for (int i = 0; i < 65; i++)
        {
          if (i == 0 || i > 32 || line.Contains("R"))
          {
            outputLine.Add(splittedLine[i]);
          }
          else
          {
            int randomValue = 0;
            if (random != null)
            {
              randomValue = random.Next(-3, 3);
              tempChange = 0;
            }
            outputLine.Add((int.Parse(splittedLine[i]) + tempChange + randomValue).ToString());
          }
        }
        outputFileLines.Add(string.Join("\t", outputLine.ToArray()));
      }
      File.WriteAllLines(outputFile, outputFileLines);
    }

    public static List<ModelOutput> GetPredictions(string file)
    {
      List<ModelOutput> outputList = new List<ModelOutput>();

      var filelines = File.ReadAllLines(file);

      foreach (var line in filelines)
      {
        if (string.IsNullOrWhiteSpace(line) || line.Contains("R"))
        {
          continue;
        }
        var splittedLine = line.Split('\t');

        if (splittedLine.Length != 65)
        {
          throw new Exception("Unsupported length=" + splittedLine.Length);
        }

        int[] inputRow = new int[32];
        int[] movementRow = new int[32];

        for (int i = 0; i < 65; i++)
        {
          if (i == 0)
          {
            continue;
          }
          if (i < 33)
          {
            inputRow[i - 1] = int.Parse(splittedLine[i]);
          }
          else
          {
            movementRow[i - 33] = int.Parse(splittedLine[i]);
          }
        }
        outputList.Add(ML.Predict(inputRow, movementRow));
      }

      return outputList;
    }

    public static List<double> GetRoomTemp(string file)
    {
      List<double> outputList = new List<double>();

      var filelines = File.ReadAllLines(file);

      foreach (var line in filelines)
      {
        if (string.IsNullOrWhiteSpace(line) || line.Contains("R"))
        {
          continue;
        }
        var splittedLine = line.Split('\t');

        if (splittedLine.Length != 65)
        {
          throw new Exception("Unsupported length=" + splittedLine.Length);
        }

        int[] inputRow = new int[32];

        for (int i = 0; i < 65; i++)
        {
          if (i == 0)
          {
            continue;
          }
          if (i < 33)
          {
            inputRow[i - 1] = int.Parse(splittedLine[i]);
          }
        }
        Array.Sort(inputRow);
        //int[] threeTempValue = new int[3] { inputRow[9], inputRow[10], inputRow[11] };
        //outputList.Add(threeTempValue.Average());
        outputList.Add(inputRow[9]);
      }
      return outputList;
    }

    public static int GetRoomTemp(int[] inputRow)
    {
      int[] inputCopy = new int[32];
      Array.Copy(inputRow, inputCopy, inputRow.Length);
      Array.Sort(inputCopy);
      return inputCopy[9];
    }

    public static void UseCalibratedRoomTemp(string file)
    {
      var filelines = File.ReadAllLines(file);
      string outputFile = "testDataCalibrated.txt";
      List<string> outputFileLines = new List<string>();
      foreach (var line in filelines)
      {
        if (string.IsNullOrWhiteSpace(line))
        {
          continue;
        }
        List<string> outputLine = new List<string>();
        var splittedLine = line.Split('\t');

        if (splittedLine.Length != 65)
        {
          throw new Exception("Unsupported length=" + splittedLine.Length);
        }

        int[] inputRow = new int[32];

        for (int i = 0; i < 65; i++)
        {
          if (i > 0 && i < 33 && !line.Contains("R"))
          {
            inputRow[i - 1] = int.Parse(splittedLine[i]);
          }
        }

        for (int i = 0; i < 65; i++)
        {
          if (i == 0 || i > 32 || line.Contains("R"))
          {
            outputLine.Add(splittedLine[i]);
          }
          else
          {
            outputLine.Add((int.Parse(splittedLine[i]) - GetRoomTemp(inputRow)).ToString());
          }
        }
        outputFileLines.Add(string.Join("\t", outputLine.ToArray()));
      }
      File.WriteAllLines(outputFile, outputFileLines);
    }
  }
}
