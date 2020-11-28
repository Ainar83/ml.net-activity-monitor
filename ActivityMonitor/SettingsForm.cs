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
  public partial class SettingsForm : Form
  {
    public SettingsForm()
    {
      InitializeComponent();
      nudComPort.Value = Properties.Settings.Default.ComPort;
      nudFalling.Value = Properties.Settings.Default.FallingThreshold;
      tbSender.Text = Properties.Settings.Default.SenderGmail;
      tbReceiver.Text = Properties.Settings.Default.ReceiverEmail;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      Properties.Settings.Default.ComPort = (int)nudComPort.Value;
      Properties.Settings.Default.FallingThreshold = (int)nudFalling.Value;
      Properties.Settings.Default.SenderGmail = tbSender.Text;
      Properties.Settings.Default.ReceiverEmail = tbReceiver.Text;
      if (!string.IsNullOrEmpty(tbPassword.Text))
      {
        Properties.Settings.Default.SenderPassword = tbPassword.Text;
      }
      Properties.Settings.Default.Save();
      DialogResult = DialogResult.OK;
      Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }
  }
}
