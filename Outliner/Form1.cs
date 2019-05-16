using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Outliner
{

    public partial class Form1 : Form
    {
        PixelInfo[,] pixelInfos;

        public Image selectedImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);

                selectedImage = Image.FromStream(reader.BaseStream);
                MainPictureBox.Size = selectedImage.Size;
                MainPictureBox.Image = selectedImage;

                //Setup pixel info
                pixelInfos = new PixelInfo[selectedImage.Size.Width, selectedImage.Size.Height];
                Bitmap bitmap = new Bitmap(selectedImage);
                for (int x = 0; x < selectedImage.Size.Width; x++)
                {
                    for (int y = 0; y < selectedImage.Size.Height; y++)
                    {
                        PixelInfo newPixelInfo = new PixelInfo(bitmap.GetPixel(x, y), new Point(x, y));
                        pixelInfos[x, y] = newPixelInfo;
                    }
                }

            }
            else
            {
                throw new Exception("Selected nothing or other exeption");
            }
        }
    }

    public class PixelInfo
    {
        public Color pixelColor;
        public Point pixelLocation;

        public PixelInfo(Color _pixelColor, Point _pixelLocation)
        {
            pixelColor = _pixelColor;
            pixelLocation = _pixelLocation;
        }
    }
}
