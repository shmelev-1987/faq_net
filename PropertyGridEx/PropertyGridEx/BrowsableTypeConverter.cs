using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace PropertyGridEx
{
  public class BrowsableTypeConverter : ExpandableObjectConverter
  {
    public enum LabelStyle
    {
      lsNormal,
      lsTypeName,
      lsEllipsis
    }

    public class BrowsableLabelStyleAttribute : Attribute
    {
      private BrowsableTypeConverter.LabelStyle eLabelStyle;

      public BrowsableTypeConverter.LabelStyle LabelStyle
      {
        get
        {
          return this.eLabelStyle;
        }
        set
        {
          this.eLabelStyle = value;
        }
      }

      public BrowsableLabelStyleAttribute(BrowsableTypeConverter.LabelStyle LabelStyle)
      {
        this.eLabelStyle = BrowsableTypeConverter.LabelStyle.lsEllipsis;
        this.eLabelStyle = LabelStyle;
      }
    }

    [DebuggerNonUserCode]
    public BrowsableTypeConverter()
    {
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      return true;
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      BrowsableTypeConverter.BrowsableLabelStyleAttribute browsableLabelStyleAttribute = (BrowsableTypeConverter.BrowsableLabelStyleAttribute)context.PropertyDescriptor.Attributes[typeof(BrowsableTypeConverter.BrowsableLabelStyleAttribute)];
      if (browsableLabelStyleAttribute != null)
      {
        switch (browsableLabelStyleAttribute.LabelStyle)
        {
          case BrowsableTypeConverter.LabelStyle.lsNormal:
            return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType);
          case BrowsableTypeConverter.LabelStyle.lsTypeName:
            return "(" + value.GetType().Name + ")";
          case BrowsableTypeConverter.LabelStyle.lsEllipsis:
            return "(...)";
        }
      }
      return base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType);
    }
  }
}
