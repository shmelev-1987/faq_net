using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FAQ_Net
{
  public partial class AppSettingsForm : Form
  {
    private CustomDesignControl[] _controls;
    //private object[] _controlsBeforeChange;
    private PropertyGridEx.PropertyGridEx _propertyGridEx;
    private const string BACK_COLOR_PROP_NAME = "Цвет фона";
    private const string HEADER_STYLE_BACK_COLOR_PROP_NAME = "Цвет заголовка";
    private const string HEADER_STYLE_FONT_PROP_NAME = "Шрифт заголовка";
    private const string CELL_FONT_PROP_NAME = "Шрифт ячеек";
    private const string FONT_PROP_NAME = "Шрифт";
    private const string CATEGORY_DESIGN_VIEW = "Внешний вид";

    public AppSettingsForm(CustomDesignControl[] customDesignControls)
    {
      InitializeComponent();

      MainForm._settingsXml.LoadFormPosition(this);

      // Создать компонент с расширенными свойствами
      _propertyGridEx = new PropertyGridEx.PropertyGridEx();
      _propertyGridEx.ShowCustomProperties = true;
      _propertyGridEx.Dock = DockStyle.Fill;
      _propertyGridEx.Parent = this;
      _propertyGridEx.BringToFront();
      _propertyGridEx.PropertyValueChanged += _propertyGridEx_PropertyValueChanged;

      _controls = customDesignControls;

      foreach (CustomDesignControl cntrl in customDesignControls)
      {
        TreeNode addedTreeNode = null;
        if (cntrl.Description != null)
          addedTreeNode = tvSettings.Nodes.Add(cntrl.Description);
        else
          addedTreeNode = tvSettings.Nodes.Add(cntrl.SettingId);

        // Загрузить пользовательские настройки
        tvSettings.SelectedNode = addedTreeNode;
        ParseProperty(ParseType.LoadFromFile);
      }
    }

    private void _propertyGridEx_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      if (tvSettings.SelectedNode != null)
      {
        try
        {
          Control control = (Control)_controls[tvSettings.SelectedNode.Index].ObjectControl;
          foreach (PropertyGridEx.CustomProperty prop in _propertyGridEx.Item)
          {
            switch (prop.Name)
            {
              case BACK_COLOR_PROP_NAME:
                if (control is DataGridView)
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    (control as DataGridView).BackgroundColor = (Color)prop.Value;
                }
                else
                if (control is TabControl)
                {
                  TabControl tc = control as TabControl;
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  {
                    foreach(TabPage tp in tc.TabPages)
                      tp.BackColor = (Color)prop.Value;
                  }
                }
                else
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    control.BackColor = (Color)prop.Value;
                }
                break;
              case HEADER_STYLE_BACK_COLOR_PROP_NAME:
                if (control is DataGridView)
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    (control as DataGridView).ColumnHeadersDefaultCellStyle.BackColor = (Color)prop.Value;
                }
                break;
              case HEADER_STYLE_FONT_PROP_NAME:
                if (control is DataGridView)
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    (control as DataGridView).ColumnHeadersDefaultCellStyle.Font = (Font)prop.Value;
                }
                break;
              case CELL_FONT_PROP_NAME:
                if (control is DataGridView)
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    (control as DataGridView).DefaultCellStyle.Font = (Font)prop.Value;
                }
                break;
              case FONT_PROP_NAME:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  control.Font = (Font)prop.Value;
                break;
                //case HEADER_BACK_COLOR_PROP_NAME:
                //  if (control is DataGridView)
                //  {
                //    if (prop.Value != null && prop.Value.ToString() != string.Empty)
                //      (control as DataGridView).ColumnHeadersDefaultCellStyle.BackColor = (Color)prop.Value;
                //  }
                //  break;
            }
          }
          tsbSave.Enabled = true;
          tsbCancel.Enabled = true;
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void SaveDesignSettings()
    {
      MainForm mf = Application.OpenForms[0] as MainForm;
      MainApp.WaitForm.Show(this);
      mf.SetStatusLabel("Сохранение настроек внешнего вида");
      this.Invoke((MethodInvoker)delegate
      {
        RefreshPropertiesForControlsBeforeChange(true);
        tsbSave.Enabled = false;
        tsbCancel.Enabled = false;
      });
      mf.SetStatusLabel("Настройки внешнего вида успешно сохранены");
      MainApp.WaitForm.Close();
    }

    private void tsbSave_Click(object sender, EventArgs e)
    {
      System.Threading.Thread th = new System.Threading.Thread(SaveDesignSettings);
      th.Start();
    }

    enum ParseType
    {
      SaveToFile,
      LoadFromFile,
      LoadFromControl
    }

    private void ParseProperty(ParseType parseType)
    {
      //_propertyGridEx.SelectedObject = _controls[0]
      CustomDesignControl customDesignControl = (CustomDesignControl)_controls[tvSettings.SelectedNode.Index];
      Control cntrl = (Control)_controls[tvSettings.SelectedNode.Index].ObjectControl;
      PropertyInfo[] properties = cntrl.GetType().GetProperties();
      if (parseType == ParseType.LoadFromControl)
        _propertyGridEx.Item.Clear();
      foreach (PropertyInfo pi in properties)
      {
        switch (pi.Name)
        {
          case "Font":
            if (cntrl is DataGridView)
              continue;
            if (cntrl is ToolStrip)
              continue;
            if (cntrl is RichTextBox)
              continue;
            cntrl.Font = ParseFontDesignSetting(parseType, cntrl, FONT_PROP_NAME, cntrl.Font, customDesignControl.SettingId);
            break;
          case "BackColor":
            if (cntrl is DataGridView)
              continue;
            if (cntrl is TabControl)
            {
              foreach(TabPage tp in (((TabControl)cntrl).TabPages))
                //tp.BackColor = ParseColorDesignSetting(parseType, (TabControl)cntrl, BACK_COLOR_PROP_NAME, cntrl.BackColor);
                tp.BackColor = ParseColorDesignSetting(parseType, (TabControl)cntrl, BACK_COLOR_PROP_NAME, tp.BackColor, customDesignControl.SettingId);
              continue;
            }
            cntrl.BackColor = ParseColorDesignSetting(parseType, cntrl, BACK_COLOR_PROP_NAME, cntrl.BackColor, customDesignControl.SettingId);
            break;
          case "BackgroundColor":
            if (cntrl is DataGridView)
            {
              ((DataGridView)cntrl).BackgroundColor = ParseColorDesignSetting(parseType, cntrl, BACK_COLOR_PROP_NAME, ((DataGridView)cntrl).BackgroundColor, customDesignControl.SettingId);
            }
            break;
          case "ColumnHeadersDefaultCellStyle":
            if (cntrl is DataGridView)
            {
              ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.BackColor = ParseColorDesignSetting(parseType, cntrl, HEADER_STYLE_BACK_COLOR_PROP_NAME, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.BackColor, customDesignControl.SettingId);
              ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.Font = ParseFontDesignSetting(parseType, cntrl, HEADER_STYLE_FONT_PROP_NAME, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.Font, customDesignControl.SettingId);
              ((DataGridView)cntrl).DefaultCellStyle.Font = ParseFontDesignSetting(parseType, cntrl, CELL_FONT_PROP_NAME, ((DataGridView)cntrl).DefaultCellStyle.Font, customDesignControl.SettingId);
            }
            break;
            //default:
            //  _propertyGridEx.Item.Add(pi.Name, string.Empty, false, pi.PropertyType.Name, string.Empty, true);
            //  break;
        }
      }
      if (parseType == ParseType.LoadFromControl)
        _propertyGridEx.Refresh();
    }

    private void SaveDesignSetting(Control cntrl, string value)
    {
      MainForm._settingsXml.SetSetting(string.Format("{0}_{1}", cntrl.Tag.ToString(), BACK_COLOR_PROP_NAME), value);
    }

    private Font ParseFontDesignSetting(ParseType parseType, Control cntrl, string customPropertyName, Font fontValue, string settingId)
    {
      var cvt = new FontConverter();
      Font resultFont = fontValue;
      if (parseType == ParseType.SaveToFile)
      {
        string fontString = cvt.ConvertToString(fontValue);
        MainForm._settingsXml.SetSetting(string.Format("{0}_{1}", settingId, customPropertyName), fontString);
      }
      else
      if (parseType == ParseType.LoadFromFile)
      {
        //string s = cvt.ConvertToString(this.Font);
        string str = MainForm._settingsXml.GetSetting(string.Format("{0}_{1}", settingId, customPropertyName));
        if (!string.IsNullOrEmpty(str))
          resultFont = cvt.ConvertFromString(str) as Font;
      }
      else
      if (parseType == ParseType.LoadFromControl)
      {

        if (cntrl is DataGridView)
        {
          switch (customPropertyName)
          {
            case HEADER_STYLE_FONT_PROP_NAME:
              _propertyGridEx.Item.Add(customPropertyName, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.Font, false, CATEGORY_DESIGN_VIEW, customPropertyName, true);
              break;
            case CELL_FONT_PROP_NAME:
              _propertyGridEx.Item.Add(customPropertyName, ((DataGridView)cntrl).DefaultCellStyle.Font, false, CATEGORY_DESIGN_VIEW, customPropertyName, true);
              break;
            default:
              _propertyGridEx.Item.Add(customPropertyName, null, false, CATEGORY_DESIGN_VIEW, customPropertyName, true);
              break;
          }
        }
        else
          //_propertyGridEx.Item.Add("Имя свойства", "Значение по-умолчанию", readOnly, "Категория", "Описание", visible);
          _propertyGridEx.Item.Add(customPropertyName, cntrl.Font, false, CATEGORY_DESIGN_VIEW, customPropertyName, true);
      }
      return resultFont;
    }

    private Color ParseColorDesignSetting(ParseType parseType, Control cntrl, string customPropertyName, Color colorValue, string settingId)
    {
      Color resultColor = colorValue;
      if (parseType == ParseType.SaveToFile)
        MainForm._settingsXml.SetSetting(string.Format("{0}_{1}", settingId, customPropertyName), colorValue.ToArgb().ToString());
      else
      if (parseType == ParseType.LoadFromFile)
      {
        string str = MainForm._settingsXml.GetSetting(string.Format("{0}_{1}", settingId, customPropertyName));
        if (!string.IsNullOrEmpty(str))
          resultColor = (Color.FromArgb(Convert.ToInt32(str)));
      }
      else
      if (parseType == ParseType.LoadFromControl)
      {
        if (cntrl is TabControl)
        {
          AddPropertyIfNotExists(cntrl, customPropertyName, ((TabControl)cntrl).TabPages[0].BackColor, CATEGORY_DESIGN_VIEW);
        }
        else
        if (cntrl is DataGridView)
        {
          switch (customPropertyName)
          {
            case BACK_COLOR_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((DataGridView)cntrl).BackgroundColor, CATEGORY_DESIGN_VIEW);
              break;
            case HEADER_STYLE_BACK_COLOR_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.BackColor, CATEGORY_DESIGN_VIEW);
              break;
            default:
              AddPropertyIfNotExists(cntrl, customPropertyName, null, CATEGORY_DESIGN_VIEW);
              break;
          }
        }
        else
          //_propertyGridEx.Item.Add("Имя свойства", "Значение по-умолчанию", readOnly, "Категория", "Описание", visible);
          AddPropertyIfNotExists(cntrl, customPropertyName, cntrl.BackColor, CATEGORY_DESIGN_VIEW);
      }
      return resultColor;
    }

    private void AddPropertyIfNotExists(Control cntrl, string customPropertyName, object value, string categoryName)
    {
      bool find = false;
      foreach (PropertyGridEx.CustomProperty prop in _propertyGridEx.Item)
      {
        if (prop.Name == customPropertyName)
        {
          find = true;
          break;
        }
      }
      if (!find)
        _propertyGridEx.Item.Add(customPropertyName, value, false, categoryName, customPropertyName, true);
    }

    private void tvSettings_AfterSelect(object sender, TreeViewEventArgs e)
    {
      ParseProperty(ParseType.LoadFromControl);
    }

    private void tsbCancel_Click(object sender, EventArgs e)
    {
      // Вернуть свойства компонента из его старой копии не получается (см.комментарии ниже),
      // поэтому используется перезагрузка приложения
      if (MessageBox.Show("Для отмены изменений требуется перезагрузка приложения. Перезапустить приложение?"
        , "Перезапустить приложение?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        Application.Restart();
        if (!MainForm.RestartApplicationCanceled)
          Application.ExitThread();
      }

      // Некоторые свойства компонентов по непонятным причинам не копируются в отдельный объект, а лишь ссылаются на это свойство
      // соответственно, при смене значения свойства изменения происходят не только в объекте-источнике, но и в объекте-назначения
      // например: у компонента DataGridView не копируется свойство DefaultCellStyle.Font
      // В связи с этим код закомментирован и неиспользуется, пока не найдется решение.
      //for (int i = 0; i < _controlsBeforeChange.Length; i++)
      //{
      //  PropertyInfo[] properties = null;
      //  properties = _controlsBeforeChange[i].GetType().GetProperties();
      //  if (_controlsBeforeChange[i] is DataGridView)
      //    properties = ((DataGridView)_controlsBeforeChange[i]).GetType().GetProperties();

      //  foreach (var propInfo in properties)
      //  {
      //    bool canSetValue = true;
      //    if (propInfo.CanWrite)
      //    {
      //      if (propInfo.Name == "Parent")
      //        continue;
      //      if (propInfo.Name == "Visible")
      //        continue;
      //      if (propInfo.Name == "WindowTarget")
      //        continue;
      //      if (propInfo.DeclaringType.FullName == "System.Windows.Forms.DataGridView")
      //      {
      //        if (propInfo.Name != "BackgroundColor"
      //         || propInfo.Name != "BackColor"
      //         || propInfo.Name != "DefaultCellStyle"
      //         || propInfo.Name != "Font")
      //          canSetValue = false;
      //      }
      //      if (canSetValue)
      //        propInfo.SetValue(_controls[i], propInfo.GetValue(_controlsBeforeChange[i], null), null);
      //    }
      //  }
      //}
      //tvSettings_AfterSelect(sender, null);
    }

    private void AppSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      MainForm._settingsXml.SaveFormPosition(this);
      e.Cancel = true;
      this.Hide();
    }

    private void AppSettingsForm_Shown(object sender, EventArgs e)
    {
      RefreshPropertiesForControlsBeforeChange(false);
    }

    private void RefreshPropertiesForControlsBeforeChange(bool saveChangesToFile)
    {
      //_controlsBeforeChange = new object[_controls.Length];

      for (int i = 0; i < _controls.Length; i++)
      {
        //if (_controls[i] is DataGridView)
        //{
        //  _controlsBeforeChange[i] = new DataGridView();
        //  _controlsBeforeChange[i] = ControlExtensions.CloneDataGridView((DataGridView)_controls[i]);
        //}
        //else
        //{
        //  _controlsBeforeChange[i] = new Control();
        //  _controlsBeforeChange[i] = ControlExtensions.Clone((Control)_controls[i]);
        //}
        if (saveChangesToFile)
        {
          this.Invoke((MethodInvoker)delegate
          {
            tvSettings.SelectedNode = tvSettings.Nodes[i];
            ParseProperty(ParseType.SaveToFile);
          });
        }
      }
    }
  }
}

