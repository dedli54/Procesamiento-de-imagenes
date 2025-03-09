using Emgu.CV;
using Emgu.CV.Structure;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace _1erEntrega
{
    public partial class Form2 : Form
    {
        FilterInfoCollection filterInfoCollection;
        private VideoCapture camera;
        private bool OpenCamera = true;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            comboBoxCamera.Items.Add(filterInfo.Name);
            comboBoxCamera.SelectedIndex = 0;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            camera = new VideoCapture(comboBoxCamera.SelectedIndex);

            if (!camera.IsOpened)
            {
                MessageBox.Show("No hay cámaras disponibles.");
                return;
            }

            while (OpenCamera)
            {
                using (var frame = camera.QueryFrame().ToImage<Bgr, Byte>())
                {
                    if (frame == null)
                        break;

                    // Agarra color dominante 
                    KeyValuePair<Color, int> dominantColor = GetDominantColor(frame);
                    
                    // dibujar cajita de color
                    DrawColorBox(frame, dominantColor.Key);
                    
                    // Display del mombre y valores rgb
                    string colorName = GetColorName(dominantColor.Key);
                    string colorInfo = $"{colorName} - R:{dominantColor.Key.R}, G:{dominantColor.Key.G}, B:{dominantColor.Key.B}";
                    CvInvoke.PutText(frame, colorInfo, new Point(10, 30), 
                                     Emgu.CV.CvEnum.FontFace.HersheyDuplex, 0.6, 
                                     new MCvScalar(255, 255, 255));

                    // Actualizar la imagen en CameraBox desde el hilo principal
                    CameraBox.Invoke((MethodInvoker)delegate
                    {
                        CameraBox.Image = frame.ToBitmap();
                    });

                    // Salir si se presiona una tecla o si se cierra el formulario
                    if (CvInvoke.WaitKey(1) >= 0 || !OpenCamera)
                        break;
                }
            }

            camera.Dispose();
        }

        private KeyValuePair<Color, int> GetDominantColor(Image<Bgr, byte> image)
        {
            // Low ress para performance
            int sampleWidth = 50;
            int sampleHeight = 50;
            
            Image<Bgr, byte> resizedImage = image.Resize(sampleWidth, sampleHeight, Emgu.CV.CvEnum.Inter.Linear);
            
            // Dictionary for the colors
            Dictionary<Color, int> colorCounts = new Dictionary<Color, int>();
            
            // see each pixel color 
            for (int y = 0; y < resizedImage.Height; y++)
            {
                for (int x = 0; x < resizedImage.Width; x++)
                {
                    Bgr pixel = resizedImage[y, x];
                    // bgr a stardar color
                    Color color = Color.FromArgb(
                        (int)(pixel.Red), 
                        (int)(pixel.Green), 
                        (int)(pixel.Blue));
                    
                    // simplify to make it easier to recognice the color lmao
                    color = SimplifyColor(color);
                    
                    if (colorCounts.ContainsKey(color))
                    {
                        colorCounts[color]++;
                    }
                    else
                    {
                        colorCounts.Add(color, 1);
                    }
                }
            }
            
            // highest count, es el color
            return colorCounts.OrderByDescending(c => c.Value).First();
        }
        
        private Color SimplifyColor(Color color)
        {
            // Quantize colors to reduce number of unique colors, basically limit the amount of colors avelibale
            int quantizationLevel = 32;
            int r = ((color.R + quantizationLevel / 2) / quantizationLevel) * quantizationLevel;
            int g = ((color.G + quantizationLevel / 2) / quantizationLevel) * quantizationLevel;
            int b = ((color.B + quantizationLevel / 2) / quantizationLevel) * quantizationLevel;
            
            // Clamp values
            r = Math.Min(255, Math.Max(0, r));
            g = Math.Min(255, Math.Max(0, g));
            b = Math.Min(255, Math.Max(0, b));
            
            return Color.FromArgb(r, g, b);
        }
        
        private void DrawColorBox(Image<Bgr, byte> frame, Color color)
        {
            // squere of the dominant color
            int boxSize = 60;
            Rectangle rect = new Rectangle(frame.Width - boxSize - 10, 10, boxSize, boxSize);
            
            // fill the rectangle 
            CvInvoke.Rectangle(frame, rect, new MCvScalar(color.B, color.G, color.R), -1);
            
            // un borde pa que se vea
            CvInvoke.Rectangle(frame, rect, new MCvScalar(255, 255, 255), 2);
        }
        
        private string GetColorName(Color color)
        {
            // No me se mas colores, pero este es el dicionario
            if (color.R > 200 && color.G < 100 && color.B < 100) return "Rojo";
            if (color.R > 200 && color.G > 200 && color.B < 100) return "Amarillo";
            if (color.R < 100 && color.G > 200 && color.B < 100) return "Verde";
            if (color.R < 100 && color.G < 100 && color.B > 200) return "Azul";
            if (color.R > 200 && color.G < 100 && color.B > 200) return "Magenta";
            if (color.R < 100 && color.G > 200 && color.B > 200) return "Azul Clarito";
            if (color.R > 200 && color.G > 150 && color.B > 50 && color.G < 200) return "Naranaja";
            if (color.R > 200 && color.G > 100 && color.B > 100) return "Rosa";
            if (color.R < 100 && color.G < 100 && color.B < 100) return "Negro";
            if (color.R > 200 && color.G > 200 && color.B > 200) return "Blanco";
       
            
            return "No se";
        }
                private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCamera = false;
            if (camera != null)
            {
                camera.Dispose();
            }
            
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            OpenCamera = false;
            if (camera != null)
            {
                camera.Dispose();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CameraBox_Click(object sender, EventArgs e)
        {
        }
    }
}
