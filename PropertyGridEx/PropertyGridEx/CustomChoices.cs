using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PropertyGridEx
{
  [Serializable]
  public class CustomChoices : ArrayList
  {
    public class CustomChoicesTypeConverter : TypeConverter
    {
      private CustomChoices.CustomChoicesAttributeList oChoices;

      public CustomChoicesTypeConverter()
      {
        this.oChoices = null;
      }

      public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
      {
        CustomChoices.CustomChoicesAttributeList customChoicesAttributeList = (CustomChoices.CustomChoicesAttributeList)context.PropertyDescriptor.Attributes[typeof(CustomChoices.CustomChoicesAttributeList)];
        if (this.oChoices != null)
        {
          return true;
        }
        bool result;
        if (customChoicesAttributeList != null)
        {
          this.oChoices = customChoicesAttributeList;
          result = true;
        }
        else
        {
          result = false;
        }
        return result;
      }

      public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
      {
        CustomChoices.CustomChoicesAttributeList customChoicesAttributeList = (CustomChoices.CustomChoicesAttributeList)context.PropertyDescriptor.Attributes[typeof(CustomChoices.CustomChoicesAttributeList)];
        if (this.oChoices != null)
        {
          return true;
        }
        bool result;
        if (customChoicesAttributeList != null)
        {
          this.oChoices = customChoicesAttributeList;
          result = true;
        }
        else
        {
          result = false;
        }
        return result;
      }

      public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
      {
        CustomChoices.CustomChoicesAttributeList customChoicesAttributeList = (CustomChoices.CustomChoicesAttributeList)context.PropertyDescriptor.Attributes[typeof(CustomChoices.CustomChoicesAttributeList)];
        if (this.oChoices != null)
        {
          return this.oChoices.Values;
        }
        return base.GetStandardValues(context);
      }
    }

    public class CustomChoicesAttributeList : Attribute
    {
      private ArrayList oList;

      public ArrayList Item
      {
        get
        {
          return this.oList;
        }
      }

      public TypeConverter.StandardValuesCollection Values
      {
        get
        {
          return new TypeConverter.StandardValuesCollection(this.oList);
        }
      }

      public CustomChoicesAttributeList(string[] List)
      {
        this.oList = new ArrayList();
        this.oList.AddRange(List);
      }

      public CustomChoicesAttributeList(ArrayList List)
      {
        this.oList = new ArrayList();
        this.oList.AddRange(List);
      }

      public CustomChoicesAttributeList(ListBox.ObjectCollection List)
      {
        this.oList = new ArrayList();
        this.oList.AddRange(List);
      }
    }

    public ArrayList Items
    {
      get
      {
        return this;
      }
    }

    public CustomChoices(ArrayList array, bool IsSorted)
    {
      this.AddRange(array);
      if (IsSorted)
      {
        this.Sort();
      }
    }

    public CustomChoices(ArrayList array)
    {
      this.AddRange(array);
    }

    public CustomChoices(string[] array, bool IsSorted)
    {
      this.AddRange(array);
      if (IsSorted)
      {
        this.Sort();
      }
    }

    public CustomChoices(string[] array)
    {
      this.AddRange(array);
    }

    public CustomChoices(int[] array, bool IsSorted)
    {
      this.AddRange(array);
      if (IsSorted)
      {
        this.Sort();
      }
    }

    public CustomChoices(int[] array)
    {
      this.AddRange(array);
    }

    public CustomChoices(double[] array, bool IsSorted)
    {
      this.AddRange(array);
      if (IsSorted)
      {
        this.Sort();
      }
    }

    public CustomChoices(double[] array)
    {
      this.AddRange(array);
    }

    public CustomChoices(object[] array, bool IsSorted)
    {
      this.AddRange(array);
      if (IsSorted)
      {
        this.Sort();
      }
    }

    public CustomChoices(object[] array)
    {
      this.AddRange(array);
    }
  }
}
