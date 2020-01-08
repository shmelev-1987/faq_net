using System.Windows.Forms;
using System.Drawing;

namespace FAQ_Net
{
    class FindForm : UserControl
    {
        // Components:
        private PulseButton.PulseButton btnSearchDown;
        private CheckBox wholeWord;
        private CheckBox matchCase;
        private int curPos = -1;
        private int startPos;
        private int endPos;
        private bool found;
        //
        private const byte REPLACE_NONE = 0;
        private const byte REPLACE_EACH = 1;
        private const byte REPLACE_ALL = 2;
        private PulseButton.PulseButton cancel;
        private PulseButton.PulseButton btnSearchUp;
    private TextBox txbReplace;
    private Label lblReplace;
    private PulseButton.PulseButton btnReplaceAll;
    private PulseButton.PulseButton btnReplace;
    public TextBox findText;
    private Label FindLabel;
    public RadioButton rbSearch;
    public RadioButton rbReplace;
    private CheckBox chkHighlightAll;
    public GradientControls.PanelGradient panelGradient;
    public RichTextBox rtb;

        /// <summary>
        /// Quick down and dirty search form. This was made
        /// from an empty code file, so this form has no
        /// .designer file.
        /// </summary>
        /// <param name="RtbToSearch">RichTextBox to search.</param>
        public FindForm(ref RichTextBoxCustom richTextBox)
        {
          rtb = richTextBox;
          InitializeComponent();
        }

