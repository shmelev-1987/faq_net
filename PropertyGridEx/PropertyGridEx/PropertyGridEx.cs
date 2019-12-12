using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
//using System.Windows.Forms.Design;

namespace PropertyGridEx
{
	[DesignerGenerated, /*Designer(typeof(System.Windows.Forms.ControlDesigner)),*/ ToolboxBitmap(typeof(PropertyGridEx))]
	public class PropertyGridEx : PropertyGrid
	{
		private IContainer components;

		protected CustomPropertyCollection oCustomPropertyCollection;

		protected bool bShowCustomProperties;

		protected CustomPropertyCollectionSet oCustomPropertyCollectionSet;

		protected bool bShowCustomPropertiesSet;

		protected object oPropertyGridView;

		protected object oHotCommands;

		protected object oDocComment;

		protected ToolStrip oToolStrip;

		protected Label oDocCommentTitle;

		protected Label oDocCommentDescription;

		protected FieldInfo oPropertyGridEntries;

		protected bool bAutoSizeProperties;

		protected bool bDrawFlatToolbar;

		[Category("Behavior"), Description("Set the collection of the CustomProperty. Set ShowCustomProperties to True to enable it."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), RefreshProperties(RefreshProperties.Repaint)]
		public CustomPropertyCollection Item
		{
			get
			{
				return this.oCustomPropertyCollection;
			}
		}

		[Category("Behavior"), Description("Set the CustomPropertyCollectionSet. Set ShowCustomPropertiesSet to True to enable it."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), RefreshProperties(RefreshProperties.Repaint)]
		public CustomPropertyCollectionSet ItemSet
		{
			get
			{
				return this.oCustomPropertyCollectionSet;
			}
		}

		[Category("Behavior"), DefaultValue(false), Description("Move automatically the splitter to better fit all the properties shown.")]
		public bool AutoSizeProperties
		{
			get
			{
				return this.bAutoSizeProperties;
			}
			set
			{
				this.bAutoSizeProperties = value;
				if (value)
				{
					this.AutoSizeSplitter(32);
				}
			}
		}

		[Category("Behavior"), DefaultValue(false), Description("Use the custom properties collection as SelectedObject."), RefreshProperties(RefreshProperties.All)]
		public bool ShowCustomProperties
		{
			get
			{
				return this.bShowCustomProperties;
			}
			set
			{
				if (value)
				{
					this.bShowCustomPropertiesSet = false;
					base.SelectedObject = this.oCustomPropertyCollection;
				}
				this.bShowCustomProperties = value;
			}
		}

		[Category("Behavior"), DefaultValue(false), Description("Use the custom properties collections as SelectedObjects."), RefreshProperties(RefreshProperties.All)]
		public bool ShowCustomPropertiesSet
		{
			get
			{
				return this.bShowCustomPropertiesSet;
			}
			set
			{
				if (value)
				{
					this.bShowCustomProperties = false;
					base.SelectedObjects = (object[])this.oCustomPropertyCollectionSet.ToArray();
				}
				this.bShowCustomPropertiesSet = value;
			}
		}

		[Category("Appearance"), DefaultValue(false), Description("Draw a flat toolbar")]
		public new bool DrawFlatToolbar
		{
			get
			{
				return this.bDrawFlatToolbar;
			}
			set
			{
				this.bDrawFlatToolbar = value;
				this.ApplyToolStripRenderMode(this.bDrawFlatToolbar);
			}
		}

