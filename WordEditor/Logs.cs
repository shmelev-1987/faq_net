using System;
using System.IO;
using System.Windows.Forms;

namespace ExcelTotalReport
{
    public class Logs
    {
        private StreamWriter _logFile;
        private string _logFileName;

        /// <summary>
        /// Расширение лог-файла
        /// </summary>
        public static string FILE_EXT = ".log";

        private object _lockWrite = new object();

        /// <summary>
        /// Создать экземпляр класса Logs (файл создается в текущей директории)
        /// </summary>
        public Logs()
        {
            // Путь относительно запущенного файла
            string executeFileName = System.Reflection.Assembly.GetEntryAssembly().Location;
            string logsDirName = Path.GetDirectoryName(executeFileName);
            _logFileName = logsDirName + "\\" + Path.GetFileNameWithoutExtension(executeFileName) + FILE_EXT;

            // Путь к каталогу текущего пользователя ApplicationData
            if (!Directory.Exists(logsDirName))
            {
                Directory.CreateDirectory(logsDirName);
            }
            _logFile = new StreamWriter(_logFileName, true, System.Text.Encoding.GetEncoding(65001));
            _logFile.AutoFlush = true;
          AddRecToLog(new string('-', 65), null);
          AddRecToLog(string.Format("{0} версия приложения {1}", Application.ProductName, Application.ProductVersion), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationName"></param>
        /// <param name="result"></param>
        /// <param name="showErrMessage">True - показать окно сообщения с ошибкой</param>
        public virtual void AddRecToLog(string operationName, string result, bool showErrMessage)
        {
            lock (_lockWrite)
            {
                AddRecToLog(operationName, result);
                if (showErrMessage)
                    MessageBox.Show(operationName + "\n\n" + result, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationName"></param>
        /// <param name="result"></param>
        public void AddRecToLog(string operationName, string result)
        {
            lock (_lockWrite)
            {
                if (String.IsNullOrEmpty(result))
                    _logFile.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "\t" + operationName);
                else
                    _logFile.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "\t" + operationName + "\t" +
                                       result);
                _logFile.Flush();
            }
        }

        public void Close()
        {
            _logFile.Close();
        }

      /// <summary>
      /// Получить имя файла лога
      /// </summary>
      public string FileName
      {
        get { return _logFileName; }
      }
    }
}
