using System;
using System.Collections.Generic;
using System.Text;

namespace FAQ_Net
{
  internal class Constants
  {
    public class Location
    {
      public const string X = "X";
      public const string Y = "Y";
      public const string Width = "Width";
      public const string Height = "Height";
      public const string Maximized = "Maximized";
    }

    public const string id_content = "id_content";
    public const string LAST_VIEW = "last_view";
    public const string LAST_SORTING = "last_sorting";
    public const string MAIN_SPLITTER_DISTANCE = "MainSplitterDistance";
    public const string SAVE_SECTION_NODE_SELECT = "SaveSectionNodeSelect";

    public const string PUBLIC_DICTIONARY_CATEGORY = "Общая (подсказка отображается во всех вопросах)";
    public const string PRIVATE_DICTIONARY_CATEGORY = "Одиночная (подсказка отображается в одном, текущем, вопросе)";

    public const string TOOLTIPTYPE_0__DB_QUESTION = "Ссылка на вопрос";
    public const string TOOLTIPTYPE_1_INTERNET_QUESTION = "Ссылка в Интернет";
    public const string TOOLTIPTYPE_2_STATIC_TEXT = "Статический текст";

    public const string WithoutGroup = "Без группы";
    public static bool CtrlSpaceEntered = false;
    public const string ICONS_DIR_NAME = "IconsDirName";
    public static string RtfToolStripName;
    public const string RTF_COMBOBOX_CONTROLS_REPLACE_TO_MENU = "ReplaceComboboxRtfControlsToMenu";
  }
}
