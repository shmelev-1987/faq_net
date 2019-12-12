using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.CompilerServices;

namespace PropertyGridEx
{
	public class UICustomEventEditor : UITypeEditor
	{
		public delegate object OnClick(object sender, EventArgs e);

		[AttributeUsage(AttributeTargets.Property)]
		public class DelegateAttribute : Attribute
		{
			protected UICustomEventEditor.OnClick m_MethodDelegate;

			public UICustomEventEditor.OnClick GetMethod
			{
				get
				{
					return this.m_MethodDelegate;
				}
			}

			public DelegateAttribute(UICustomEventEditor.OnClick MethodDelegate)
			{
				this.m_MethodDelegate = MethodDelegate;
			}
		}

		protected UICustomEventEditor.OnClick m_MethodDelegate;

		protected CustomProperty.CustomPropertyDescriptor m_sender;

		[DebuggerNonUserCode]
		public UICustomEventEditor()
		{
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context != null && context.Instance != null && !context.PropertyDescriptor.IsReadOnly)
			{
				return UITypeEditorEditStyle.Modal;
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
						if (this.m_MethodDelegate == null)
						{
							UICustomEventEditor.DelegateAttribute delegateAttribute = (UICustomEventEditor.DelegateAttribute)context.PropertyDescriptor.Attributes[typeof(UICustomEventEditor.DelegateAttribute)];
							this.m_MethodDelegate = delegateAttribute.GetMethod;
						}
						if (this.m_sender == null)
						{
							this.m_sender = (context.PropertyDescriptor as CustomProperty.CustomPropertyDescriptor);
						}
						return this.m_MethodDelegate(this.m_sender, null);
					}
				}
			}
			return base.EditValue(provider, RuntimeHelpers.GetObjectValue(value));
		}
	}
}
