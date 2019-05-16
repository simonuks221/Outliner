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

        public Bitmap generatedPicture;

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

                //Setup pixel info and populate pixelInfos
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

                //Populate pixel differences
                for (int x = 0; x < selectedImage.Size.Width; x++)
                {
                    for (int y = 0; y < selectedImage.Size.Height; y++)
                    {
                        Color avarageNeighbourColor = GetAvarageNeighbourColor(new Point(x, y));
                        pixelInfos[x, y].pixelDifference = ColorDifference(pixelInfos[x, y].pixelColor, avarageNeighbourColor);
                    }
                }

                UpdateShownImage(SensitivitySlider.Value);
            }
            else
            {
                throw new Exception("Selected nothing or other exeption");
            }
        }


        Color GetAvarageNeighbourColor(Point _pixelLocation)
        {
            int r = 0, g = 0, b = 0, n = 0;
            for(int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x != 0 && y != 0) //Not the same pixel
                    {
                        if (_pixelLocation.X + x >= 0 && _pixelLocation.Y + y >= 0 && _pixelLocation.X + x < selectedImage.Width && _pixelLocation.Y + y < selectedImage.Height)
                        {
                            r += pixelInfos[_pixelLocation.X + x, _pixelLocation.Y + y].pixelColor.R;
                            g += pixelInfos[_pixelLocation.X + x, _pixelLocation.Y + y].pixelColor.G;
                            b += pixelInfos[_pixelLocation.X + x, _pixelLocation.Y + y].pixelColor.B;
                            n++;
                        }
                    }
                }
            }
            r = r / n;
            g = g / n;
            b = b / n;
            return Color.FromArgb(r, g, b);
        }

        int ColorDifference(Color _color1, Color _color2)
        {
            return _color1.R - _color2.R + _color1.B - _color2.B + _color1.G - _color2.G;
        }

        void UpdateShownImage(int _differenceValue)
        {
            generatedPicture = new Bitmap(selectedImage);

            for (int x = 0; x < selectedImage.Size.Width; x++)
            {
                for (int y = 0; y < selectedImage.Size.Height; y++)
                {
                    if (pixelInfos[x, y].pixelDifference < _differenceValue)
                    {
                        generatedPicture.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        generatedPicture.SetPixel(x, y, Color.Black);
                    }
                }
            }

            MainPictureBox.Image = generatedPicture;
        }

        private void SensitivitySlider_ValueChanged(object sender, EventArgs e)
        {
            UpdateShownImage(SensitivitySlider.Value);
        }

        private void SensitivitySlider_MouseCaptureChanged(object sender, EventArgs e)
        {
            UpdateShownImage(SensitivitySlider.Value);
        }

        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                generatedPicture.Save(saveFileDialog.FileName);
            }
        }
    }

    public class PixelInfo
    {
        public Color pixelColor;
        public Point pixelLocation;
        public int pixelDifference;

        public PixelInfo(Color _pixelColor, Point _pixelLocation)
        {
            pixelColor = _pixelColor;
            pixelLocation = _pixelLocation;
            pixelDifference = 0;
        }
    }
}
