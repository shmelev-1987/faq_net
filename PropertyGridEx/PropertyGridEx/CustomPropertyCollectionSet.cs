using System;
using System.Collections;
using System.Diagnostics;

namespace PropertyGridEx
{
  public class CustomPropertyCollectionSet : CollectionBase
  {
    public virtual CustomPropertyCollection this[int index]
    {
      get
      {
        return (CustomPropertyCollection)base.List[index];
      }
      set
      {
        base.List[index] = value;
      }
    }

    [DebuggerNonUserCode]
    public CustomPropertyCollectionSet()
    {
    }

    public virtual int Add(CustomPropertyCollection value)
    {
      return base.List.Add(value);
    }

    public virtual int Add()
    {
      return base.List.Add(new CustomPropertyCollection());
    }

    public virtual object ToArray()
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange(base.List);
      return arrayList.ToArray(typeof(CustomPropertyCollection));
    }
  }
}