        private void InitializeComponent()
        {
      this.btnSearchDown = new PulseButton.PulseButton();
      this.wholeWord = new System.Windows.Forms.CheckBox();
      this.matchCase = new System.Windows.Forms.CheckBox();
      this.btnReplace = new PulseButton.PulseButton();
      this.btnReplaceAll = new PulseButton.PulseButton();
      this.txbReplace = new System.Windows.Forms.TextBox();
      this.lblReplace = new System.Windows.Forms.Label();
      this.btnSearchUp = new PulseButton.PulseButton();
      this.cancel = new PulseButton.PulseButton();
      this.findText = new System.Windows.Forms.TextBox();
      this.FindLabel = new System.Windows.Forms.Label();
      this.rbSearch = new System.Windows.Forms.RadioButton();
      this.rbReplace = new System.Windows.Forms.RadioButton();
      this.chkHighlightAll = new System.Windows.Forms.CheckBox();
      this.panelGradient = new GradientControls.PanelGradient();
      this.panelGradient.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnSearchDown
      // 
      this.btnSearchDown.ButtonColorBottom = System.Drawing.Color.LightSkyBlue;
      this.btnSearchDown.ButtonColorTop = System.Drawing.Color.LightCyan;
      this.btnSearchDown.CornerRadius = 5;
      this.btnSearchDown.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnSearchDown.Image = global::FAQ_Net.Properties.Resources.down;
      this.btnSearchDown.Location = new System.Drawing.Point(331, 23);
      this.btnSearchDown.Name = "btnSearchDown";
      this.btnSearchDown.PulseSpeed = 0.3F;
      this.btnSearchDown.PulseWidth = 1;
      this.btnSearchDown.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      this.btnSearchDown.Size = new System.Drawing.Size(25, 25);
      this.btnSearchDown.TabIndex = 2;
      this.btnSearchDown.TabStop = false;
      this.btnSearchDown.UseVisualStyleBackColor = true;
      this.btnSearchDown.Click += new System.EventHandler(this.btnSearchDown_Click);
      this.btnSearchDown.Enter += new System.EventHandler(this.findButton_Enter);
      // 
      // wholeWord
      // 
      this.wholeWord.AutoSize = true;
      this.wholeWord.Location = new System.Drawing.Point(601, 28);
      this.wholeWord.Name = "wholeWord";
      this.wholeWord.Size = new System.Drawing.Size(143, 17);
      this.wholeWord.TabIndex = 345;
      this.wholeWord.TabStop = false;
      this.wholeWord.Text = "Только &слово целиком";
      this.wholeWord.UseVisualStyleBackColor = true;
      // 
      // matchCase
      // 
      this.matchCase.AutoSize = true;
      this.matchCase.Location = new System.Drawing.Point(475, 28);
      this.matchCase.Name = "matchCase";
      this.matchCase.Size = new System.Drawing.Size(120, 17);
      this.matchCase.TabIndex = 444;
      this.matchCase.TabStop = false;
      this.matchCase.Text = "С учетом &регистра";
      this.matchCase.UseVisualStyleBackColor = true;
      // 
      // btnReplace
      // 
      this.btnReplace.ButtonColorBottom = System.Drawing.Color.LightSkyBlue;
      this.btnReplace.ButtonColorTop = System.Drawing.Color.LightCyan;
      this.btnReplace.CornerRadius = 5;
      this.btnReplace.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnReplace.Location = new System.Drawing.Point(362, 50);
      this.btnReplace.Name = "btnReplace";
      this.btnReplace.PulseSpeed = 0.3F;
      this.btnReplace.PulseWidth = 1;
      this.btnReplace.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      this.btnReplace.Size = new System.Drawing.Size(75, 23);
      this.btnReplace.TabIndex = 683;
      this.btnReplace.Text = "Заменить";
      this.btnReplace.UseVisualStyleBackColor = true;
      this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
      // 
      // btnReplaceAll
      // 
      this.btnReplaceAll.ButtonColorBottom = System.Drawing.Color.LightSkyBlue;
      this.btnReplaceAll.ButtonColorTop = System.Drawing.Color.LightCyan;
      this.btnReplaceAll.CornerRadius = 5;
      this.btnReplaceAll.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnReplaceAll.Location = new System.Drawing.Point(443, 50);
      this.btnReplaceAll.Name = "btnReplaceAll";
      this.btnReplaceAll.PulseSpeed = 0.3F;
      this.btnReplaceAll.PulseWidth = 1;
      this.btnReplaceAll.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      this.btnReplaceAll.Size = new System.Drawing.Size(89, 23);
      this.btnReplaceAll.TabIndex = 682;
      this.btnReplaceAll.TabStop = false;
      this.btnReplaceAll.Text = "Заменить все";
      this.btnReplaceAll.UseVisualStyleBackColor = true;
      this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
      // 
      // txbReplace
      // 
      this.txbReplace.Location = new System.Drawing.Point(86, 52);
      this.txbReplace.Name = "txbReplace";
      this.txbReplace.Size = new System.Drawing.Size(215, 20);
      this.txbReplace.TabIndex = 680;
      // 
      // lblReplace
      // 
      this.lblReplace.AutoSize = true;
      this.lblReplace.Location = new System.Drawing.Point(8, 55);
      this.lblReplace.Name = "lblReplace";
      this.lblReplace.Size = new System.Drawing.Size(75, 13);
      this.lblReplace.TabIndex = 681;
      this.lblReplace.Text = "&Заменить на:";
      // 
      // btnSearchUp
      // 
      this.btnSearchUp.ButtonColorBottom = System.Drawing.Color.LightSkyBlue;
      this.btnSearchUp.ButtonColorTop = System.Drawing.Color.LightCyan;
      this.btnSearchUp.CornerRadius = 5;
      this.btnSearchUp.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnSearchUp.Image = global::FAQ_Net.Properties.Resources.up;
      this.btnSearchUp.Location = new System.Drawing.Point(305, 23);
      this.btnSearchUp.Name = "btnSearchUp";
      this.btnSearchUp.PulseSpeed = 0.3F;
      this.btnSearchUp.PulseWidth = 1;
      this.btnSearchUp.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      this.btnSearchUp.Size = new System.Drawing.Size(25, 25);
      this.btnSearchUp.TabIndex = 679;
      this.btnSearchUp.UseVisualStyleBackColor = true;
      this.btnSearchUp.Click += new System.EventHandler(this.btnSearchUp_Click);
      // 
      // cancel
      // 
      this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cancel.ButtonColorBottom = System.Drawing.Color.LightSkyBlue;
      this.cancel.ButtonColorTop = System.Drawing.Color.LightCyan;
      this.cancel.CornerRadius = 5;
      this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancel.ForeColor = System.Drawing.SystemColors.ControlText;
      this.cancel.Location = new System.Drawing.Point(759, 3);
      this.cancel.Name = "cancel";
      this.cancel.PulseSpeed = 0.3F;
      this.cancel.PulseWidth = 1;
      this.cancel.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      this.cancel.Size = new System.Drawing.Size(21, 20);
      this.cancel.TabIndex = 3;
      this.cancel.TabStop = false;
      this.cancel.Text = "X";
      this.cancel.UseVisualStyleBackColor = true;
      this.cancel.Click += new System.EventHandler(this.cancel_Click);
      // 
      // findText
      // 
      this.findText.Location = new System.Drawing.Point(86, 26);
      this.findText.Name = "findText";
      this.findText.Size = new System.Drawing.Size(215, 20);
      this.findText.TabIndex = 1;
      // 
      // FindLabel
      // 
      this.FindLabel.AutoSize = true;
      this.FindLabel.Location = new System.Drawing.Point(9, 29);
      this.FindLabel.Name = "FindLabel";
      this.FindLabel.Size = new System.Drawing.Size(41, 13);
      this.FindLabel.TabIndex = 7;
      this.FindLabel.Text = "&Найти:";
      // 
      // rbSearch
      // 
      this.rbSearch.AutoSize = true;
      this.rbSearch.Location = new System.Drawing.Point(13, 3);
      this.rbSearch.Name = "rbSearch";
      this.rbSearch.Size = new System.Drawing.Size(56, 17);
      this.rbSearch.TabIndex = 685;
      this.rbSearch.Text = "Найти";
      this.rbSearch.UseVisualStyleBackColor = true;
      // 
      // rbReplace
      // 
      this.rbReplace.AutoSize = true;
      this.rbReplace.Checked = true;
      this.rbReplace.Location = new System.Drawing.Point(75, 3);
      this.rbReplace.Name = "rbReplace";
      this.rbReplace.Size = new System.Drawing.Size(75, 17);
      this.rbReplace.TabIndex = 686;
      this.rbReplace.TabStop = true;
      this.rbReplace.Text = "Заменить";
      this.rbReplace.UseVisualStyleBackColor = true;
      this.rbReplace.CheckedChanged += new System.EventHandler(this.rbReplace_CheckedChanged);
      // 
      // chkHighlightAll
      // 
      this.chkHighlightAll.AutoSize = true;
      this.chkHighlightAll.Location = new System.Drawing.Point(362, 28);
      this.chkHighlightAll.Name = "chkHighlightAll";
      this.chkHighlightAll.Size = new System.Drawing.Size(107, 17);
      this.chkHighlightAll.TabIndex = 687;
      this.chkHighlightAll.TabStop = false;
      this.chkHighlightAll.Text = "Подсветить все";
      this.chkHighlightAll.UseVisualStyleBackColor = true;
      this.chkHighlightAll.CheckedChanged += new System.EventHandler(this.chkHighlightAll_CheckedChanged);
      // 
      // panelGradient
      // 
      this.panelGradient.BackColorBottom = System.Drawing.Color.Empty;
      this.panelGradient.Controls.Add(this.chkHighlightAll);
      this.panelGradient.Controls.Add(this.rbSearch);
      this.panelGradient.Controls.Add(this.rbReplace);
      this.panelGradient.Controls.Add(this.matchCase);
      this.panelGradient.Controls.Add(this.btnSearchDown);
      this.panelGradient.Controls.Add(this.btnReplace);
      this.panelGradient.Controls.Add(this.wholeWord);
      this.panelGradient.Controls.Add(this.btnReplaceAll);
      this.panelGradient.Controls.Add(this.btnSearchUp);
      this.panelGradient.Controls.Add(this.cancel);
      this.panelGradient.Controls.Add(this.lblReplace);
      this.panelGradient.Controls.Add(this.FindLabel);
      this.panelGradient.Controls.Add(this.findText);
      this.panelGradient.Controls.Add(this.txbReplace);
      this.panelGradient.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelGradient.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
      this.panelGradient.Location = new System.Drawing.Point(0, 0);
      this.panelGradient.Name = "panelGradient";
      this.panelGradient.Size = new System.Drawing.Size(783, 78);
      this.panelGradient.TabIndex = 688;
      // 
      // FindForm
      // 
      this.BackColor = System.Drawing.SystemColors.Window;
      this.Controls.Add(this.panelGradient);
      this.Name = "FindForm";
      this.Size = new System.Drawing.Size(783, 78);
      this.panelGradient.ResumeLayout(false);
      this.panelGradient.PerformLayout();
      this.ResumeLayout(false);

    }

