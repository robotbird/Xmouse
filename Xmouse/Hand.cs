using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Xmouse
{
    public partial class Hand : Form
    {
        //TODO:更高级的切换样式
        public Hand()
        {
            InitializeComponent();
        }

        private void Hand_Load(object sender, EventArgs e)
        {
            Tools.SetMid(this);
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;

            this.pictureBox1.Image = ToTransparent(this.pictureBox1.Image,0.1f);
           // String imgpath = AppDomain.CurrentDomain.BaseDirectory + @"\img\hand-left-bo.png";
            //this.BackgroundImage = Image.FromFile(imgpath);

          //  this.BackgroundImage = imgAlpha(new Bitmap(imgpath),10000);
           
            
           
        }

        /// <summary>
        /// 透明度调整
        /// </summary>
        /// <param name="image"></param>
        /// <param name="opacity">  0.1  -- 1 </param>
        /// <returns></returns>
        public Image ToTransparent(Image image, float opacity)
        {
            if (opacity >= 1 || opacity < 0) return image;//透明度应在0.1 - 1之间
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                var matrix = new ColorMatrix { Matrix33 = opacity };
                var attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                var rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                g.DrawImage(image, rectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bitmap;
        }


        public void ShowLeftHand()
        {
           // Bitmap img = Image.FromFile("img/hand-left-big.png");
            Image image = Image.FromFile("img/hand-left-big.png");
            // this.BackgroundImage = imgAlpha(new Bitmap("img/hand-left-big.png"),12000);
            this.BackgroundImage =image;
            this.Show();
        }

        //改变图片的透明度
        private Image ChangeAlpha(Image image)
        {
            Bitmap img = new Bitmap(image);
            using (Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(img, 0, 0);
                    for (int h = 0; h <= img.Height - 1; h++)
                    {
                        for (int w = 0; w <= img.Width - 1; w++)
                        {
                            Color c = img.GetPixel(w, h);
                            bmp.SetPixel(w, h, Color.FromArgb(20, c.R, c.G, c.B));
                        }
                    }
                    return (Image)bmp.Clone();
                }
            }
        }

        /// <summary>
        /// 调节图片的透明度
        /// </summary>
        /// <param name="bitmapImg">图像对象</param>
        /// <param name="alpha">调节度</param>
        /// <returns>调节后的图形对象</returns>
        public static Image imgAlpha(Bitmap bitmapImg, int alpha)
        {
            Bitmap bitmap = new Bitmap(bitmapImg.Width, bitmapImg.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int h = 0; h < bitmapImg.Height; h++)
            {
                for (int w = 0; w < bitmapImg.Width; w++)
                {
                    Color color = bitmapImg.GetPixel(w, h);
                    bitmap.SetPixel(w, h, Color.FromArgb(alpha / 100, color.R, color.G, color.B));
                }
            }
            return (Image)bitmap.Clone();
        }
       


    }
}
