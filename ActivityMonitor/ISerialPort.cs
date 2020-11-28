using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityMonitor
{
  public interface ISerialPort
  {
    bool IsOpen { get; }
    string ReadLine();
    void Close();
    void Open(string comPort, int speed);
  }
}
