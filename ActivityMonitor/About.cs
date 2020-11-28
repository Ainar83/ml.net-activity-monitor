using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivityMonitor
{
  public partial class About : Form
  {
    public About()
    {
      InitializeComponent();

      textBoxAbout.Text = "This program is a work product of Master Thesis:" + Environment.NewLine + Environment.NewLine;
      textBoxAbout.Text += "Investigating behavioral anomalies using machine learning" + Environment.NewLine + Environment.NewLine;
      textBoxAbout.Text += "Author: Ainar Assuküll";
    }
  }
}
