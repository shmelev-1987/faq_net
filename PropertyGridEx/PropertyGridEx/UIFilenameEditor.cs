using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PropertyGridEx
{
	public class UIFilenameEditor : UITypeEditor
	{
		[AttributeUsage(AttributeTargets.Property)]
		public class FileDialogFilterAttribute : Attribute
		{
			private string _filter;

			public string Filter
			{
				get
				{
					return this._filter;
				}
			}

			public FileDialogFilterAttribute(string filter)
			{
				this._filter = filter;
			}
		}

		[AttributeUsage(AttributeTargets.Property)]
		public class SaveFileAttribute : Attribute
		{
			[DebuggerNonUserCode]
			public SaveFileAttribute()
			{
			}
		}

		public enum FileDialogType
		{
			LoadFileDialog,
			SaveFileDialog
		}

		[DebuggerNonUserCode]
		public UIFilenameEditor()
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
						FileDialog fileDialog;
						if (context.PropertyDescriptor.Attributes[typeof(UIFilenameEditor.SaveFileAttribute)] == null)
						{
							fileDialog = new OpenFileDialog();
						}
						else
						{
							fileDialog = new SaveFileDialog();
						}
						fileDialog.Title = "Select " + context.PropertyDescriptor.DisplayName;
						fileDialog.FileName = Conversions.ToString(value);
						UIFilenameEditor.FileDialogFilterAttribute fileDialogFilterAttribute = (UIFilenameEditor.FileDialogFilterAttribute)context.PropertyDescriptor.Attributes[typeof(UIFilenameEditor.FileDialogFilterAttribute)];
						if (fileDialogFilterAttribute != null)
						{
							fileDialog.Filter = fileDialogFilterAttribute.Filter;
						}
						if (fileDialog.ShowDialog() == DialogResult.OK)
						{
							value = fileDialog.FileName;
						}
						fileDialog.Dispose();
						return value;
					}
				}
			}
			return base.EditValue(provider, RuntimeHelpers.GetObjectValue(value));
		}
	}
}
