using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyGridEx
{
	public class UIListboxEditor : UITypeEditor
	{
		public class UIListboxDatasource : Attribute
		{
			private object oDataSource;

			public object Value
			{
				get
				{
					return this.oDataSource;
				}
			}

			public UIListboxDatasource(ref object Datasource)
			{
				this.oDataSource = RuntimeHelpers.GetObjectValue(Datasource);
			}
		}

		public class UIListboxValueMember : Attribute
		{
			private string sValueMember;

			public string Value
			{
				get
				{
					return this.sValueMember;
				}
				set
				{
					this.sValueMember = value;
				}
			}

			public UIListboxValueMember(string ValueMember)
			{
				this.sValueMember = ValueMember;
			}
		}

		public class UIListboxDisplayMember : Attribute
		{
			private string sDisplayMember;

			public string Value
			{
				get
				{
					return this.sDisplayMember;
				}
				set
				{
					this.sDisplayMember = value;
				}
			}

			public UIListboxDisplayMember(string DisplayMember)
			{
				this.sDisplayMember = DisplayMember;
			}
		}

		public class UIListboxIsDropDownResizable : Attribute
		{
			[DebuggerNonUserCode]
			public UIListboxIsDropDownResizable()
			{
			}
		}

		private bool bIsDropDownResizable;

		[AccessedThroughProperty("oList")]
		private ListBox _oList;

		private object oSelectedValue;

		private IWindowsFormsEditorService oEditorService;

		internal virtual ListBox oList
		{
			[DebuggerNonUserCode]
			get
			{
				return this._oList;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._oList = value;
			}
		}

		public override bool IsDropDownResizable
		{
			get
			{
				return this.bIsDropDownResizable;
			}
		}

		public UIListboxEditor()
		{
			this.bIsDropDownResizable = false;
			this.oList = new ListBox();
			this.oSelectedValue = null;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context != null && context.Instance != null)
			{
				UIListboxEditor.UIListboxIsDropDownResizable uIListboxIsDropDownResizable = (UIListboxEditor.UIListboxIsDropDownResizable)context.PropertyDescriptor.Attributes[typeof(UIListboxEditor.UIListboxIsDropDownResizable)];
				if (uIListboxIsDropDownResizable != null)
				{
					this.bIsDropDownResizable = true;
				}
				return UITypeEditorEditStyle.DropDown;
			}
			return UITypeEditorEditStyle.None;
		}

		[RefreshProperties(RefreshProperties.All)]
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context != null)
			{
				if (provider != null)
				{
					if (context.Instance != null)
					{
						this.oEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
						if (this.oEditorService != null)
						{
							CustomProperty.CustomPropertyDescriptor customPropertyDescriptor = (CustomProperty.CustomPropertyDescriptor)context.PropertyDescriptor;
							CustomProperty customProperty = (CustomProperty)customPropertyDescriptor.CustomProperty;
							PropertyDescriptor propertyDescriptor = context.PropertyDescriptor;
							UIListboxEditor.UIListboxDatasource uIListboxDatasource = (UIListboxEditor.UIListboxDatasource)propertyDescriptor.Attributes[typeof(UIListboxEditor.UIListboxDatasource)];
							UIListboxEditor.UIListboxValueMember uIListboxValueMember = (UIListboxEditor.UIListboxValueMember)propertyDescriptor.Attributes[typeof(UIListboxEditor.UIListboxValueMember)];
							UIListboxEditor.UIListboxDisplayMember uIListboxDisplayMember = (UIListboxEditor.UIListboxDisplayMember)propertyDescriptor.Attributes[typeof(UIListboxEditor.UIListboxDisplayMember)];
							ListBox oList = this.oList;
							oList.BorderStyle = BorderStyle.None;
							oList.IntegralHeight = true;
							if (uIListboxDatasource != null)
							{
								oList.DataSource = RuntimeHelpers.GetObjectValue(uIListboxDatasource.Value);
							}
							if (uIListboxDisplayMember != null)
							{
								oList.DisplayMember = uIListboxDisplayMember.Value;
							}
							if (uIListboxValueMember != null)
							{
								oList.ValueMember = uIListboxValueMember.Value;
							}
							if (value != null)
							{
								if (Operators.CompareString(value.GetType().Name, "String", false) == 0)
								{
									this.oList.Text = Conversions.ToString(value);
								}
								else
								{
									this.oList.SelectedItem = RuntimeHelpers.GetObjectValue(value);
								}
							}
							this.oList.SelectedIndexChanged += new EventHandler(this.SelectedItem);
							this.oEditorService.DropDownControl(this.oList);
							if (this.oList.SelectedIndices.Count == 1)
							{
								customProperty.SelectedItem = RuntimeHelpers.GetObjectValue(this.oList.SelectedItem);
								customProperty.SelectedValue = RuntimeHelpers.GetObjectValue(this.oSelectedValue);
								value = this.oList.Text;
							}
							this.oEditorService.CloseDropDown();
							return value;
						}
						return base.EditValue(provider, RuntimeHelpers.GetObjectValue(value));
					}
				}
			}
			return base.EditValue(provider, RuntimeHelpers.GetObjectValue(value));
		}

		private void SelectedItem(object sender, EventArgs e)
		{
			if (this.oEditorService != null)
			{
				if (this.oList.SelectedValue != null)
				{
					this.oSelectedValue = RuntimeHelpers.GetObjectValue(this.oList.SelectedValue);
				}
				this.oEditorService.CloseDropDown();
			}
		}
	}
}
