using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityMonitor
{
  class SerialPortImpl : ISerialPort
  {
    SerialPort serial;

    public bool IsOpen => serial.IsOpen;

    public void Close()
    {
      serial.Close();
    }

    public void Open(string comPort, int speed)
    {
      serial = new SerialPort(comPort, speed);
      serial.Open();
    }

    public string ReadLine()
    {
      return serial.ReadLine();
    }
  }
}
