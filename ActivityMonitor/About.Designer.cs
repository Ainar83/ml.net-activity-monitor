namespace ActivityMonitor
{
  partial class About
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
      this.textBoxAbout = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // textBoxAbout
      // 
      this.textBoxAbout.BackColor = System.Drawing.SystemColors.Control;
      this.textBoxAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBoxAbout.Location = new System.Drawing.Point(31, 55);
      this.textBoxAbout.Multiline = true;
      this.textBoxAbout.Name = "textBoxAbout";
      this.textBoxAbout.ReadOnly = true;
      this.textBoxAbout.Size = new System.Drawing.Size(370, 109);
      this.textBoxAbout.TabIndex = 0;
      this.textBoxAbout.Text = "This progrma is a work product of Master Thesis:\\nInvestigating behavioral anomal" +
    "ies using machine learning";
      // 
      // About
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(468, 328);
      this.Controls.Add(this.textBoxAbout);
      this.Name = "About";
      this.Text = "About";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBoxAbout;
  }
}