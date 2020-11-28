using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityMonitor
{
  class Utilities
  {
    public static string GetTimeString()
    {
      DateTime dt = DateTime.Now;
      return dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2");
    }

    public static Color GetColor(int value)
    {
      int red = value - 250;

      int green = 0;

      if (value > 250)
      {
        green = 500 - value;
      }
      else
      {
        green = value;
      }

      if (green < 0)
      {
        green = 0;
      }

      if (red < 0)
      {
        red = 0;
      }
      int blue = 250 - value;
      if (blue < 0)
      {
        blue = 0;
      }
      red = red * 3;
      blue = blue * 3;
      if (red > 255)
      {
        red = 255;
      }
      if (blue > 255)
      {
        blue = 255;
      }
      //AddInfo("Value " + value + ", red: " + red + ", green: " + green + ", blue: " + blue);
      return Color.FromArgb(red, green, blue);
    }
  }
}
