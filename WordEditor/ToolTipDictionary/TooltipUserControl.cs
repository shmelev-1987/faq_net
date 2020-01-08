using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FAQ_Net
{
  public partial class TooltipUserControl : UserControl
  {
    public static char[] StartOrEndWordChars = new char[] {',',';',':','!','?','%','+',
                                              '=','*','$','\'','\"','<','>','^','(',')',
                                              '[',']','{','}','°','&','|',' ','\n','"','\t' };

    private eDictionary _dict = new eDictionary();
    private RichTextBoxCustom _rtb;
    private readonly Timer timerShowToolTip = new Timer();
    private Point _lastMouseCoord;
    private Point _startWordLocation;
    private Point _endWordLocation;
    public string _toolTipWord;

    public TooltipUserControl()
    {
      InitializeComponent();
    }

    #region Всплывающая подсказка внутри RichTextBox

    public TooltipUserControl(RichTextBoxCustom rtb)
    {
      InitializeComponent();
      _rtb = rtb;
      _rtb.MouseMove += RichTextBox_MouseMove;
      _rtb.MouseLeave += RichTextBox_MouseLeave;
      timerShowToolTip.Interval = 300;
      timerShowToolTip.Tick += timer_tick;
      this.Parent = _rtb;
      this.BringToFront();
    }

    private void RichTextBox_MouseLeave(object sender, EventArgs e)
    {
      timerShowToolTip.Stop();
      this.HideTooltip();
    }

    private void timer_tick(object sender, EventArgs e)
    {
      timerShowToolTip.Stop();
      ShowToolTip();
    }

    private void RichTextBox_MouseMove(object sender, MouseEventArgs e)
    {
      //Point startWordLocationBefore = _startWordLocation;
      _toolTipWord = GetWordFromCharIndex(e.Location, ref _startWordLocation, ref _endWordLocation);
      if (_lastMouseCoord != e.Location)
      {
        //restart tooltip timer
        CancelToolTip();
        timerShowToolTip.Start();
      }
      _lastMouseCoord = e.Location;
    }

    private string GetWordFromCharIndex(Point location, ref Point startWordLocation, ref Point endWordLocation)
    {
      string word = null;
      try
      {
        int mousePointerCharIndex = _rtb.GetCharIndexFromPosition(location);

        //int mousePointerLine = richText.GetLineFromCharIndex(mousePointerCharIndex);
        //int firstCharIndexInMousePointerLine = richText.GetFirstCharIndexFromLine(mousePointerLine);
        //int firstCharIndexInNextLine = richText.GetFirstCharIndexFromLine(mousePointerLine + 1);
        //if (firstCharIndexInNextLine < 0)
        //{
        //  firstCharIndexInNextLine = richText.Text.Length;
        //}
        //int hotTextStartIndex = richText.Find(
        //    "http://1", firstCharIndexInMousePointerLine, firstCharIndexInNextLine, RichTextBoxFinds.NoHighlight);

        int startWord = mousePointerCharIndex;
        // Символы определения начала или окончания слова
        //char[] startOrEndWordChars = new char[] { ' ', '\n', '*', '(', ')', '.', ',', '"', '[',']','?','!','$','%','^' };
        //bool cicle = false;
        while (startWord > 0)
        {
          startWord--;
          string s = _rtb.Text.Substring(startWord, 1);
          if (s.IndexOfAny(StartOrEndWordChars) >= 0)
          {
            startWord += 1;
            break;
          }
        }
        int endWord = mousePointerCharIndex;
        //bool cicle = false;
        while (endWord < _rtb.Text.Length)
        {
          string s = _rtb.Text.Substring(endWord, 1);
          if (s.IndexOfAny(StartOrEndWordChars) >= 0)
          {
            break;
          }
          endWord++;
        }
        word = _rtb.Text.Substring(startWord, endWord - startWord);
        while (word.EndsWith("."))
        {
          word = word.Remove(word.Length - 1);
          endWord--;
        }
        startWordLocation = _rtb.GetPositionFromCharIndex(startWord);
        endWordLocation = _rtb.GetPositionFromCharIndex(endWord);
      }
      catch (Exception) { }
      return word;
    }

    private void CancelToolTip()
    {
      timerShowToolTip.Stop();
      this.HideTooltip();
    }

    private void ShowToolTip()
    {
      //Проверка, что курсор находится не за пределами слова и не ниже последней строки
      bool cursorInWordContains = (_lastMouseCoord.X >= _startWordLocation.X && _lastMouseCoord.X <= _endWordLocation.X);
      //(Application.OpenForms[0] as MainForm).Text = string.Format("_lastMouseCoord.X >= _startWordLocation.X && _lastMouseCoord.X <= _endWordLocation.X: {0}>={1} && {2}<={3}"
      //  , _lastMouseCoord.X, _startWordLocation.X, _lastMouseCoord.X, _endWordLocation.X);
      if (!cursorInWordContains/* || IsMousePosOutOfLastLine()*/)
      {
        this.HideTooltip();
        return;
      }

      DictionaryInfo wordDefinition = Dictionary.GetByTitle(Convert.ToInt32((Application.OpenForms[0] as MainForm).GetCurrentQuestionId().ToString()), _toolTipWord);
      if (wordDefinition != null)
      {
        this.Title = _toolTipWord;
        this.Description = wordDefinition.Description;
        this.Url = wordDefinition.Url;
        this.Footer = string.Empty;
        if (!string.IsNullOrEmpty(wordDefinition.Url))
        {
          MainForm mf = Application.OpenForms[0] as MainForm;
          if (MainForm.IdContentUrlRegEx_v1.IsMatch(wordDefinition.Url))
          {
            if (mf.GetCurrentQuestionId().ToString() != wordDefinition.Url.Substring(7))
              this.Footer = "Нажмите Ctrl+LeftMouse для быстрого перехода на вопрос";
          }
          else
          if (MainForm.IdContentUrlRegEx_v2.IsMatch(wordDefinition.Url))
          {
            if (mf.GetCurrentQuestionId().ToString() != wordDefinition.Url.Substring(2))
              this.Footer = "Нажмите Ctrl+LeftMouse для быстрого перехода на вопрос";
          }
          else
            this.Footer = "Нажмите Ctrl+LeftMouse для открытия страницы в браузере";
        }
        int xPosition = _lastMouseCoord.X + 5;
        if (xPosition + lblDescription.MaximumSize.Width > _rtb.Width)
          xPosition = xPosition - lblDescription.MaximumSize.Width;
        if (xPosition < 0)
          xPosition = 0;

        int yPosition = _lastMouseCoord.Y + 5;
        if (yPosition + this.Height > _rtb.Height)
          yPosition = yPosition - this.Height;
        if (yPosition < 0)
          yPosition = 0;

          this.Location = new Point(xPosition, yPosition);
        this.ShowTooltip();
      }
    }

    #endregion Всплывающая подсказка внутри RichTextBox

    /// <summary>
    /// Gets or sets a specified dictionary to use with the specified RichTextBox control.
    /// </summary>
    public eDictionary Dictionary
    {
      get { return _dict; }
      set { _dict = value; }
    }

    public string Title
    {
      get { return lblHeader.Text; }
      set { lblHeader.Text = value; }
    }
    public string Description
    {
      get { return lblDescription.Text; }
      set { lblDescription.Text = value; }
    }

    public string Footer
    {
      get { return lblFooter.Text; }
      set { lblFooter.Text = value; }
    }
    public string Url { get; set; }
    public RichTextBox RichTextBox { get { return _rtb; } }
    public Color TitleForeColor { get { return lblHeader.ForeColor; } set { lblHeader.ForeColor = value; } }
    public Font TitleFont { get { return lblHeader.Font; } set { lblHeader.Font = value; } }
    public Color DescriptionForeColor { get { return lblDescription.ForeColor; } set { lblDescription.ForeColor = value; } }
    public Font DescriptionFont { get { return lblDescription.Font; } set { lblDescription.Font = value; } }
    public Label TitleLabel { get { return lblHeader; } }
    public Label DescriptionLabel { get { return lblDescription; } }
    public Label FooterLabel { get { return lblFooter; } }

    public void ShowTooltip()
    {
      tableLayoutPanel1.RowStyles[2].Height = 25;
      if (string.IsNullOrEmpty(lblFooter.Text))
        tableLayoutPanel1.RowStyles[2].Height = 5;
      this.Show();
    }

    public void HideTooltip()
    {
      this.Hide();
    }

    private struct CompoundedPos
    {
      public Point StartPos;
      public Point EndPos;
    };

    private CompoundedPos GetLastLinePos()
    {
      Point p = new Point(0, 0);
      int ln = _rtb.Lines.Length - 1;
      var cp = _rtb.GetPositionFromCharIndex(_rtb.GetFirstCharIndexFromLine(ln));

      return new CompoundedPos()
      {
        StartPos = cp,
        EndPos = cp
        //new Point(cp.X + referencedRTB.Lines[ln - 1].Length * referencedRTB.Font.Height, cp.Y) 
      };
    }
    private bool IsMousePosOutOfLastLine()
    {
      var xp = GetLastLinePos();
      //MessageBox.Show(xp.StartPos.ToString());
      var vp = xp.StartPos.Y + _rtb.Font.Height;

      return _rtb.PointToClient(Control.MousePosition).Y > vp;
    }
  }
}
