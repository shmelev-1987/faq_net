using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PropertyGridEx
{
  [Serializable]
  public class CustomPropertyCollection : CollectionBase, ICustomTypeDescriptor
  {
    public CustomProperty this[int index]
    {
      get
      {
        return (CustomProperty)base.List[index];
      }
    }

    [DebuggerNonUserCode]
    public CustomPropertyCollection()
    {
    }

    public virtual int Add(CustomProperty value)
    {
      return base.List.Add(value);
    }

    public virtual int Add(string strName, object objValue, bool boolIsReadOnly = true, string strCategory = "", string strDescription = "", bool boolVisible = true)
    {
      return base.List.Add(new CustomProperty(strName, RuntimeHelpers.GetObjectValue(objValue), boolIsReadOnly, strCategory, strDescription, boolVisible));
    }

    public virtual int Add(string strName, ref object objRef, string strProp, bool boolIsReadOnly = true, string strCategory = "", string strDescription = "", bool boolVisible = true)
    {
      return base.List.Add(new CustomProperty(strName, ref objRef, strProp, boolIsReadOnly, strCategory, strDescription, boolVisible));
    }

    public int FindItem(string label)
    {
      int num = 0;
      checked
      {
        int result = 0;
        IEnumerator enumerator = null;
        try
        {
          enumerator = base.List.GetEnumerator();
          while (enumerator.MoveNext())
          {
            CustomProperty customProperty = (CustomProperty)enumerator.Current;
            if (Operators.CompareString(customProperty.Name, label, false) == 0)
            {
              result = num;
              break;
            }
            num++;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
          {
            (enumerator as IDisposable).Dispose();
          }
        }
        return result;
      }
    }

    public virtual void Remove(string Name)
    {
      IEnumerator enumerator = null;
      try
      {
        enumerator = base.List.GetEnumerator();
        while (enumerator.MoveNext())
        {
          CustomProperty customProperty = (CustomProperty)enumerator.Current;
          if (Operators.CompareString(customProperty.Name, Name, false) == 0)
          {
            base.List.Remove(customProperty);
            break;
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
        {
          (enumerator as IDisposable).Dispose();
        }
      }
    }

    public AttributeCollection GetAttributes()
    {
      return TypeDescriptor.GetAttributes(this, true);
    }

    public string GetClassName()
    {
      return TypeDescriptor.GetClassName(this, true);
    }

    public string GetComponentName()
    {
      return TypeDescriptor.GetComponentName(this, true);
    }

    public TypeConverter GetConverter()
    {
      return TypeDescriptor.GetConverter(this, true);
    }

    public EventDescriptor GetDefaultEvent()
    {
      return TypeDescriptor.GetDefaultEvent(this, true);
    }

    public PropertyDescriptor GetDefaultProperty()
    {
      return TypeDescriptor.GetDefaultProperty(this, true);
    }

    public object GetEditor(Type editorBaseType)
    {
      return TypeDescriptor.GetEditor(this, editorBaseType, true);
    }

    public EventDescriptorCollection GetEvents()
    {
      return TypeDescriptor.GetEvents(this, true);
    }

    public EventDescriptorCollection GetEvents(Attribute[] attributes)
    {
      return TypeDescriptor.GetEvents(this, attributes, true);
    }

    public PropertyDescriptorCollection GetProperties()
    {
      return TypeDescriptor.GetProperties(this, true);
    }

    public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
    {
      PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
      IEnumerator enumerator = null;
      try
      {
        enumerator = base.List.GetEnumerator();
        while (enumerator.MoveNext())
        {
          CustomProperty customProperty = (CustomProperty)enumerator.Current;
          if (customProperty.Visible)
          {
            ArrayList arrayList = new ArrayList();
            if (customProperty.IsBrowsable)
            {
              arrayList.Add(new TypeConverterAttribute(typeof(BrowsableTypeConverter)));
            }
            if (customProperty.UseFileNameEditor)
            {
              arrayList.Add(new EditorAttribute(typeof(UIFilenameEditor), typeof(UITypeEditor)));
            }
            if (customProperty.Choices != null)
            {
              arrayList.Add(new TypeConverterAttribute(typeof(CustomChoices.CustomChoicesTypeConverter)));
            }
            if (customProperty.IsPassword)
            {
              arrayList.Add(new PasswordPropertyTextAttribute(true));
            }
            if (customProperty.Parenthesize)
            {
              arrayList.Add(new ParenthesizePropertyNameAttribute(true));
            }
            if (customProperty.Datasource != null)
            {
              arrayList.Add(new EditorAttribute(typeof(UIListboxEditor), typeof(UITypeEditor)));
            }
            if (customProperty.CustomEditor != null)
            {
              arrayList.Add(new EditorAttribute(customProperty.CustomEditor.GetType(), typeof(UITypeEditor)));
            }
            if (customProperty.CustomTypeConverter != null)
            {
              arrayList.Add(new TypeConverterAttribute(customProperty.CustomTypeConverter.GetType()));
            }
            if (customProperty.IsPercentage)
            {
              arrayList.Add(new TypeConverterAttribute(typeof(OpacityConverter)));
            }
            if (customProperty.OnClick != null)
            {
              arrayList.Add(new EditorAttribute(typeof(UICustomEventEditor), typeof(UITypeEditor)));
            }
            if (customProperty.DefaultValue != null)
            {
              arrayList.Add(new DefaultValueAttribute(customProperty.Type, customProperty.Value.ToString()));
            }
            else if (customProperty.DefaultType != null)
            {
              arrayList.Add(new DefaultValueAttribute(customProperty.DefaultType, null));
            }
            if (customProperty.Attributes != null)
            {
              arrayList.AddRange(customProperty.Attributes);
            }
            Attribute[] attrs = (Attribute[])arrayList.ToArray(typeof(Attribute));
            propertyDescriptorCollection.Add(new CustomProperty.CustomPropertyDescriptor(customProperty, attrs));
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
        {
          (enumerator as IDisposable).Dispose();
        }
      }
      return propertyDescriptorCollection;
    }

    public object GetPropertyOwner(PropertyDescriptor pd)
    {
      return this;
    }

    public void SaveXml(string filename)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomPropertyCollection));
      FileStream fileStream = new FileStream(filename, FileMode.Create);
      try
      {
        xmlSerializer.Serialize(fileStream, this);
      }
      catch (Exception expr_22)
      {
        ProjectData.SetProjectError(expr_22);
        Exception ex = expr_22;
        Interaction.MsgBox(ex.InnerException.Message, MsgBoxStyle.OkOnly, null);
        ProjectData.ClearProjectError();
      }
      fileStream.Close();
    }

    public bool LoadXml(string filename)
    {
      bool result;
      IEnumerator enumerator = null;
      try
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomPropertyCollection));
        FileStream fileStream = new FileStream(filename, FileMode.Open);
        CustomPropertyCollection customPropertyCollection = (CustomPropertyCollection)xmlSerializer.Deserialize(fileStream);
        try
        {
          enumerator = customPropertyCollection.GetEnumerator();
          while (enumerator.MoveNext())
          {
            CustomProperty customProperty = (CustomProperty)enumerator.Current;
            customProperty.RebuildAttributes();
            this.Add(customProperty);
          }
        }
        finally
        {
          if (enumerator is IDisposable)
          {
            (enumerator as IDisposable).Dispose();
          }
        }
        fileStream.Close();
        result = true;
      }
      catch (Exception expr_7A)
      {
        ProjectData.SetProjectError(expr_7A);
        result = false;
        ProjectData.ClearProjectError();
      }
      return result;
    }

    public void SaveBinary(string filename)
    {
      Stream stream = File.Create(filename);
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      try
      {
        binaryFormatter.Serialize(stream, this);
      }
      catch (Exception expr_17)
      {
        ProjectData.SetProjectError(expr_17);
        Exception ex = expr_17;
        Interaction.MsgBox(ex.InnerException.Message, MsgBoxStyle.OkOnly, null);
        ProjectData.ClearProjectError();
      }
      stream.Close();
    }

    public bool LoadBinary(string filename)
    {
      bool result;
      try
      {
        Stream stream = File.Open(filename, FileMode.Open);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (stream.Length > 0L)
        {
          CustomPropertyCollection customPropertyCollection = (CustomPropertyCollection)binaryFormatter.Deserialize(stream);
          IEnumerator enumerator = null;
          try
          {
            enumerator = customPropertyCollection.GetEnumerator();
            while (enumerator.MoveNext())
            {
              CustomProperty customProperty = (CustomProperty)enumerator.Current;
              customProperty.RebuildAttributes();
              this.Add(customProperty);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
            {
              (enumerator as IDisposable).Dispose();
            }
          }
          stream.Close();
          result = true;
        }
        else
        {
          stream.Close();
          result = false;
        }
      }
      catch (Exception expr_84)
      {
        ProjectData.SetProjectError(expr_84);
        result = false;
        ProjectData.ClearProjectError();
      }
      return result;
    }
  }
}
