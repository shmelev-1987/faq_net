using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace PropertyGridEx
{
	[XmlRoot("CustomProperty")]
	[Serializable]
	public class CustomProperty
	{
		public class CustomPropertyDescriptor : PropertyDescriptor
		{
			protected CustomProperty oCustomProperty;

			public override Type ComponentType
			{
				get
				{
					return this.GetType();
				}
			}

			public override bool IsReadOnly
			{
				get
				{
					return this.oCustomProperty.IsReadOnly;
				}
			}

			public override Type PropertyType
			{
				get
				{
					return this.oCustomProperty.Type;
				}
			}

			public override string Description
			{
				get
				{
					return this.oCustomProperty.Description;
				}
			}

			public override string Category
			{
				get
				{
					return this.oCustomProperty.Category;
				}
			}

			public override string DisplayName
			{
				get
				{
					return this.oCustomProperty.Name;
				}
			}

			public override bool IsBrowsable
			{
				get
				{
					return this.oCustomProperty.IsBrowsable;
				}
			}

			public object CustomProperty
			{
				get
				{
					return this.oCustomProperty;
				}
			}

			public CustomPropertyDescriptor(CustomProperty myProperty, Attribute[] attrs) : base(myProperty.Name, attrs)
			{
				if (myProperty == null)
				{
					this.oCustomProperty = null;
				}
				else
				{
					this.oCustomProperty = myProperty;
				}
			}

			public override bool CanResetValue(object component)
			{
				return this.oCustomProperty.DefaultValue != null || this.oCustomProperty.DefaultType != null;
			}

			public override object GetValue(object component)
			{
				return this.oCustomProperty.Value;
			}

			public override void ResetValue(object component)
			{
				this.oCustomProperty.Value = RuntimeHelpers.GetObjectValue(this.oCustomProperty.DefaultValue);
				this.OnValueChanged(RuntimeHelpers.GetObjectValue(component), EventArgs.Empty);
			}

			public override void SetValue(object component, object value)
			{
				this.oCustomProperty.Value = RuntimeHelpers.GetObjectValue(value);
				this.OnValueChanged(RuntimeHelpers.GetObjectValue(component), EventArgs.Empty);
			}

			public override bool ShouldSerializeValue(object component)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(this.oCustomProperty.Value);
				return this.oCustomProperty.DefaultValue != null && objectValue != null && !objectValue.Equals(RuntimeHelpers.GetObjectValue(this.oCustomProperty.DefaultValue));
			}
		}

		protected string sName;

		protected object oValue;

		protected bool bIsReadOnly;

		protected bool bVisible;

		protected string sDescription;

		protected string sCategory;

		protected bool bIsPassword;

		protected bool bIsPercentage;

		protected bool bParenthesize;

		protected string sFilter;

		protected UIFilenameEditor.FileDialogType eDialogType;

		protected bool bUseFileNameEditor;

		protected CustomChoices oChoices;

		protected bool bIsBrowsable;

		protected BrowsableTypeConverter.LabelStyle eBrowsablePropertyLabel;

		protected bool bRef;

		protected object oRef;

		protected string sProp;

		protected object oDatasource;

		protected string sDisplayMember;

		protected string sValueMember;

		protected object oSelectedValue;

		protected object oSelectedItem;

		protected bool bIsDropdownResizable;

		protected UICustomEventEditor.OnClick MethodDelegate;

		[NonSerialized]
		protected AttributeCollection oCustomAttributes;

		protected object oTag;

		protected object oDefaultValue;

		protected Type oDefaultType;

		[NonSerialized]
		protected UITypeEditor oCustomEditor;

		[NonSerialized]
		protected TypeConverter oCustomTypeConverter;

		private object DataColumn
		{
			get
			{
				DataRow dataRow = (DataRow)this.oRef;
				if (dataRow.RowState == DataRowState.Deleted)
				{
					return null;
				}
				if (this.oDatasource == null)
				{
					return dataRow[this.sProp];
				}
				DataTable dataTable = this.oDatasource as DataTable;
				if (dataTable != null)
				{
					return dataTable.Select(Conversions.ToString(Operators.ConcatenateObject(this.sValueMember + "=", dataRow[this.sProp])))[0][this.sDisplayMember];
				}
				Information.Err().Raise(-2147220991, null, "Bind of DataRow with a DataSource that is not a DataTable is not possible", null, null);
				return null;
			}
			set
			{
				DataRow dataRow = (DataRow)this.oRef;
				if (dataRow.RowState != DataRowState.Deleted)
				{
					if (this.oDatasource == null)
					{
						dataRow[this.sProp] = RuntimeHelpers.GetObjectValue(value);
					}
					else
					{
						DataTable dataTable = this.oDatasource as DataTable;
						if (dataTable != null)
						{
							if (dataTable.Columns[this.sDisplayMember].DataType.Equals(Type.GetType("System.String")))
							{
								dataRow[this.sProp] = RuntimeHelpers.GetObjectValue(dataTable.Select(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable.Columns[this.sDisplayMember].ColumnName + " = '", value), "'")))[0][this.sValueMember]);
							}
							else
							{
								dataRow[this.sProp] = RuntimeHelpers.GetObjectValue(dataTable.Select(Conversions.ToString(Operators.ConcatenateObject(dataTable.Columns[this.sDisplayMember].ColumnName + " = ", value)))[0][this.sValueMember]);
							}
						}
						else
						{
							Information.Err().Raise(-2147220990, null, "Bind of DataRow with a DataSource that is not a DataTable is impossible", null, null);
						}
					}
				}
			}
		}

		[Category("Appearance"), Description("Display Name of the CustomProperty."), DisplayName("Name"), ParenthesizePropertyName(true), XmlElement("Name")]
		public string Name
		{
			get
			{
				return this.sName;
			}
			set
			{
				this.sName = value;
			}
		}

		[Category("Appearance"), Description("Set read only attribute of the CustomProperty."), DisplayName("ReadOnly"), XmlElement("ReadOnly")]
		public bool IsReadOnly
		{
			get
			{
				return this.bIsReadOnly;
			}
			set
			{
				this.bIsReadOnly = value;
			}
		}

		[Category("Appearance"), Description("Set visibility attribute of the CustomProperty.")]
		public bool Visible
		{
			get
			{
				return this.bVisible;
			}
			set
			{
				this.bVisible = value;
			}
		}

		[Category("Appearance"), Description("Represent the Value of the CustomProperty.")]
		public object Value
		{
			get
			{
				if (!this.bRef)
				{
					return this.oValue;
				}
				if (this.oRef is DataRow)
				{
					return this.DataColumn;
				}
				return Versioned.CallByName(RuntimeHelpers.GetObjectValue(this.oRef), this.sProp, CallType.Get, new object[0]);
			}
			set
			{
				if (this.bRef)
				{
					if (this.oRef is DataRow)
					{
						this.DataColumn = RuntimeHelpers.GetObjectValue(value);
					}
					else
					{
						Versioned.CallByName(RuntimeHelpers.GetObjectValue(this.oRef), this.sProp, CallType.Set, new object[]
						{
							RuntimeHelpers.GetObjectValue(value)
						});
					}
				}
				else
				{
					this.oValue = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		[Category("Appearance"), Description("Set description associated with the CustomProperty.")]
		public string Description
		{
			get
			{
				return this.sDescription;
			}
			set
			{
				this.sDescription = value;
			}
		}

		[Category("Appearance"), Description("Set category associated with the CustomProperty.")]
		public string Category
		{
			get
			{
				return this.sCategory;
			}
			set
			{
				this.sCategory = value;
			}
		}

		[XmlIgnore]
		public Type Type
		{
			get
			{
				if (this.Value != null)
				{
					return this.Value.GetType();
				}
				if (this.oDefaultValue != null)
				{
					return this.oDefaultValue.GetType();
				}
				return this.oDefaultType;
			}
		}

		[XmlIgnore]
		public AttributeCollection Attributes
		{
			get
			{
				return this.oCustomAttributes;
			}
			set
			{
				this.oCustomAttributes = value;
			}
		}

		[Category("Behavior"), Description("Indicates if the property is browsable or not."), XmlElement(IsNullable = false)]
		public bool IsBrowsable
		{
			get
			{
				return this.bIsBrowsable;
			}
			set
			{
				this.bIsBrowsable = value;
				if (value)
				{
					this.BuildAttributes_BrowsableProperty();
				}
			}
		}

		[Category("Appearance"), DefaultValue(false), Description("Indicates whether the name of the associated property is displayed with parentheses in the Properties window."), DisplayName("Parenthesize"), XmlElement("Parenthesize")]
		public bool Parenthesize
		{
			get
			{
				return this.bParenthesize;
			}
			set
			{
				this.bParenthesize = value;
			}
		}

		[Category("Behavior"), Description("Indicates the style of the label when a property is browsable."), XmlElement(IsNullable = false)]
		public BrowsableTypeConverter.LabelStyle BrowsableLabelStyle
		{
			get
			{
				return this.eBrowsablePropertyLabel;
			}
			set
			{
				bool flag = false;
				if (value != this.eBrowsablePropertyLabel)
				{
					flag = true;
				}
				this.eBrowsablePropertyLabel = value;
				if (flag)
				{
					BrowsableTypeConverter.BrowsableLabelStyleAttribute browsableLabelStyleAttribute = new BrowsableTypeConverter.BrowsableLabelStyleAttribute(value);
					this.oCustomAttributes = new AttributeCollection(new Attribute[]
					{
						browsableLabelStyleAttribute
					});
				}
			}
		}

		[Category("Behavior"), Description("Indicates if the property is masked or not."), XmlElement(IsNullable = false)]
		public bool IsPassword
		{
			get
			{
				return this.bIsPassword;
			}
			set
			{
				this.bIsPassword = value;
			}
		}

		[Category("Behavior"), Description("Indicates if the property represents a value in percentage."), XmlElement(IsNullable = false)]
		public bool IsPercentage
		{
			get
			{
				return this.bIsPercentage;
			}
			set
			{
				this.bIsPercentage = value;
			}
		}

		[Category("Behavior"), Description("Indicates if the property uses a FileNameEditor converter."), XmlElement(IsNullable = false)]
		public bool UseFileNameEditor
		{
			get
			{
				return this.bUseFileNameEditor;
			}
			set
			{
				this.bUseFileNameEditor = value;
			}
		}

		[Category("Behavior"), Description("Apply a filter to FileNameEditor converter."), XmlElement(IsNullable = false)]
		public string FileNameFilter
		{
			get
			{
				return this.sFilter;
			}
			set
			{
				bool flag = false;
				if (Operators.CompareString(value, this.sFilter, false) != 0)
				{
					flag = true;
				}
				this.sFilter = value;
				if (flag)
				{
					this.BuildAttributes_FilenameEditor();
				}
			}
		}

		[Category("Behavior"), Description("DialogType of the FileNameEditor."), XmlElement(IsNullable = false)]
		public UIFilenameEditor.FileDialogType FileNameDialogType
		{
			get
			{
				return this.eDialogType;
			}
			set
			{
				bool flag = false;
				if (value != this.eDialogType)
				{
					flag = true;
				}
				this.eDialogType = value;
				if (flag)
				{
					this.BuildAttributes_FilenameEditor();
				}
			}
		}

		[Category("Behavior"), Description("Custom Choices list."), XmlIgnore]
		public CustomChoices Choices
		{
			get
			{
				return this.oChoices;
			}
			set
			{
				this.oChoices = value;
				this.BuildAttributes_CustomChoices();
			}
		}

		[Category("Databinding"), XmlIgnore]
		public object Datasource
		{
			get
			{
				return this.oDatasource;
			}
			set
			{
				this.oDatasource = RuntimeHelpers.GetObjectValue(value);
				this.BuildAttributes_ListboxEditor();
			}
		}

		[Category("Databinding"), XmlElement(IsNullable = false)]
		public string ValueMember
		{
			get
			{
				return this.sValueMember;
			}
			set
			{
				this.sValueMember = value;
				this.BuildAttributes_ListboxEditor();
			}
		}

		[Category("Databinding"), XmlElement(IsNullable = false)]
		public string DisplayMember
		{
			get
			{
				return this.sDisplayMember;
			}
			set
			{
				this.sDisplayMember = value;
				this.BuildAttributes_ListboxEditor();
			}
		}

		[Category("Databinding"), XmlElement(IsNullable = false)]
		public object SelectedValue
		{
			get
			{
				return this.oSelectedValue;
			}
			set
			{
				this.oSelectedValue = RuntimeHelpers.GetObjectValue(value);
			}
		}

		[Category("Databinding"), XmlElement(IsNullable = false)]
		public object SelectedItem
		{
			get
			{
				return this.oSelectedItem;
			}
			set
			{
				this.oSelectedItem = RuntimeHelpers.GetObjectValue(value);
			}
		}

		[Category("Databinding"), XmlElement(IsNullable = false)]
		public bool IsDropdownResizable
		{
			get
			{
				return this.bIsDropdownResizable;
			}
			set
			{
				this.bIsDropdownResizable = value;
				this.BuildAttributes_ListboxEditor();
			}
		}

		[XmlIgnore]
		public UITypeEditor CustomEditor
		{
			get
			{
				return this.oCustomEditor;
			}
			set
			{
				this.oCustomEditor = value;
			}
		}

		[XmlIgnore]
		public TypeConverter CustomTypeConverter
		{
			get
			{
				return this.oCustomTypeConverter;
			}
			set
			{
				this.oCustomTypeConverter = value;
			}
		}

		[XmlIgnore]
		public object Tag
		{
			get
			{
				return this.oTag;
			}
			set
			{
				this.oTag = RuntimeHelpers.GetObjectValue(value);
			}
		}

		[XmlIgnore]
		public object DefaultValue
		{
			get
			{
				return this.oDefaultValue;
			}
			set
			{
				this.oDefaultValue = RuntimeHelpers.GetObjectValue(value);
			}
		}

		[XmlIgnore]
		public Type DefaultType
		{
			get
			{
				return this.oDefaultType;
			}
			set
			{
				this.oDefaultType = value;
			}
		}

		[XmlIgnore]
		public UICustomEventEditor.OnClick OnClick
		{
			get
			{
				return this.MethodDelegate;
			}
			set
			{
				this.MethodDelegate = value;
				this.BuildAttributes_CustomEventProperty();
			}
		}

		public CustomProperty()
		{
			this.sName = "";
			this.oValue = null;
			this.bIsReadOnly = false;
			this.bVisible = true;
			this.sDescription = "";
			this.sCategory = "";
			this.bIsPassword = false;
			this.bIsPercentage = false;
			this.bParenthesize = false;
			this.sFilter = null;
			this.eDialogType = UIFilenameEditor.FileDialogType.LoadFileDialog;
			this.bUseFileNameEditor = false;
			this.oChoices = null;
			this.bIsBrowsable = false;
			this.eBrowsablePropertyLabel = BrowsableTypeConverter.LabelStyle.lsEllipsis;
			this.bRef = false;
			this.oRef = null;
			this.sProp = "";
			this.oDatasource = null;
			this.sDisplayMember = null;
			this.sValueMember = null;
			this.oSelectedValue = null;
			this.oSelectedItem = null;
			this.bIsDropdownResizable = false;
			this.oCustomAttributes = null;
			this.oTag = null;
			this.oDefaultValue = null;
			this.oDefaultType = null;
			this.oCustomEditor = null;
			this.oCustomTypeConverter = null;
			this.sName = "New Property";
			this.oValue = new string(Conversions.ToCharArrayRankOne(""));
		}

		public CustomProperty(string strName, object objValue, bool boolIsReadOnly = true, string strCategory = "", string strDescription = "", bool boolVisible = true)
		{
			this.sName = "";
			this.oValue = null;
			this.bIsReadOnly = false;
			this.bVisible = true;
			this.sDescription = "";
			this.sCategory = "";
			this.bIsPassword = false;
			this.bIsPercentage = false;
			this.bParenthesize = false;
			this.sFilter = null;
			this.eDialogType = UIFilenameEditor.FileDialogType.LoadFileDialog;
			this.bUseFileNameEditor = false;
			this.oChoices = null;
			this.bIsBrowsable = false;
			this.eBrowsablePropertyLabel = BrowsableTypeConverter.LabelStyle.lsEllipsis;
			this.bRef = false;
			this.oRef = null;
			this.sProp = "";
			this.oDatasource = null;
			this.sDisplayMember = null;
			this.sValueMember = null;
			this.oSelectedValue = null;
			this.oSelectedItem = null;
			this.bIsDropdownResizable = false;
			this.oCustomAttributes = null;
			this.oTag = null;
			this.oDefaultValue = null;
			this.oDefaultType = null;
			this.oCustomEditor = null;
			this.oCustomTypeConverter = null;
			this.sName = strName;
			this.oValue = RuntimeHelpers.GetObjectValue(objValue);
			this.bIsReadOnly = boolIsReadOnly;
			this.sDescription = strDescription;
			this.sCategory = strCategory;
			this.bVisible = boolVisible;
			if (this.oValue != null)
			{
				this.oDefaultValue = RuntimeHelpers.GetObjectValue(this.oValue);
			}
		}

		public CustomProperty(string strName, ref object objRef, string strProp, bool boolIsReadOnly = true, string strCategory = "", string strDescription = "", bool boolVisible = true)
		{
			this.sName = "";
			this.oValue = null;
			this.bIsReadOnly = false;
			this.bVisible = true;
			this.sDescription = "";
			this.sCategory = "";
			this.bIsPassword = false;
			this.bIsPercentage = false;
			this.bParenthesize = false;
			this.sFilter = null;
			this.eDialogType = UIFilenameEditor.FileDialogType.LoadFileDialog;
			this.bUseFileNameEditor = false;
			this.oChoices = null;
			this.bIsBrowsable = false;
			this.eBrowsablePropertyLabel = BrowsableTypeConverter.LabelStyle.lsEllipsis;
			this.bRef = false;
			this.oRef = null;
			this.sProp = "";
			this.oDatasource = null;
			this.sDisplayMember = null;
			this.sValueMember = null;
			this.oSelectedValue = null;
			this.oSelectedItem = null;
			this.bIsDropdownResizable = false;
			this.oCustomAttributes = null;
			this.oTag = null;
			this.oDefaultValue = null;
			this.oDefaultType = null;
			this.oCustomEditor = null;
			this.oCustomTypeConverter = null;
			this.sName = strName;
			this.bIsReadOnly = boolIsReadOnly;
			this.sDescription = strDescription;
			this.sCategory = strCategory;
			this.bVisible = boolVisible;
			this.bRef = true;
			this.oRef = RuntimeHelpers.GetObjectValue(objRef);
			this.sProp = strProp;
			if (this.Value != null)
			{
				this.oDefaultValue = RuntimeHelpers.GetObjectValue(this.Value);
			}
		}

		public void RebuildAttributes()
		{
			if (this.bUseFileNameEditor)
			{
				this.BuildAttributes_FilenameEditor();
			}
			else if (this.oChoices != null)
			{
				this.BuildAttributes_CustomChoices();
			}
			else if (this.oDatasource != null)
			{
				this.BuildAttributes_ListboxEditor();
			}
			else if (this.bIsBrowsable)
			{
				this.BuildAttributes_BrowsableProperty();
			}
		}

		private void BuildAttributes_FilenameEditor()
		{
			ArrayList arrayList = new ArrayList();
			UIFilenameEditor.FileDialogFilterAttribute value = new UIFilenameEditor.FileDialogFilterAttribute(this.sFilter);
			UIFilenameEditor.SaveFileAttribute value2 = new UIFilenameEditor.SaveFileAttribute();
			arrayList.Add(value);
			if (this.eDialogType == UIFilenameEditor.FileDialogType.SaveFileDialog)
			{
				arrayList.Add(value2);
			}
			Attribute[] attributes = (Attribute[])arrayList.ToArray(typeof(Attribute));
			this.oCustomAttributes = new AttributeCollection(attributes);
		}

		private void BuildAttributes_CustomChoices()
		{
			if (this.oChoices != null)
			{
				CustomChoices.CustomChoicesAttributeList value = new CustomChoices.CustomChoicesAttributeList(this.oChoices.Items);
				Attribute[] attributes = (Attribute[])new ArrayList
				{
					value
				}.ToArray(typeof(Attribute));
				this.oCustomAttributes = new AttributeCollection(attributes);
			}
		}

		private void BuildAttributes_ListboxEditor()
		{
			if (this.oDatasource != null)
			{
				UIListboxEditor.UIListboxDatasource value = new UIListboxEditor.UIListboxDatasource(ref this.oDatasource);
				UIListboxEditor.UIListboxValueMember value2 = new UIListboxEditor.UIListboxValueMember(this.sValueMember);
				UIListboxEditor.UIListboxDisplayMember value3 = new UIListboxEditor.UIListboxDisplayMember(this.sDisplayMember);
				ArrayList arrayList = new ArrayList();
				arrayList.Add(value);
				arrayList.Add(value2);
				arrayList.Add(value3);
				if (this.bIsDropdownResizable)
				{
					UIListboxEditor.UIListboxIsDropDownResizable value4 = new UIListboxEditor.UIListboxIsDropDownResizable();
					arrayList.Add(value4);
				}
				Attribute[] attributes = (Attribute[])arrayList.ToArray(typeof(Attribute));
				this.oCustomAttributes = new AttributeCollection(attributes);
			}
		}

		private void BuildAttributes_BrowsableProperty()
		{
			BrowsableTypeConverter.BrowsableLabelStyleAttribute browsableLabelStyleAttribute = new BrowsableTypeConverter.BrowsableLabelStyleAttribute(this.eBrowsablePropertyLabel);
			this.oCustomAttributes = new AttributeCollection(new Attribute[]
			{
				browsableLabelStyleAttribute
			});
		}

		private void BuildAttributes_CustomEventProperty()
		{
			UICustomEventEditor.DelegateAttribute delegateAttribute = new UICustomEventEditor.DelegateAttribute(this.MethodDelegate);
			this.oCustomAttributes = new AttributeCollection(new Attribute[]
			{
				delegateAttribute
			});
		}
	}
}