		[Browsable(true), Category("Appearance"), Description("Toolbar object"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DisplayName("Toolstrip")]
		public ToolStrip ToolStrip
		{
			get
			{
				return this.oToolStrip;
			}
		}

		[Browsable(false), Category("Appearance"), Description("DocComment object. Represent the comments area of the PropertyGrid."), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DisplayName("Help")]
		public Control DocComment
		{
			get
			{
				return (Control)this.oDocComment;
			}
		}

		[Browsable(true), Category("Appearance"), Description("Help Title Label."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DisplayName("HelpTitle")]
		public Label DocCommentTitle
		{
			get
			{
				return this.oDocCommentTitle;
			}
		}

		[Browsable(true), Category("Appearance"), Description("Help Description Label."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DisplayName("HelpDescription")]
		public Label DocCommentDescription
		{
			get
			{
				return this.oDocCommentDescription;
			}
		}

		[Category("Appearance"), Description("Help Image Background."), DisplayName("HelpImageBackground")]
		public Image DocCommentImage
		{
			get
			{
				return (Image)NewLateBinding.LateGet(this.oDocComment, null, "BackgroundImage", new object[0], null, null, null);
			}
			set
			{
				NewLateBinding.LateSet(this.oDocComment, null, "BackgroundImage", new object[]
				{
					value
				}, null, null);
			}
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new Container();
			this.AutoScaleMode = AutoScaleMode.Font;
		}

		public PropertyGridEx()
		{
			this.InitializeComponent();
			this.DoubleBuffered = true;
			this.oCustomPropertyCollection = new CustomPropertyCollection();
			this.oCustomPropertyCollectionSet = new CustomPropertyCollectionSet();
			this.oPropertyGridView = RuntimeHelpers.GetObjectValue(base.GetType().BaseType.InvokeMember("gridView", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, this, null));
			this.oHotCommands = RuntimeHelpers.GetObjectValue(base.GetType().BaseType.InvokeMember("hotcommands", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, this, null));
			this.oToolStrip = (ToolStrip)base.GetType().BaseType.InvokeMember("toolStrip", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, this, null);
			this.oDocComment = RuntimeHelpers.GetObjectValue(base.GetType().BaseType.InvokeMember("doccomment", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, this, null));
			if (this.oDocComment != null)
			{
				this.oDocCommentTitle = (Label)this.oDocComment.GetType().InvokeMember("m_labelTitle", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, RuntimeHelpers.GetObjectValue(this.oDocComment), null);
				this.oDocCommentDescription = (Label)this.oDocComment.GetType().InvokeMember("m_labelDesc", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, RuntimeHelpers.GetObjectValue(this.oDocComment), null);
			}
			if (this.oPropertyGridView != null)
			{
				this.oPropertyGridEntries = this.oPropertyGridView.GetType().GetField("allGridEntries", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);
			}
			if (this.oToolStrip != null)
			{
				this.ApplyToolStripRenderMode(this.bDrawFlatToolbar);
			}
		}

		public void MoveSplitterTo(int x)
		{
			this.oPropertyGridView.GetType().InvokeMember("MoveSplitterTo", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, RuntimeHelpers.GetObjectValue(this.oPropertyGridView), new object[]
			{
				x
			});
		}

		public override void Refresh()
		{
			if (this.bShowCustomPropertiesSet)
			{
				base.SelectedObjects = (object[])this.oCustomPropertyCollectionSet.ToArray();
			}
			try
			{
				base.Refresh();
			}
			catch (Exception expr_26)
			{
				ProjectData.SetProjectError(expr_26);
				Exception ex = expr_26;
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Erro");
				ProjectData.ClearProjectError();
			}
			if (this.bAutoSizeProperties)
			{
				this.AutoSizeSplitter(32);
			}
		}

		public void SetComment(string title, string description)
		{
			object arg_31_0 = this.oDocComment;
			Type arg_31_1 = null;
			string arg_31_2 = "SetComment";
			object[] array = new object[]
			{
				title,
				description
			};
			object[] arg_31_3 = array;
			string[] arg_31_4 = null;
			Type[] arg_31_5 = null;
			bool[] array2 = new bool[]
			{
				true,
				true
			};
			NewLateBinding.LateCall(arg_31_0, arg_31_1, arg_31_2, arg_31_3, arg_31_4, arg_31_5, array2, true);
			if (array2[0])
			{
				title = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			if (array2[1])
			{
				description = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this.bAutoSizeProperties)
			{
				this.AutoSizeSplitter(32);
			}
		}

		protected void AutoSizeSplitter(int RightMargin = 32)
		{
			GridItemCollection gridItemCollection = (GridItemCollection)this.oPropertyGridEntries.GetValue(RuntimeHelpers.GetObjectValue(this.oPropertyGridView));
			if (gridItemCollection == null)
			{
				return;
			}
			Graphics graphics = Graphics.FromHwnd(this.Handle);
			int num = 0;
      IEnumerator enumerator = null;
      try
			{
        enumerator = gridItemCollection.GetEnumerator();
				while (enumerator.MoveNext())
				{
					GridItem gridItem = (GridItem)enumerator.Current;
					if (gridItem.GridItemType == GridItemType.Property)
					{
						int num2 = checked((int)Math.Round((double)(unchecked(graphics.MeasureString(gridItem.Label, this.Font).Width + (float)RightMargin))));
						if (num2 > num)
						{
							num = num2;
						}
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
			this.MoveSplitterTo(num);
		}

		protected void ApplyToolStripRenderMode(bool value)
		{
			if (value)
			{
				this.oToolStrip.Renderer = new ToolStripSystemRenderer();
			}
			else
			{
				ToolStripProfessionalRenderer toolStripProfessionalRenderer = new ToolStripProfessionalRenderer(new CustomColorScheme());
				toolStripProfessionalRenderer.RoundedEdges = false;
				this.oToolStrip.Renderer = toolStripProfessionalRenderer;
			}
		}
	}
}
