namespace WaitWnd
{
    partial class WaitForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Image = global::FAQ_Net.Properties.Resources.wait;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(227, 222);
      this.label1.TabIndex = 0;
      this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_MouseDown);
      this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Move_MouseMove);
      // 
      // WaitForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(227, 222);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "WaitForm";
      this.Text = "WaitForm";
      this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
    }
}