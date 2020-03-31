using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PropertyGridEx
{
  public class CustomColorScheme : ProfessionalColorTable
  {
    public override Color ButtonCheckedGradientBegin
    {
      get
      {
        return Color.FromArgb(193, 210, 238);
      }
    }

    public override Color ButtonCheckedGradientEnd
    {
      get
      {
        return Color.FromArgb(193, 210, 238);
      }
    }

    public override Color ButtonCheckedGradientMiddle
    {
      get
      {
        return Color.FromArgb(193, 210, 238);
      }
    }

    public override Color ButtonPressedBorder
    {
      get
      {
        return Color.FromArgb(49, 106, 197);
      }
    }

    public override Color ButtonPressedGradientBegin
    {
      get
      {
        return Color.FromArgb(152, 181, 226);
      }
    }

    public override Color ButtonPressedGradientEnd
    {
      get
      {
        return Color.FromArgb(152, 181, 226);
      }
    }

    public override Color ButtonPressedGradientMiddle
    {
      get
      {
        return Color.FromArgb(152, 181, 226);
      }
    }

    public override Color ButtonSelectedBorder
    {
      get
      {
        return base.ButtonSelectedBorder;
      }
    }

    public override Color ButtonSelectedGradientBegin
    {
      get
      {
        return Color.FromArgb(193, 210, 238);
      }
    }

    public override Color ButtonSelectedGradientEnd
    {
      get
      {
        return Color.FromArgb(193, 210, 238);
      }
    }

    public override Color ButtonSelectedGradientMiddle
    {
      get
      {
        return Color.FromArgb(193, 210, 238);
      }
    }

    public override Color CheckBackground
    {
      get
      {
        return Color.FromArgb(225, 230, 232);
      }
    }

    public override Color CheckPressedBackground
    {
      get
      {
        return Color.FromArgb(49, 106, 197);
      }
    }

    public override Color CheckSelectedBackground
    {
      get
      {
        return Color.FromArgb(49, 106, 197);
      }
    }

    public override Color GripDark
    {
      get
      {
        return Color.FromArgb(193, 190, 179);
      }
    }

    public override Color GripLight
    {
      get
      {
        return Color.FromArgb(255, 255, 255);
      }
    }

    public override Color ImageMarginGradientBegin
    {
      get
      {
        return Color.FromArgb(251, 250, 247);
      }
    }

    public override Color ImageMarginGradientEnd
    {
      get
      {
        return Color.FromArgb(189, 189, 163);
      }
    }

    public override Color ImageMarginGradientMiddle
    {
      get
      {
        return Color.FromArgb(236, 231, 224);
      }
    }

    public override Color ImageMarginRevealedGradientBegin
    {
      get
      {
        return Color.FromArgb(247, 246, 239);
      }
    }

    public override Color ImageMarginRevealedGradientEnd
    {
      get
      {
        return Color.FromArgb(230, 227, 210);
      }
    }

    public override Color ImageMarginRevealedGradientMiddle
    {
      get
      {
        return Color.FromArgb(242, 240, 228);
      }
    }

    public override Color MenuBorder
    {
      get
      {
        return Color.FromArgb(138, 134, 122);
      }
    }

    public override Color MenuItemBorder
    {
      get
      {
        return Color.FromArgb(49, 106, 197);
      }
    }

    public override Color MenuItemPressedGradientBegin
    {
      get
      {
        return base.MenuItemPressedGradientBegin;
      }
    }

    public override Color MenuItemPressedGradientEnd
    {
      get
      {
        return base.MenuItemPressedGradientEnd;
      }
    }

    public override Color MenuItemPressedGradientMiddle
    {
      get
      {
        return base.MenuItemPressedGradientMiddle;
      }
    }

    public override Color MenuItemSelected
    {
      get
      {
        return Color.FromArgb(193, 210, 238);
      }
    }

    public override Color MenuItemSelectedGradientBegin
    {
      get
      {
        return Color.FromArgb(193, 210, 238);
      }
    }

    public override Color MenuItemSelectedGradientEnd
    {
      get
      {
        return Color.FromArgb(193, 210, 238);
      }
    }

    public override Color MenuStripGradientBegin
    {
      get
      {
        return Color.FromArgb(229, 229, 215);
      }
    }

    public override Color MenuStripGradientEnd
    {
      get
      {
        return Color.FromArgb(244, 242, 232);
      }
    }

    public override Color OverflowButtonGradientBegin
    {
      get
      {
        return Color.FromArgb(243, 242, 240);
      }
    }

    public override Color OverflowButtonGradientEnd
    {
      get
      {
        return Color.FromArgb(146, 146, 118);
      }
    }

    public override Color OverflowButtonGradientMiddle
    {
      get
      {
        return Color.FromArgb(226, 225, 219);
      }
    }

    public override Color RaftingContainerGradientBegin
    {
      get
      {
        return Color.FromArgb(229, 229, 215);
      }
    }

    public override Color RaftingContainerGradientEnd
    {
      get
      {
        return Color.FromArgb(244, 242, 232);
      }
    }

    public override Color SeparatorDark
    {
      get
      {
        return Color.FromArgb(197, 194, 184);
      }
    }

    public override Color SeparatorLight
    {
      get
      {
        return Color.FromArgb(255, 255, 255);
      }
    }

    public override Color ToolStripBorder
    {
      get
      {
        return Color.FromArgb(163, 163, 124);
      }
    }

    public override Color ToolStripDropDownBackground
    {
      get
      {
        return Color.FromArgb(252, 252, 249);
      }
    }

    public override Color ToolStripGradientBegin
    {
      get
      {
        return Color.FromArgb(247, 246, 239);
      }
    }

    public override Color ToolStripGradientEnd
    {
      get
      {
        return Color.FromArgb(192, 192, 168);
      }
    }

    public override Color ToolStripGradientMiddle
    {
      get
      {
        return Color.FromArgb(242, 240, 228);
      }
    }

    public override Color ToolStripPanelGradientBegin
    {
      get
      {
        return Color.FromArgb(229, 229, 215);
      }
    }

    public override Color ToolStripPanelGradientEnd
    {
      get
      {
        return Color.FromArgb(244, 242, 232);
      }
    }

    [DebuggerNonUserCode]
    public CustomColorScheme()
    {
    }
  }
}
