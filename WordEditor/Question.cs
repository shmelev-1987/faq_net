using System;
using System.Collections.Generic;
using System.Text;

namespace FAQ_Net
{
  internal class Question : IComparable, IDisposable
  {
    private string _questionText;
    private DateTime _createTime;
    private DateTime? _modifTime;
    private int _idContent;

    private static int _nextId = 1;
    private int _id = _nextId++;

    public Question(int idContent, string text, DateTime createTime, DateTime? modifTime)
    {
      _idContent = idContent;
      _questionText = text;
      _createTime = createTime;
      _modifTime = modifTime;
    }

    public int IdContent
    {
      get { return _idContent; }
    }

    public string Text
    {
      get { return _questionText; }
      set { _questionText = value; }
    }

    public DateTime? CreateTime
    {
      get { return _createTime; }
    }

    public DateTime? ModifTime
    {
      get { return _modifTime; }
    }

    #region IComparable Members

    public int CompareTo(object obj)
    {
      Question q = obj as Question;
      if (q == null)
      {
        return -1;
      }
      return _id - q._id;
    }

    #endregion

    public void Dispose()
    {
      _questionText = null;
      _modifTime = null;
      //GC.Collect();
      //GC.WaitForPendingFinalizers();
    }

    //public ~Question()
    //{
    //  _questionText = null;
    //  _createTime = null;
    //  _modifTime.di
    //}
  }
}
