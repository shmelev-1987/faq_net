using System;
using System.ComponentModel;
using System.Text;

namespace GradientControls
{
  public class GradientEnums
  {
    public enum FillColorMode
    {
      //[DescriptionAttribute("Сплошная заливка")]
      [DescriptionAttribute("Full")]
      Full,

      //[DescriptionAttribute("Градиентная заливка")]
      [DescriptionAttribute("Gradient")]
      Gradient
    }
  }
}
