using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FAQ_Net
{
  public partial class EditImageForm : Form
  {
    private Image _sourceImage;
    public EditImageForm()
    {
      InitializeComponent();
    }

    private int _resultWidth;
    private int _resultHeight;

    public Image Picture
    {
      set
      {
        _sourceImage = value;
        int formWidth = this.Width;
        int formHeight = this.Height;
        tscmbScaleImagePersent_SelectedIndexChanged(null, null);
        if (_sourceImage.Width + 19> formWidth)
          this.Width = _sourceImage.Width + 19;
        if (_sourceImage.Height + 45 > formHeight)
          this.Height = _sourceImage.Height + 45;
        //pictureBoxImage.Image = ScaleImage(_sourceImage, _sourceImage.Width, _sourceImage.Height);
        //EditImageForm_Resize(null, null);
      }
      get
      {
        Image img = ScaleImage(_sourceImage, _resultWidth, _resultHeight);
        return img;
      }
    }

    public int PictureHeight
    {
      get { return pictureBoxImage.Height; }
    }

    private void tsbSave_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    private void EditImageForm_Resize(object sender, EventArgs e)
    {
      pictureBoxImage.Image = ScaleImage(_sourceImage, pictureBoxImage.Width, pictureBoxImage.Height);
    }

    /// <summary>
    /// Изменение размеров изображения с сохранением пропорций
    /// </summary>
    /// <param name="source">Исходное изображение</param>
    /// <param name="width">Ширина</param>
    /// <param name="height">Высота</param>
    /// <returns>Изображение с измененными пропорциями</returns>
    private Image ScaleImage(Image source, int width, int height)
    {

      Image dest = new Bitmap(width, height);
      using (Graphics gr = Graphics.FromImage(dest))
      {
        gr.FillRectangle(Brushes.White, 0, 0, width, height);  // Очищаем экран
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        float srcwidth = source.Width;
        float srcheight = source.Height;
        float dstwidth = width;
        float dstheight = height;

        if (srcwidth <= dstwidth && srcheight <= dstheight)  // Исходное изображение меньше целевого
        {
          _resultWidth = source.Width;
          _resultHeight = source.Height;
        }
        else if (srcwidth / srcheight > dstwidth / dstheight)  // Пропорции исходного изображения более широкие
        {
          float cy = srcheight / srcwidth * dstwidth;
          _resultWidth = Convert.ToInt32(dstwidth);
          _resultHeight = Convert.ToInt32(cy);
        }
        else  // Пропорции исходного изображения более узкие
        {
          float cx = srcwidth / srcheight * dstheight;
          _resultWidth = Convert.ToInt32(cx);
          _resultHeight = Convert.ToInt32(dstheight);
        }
        gr.DrawImage(source, 0, 0, _resultWidth, _resultHeight);

        return dest;
      }
    }

    public static System.Drawing.Bitmap CombineBitmap(string[] files)
    {
      //read all images into memory
      List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
      System.Drawing.Bitmap finalImage = null;

      try
      {
        int width = 0;
        int height = 0;

        foreach (string image in files)
        {
          //create a Bitmap from the file and add it to the list
          System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(image);

          //update the size of the final bitmap
          width += bitmap.Width;
          height = bitmap.Height > height ? bitmap.Height : height;

          images.Add(bitmap);
        }

        //create a bitmap to hold the combined image
        finalImage = new System.Drawing.Bitmap(width, height);

        //get a graphics object from the image so we can draw on it
        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
        {
          //set background color
          g.Clear(System.Drawing.Color.White);

          //go through each image and draw it on the final image
          int offset = 0;
          foreach (System.Drawing.Bitmap image in images)
          {
            g.DrawImage(image,
              new System.Drawing.Rectangle(offset, (height - image.Height) / 2, image.Width, image.Height));
            offset += image.Width + 5;
          }
        }

        return finalImage;
      }
      catch (Exception)
      {
        if (finalImage != null)
          finalImage.Dispose();
        //throw ex;
        throw;
      }
      finally
      {
        //clean up memory
        foreach (System.Drawing.Bitmap image in images)
        {
          image.Dispose();
        }
      }
    }

    public static byte[] ImageToByte(Image img)
    {
      ImageConverter converter = new ImageConverter();
      return (byte[])converter.ConvertTo(img, typeof(byte[]));
    }

    public static Image ByteToImage(byte[] byteArray)
    {
      return (Bitmap)((new ImageConverter()).ConvertFrom(byteArray));
    }

    private void tsbMaxWidthFormatA4_Click(object sender, EventArgs e)
    {
      tsbMaxWidthFormatA4.Checked = !tsbMaxWidthFormatA4.Checked;
      tscmbScaleImagePersent_SelectedIndexChanged(null, null);
    }

    private void tscmbScaleImagePersent_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (tscmbScaleImagePersent.Text == string.Empty)
        tscmbScaleImagePersent.SelectedIndex = tscmbScaleImagePersent.Items.IndexOf("100%");

      // Масштабирование в процентах
      int percent = Convert.ToInt32(tscmbScaleImagePersent.Text.Replace("%", ""));
      float scalePercent = ((float)percent / 100);
      int scaleWidth = (int)(_sourceImage.Width * scalePercent);
      int scaleHeight = (int)(_sourceImage.Height * scalePercent);

      if (tsbMaxWidthFormatA4.Checked)
      {
        int maxWidth = 714; // 714 - это MAX ширина изображения, которое умещается в ширине листа A4
        if (scaleWidth + 19 > maxWidth)
          scaleWidth = maxWidth;
        this.MaximumSize = new Size(maxWidth + 19, _sourceImage.Height + toolStrip1.Height + 45);
      }
      else
        this.MaximumSize = new Size(0, 0);

      pictureBoxImage.Image = ScaleImage(_sourceImage, scaleWidth, scaleHeight);
    }
  }
}