        /// <summary>
        /// Performs find operation based on selected Search options, and replace options.
        /// </summary>
        /// <param name="replaceOptions">Replaces each instance, or all instances, or none. (0=None; 1=Each; 2=All)</param>
        private bool Find(byte replaceOptions, bool down)
        {
            bool done = false;

            // Задать опции поиска
            RichTextBoxFinds SearchOptions = (matchCase.Checked ? RichTextBoxFinds.MatchCase : 0)
              | (wholeWord.Checked ? RichTextBoxFinds.WholeWord : 0)
              | (down ? 0 : RichTextBoxFinds.Reverse);

            if (replaceOptions == REPLACE_EACH && string.Compare(rtb.SelectedText, findText.Text, !matchCase.Checked) == 0)
            {
                // curPos = rtb.SelectionStart;
                rtb.SelectedText = txbReplace.Text;
                // rtb.Select(curPos, replaceText.TextLength); 
                done = true;
            }
            if (down)
            {
                if (curPos > -1 && curPos < rtb.TextLength)
                {
                    startPos = curPos + 1;
                }
                else
                {
                    startPos = 0;
                }
                curPos = rtb.Find(findText.Text, startPos, SearchOptions);
                if (curPos == -1)
                {
                    found = rtb.Text.IndexOf(findText.Text) > -1;
                    if (found)
                    {
                        if (replaceOptions == REPLACE_NONE)
                        {
                            // Finished searching to the end.
                            // Automatically find next item back at the beginning.
                            startPos = 0;
                            curPos = rtb.Find(findText.Text, startPos, SearchOptions);
                        }
                        else
                        {
                            MessageBox.Show("Finished replacing text.", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (curPos > -1)
                {
                    found = true;
                    // Replace text if not already done and replace each specified.
                    if (replaceOptions == REPLACE_EACH)
                    {
                        if (!done)
                        {
                            rtb.SelectedText = txbReplace.Text;
                        }
                        curPos = rtb.Find(findText.Text, startPos, SearchOptions);
                        //Find(REPLACE_NONE, down);
                        //rtb.Select(curPos, replaceText.TextLength);
                    }
                    else if (replaceOptions == REPLACE_ALL)
                    {
                        rtb.SelectedText = txbReplace.Text;
                        rtb.Select(curPos, txbReplace.TextLength);
                        Find(REPLACE_ALL, down);
                    }
                }
            }
            else
            {
                if (curPos > 0)
                {
                    startPos = 0;
                    endPos = curPos;
                }
                else
                {
                    startPos = 0;
                    endPos = rtb.TextLength;
                }
                curPos = rtb.Find(findText.Text, startPos, endPos, SearchOptions);
                if (curPos == -1 && found)
                {
                    if (replaceOptions == REPLACE_NONE)
                    {
                        // Finished searching to the end.
                        // Automatically find next item back at the beginning.
                        endPos = rtb.TextLength;
                        curPos = rtb.Find(findText.Text, startPos, endPos, SearchOptions);
                    }
                    else
                    {
                        MessageBox.Show("Finished replacing text.", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (curPos > -1)
                {
                    found = true;
                    if (replaceOptions == REPLACE_EACH)
                    {
                        if (!done)
                        {
                            rtb.SelectedText = txbReplace.Text;
                        }
                        Find(REPLACE_NONE, down);
                        //rtb.Select(curPos, replaceText.TextLength);
                    }
                    else if (replaceOptions == REPLACE_ALL)
                    {
                        rtb.SelectedText = txbReplace.Text;
                        rtb.Select(curPos, txbReplace.TextLength);
                        Find(REPLACE_ALL, down);
                    }
                }
            }
      //if (!found)
      //{
      //  rtb.SelectionLength = 0;
      //  string msg;
      //  if (replaceOptions == REPLACE_NONE)
      //  {
      //    msg = "Finished Searching.";
      //  }
      //  else if (rtb.Rtf != undoRtf)
      //  {
      //    msg = "Finished replacing text.";
      //  }
      //  else
      //  {
      //    msg = "Finished Searching. No text was replaced.";
      //  }
      //  MessageBox.Show(msg, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
      //}
      if (curPos == -1)
        findText.BackColor = Color.LightCoral;
      else
        findText.BackColor = Color.White;
      return (curPos != -1);
    }

        private void btnSearchDown_Click(object sender, System.EventArgs e)
        {
            curPos = rtb.SelectionStart;
            if (findText.Text.Length > 0)
            {
                Find(REPLACE_NONE, true);
            }
        }

        private void FindText_TextChanged(object sender, System.EventArgs e)
        {
            curPos = -1;
            found = false;
        }

        private void btnReplace_Click(object sender, System.EventArgs e)
        {
            if (findText.Text.Length > 0)
            {
                curPos = rtb.SelectionStart;
                Find(REPLACE_EACH, true);
            }
        }

        private void replaceAll_Click(object sender, System.EventArgs e)
        {
            
        }

        private void replaceText_Enter(object sender, System.EventArgs e)
        {
             btnSearchDown.TabStop = true;
        }

        private void findButton_Enter(object sender, System.EventArgs e)
        {
            cancel.TabStop = true;
        }

        private void btnSearchUp_Click(object sender, System.EventArgs e)
        {
            curPos = rtb.SelectionStart;
            if (findText.Text.Length > 0)
            {
                Find(REPLACE_NONE, false);
            }
        }

        private void cancel_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

    private void rbReplace_CheckedChanged(object sender, System.EventArgs e)
    {
      lblReplace.Visible =
        txbReplace.Visible =
        btnReplace.Visible =
        btnReplaceAll.Visible = rbReplace.Checked;
      if (rbReplace.Checked)
        this.Height = 78;
      else
        this.Height = 52;
    }

    //private void btnUndoAll_Click(object sender, System.EventArgs e)
    //{
    //  if (undoRtf.Length > 0)
    //  {
    //    if (MessageBox.Show("Undo all replace operations?", "Verify Undo All", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    //    {
    //      rtb.Rtf = undoRtf;
    //    }
    //    else
    //    {
    //      MessageBox.Show("Can't undo.", "Unable to Undo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //    }
    //  }
    //}

    private void btnReplaceAll_Click(object sender, System.EventArgs e)
    {
      if (findText.Text.Length > 0)
      {
        // команда "Заменить все" выполняется через создание временного RichTextBox в котором изменяются
        // данные по частям, а результат передается в рабочий компонент, чтобы операция "Отменить"
        // была выполнена одним действием
        using (RichTextBox rtbTemp = new RichTextBox())
        {
          rtbTemp.Rtf = rtb.Rtf;
          int index = 0;
          RichTextBoxFinds SearchOptions = (matchCase.Checked ? RichTextBoxFinds.MatchCase : 0)
                | (wholeWord.Checked ? RichTextBoxFinds.WholeWord : 0);
          int countReplace = 0;
          while ((index = rtbTemp.Find(findText.Text, index, SearchOptions)) > -1)
          {
            rtbTemp.SelectedText = txbReplace.Text;
            countReplace += 1;
            //rtbTemp.Select(curPos, txbReplace.TextLength);
          }
          if (countReplace > 0)
          {
            rtb.SelectAll();
            rtb.SelectedRtf = rtbTemp.Rtf;
          }
          MessageBox.Show(string.Format("Готово. Число выполненых замен: {0}", countReplace));
        }
      }
    }

    private void chkHighlightAll_CheckedChanged(object sender, System.EventArgs e)
    {
      if (findText.Text.Length > 0)
      {
        using (RichTextBox rtbTemp = new RichTextBox())
        {
          rtbTemp.Rtf = rtb.Rtf;
          int index = 0;
          int countFind = 0;
          RichTextBoxFinds SearchOptions = (matchCase.Checked ? RichTextBoxFinds.MatchCase : 0)
                   | (wholeWord.Checked ? RichTextBoxFinds.WholeWord : 0);
          while ((index = rtbTemp.Find(findText.Text, index, SearchOptions)) > -1)
          {
            rtbTemp.SelectionBackColor = chkHighlightAll.Checked ? Color.Plum : Color.Transparent;
            index = rtbTemp.Text.IndexOf(findText.Text, index) + 1;
            countFind += 1;
          }
          if (countFind > 0)
          {
            if (rtb.CanUndo)
            {
              rtb.SelectAll();
              rtb.SelectedRtf = rtbTemp.Rtf;
            }
            else
              rtb.Rtf = rtbTemp.Rtf;
          }
        }
      }
    }
  }
}