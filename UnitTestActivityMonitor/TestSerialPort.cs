using ActivityMonitor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestActivityMonitor
{
  class TestSerialPort : ISerialPort
  {
    const string inputFile = "testSerialInput.txt";
    string[] fileContents = null;
    int readCounter = 0;
    public void Close()
    {

    }

    public void Open()
    {

    }

    public string ReadLine()
    {
      if (fileContents == null)
      {
        fileContents = File.ReadAllLines(inputFile);
      }
      Thread.Sleep(100);

      if (readCounter == fileContents.Length)
      {
        throw new Exception("File:  " + inputFile + " ended");
      }
      return fileContents[readCounter++];
    }
  }
}
