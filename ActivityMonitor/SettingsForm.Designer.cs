namespace ActivityMonitor
{
  partial class SettingsForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.nudComPort = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.nudFalling = new System.Windows.Forms.NumericUpDown();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.tbSender = new System.Windows.Forms.TextBox();
      this.tbPassword = new System.Windows.Forms.TextBox();
      this.tbReceiver = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.nudComPort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFalling)).BeginInit();
      this.SuspendLayout();
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(282, 326);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(201, 326);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(32, 38);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(58, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "COM port: ";
      // 
      // nudComPort
      // 
      this.nudComPort.Location = new System.Drawing.Point(127, 38);
      this.nudComPort.Name = "nudComPort";
      this.nudComPort.Size = new System.Drawing.Size(48, 20);
      this.nudComPort.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(32, 81);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Falling threshold:";
      this.toolTip1.SetToolTip(this.label2, "(Temperature change to be considered falling 10*C)");
      // 
      // nudFalling
      // 
      this.nudFalling.Location = new System.Drawing.Point(127, 79);
      this.nudFalling.Name = "nudFalling";
      this.nudFalling.Size = new System.Drawing.Size(48, 20);
      this.nudFalling.TabIndex = 5;
      this.toolTip1.SetToolTip(this.nudFalling, "(Temperature change to be considered falling 10*C)");
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(32, 117);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(73, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Sender Gmail:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(32, 149);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(92, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Sender password:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(32, 185);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(80, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "Receiver email:";
      // 
      // tbSender
      // 
      this.tbSender.Location = new System.Drawing.Point(127, 114);
      this.tbSender.Name = "tbSender";
      this.tbSender.Size = new System.Drawing.Size(128, 20);
      this.tbSender.TabIndex = 9;
      // 
      // tbPassword
      // 
      this.tbPassword.Location = new System.Drawing.Point(127, 146);
      this.tbPassword.Name = "tbPassword";
      this.tbPassword.PasswordChar = '*';
      this.tbPassword.Size = new System.Drawing.Size(128, 20);
      this.tbPassword.TabIndex = 10;
      // 
      // tbReceiver
      // 
      this.tbReceiver.Location = new System.Drawing.Point(127, 182);
      this.tbReceiver.Name = "tbReceiver";
      this.tbReceiver.Size = new System.Drawing.Size(128, 20);
      this.tbReceiver.TabIndex = 11;
      // 
      // SettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(384, 361);
      this.Controls.Add(this.tbReceiver);
      this.Controls.Add(this.tbPassword);
      this.Controls.Add(this.tbSender);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.nudFalling);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.nudComPort);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSave);
      this.Name = "SettingsForm";
      this.Text = "Settings";
      ((System.ComponentModel.ISupportInitialize)(this.nudComPort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudFalling)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown nudComPort;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown nudFalling;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbSender;
    private System.Windows.Forms.TextBox tbPassword;
    private System.Windows.Forms.TextBox tbReceiver;
  }
}