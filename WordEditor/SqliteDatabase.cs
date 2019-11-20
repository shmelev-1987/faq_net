using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace FAQ_Net
{
  internal class SqliteDatabase
  {
    private static DataTable _allFbTablesTable;
    private static DataTable _allFbColumnsTable;
    private const string TABLE_NAME = "table_name";
    private const string COLUMN_NAME = "name";
    private const string COLUMN_TYPE = "type";

    /// <summary>
    /// Создание БД
    /// </summary>
    public static void Create()
    {
      string dbFileName = System.IO.Path.Combine(G.CurDir, "FAQ.sqlite");
      if (!System.IO.File.Exists(dbFileName))
        SQLiteConnection.CreateFile(dbFileName);

      RefreshDbSchema();

      string resultMsg = string.Empty;

      if (CreateTableIfNotExists("category", Sql.CreateTable.category, ref resultMsg) == ResultOperation.Error
       || CreateTableIfNotExists("vopros", Sql.CreateTable.vopros, ref resultMsg) == ResultOperation.Error
       || CreateTableIfNotExists("otvet", Sql.CreateTable.otvet, ref resultMsg) == ResultOperation.Error
       || CreateTableIfNotExists("word_tooltip", Sql.CreateTable.word_tooltip, ref resultMsg) == ResultOperation.Error
       //|| CreateOrAlterColumn("")
       )
      {
        MessageBox.Show("Возникла ошибка при создании таблиц", resultMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static void RefreshDbTablesAndColumns()
    {
      // Извлечение списка таблиц
      if (_allFbTablesTable == null)
      {
        _allFbTablesTable = new DataTable();
        _allFbTablesTable.Columns.Add(TABLE_NAME, typeof(string));
      }
      _allFbTablesTable.Rows.Clear();
      if (G.ExecSQLiteQuery("SELECT name FROM sqlite_master WHERE type='table';"))
      {
        foreach (DataRow tableRow in G.DT.Rows)
          _allFbTablesTable.Rows.Add(tableRow[0]);
      }

      // Извлечение списка полей в таблицах
      if (_allFbColumnsTable == null)
      {
        _allFbColumnsTable = new DataTable();
        _allFbColumnsTable.Columns.Add(TABLE_NAME, typeof(string));
        _allFbColumnsTable.Columns.Add("cid", typeof(int));
        _allFbColumnsTable.Columns.Add(COLUMN_NAME, typeof(string));
        _allFbColumnsTable.Columns.Add(COLUMN_TYPE, typeof(string));
        _allFbColumnsTable.Columns.Add("notnull", typeof(bool));
        _allFbColumnsTable.Columns.Add("dflt_value", typeof(string));
        _allFbColumnsTable.Columns.Add("pk", typeof(bool));
      }
      _allFbColumnsTable.Rows.Clear();
      foreach (DataRow tableRow in _allFbTablesTable.Rows)
      {
        if (G.ExecSQLiteQuery("PRAGMA table_info('" + tableRow[0] + "')"))
        {
          DataRow newTableColumnRow = _allFbColumnsTable.NewRow();
          newTableColumnRow[TABLE_NAME] = tableRow[0];
          foreach (DataRow columnRow in G.DT.Rows)
          {
            foreach (DataColumn column in G.DT.Columns)
              newTableColumnRow[column.ColumnName] = columnRow[column.ColumnName];
          }
          _allFbColumnsTable.Rows.Add(newTableColumnRow);
        }
      }
    }

    private static void RefreshDbSchema()
    {
      RefreshDbTablesAndColumns();
    }

    //private static bool CreateTableIfNotExists(string tableName, string createTableSql)
    //{
    //  bool existTable = (_allFbTablesTable.Select(string.Format("{0}='{1}'", TABLE_NAME, tableName)).Length == 0);
    //  if (!existTable)
    //    existTable = G.ExecSQLiteQuery(createTableSql);
    //  return existTable;
    //}

    private static ResultOperation CreateTableIfNotExists(string tableName, string sqlQuery, ref string result)
    {
      // Создать таблицу в БД
      if (!IsExistsTable(tableName))
      {
        int countExecuteSqlQueries;
        bool execResult = ExecManySql(tableName, "Ошибка создания таблицы", sqlQuery, ref result, out countExecuteSqlQueries);
        if (countExecuteSqlQueries > 0)
        {
          result += Environment.NewLine + "Создана таблица: " + tableName + " (выполнено запросов " + countExecuteSqlQueries + ")";
          return ResultOperation.CreateTable;
        }
        return ResultOperation.Error;
      }
      return ResultOperation.Nothing;
    }

    private static bool IsExistsTable(string tableName)
    {
      foreach (DataRow tableRow in _allFbTablesTable.Rows)
      {
        if (tableRow[TABLE_NAME].ToString().ToUpper() == tableName.ToUpper())
        {
          return true;
        }
      }
      return false;
    }

    private static bool ExecManySql(string sqlName, string errHeader, string sqlQuery, ref string result, out int countExecuteSqlQueries)
    {
      char[] delimiters = new char[] { ';' };
      string[] parts = sqlQuery.Split(delimiters);
      countExecuteSqlQueries = 0;
      foreach (string sql in parts)
      {
        if (sql.Trim() != string.Empty)
        {
          if (G.ExecSQLiteQuery(sql))
            countExecuteSqlQueries += 1;
          else
          {
            result += Environment.NewLine + errHeader + ": " + sqlName;
            //MainForm.Log.AddRecToLog("Ошибка выполнения запроса " + sqlName, ex.Message + "\n" + sql, true);
            return false;
          }
        }
      }
      return true;
    }

    /// <summary>
    /// Проверить поле таблицы на существование и необходимость изменения типа
    /// </summary>
    /// <param name="tableName">Наименование таблицы</param>
    /// <param name="columnName">Наименование поля</param>
    /// <param name="columnType">Наименование типа</param>
    /// <param name="allColumns">Таблица со всеми полями БД</param>
    /// <param name="isExistsColumn">Возвращает true, если поле существует</param>
    /// <param name="isMustCreateOrAlterColumn">Возвращает true, если поле нужно изменить</param>
    /// <param name="oldTypeColumn">Возвращает текущий тип поля в БД</param>
    private void CheckColumn(string tableName, string columnName, string columnType
      , out bool isExistsColumn, out bool isMustCreateOrAlterColumn, out string oldTypeColumn)
    {
      isExistsColumn = false;
      isMustCreateOrAlterColumn = true;
      oldTypeColumn = string.Empty;
      foreach (DataRow fbColumnRow in _allFbColumnsTable.Rows)
      {
        if (fbColumnRow[TABLE_NAME].ToString().ToUpper() == tableName.ToUpper()
        && fbColumnRow[COLUMN_NAME].ToString().ToUpper() == columnName.ToUpper())
        {
          isExistsColumn = true;
          oldTypeColumn = fbColumnRow[COLUMN_TYPE].ToString();
          if (oldTypeColumn.ToUpper() == columnType.ToUpper())
          {
            isMustCreateOrAlterColumn = false;
          }
          break;
        }
      }
    }

    private bool CreateOrAlterColumn(string tableName, string columnName, string columnType, ref string result)
    {
      bool isExistsColumn;
      bool isMustCreateOrAlterColumn;
      string oldTypeColumn;
      CheckColumn(tableName, columnName, columnType, out isExistsColumn, out isMustCreateOrAlterColumn, out oldTypeColumn);
      // Обновить SQL-запрос процедуры
      if (isMustCreateOrAlterColumn)
      {
        string sql = string.Empty;
        if (isExistsColumn)
        {
          sql = string.Format("ALTER TABLE {0} ALTER {1} TYPE {2};", tableName, columnName,
              columnType);
          if (G.ExecSQLiteQuery(sql))
          {
            result += Environment.NewLine +
                      string.Format("Изменен тип поля {0}.{1} с {2} на {3}", tableName, columnName, oldTypeColumn,
                        columnType);
          }
          else
          {
            result += Environment.NewLine + "Ошибка изменения поля: " + tableName + "." + columnName;
            return false;
          }
        }
        else
        {
          sql = string.Format("ALTER TABLE {0} ADD {1} {2};", tableName, columnName, columnType);
          if (G.ExecSQLiteQuery(sql))
            result += Environment.NewLine + string.Format("Создано поле {0} типа {1} в таблице {2}", columnName, columnType, tableName);
          else
          {
            result += Environment.NewLine + "Ошибка создания поля: " + tableName + "." + columnName;
            return false;
          }
        }
        return true;

      }
      return true;
    }

    /// <summary>
    /// Результат выполнения операции изменения структуры БД
    /// </summary>
    private enum ResultOperation
    {
      Nothing,
      Error,
      //CreateOrAlterProcedure,
      //DropProcedure,
      CreateTable,
      //CreateOrAlterView,
      //DropColumn,
    }
  }
}
