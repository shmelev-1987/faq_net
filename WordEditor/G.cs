﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace FAQ_Net
{
  class G
  {
    //#region Ограничение времени работы с приложением
    //public static DateTime ExecTime = DateTime.Now;
    //private static int minutes = 2;
    //public static void CheckTime()
    //{
    //    if (((TimeSpan)(DateTime.Now - ExecTime)).Minutes >= minutes)
    //    {
    //        MessageBox.Show("Время работы в приложении привысило " + minutes.ToString() + " минуты", "Ограничение работы", MessageBoxButtons.OK, MessageBoxIcon.Stop);
    //        //System.Diagnostics.Process.GetCurrentProcess().Kill();
    //        Application.Exit();
    //    }
    //}
    //#endregion Ограничение времени работы с приложением

    public static string CurDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);    //Текущий каталог приложения
    private static SQLiteConnection SQLiteConn = new SQLiteConnection(); //Строка соединения SQLite
    private static SQLiteDataReader SQLite_DR;
    public static System.Data.DataTable DT;
    public static System.Text.RegularExpressions.Regex SelectRegex = new System.Text.RegularExpressions.Regex("(?i)^SELECT");  //(?i) - отключить чувствительность к регистру
    public static UTF8Encoding utf8 = new UTF8Encoding();
    public static string Question = "";
    public static int
        MaxIdCategory = 0,
        MaxIdVopros = 0;

    public static List<Question> QuestionList = new List<Question>();
    private static object _lockWrite = new object();

    public static string ConvertEncoding(string Str, int FromEncoding, int ToEncoding)
    {
      //MessageBox.Show(Encoding.UTF8.CodePage.ToString());
      var fromEncodind = Encoding.GetEncoding(FromEncoding);//из какой кодировки
      var bytes = fromEncodind.GetBytes(Str);
      var toEncoding = Encoding.GetEncoding(ToEncoding);//в какую кодировку
      return toEncoding.GetString(bytes);
    }

    /// <summary>
    /// Добавить запись в лог-файл (log.txt)
    /// </summary>
    /// <param name="operation">Наименование операции</param>
    /// <param name="result">Результат</param>
    public static void AddRowToLog(string operation, string result)
    {
      lock (_lockWrite)
      {
        string logsDir = Path.Combine(G.CurDir, "logs");
        if (!Directory.Exists(logsDir))
          Directory.CreateDirectory(logsDir);

        string logFileName = Path.Combine(logsDir, "log.txt");
        int maxLogSize = 204800;
        if (maxLogSize > 0)
        {
          if (!System.IO.File.Exists(logFileName))
            System.IO.File.Create(logFileName).Close();

          // Если файл больше макимального размера, то писать в новый файл.
          // Старый лог файл переименовывается
          FileInfo log = new FileInfo(logFileName);
          if (log.Length > maxLogSize)
          {
            using (StreamWriter logWriter = new StreamWriter(logFileName, true, Encoding.GetEncoding(65001)))
            {
              logWriter.Close();
              string logFileExt = Path.GetExtension(logFileName);
              string histFileName = string.Format("{0} {1:yyyy-MM-dd HH-mm-ss ff}{2}"
                , Path.Combine(Path.GetDirectoryName(logFileName), Path.GetFileNameWithoutExtension(logFileName))
                , DateTime.Now
                , logFileExt
                );
              try
              {
                File.Move(logFileName, histFileName);

                // Удалить старые логи, оставив последние 5 файлов
                DirectoryInfo dirInfo = new DirectoryInfo(logsDir);
                FileInfo[] logFileInfos = dirInfo.GetFiles("*" + logFileExt);
                const int MAX_COUNT_FILES_NOT_DELETED = 5;
                if (logFileInfos.Length > MAX_COUNT_FILES_NOT_DELETED)
                {
                  // Сортировка файлов по дате последнего изменения
                  Array.Sort(logFileInfos,
                      new Comparison<FileInfo>(delegate (FileInfo f, FileInfo f2)
                      {
                        return f.LastWriteTime.CompareTo(f2.LastWriteTime);
                      }));
                  // Удалить старые файлы
                  for (int i = 0; i < logFileInfos.Length - MAX_COUNT_FILES_NOT_DELETED; i++)
                  {
                    try
                    {
                      File.Delete(logFileInfos[i].FullName);
                    }
                    catch (Exception) { }
                  }
                }
              }
              catch (Exception) { }
            }
          }

        }
        try
        {
          using (System.IO.StreamWriter logWriter = new System.IO.StreamWriter(logFileName, true, Encoding.GetEncoding(65001)))
          {
            logWriter.WriteLine(string.Format("{0:dd.MM.yyyy HH:mm:ss}\t{1}\t{2}\t{3}\t{4}"
              , DateTime.Now, operation, result, Environment.MachineName, SystemInformation.UserName));
            logWriter.Close();
            logWriter.Dispose();
          }
        }
        catch (Exception) { }
      }
    }

    public static bool CreateBackup(Form parentForm, out string err)
    {
      err = string.Empty;
      bool result = false;
      MainApp.WaitForm.Show(parentForm);
      try
      {
        string NewFileDB = Path.Combine(G.CurDir, string.Format("FAQ_{0:yyyyMMdd_HH_mm}.sqlite", DateTime.Now));
        System.IO.File.Copy(Path.Combine(G.CurDir, "FAQ.sqlite"), NewFileDB, true);

        //System.Threading.Thread t = new System.Threading.Thread();
        SQLiteConnection SQLiteConnBackup = new SQLiteConnection();
        SQLiteConnBackup.ConnectionString = "Data Source=" + NewFileDB + ";Version=3;";

        SQLiteConnBackup.Open();
        SQLiteCommand c = new SQLiteCommand("VACUUM;", SQLiteConnBackup);
        c.ExecuteNonQuery();
        c.Dispose();
        SQLiteConnBackup.Close();
        SQLiteConnBackup.Dispose();
        MainApp.WaitForm.Close();
        G.Explorer.OpenFolderAndSelectFiles(G.CurDir, new string[] { NewFileDB });
        //OpenExplorerWithSelect(NewFileDB);
        result = true;
      }
      catch (Exception ex)
      {
        MainApp.WaitForm.Close();
        err = ex.Message;
        //MessageBox.Show("Ошибка создания резервной копии БД", ex.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
      }
      return result;
    }

    public static bool ExecSQLiteQuery(string SqlQuery)
    {
      string dbFileName = Path.Combine(G.CurDir, "FAQ.sqlite");
      if (File.Exists(dbFileName))
      {
        //CheckTime();
        try
        {
          if (SQLiteConn.State == System.Data.ConnectionState.Closed)
          {
            try
            {
              SQLiteConn.ConnectionString = string.Format("Data Source={0};Version=3;", dbFileName);
              SQLiteConn.Open();
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              AddRowToLog("Соединение с файлом БД 'FAQ.sqlite'", ex.Message);
              return false;
            }
          }
          System.Data.SQLite.SQLiteCommand SQLiteCom =
              new System.Data.SQLite.SQLiteCommand(SqlQuery, SQLiteConn);
          SQLiteCom.CommandTimeout = 0;                        //выполнять запрос, пока не выполнится
          if (SelectRegex.IsMatch(SqlQuery.TrimStart()))
          {
            DT = new System.Data.DataTable();
            SQLite_DR = SQLiteCom.ExecuteReader();
            DT.Load(SQLite_DR);
            SQLite_DR.Close();
            //Question = "";
            //foreach (System.Data.DataColumn col in DT.Columns)
            //{
            //    if (col.DataType.Name == "String")
            //    {
            //        foreach (System.Data.DataRow row in DT.Rows)
            //        {
            //            row[col.ColumnName] = G.ConvertEncoding(row[col.ColumnName].ToString(), 20127, 65001);
            //        }
            //    }
            //}
          }
          else
          {
            SQLiteCom.ExecuteNonQuery();
          }
          SQLiteCom.Dispose();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          AddRowToLog("ExecSQLiteQuery: " + SqlQuery, ex.Message);
          return false;
        }
        return true;
      }
      else
      {
        MessageBox.Show("Файла БД не существует.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Application.Exit();
        return false;
      }
    }

    #region Процедура выполнения запроса Select c выводом результата в ComboBox

    #region Описание класса ListItems
    public class ListItems
    {
      private string myShortName;
      private string myLongName;

      public ListItems(string Text, string Value)
      {
        this.myShortName = Value;
        this.myLongName = Text;
      }

      public string ShortName
      {
        get
        {
          return myShortName;
        }
      }

      public string LongName
      {

        get
        {
          return myLongName;
        }
      }

      public override string ToString()
      {
        return this.ShortName;
      }
    }
    #endregion Описание класса ListItems

    public static bool SelectToComboBox(string SqlQuery, ComboBox CmbBox, string IDColumnName, string TextColumnName)
    {
      try
      {
        //Вывести данные таблицы
        ExecSQLiteQuery(SqlQuery);
        System.Collections.ArrayList ItemsArray = new System.Collections.ArrayList();
        foreach (System.Data.DataRow row in DT.Rows)
        {
          ItemsArray.Add(new ListItems(row[TextColumnName].ToString(), row[IDColumnName].ToString()));
        }
        CmbBox.DataSource = ItemsArray;
        CmbBox.DisplayMember = "LongName";
        CmbBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        CmbBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        return true;
      }
      catch (System.Exception ex)
      {
        MessageBox.Show("SQL-скрипт: " + SqlQuery + "\n\nОшибка: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        AddRowToLog(SqlQuery, ex.Message);
        return false;
      }
    }
    #endregion Процедура выполнения запроса Select c выводом результата в ComboBox

    //private static int GetCountNodesFromText(string TN_Text)
    //{
    //  try
    //  {
    //    TN_Text = TN_Text.Substring(TN_Text.LastIndexOf("(") + 1);
    //    return Convert.ToInt32(TN_Text.Remove(TN_Text.Length - 1));
    //  }
    //  catch (Exception)
    //  {
    //    return 0;
    //  }
    //}

    #region Процедура заполнения разделов
    public static void GetTreeNodes(TreeView TV, TreeNode TN, bool reloadTreeNode, bool onlyAddQuestions = false
      , string sortedColumnName = "question", string sort = "ASC")
    {
      const string ID_CATEGORY = "id_category";
      const string NAME_CATEGORY = "name_category";
      const string COUNT_CHILD = "count_child";
      const string NULL = "null";
      if (TN == null)
      {
        TV.Nodes.Clear();
        //Вывод корневых узлов
        ExecSQLiteQuery(Sql.SqlQueries.SelectRootCategories);
        foreach (System.Data.DataRow row in DT.Rows)
        {
          TN = TV.Nodes.Add(row[ID_CATEGORY].ToString(), row[NAME_CATEGORY].ToString());
          TN.Tag = row[COUNT_CHILD].ToString();
          if ((long)row[COUNT_CHILD] != 0)
            TN.Nodes.Add(NULL, NULL);   //Пустой узел, для возможности развертывания
        }
      }
      else
      {
        if (onlyAddQuestions)
        {
          return;
        }
        //Перезагрузить узел
        if (reloadTreeNode)
        {
          //Для обновления узла удаляем все дочерние узлы для срабатывания следующего условия (TN.Nodes.Count == 0)
          while (TN.Nodes.Count > 0)
            TN.Nodes.RemoveAt(0);
        }
        if (TN.Nodes.Count == 0 ||
            (TN.Nodes.Count == 1 && TN.Nodes[0].Name == NULL))
        {
          // Добавление подразделов
          ExecSQLiteQuery(string.Format(Sql.SqlQueries.SelectSubCategories
            , TN.Name.Replace("'", "''")));
          foreach (System.Data.DataRow row in DT.Rows)
          {
            //Добавляем дочерний узел
            TreeNode TNChild = TN.Nodes.Add(row[ID_CATEGORY].ToString(), row[NAME_CATEGORY].ToString());
            TNChild.Tag = row[COUNT_CHILD].ToString();
            if ((long)row[COUNT_CHILD] != 0)
              TNChild.Nodes.Add(NULL, NULL);   //Пустой дочерний узел, для возможности развертывания
          }
          TN.Tag = DT.Rows.Count.ToString();
        }
      }
    }
    #endregion Процедура заполнения разделов

    #region Добавление раздела
    public static void CreateCategory(TreeView TV, TreeNode TN)
    {
      if (MaxIdCategory == 0)
      {
        G.ExecSQLiteQuery("SELECT MAX(id_category)+1 FROM category WHERE id_category IS NOT NULL");
        if (G.DT.Rows.Count == 1 &&
            G.DT.Rows[0][0].ToString() != "")
          MaxIdCategory = Convert.ToInt32(G.DT.Rows[0][0].ToString());
        else
          MaxIdCategory = 1;
      }
      string
          CategoryName = "",
          SqlQuery = "INSERT INTO category (id_category, name_category, parent_category, count_child) VALUES ({0},'{1}',{2},{3})";
      if (TN == null)
      {
        #region Создание раздела
        if (G.InputBox("Создание раздела", "Наименование раздела", ref CategoryName) == DialogResult.OK)
        {
          //CategoryName = G.ConvertEncoding(CategoryName, Encoding.UTF8.CodePage, 1251);
          SqlQuery = String.Format(SqlQuery,
              MaxIdCategory.ToString(),           //id_category
              CategoryName.Replace("'", "''"),    //name_category
              "null",                             //parent_category
              "0");
          if (G.ExecSQLiteQuery(SqlQuery))
          {
            //CategoryName = G.ConvertEncoding(CategoryName, 20127, 65001);
            TV.Nodes.Add(MaxIdCategory.ToString(), CategoryName).Tag = "0";
            MaxIdCategory += 1;
          }
        }
        #endregion Создание раздела
      }
      else
      #region Создание подраздела
                if (G.InputBox("Создание подраздела для раздела '" + TN.Text + "'", "Наименование подраздела", ref CategoryName) == DialogResult.OK)
      {
        //CategoryName = G.ConvertEncoding(CategoryName, 65001, 20127);
        SqlQuery = String.Format(SqlQuery,
            MaxIdCategory.ToString(),           //id_category
            CategoryName.Replace("'", "''"),    //name_category
            TN.Name,                            //parent_category
            "0");
        if (G.ExecSQLiteQuery(SqlQuery))
        {
          //CategoryName = G.ConvertEncoding(CategoryName, 20127, 65001);
          TN.Nodes.Add(MaxIdCategory.ToString(), CategoryName).Tag = "0";
          TN.Tag = (Convert.ToInt32(TN.Tag) + 1).ToString();
          //TN.Text = TN.Text;
          G.ExecSQLiteQuery("UPDATE category SET count_child=count_child+1 WHERE id_category=" + TN.Name);
          MaxIdCategory += 1;
        }
      }
      #endregion Создание подраздела
    }
    #endregion Добавление раздела

    #region Диалоговое окно InputBox
    public static DialogResult InputBox(string title, string promptText, ref string value)
    {
      Form form = new Form();
      Label label = new Label() { Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular) };
      TextBox textBox = new TextBox() { Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular) };
      PulseButton.PulseButton buttonOk = new PulseButton.PulseButton() { Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular) };
      PulseButton.PulseButton buttonCancel = new PulseButton.PulseButton() { Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular) };
      buttonOk.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      buttonOk.BackColor = System.Drawing.SystemColors.Control;
      buttonOk.ButtonColorTop = System.Drawing.Color.GreenYellow;
      buttonOk.ButtonColorBottom = System.Drawing.Color.YellowGreen;
      buttonCancel.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
      buttonOk.PulseWidth = 1;
      buttonOk.CornerRadius = 5;
      buttonCancel.PulseWidth = 1;
      buttonCancel.ButtonColorTop = System.Drawing.Color.MistyRose;
      buttonCancel.ButtonColorBottom = System.Drawing.Color.LightCoral;
      buttonCancel.BackColor = System.Drawing.SystemColors.Control;
      buttonCancel.CornerRadius = 5;

      form.Text = title;
      label.Text = promptText;
      textBox.Text = value;

      buttonOk.Text = "OK";
      //buttonOk.Image = FAQ_Net.Properties.Resources.OK;
      buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      buttonCancel.Text = "Отмена";
      //buttonCancel.Image = FAQ_Net.Properties.Resources.No;
      buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      buttonOk.DialogResult = DialogResult.OK;
      buttonCancel.DialogResult = DialogResult.Cancel;

      label.SetBounds(5, 5, 510, 13);
      textBox.SetBounds(5, 35, 510, 20);
      buttonOk.SetBounds(170, 70, 80, 25);
      buttonCancel.SetBounds(280, 70, 80, 25);

      label.AutoSize = true;
      textBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
      buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

      form.ClientSize = new System.Drawing.Size(520, 100);
      form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
      //form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
      form.FormBorderStyle = FormBorderStyle.FixedDialog;
      form.StartPosition = FormStartPosition.CenterScreen;
      form.MinimizeBox = false;
      form.MaximizeBox = false;
      form.AcceptButton = buttonOk;
      form.CancelButton = buttonCancel;

      DialogResult dialogResult = form.ShowDialog();
      value = textBox.Text;
      return dialogResult;
    }
    #endregion Диалоговое окно InputBox

    #region Добавление вопросов в ListView

    public static void AddItemsIntoListView(ListView listView, bool isUseGlobalQuestionList)
    {
      listView.Items.Clear();
      if (isUseGlobalQuestionList)
      {
        foreach (Question question in G.QuestionList)
        {
          ListViewItem i = new ListViewItem(question.Text);
          i.Tag = question.IdContent;
          listView.Items.Add(i);
        }
        return;
      }
      foreach (Question q in G.QuestionList)
      {
        q.Dispose();
      }
      G.QuestionList.Clear();
      //LV.Columns.Clear();
      //LV.Columns.Add("Наименование вопроса").Width = -1;
      foreach (System.Data.DataRow r in G.DT.Rows)
      {
        DateTime? modifDate = null;
        if (!string.IsNullOrEmpty(r["modif_date"].ToString()))
          modifDate = Convert.ToDateTime(r["modif_date"]);
        Question question = new Question(Convert.ToInt32(r[Constants.id_content]), r["question"].ToString(), Convert.ToDateTime(r["create_date"].ToString()),
          modifDate);
        G.QuestionList.Add(question);
        ListViewItem i = new ListViewItem(question.Text);
        i.Tag = question.IdContent;
        listView.Items.Add(i);
      }
    }

    public static void AddItemsIntoListView(IViewQuestion control, bool isUseGlobalQuestionList)
    {
      control.ClearItems();
      if (isUseGlobalQuestionList)
      {
        foreach (Question question in G.QuestionList)
        {
          control.AddItem(question);
        }
        return;
      }
      foreach (Question q in G.QuestionList)
      {
        q.Dispose();
      }
      G.QuestionList.Clear();
      //LV.Columns.Clear();
      //LV.Columns.Add("Наименование вопроса").Width = -1;
      foreach (System.Data.DataRow r in G.DT.Rows)
      {
        DateTime? modifDate = null;
        if (!string.IsNullOrEmpty(r["modif_date"].ToString()))
          modifDate = Convert.ToDateTime(r["modif_date"]);
        Question question = new Question(Convert.ToInt32(r[Constants.id_content]), r["question"].ToString(), Convert.ToDateTime(r["create_date"].ToString()), modifDate);
        G.QuestionList.Add(question);
        //question
        //ListViewItem i = new ListViewItem(new string[] { r["question"].ToString(), createDate });
        //            i.Tag = r[Constants.id_content];
        control.AddItem(question);
      }
      //control.SizeColumnsToFit();
    }

    #endregion Добавление вопросов в ListView

    #region Запретить запуск второй копии приложения
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hwnd);
    public static void CancelRunSecondaryApp()
    {
      int CountProc = -1;  //Т.к. запущенный процесс, включается в поиск
      foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName(System.Windows.Forms.Application.ProductName))
      {
        try
        {
          if (System.IO.Path.GetDirectoryName(p.MainModule.FileName) == System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath))
          {
            CountProc += 1;
            SetForegroundWindow(p.MainWindowHandle);
          }
        }
        catch (Exception) { }
      }
      if (CountProc > 0)
      {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
        return;
      }
    }
    #endregion Запретить запуск второй копии приложения

    /// <summary>
    /// Открыть проводник с одним выделенным файлом
    /// </summary>
    /// <param name="fileName"></param>
    public static void OpenExplorerWithSelect(string fileName)
    {
      if (System.IO.File.Exists(fileName))
      {
        System.Diagnostics.Process.Start("explorer.exe", "/select," + fileName);
        return;
      }
      if (System.IO.Directory.Exists(fileName))
        System.Diagnostics.Process.Start("explorer.exe", fileName);
    }

    public class Explorer
    {
      [DllImport("shell32.dll", ExactSpelling = true)]
      public static extern int SHOpenFolderAndSelectItems(
        IntPtr pidlFolder,
        uint cidl,
        [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl,
        uint dwFlags);

      [DllImport("shell32.dll", CharSet = CharSet.Auto)]
      public static extern IntPtr ILCreateFromPath([MarshalAs(UnmanagedType.LPTStr)] string pszPath);

      [ComImport]
      [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
      [Guid("000214F9-0000-0000-C000-000000000046")]
      public interface IShellLinkW
      {
        [PreserveSig]
        int GetPath(StringBuilder pszFile, int cch, [In, Out] ref WIN32_FIND_DATAW pfd, uint fFlags);

        [PreserveSig]
        int GetIDList([Out] out IntPtr ppidl);

        [PreserveSig]
        int SetIDList([In] ref IntPtr pidl);

        [PreserveSig]
        int GetDescription(StringBuilder pszName, int cch);

        [PreserveSig]
        int SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

        [PreserveSig]
        int GetWorkingDirectory(StringBuilder pszDir, int cch);

        [PreserveSig]
        int SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);

        [PreserveSig]
        int GetArguments(StringBuilder pszArgs, int cch);

        [PreserveSig]
        int SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

        [PreserveSig]
        int GetHotkey([Out] out ushort pwHotkey);

        [PreserveSig]
        int SetHotkey(ushort wHotkey);

        [PreserveSig]
        int GetShowCmd([Out] out int piShowCmd);

        [PreserveSig]
        int SetShowCmd(int iShowCmd);

        [PreserveSig]
        int GetIconLocation(StringBuilder pszIconPath, int cch, [Out] out int piIcon);

        [PreserveSig]
        int SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

        [PreserveSig]
        int SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, uint dwReserved);

        [PreserveSig]
        int Resolve(IntPtr hwnd, uint fFlags);

        [PreserveSig]
        int SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
      }

      [Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode), BestFitMapping(false)]
      public struct WIN32_FIND_DATAW
      {
        public uint dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public uint dwReserved0;
        public uint dwReserved1;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;
      }

      /// <summary>
      /// Открыть папку в Проводнике с несколькими выделенными файлами
      /// </summary>
      /// <param name="folder">Имя каталога</param>
      /// <param name="filesToSelect">Полные имена файлов</param>
      public static void OpenFolderAndSelectFiles(string folder, params string[] filesToSelect)
      {
        IntPtr dir = ILCreateFromPath(folder);

        var filesToSelectIntPtrs = new IntPtr[filesToSelect.Length];
        for (int i = 0; i < filesToSelect.Length; i++)
        {
          filesToSelectIntPtrs[i] = ILCreateFromPath(filesToSelect[i]);
        }

        SHOpenFolderAndSelectItems(dir, (uint)filesToSelect.Length, filesToSelectIntPtrs, 0);
        ReleaseComObject(dir);
        ReleaseComObject(filesToSelectIntPtrs);
      }

      private static void ReleaseComObject(params object[] comObjs)
      {
        foreach (object obj in comObjs)
        {
          if (obj != null && Marshal.IsComObject(obj))
            Marshal.ReleaseComObject(obj);
        }
      }
    }
  }
}
