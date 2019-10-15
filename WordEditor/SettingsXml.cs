using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace FAQ_Net
{
    public class SettingsXml
    {
      #region Конструкторы / Constructors

      /// <summary>
      /// Конструктор класса SettingsXml
      /// </summary>
      public SettingsXml()
      {
        SettingsXmlDoc = new System.Xml.XmlDocument();

        // Файл настроек создается в каталоге, откуда запускается приложение
        _settingsXML = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" +
                             Application.ProductName + ".xml";
        LoadXml();
      }

      #endregion Конструкторы / Constructors

        #region Методы / Methods

      private string Encrypt(string keyValue)
      {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(keyValue));
      }

      private string Decrypt(string keyValue)
      {
        return Encoding.UTF8.GetString(Convert.FromBase64String(keyValue));
      }

        /// <summary>
        /// Получить строку из файла настроек
        /// </summary>
        /// <param name="KeyName">Имя параметра</param>
        /// <returns>Значение параметра</returns>
        public string GetSetting(string KeyName)
        {
            try
            {
                SettingsXmlDoc.Load(_settingsXML);
                return Decrypt(SettingsXmlDoc.SelectSingleNode("//root/SettingString[@KeyName='" + KeyName + "']").Attributes["KeyValue"].Value);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        ///// <summary>
        ///// Получить строку из файла настроек
        ///// </summary>
        ///// <param name="KeyName">Имя параметра</param>
        ///// <param name="FileName">Имя файла настроек</param>
        ///// <returns>Значение параметра</returns>
        //public string GetSettingFromFile(string KeyName, string FileName)
        //{
        //    try
        //    {
        //        System.Xml.XmlDocument XmlDoc = new System.Xml.XmlDocument();
        //        XmlDoc.Load(FileName);
        //        return Crypt.Decrypt(XmlDoc.SelectSingleNode("//root/SettingString[@KeyName='" + KeyName + "']").Attributes["KeyValue"].Value, _p);
        //    }
        //    catch (Exception)
        //    {
        //        return "";
        //    }
        //}

        public int GetSettingAsInt(string keyName, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(GetSetting(keyName));
            }
            catch (Exception) { }
            return defaultValue;
        }

        public bool GetSettingAsBool(string keyName, bool defaultValue)
        {
            try
            {
                return Convert.ToBoolean(GetSetting(keyName));
            }
            catch (Exception) { }
            return defaultValue;
        }

      private void LoadXml()
      {
        if (!System.IO.File.Exists(_settingsXML))
        {
          // Создать файл настроек
          SettingsXmlDoc.LoadXml("<root></root>");
          SettingsXmlDoc.Save(_settingsXML);
        }
        else
          SettingsXmlDoc.Load(_settingsXML);
      }

        /// <summary>
        /// Запись параметра в файл настроек
        /// </summary>
        /// <param name="KeyName">Имя параметра</param>
        /// <param name="KeyValue">Значение параметра</param>
        /// <returns></returns>
        public bool SetSetting(string KeyName, string KeyValue)
        {
            try
            {
              KeyValue = Encrypt(KeyValue);
                LoadXml();

                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXml(_settingsXML);
                if (ds.Tables.Count == 0 || ds.Tables[0].Select("KeyName='" + KeyName + "'").Length == 0)
                {
                    // Добавление параметра в файл, если его не существует
                    AddSettingToXml(KeyName, KeyValue);
                }
                else
                {
                    // Редактировать параметр в файле
                    SettingsXmlDoc.SelectSingleNode("//root/SettingString[@KeyName='" + KeyName + "']").Attributes["KeyValue"].Value = KeyValue;
                    SettingsXmlDoc.Save(_settingsXML);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Добавить строку в файл настроек
        /// </summary>
        /// <param name="KeyName">Наименование настройки</param>
        /// <param name="KeyValue">Значение настройки</param>
        /// <returns>True - успешная запись в файл настроек</returns>
        private bool AddSettingToXml(string KeyName, string KeyValue)
        {
            System.Xml.XmlElement El = SettingsXmlDoc.CreateElement("SettingString");
            El.SetAttribute("KeyName", KeyName);
            El.SetAttribute("KeyValue", KeyValue);
            El.SetAttribute("UserName", Environment.UserName);
            SettingsXmlDoc.DocumentElement.AppendChild(El);
            SettingsXmlDoc.Save(_settingsXML);
            return true;
        }

        ///// <summary>
        ///// Получить строку из файла настроек
        ///// </summary>
        ///// <param name="fileName">Имя файла</param>
        ///// <returns>Значение параметра</returns>
        //public bool SaveToFile(string fileName)
        //{
        //    try
        //    {
        //        SettingsXmlDoc.Save(fileName);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Не удалось сохранить файл настроек. "+ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Получить строку из файла настроек
        ///// </summary>
        ///// <param name="fileName">Имя файла</param>
        ///// <returns>Значение параметра</returns>
        //public bool LoadFromFile(string fileName)
        //{
        //    try
        //    {
        //        if (MessageBox.Show(
        //            "Внимание все настройки приложения будут перезаписаны. Вы уверены, что хотите загрузить настройки из файла?",
        //            "Подтверждение загрузки настроек",
        //            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            SettingsXmlDoc.Load(fileName);
        //            SettingsXmlDoc.Save(_settingsXML);
        //            if (MessageBox.Show(
        //                "ВНИМАНИЕ: Изменения вступят в силу после перезагрузки приложения. Перезапустить приложение сейчас?",
        //                "Подтверждение перезагрузки приложения",
        //                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //            {
        //                Application.Restart();
        //            }
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Не удалось сохранить файл настроек. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return false;
        //}

        /// <summary>
        /// Записать таблицу
        /// </summary>
        /// <param name="dt">Таблица, данные которой нужно сохранить</param>
        /// <param name="elementName">Наименование XML-элемента</param>
        /// <returns></returns>
        public bool SaveDataTable(DataTable dt, string elementName)
        {
            //System.Xml.XmlElement xmlElement = SettingsXmlDoc.CreateElement(elementName);
            LoadXml();
            XmlNode rootNode = SettingsXmlDoc.SelectSingleNode("//root");
            XmlNode childElement;
            if (SettingsXmlDoc.SelectNodes("//root/" + elementName).Count > 0)
            {
                childElement = SettingsXmlDoc.SelectSingleNode("//root/" + elementName);
                childElement.RemoveAll();
            }
            else
            {
                childElement = SettingsXmlDoc.CreateNode(XmlNodeType.Element, elementName, null);
            }
            foreach (DataRow row in dt.Rows)
            {
                XmlElement rowElement = SettingsXmlDoc.CreateElement("row");
                foreach (DataColumn col in dt.Columns)
                {
                    //switch (col.DataType)
                    //{
                    //    case System.Int16:
                    //        rowElement.SetAttribute(col.ColumnName, (string)row[col]);
                    //        break;
                    //}
                    rowElement.SetAttribute(col.ColumnName, Encrypt(Convert.ToString(row[col])));
                }
                childElement.AppendChild(rowElement);
            }
            rootNode.AppendChild(childElement);
            SettingsXmlDoc.Save(_settingsXML);
            return true;
        }

      /// <summary>
      /// Получить таблицу
      /// </summary>
      /// <param name="elementName">Наименование XML-элемента (таблицы)</param>
      /// <returns></returns>
      public DataTable GetDataTable(string elementName)
      {
        LoadXml();
        XmlNodeList xmlNodes = this.SettingsXmlDoc.SelectNodes("//root/" + elementName + "/row");
        if (xmlNodes == null)
        {
          return null;
        }
        DataTable dt = new DataTable();
        bool columnsWasCreated = false;
        foreach (XmlElement xmlElement in xmlNodes)
          {
            // Создание столбцов
            if (!columnsWasCreated)
            {
              foreach (XmlAttribute attr in xmlElement.Attributes)
              {
                if (dt.Columns[attr.Name] == null)
                  dt.Columns.Add(attr.Name, typeof (string));
              }
              columnsWasCreated = true;
            }
            DataRow row = dt.Rows.Add();
            foreach (DataColumn col in dt.Columns)
            {
              row[col.ColumnName] = Decrypt(xmlElement.GetAttribute(col.ColumnName));
            }
          }
        return dt;
      }

      ///// <summary>
      //  /// Выбирает список узлов, соответствующий выражению XPath
      //  /// </summary>
      //  /// <param name="xpath">Выражение XPath</param>
      //  /// <returns></returns>
      //  public XmlNodeList SelectNodes(string xpath)
      //  {
      //      return SettingsXmlDoc.SelectNodes(xpath);
      //  }

        /// <summary>
        /// Сохранить положение формы
        /// </summary>
        /// <param name="form">Форма</param>
        public void SaveFormPosition(Form form)
        {
            bool isMaximizedForm = (form.WindowState == FormWindowState.Maximized);
            if (!isMaximizedForm)
            {
                SetSetting(form.Name + Constants.Location.X, form.Location.X.ToString());
                SetSetting(form.Name + Constants.Location.Y, form.Location.Y.ToString());
                SetSetting(form.Name + Constants.Location.Width, form.Width.ToString());
                SetSetting(form.Name + Constants.Location.Height, form.Height.ToString());
            }
            SetSetting(form.Name + Constants.Location.Maximized, isMaximizedForm.ToString());
        }

        /// <summary>
        /// Загрузить положение формы
        /// </summary>
        /// <param name="form">Форма</param>
        public void LoadFormPosition(Form form)
        {
            // Положение формы
            int X = GetSettingAsInt(form.Name + Constants.Location.X, form.Location.X);
            int Y = GetSettingAsInt(form.Name + Constants.Location.Y, form.Location.Y);
            if (X > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width || X < 0)
                X = 0;
            if (Y > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height || Y < 0)
                Y = 0;
            form.Location = new Point(X, Y);

            // Ширина и высота формы
            form.Width = GetSettingAsInt(form.Name + Constants.Location.Width, form.Width);
            form.Height = GetSettingAsInt(form.Name + Constants.Location.Height, form.Height);

            if (GetSettingAsBool(form.Name + Constants.Location.Maximized, false))
            {
                // Развернуть на весь экран
                form.WindowState = FormWindowState.Maximized;
            }
        }

        #endregion Методы / Methods

        #region Свойства / Properties

        /// <summary>
        /// Получить путь к XML-файлу настроек
        /// </summary>
        public string FileName
        {
            get { return _settingsXML; }
        }

        #endregion Свойства / Properties

        #region Поля / Fields

        /// <summary>
        /// XML-документ настроек
        /// </summary>
        private System.Xml.XmlDocument SettingsXmlDoc = new System.Xml.XmlDocument();

        /// <summary>
        /// Путь к XML-файлу настроек
        /// </summary>
        private string _settingsXML;

        #endregion Поля / Fields
    }
}
