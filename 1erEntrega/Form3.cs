using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;

namespace _1erEntrega
{
    public partial class Form3 : Form
    {
        VideoCapture capture;
        int TotalFrames;
        int FPS;
        bool IsPlaying = false;
        Mat CurrentFrame;
        int CurrentFrameNo;
        private Bitmap original;
        int filter = 5;
        private int[] histogramaR = new int[256];
        private int[] histogramaG = new int[256];
        private int[] histogramaB = new int[256];
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Initialize the histogram picturebox with a blank histogram
            Bitmap emptyHistogram = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(emptyHistogram);
            g.Clear(this.BackColor);
            
            // Draw axes
            Pen plumaEjes = new Pen(Color.Coral);
            g.DrawLine(plumaEjes, 19, 271, 277, 271);
            g.DrawLine(plumaEjes, 19, 270, 19, 14);
            
            pictureBoxHistogram.Image = emptyHistogram;
            g.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsPlaying = false;
            
            // Optionally clear the histogram when stopping playback
            if (pictureBoxHistogram.Image != null)
            {
                Bitmap emptyHistogram = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(emptyHistogram);
                g.Clear(this.BackColor);
                
                // Draw axes
                Pen plumaEjes = new Pen(Color.Coral);
                g.DrawLine(plumaEjes, 19, 271, 277, 271);
                g.DrawLine(plumaEjes, 19, 270, 19, 14);
                
                pictureBoxHistogram.Image = emptyHistogram;
                g.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                IsPlaying = true;
                PlayVideo();
            }
            else
            {
                IsPlaying = false;
            }
        }

        private void cargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                capture = new VideoCapture(openFileDialog1.FileName);
                TotalFrames = Convert.ToInt32(capture.Get(Emgu.CV.CvEnum.CapProp.FrameCount));
                FPS = Convert.ToInt32(capture.Get(Emgu.CV.CvEnum.CapProp.Fps));
                IsPlaying = true;
                CurrentFrame = new Mat();
                CurrentFrameNo = 0;
                trackBar1.Minimum = 0;
                trackBar1.Maximum = TotalFrames - 1;
                trackBar1.Value = 0;
                PlayVideo();
                filter = default;
                filtroToolStripMenuItem.Enabled = true;

            }
        }

        private async void PlayVideo()
        {
            if (capture == null)
            {
                return;
            }
            try
            {
                while (IsPlaying == true && CurrentFrameNo < TotalFrames)
                {
                    capture.Set(Emgu.CV.CvEnum.CapProp.PosFrames, CurrentFrameNo);
                    capture.Read(CurrentFrame);

                    switch (filter)
                    {
                        case 0:
                            {
                                original = CurrentFrame.ToBitmap();
                                break;
                            }
                        case 1:
                            {
                                original = AberracionCromaticaFiltro(CurrentFrame.ToBitmap());
                                break;
                            }
                        case 2:
                            {
                                original = colorizarFiltro(CurrentFrame.ToBitmap());
                                break;
                            }
                        case 3:
                            {
                                original = contrasteFiltro(CurrentFrame.ToBitmap());
                                break;
                            }
                        case 4:
                            {
                                original = ruidoFiltro(CurrentFrame.ToBitmap());
                                break;
                            }
                        case 5:
                            {
                                original = InvertirFiltro(CurrentFrame.ToBitmap());
                                break;
                            }
                        case 6:
                            {
                                original = MosaicoFiltro(CurrentFrame.ToBitmap());
                                break;
                            }
                        case 7:
                            {
                                original = FlipFiltro(CurrentFrame.ToBitmap());
                                break;
                            }
                        case 8:
                            {
                                original = SupresionDFiltro(CurrentFrame.ToBitmap());
                                break;
                            }
                        case 9:
                            {
                                original = DegradadoFiltro(CurrentFrame.ToBitmap());
                                break;
                            }
                        case 10:
                            {
                                original = BrilloFiltro(CurrentFrame.ToBitmap());
                                break;
                            }
                        default:
                            {
                                original = CurrentFrame.ToBitmap();
                                break;
                            }
                    }

                    pictureBox1.Image = original;
                    trackBar1.Value = CurrentFrameNo;
                    
                    // Update histogram with the current frame
                    UpdateHistogram(original);

                    if (filter >= 5)
                    {
                        CurrentFrameNo += 1;
                    }
                    else
                    {
                        CurrentFrameNo += 3;
                    }

                    await Task.Delay(1000 / FPS);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsPlaying = false;
            CurrentFrameNo = 0;
            trackBar1.Value = 0;
            
            if (pictureBoxHistogram.Image != null)
            {
                pictureBoxHistogram.Image.Dispose();
                pictureBoxHistogram.Image = null;
            }
            
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            
            // Close the form - this will trigger the FormClosed event
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (capture != null)
            {
                CurrentFrameNo = trackBar1.Value;
            }
        }

        private Bitmap AberracionCromaticaFiltro(Bitmap Current)
        {
            int x = 0;
            int y = 0;
            int a = 8;

            int r = 0;
            int g = 0;
            int b = 0;

            for (x = 0; x < Current.Width; x++)
            {
                for (y = 0; y < Current.Height; y++)
                {
                    g = Current.GetPixel(x, y).G;

                    if (x + a < Current.Width)
                    {
                        r = Current.GetPixel(x + a, y).R;
                    }
                    else r = 0;
                    if (x - a >= 0)
                    {
                        b = Current.GetPixel(x - a, y).B;
                    }
                    else b = 0;

                    Current.SetPixel(x, y, Color.FromArgb(r, g, b));

                }
            }
            return Current;
        }

        private Bitmap colorizarFiltro(Bitmap current)
        {

            int x = 0;
            int y = 0;


            double rc = 120 / 255.0;
            double gc = 200 / 255.0;
            double bc = 120 / 255.0;

            Color miColor = new Color();
            int r = 0;
            int g = 0;
            int b = 0;

            //Crear la imagen en tonos de gris
            TonosdeGrisFiltro(current);

            for (x = 0; x < current.Width; x++)
            {
                for (y = 0; y < current.Height; y++)
                {
                    miColor = current.GetPixel(x, y);

                    r = (int)(miColor.R * rc);
                    g = (int)(miColor.G * gc);
                    b = (int)(miColor.B * bc);

                    current.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return current;
        }

        private Bitmap TonosdeGrisFiltro(Bitmap current)
        {

            int x = 0;
            int y = 0;
            Color colorResultante = new Color(); //color que resulta
            Color colorOriginal = new Color(); //color que obtenemos de la imagen
            float g = 0;
            for (x = 0; x < current.Width; x++)
            {
                for (y = 0; y < current.Height; y++)
                {
                    //Obtnemos el color del pixel
                    colorOriginal = current.GetPixel(x, y);
                    g = colorOriginal.R * 0.299f + colorOriginal.G * 0.587f + colorOriginal.B * 0.114f;

                    colorResultante = Color.FromArgb((int)g, (int)g, (int)g);

                    current.SetPixel(x, y, colorResultante);
                }
            }

            return current;
        }

        private Bitmap contrasteFiltro(Bitmap current)
        {
            //diferenciar entre areas mas iluminadas y más oscuras
            //el valor va de -100 a 100
            int contraste = 30;
            float c = (100.0f + contraste) / 100.0f;
            c *= c;
            int x = 0;
            int y = 0;

            Color colorResultante = new Color();
            Color colorOriginal = new Color();

            float r = 0;
            float g = 0;
            float b = 0;

            for (x = 0; x < current.Width; x++)
            {
                for (y = 0; y < current.Height; y++)
                {
                    //Get pixel color
                    colorOriginal = current.GetPixel(x, y);
                    //process and get the new colorxdd le salia el ingles de repente
                    r = ((((colorOriginal.R / 255.0f) - 0.5f) * c) + 0.5f) * 255;
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;

                    g = ((((colorOriginal.G / 255.0f) - 0.5f) * c) + 0.5f) * 255;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;

                    b = ((((colorOriginal.B / 255.0f) - 0.5f) * c) + 0.5f) * 255;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    colorResultante = Color.FromArgb((int)r, (int)g, (int)b);
                    current.SetPixel(x, y, colorResultante);
                }
            }


            return current;
        }

        private Bitmap BrilloFiltro(Bitmap current)
        {
            int brillo = 100;

            int x = 0;
            int y = 0;


            Color rColor = new Color();
            Color oColor = new Color();

            int r = 0;
            int g = 0;
            int b = 0;

            for (x = 0; x < current.Width; x++)
            {
                for (y = 0; y < current.Height; y++)
                {
                    oColor = current.GetPixel(x, y);

                    r = oColor.R + brillo;
                    g = oColor.G + brillo;
                    b = oColor.B + brillo;

                    if (r > 255) r = 255;
                    else if (r < 0) r = 0;

                    if (g > 255) g = 255;
                    else if (g < 0) g = 0;

                    if (b > 255) b = 255;
                    else if (b < 0) b = 0;

                    rColor = Color.FromArgb(r, g, b);

                    current.SetPixel(x, y, rColor);

                }
            }
            return current;
        }

        private Bitmap ruidoFiltro(Bitmap current)
        {
            int rangoMin = 50;
            int rangoMax = 195;
            float pBrillo;

            Random random = new Random();

            Color colorResultante;
            Color colorOriginal;

            int r, g, b;

            for (int x = 0; x < current.Width; x++)
            {
                for (int y = 0; y < current.Height; y++)
                {
                    if (random.Next(1, 100) <= 75)
                    {
                        //metodo 1 al color resultante le creamos un color al azar
                        colorResultante = Color.FromArgb(random.Next(rangoMin, rangoMax),
                            random.Next(rangoMin, rangoMax), random.Next(rangoMin, rangoMax));

                        //metodo2
                        pBrillo = random.Next(rangoMin, rangoMax) / 100.0f;
                        colorOriginal = current.GetPixel(x, y);
                        r = (int)(colorOriginal.R * pBrillo);
                        g = (int)(colorOriginal.G * pBrillo);
                        b = (int)(colorOriginal.B * pBrillo);

                        if (r > 255) r = 255;
                        else if (r < 0) r = 0;

                        if (g > 255) g = 255;
                        else if (g < 0) g = 0;

                        if (b > 255) b = 255;
                        else if (r < 0) b = 0;

                        colorResultante = Color.FromArgb(r, g, b);
                    }

                    else
                    {
                        colorResultante = current.GetPixel(x, y);
                    }

                    current.SetPixel(x, y, colorResultante);
                }
            }
            return current;
        }

        private Bitmap InvertirFiltro(Bitmap current)
        {
            int x = 0;
            int y = 0;
            Color colorResultante = new Color(); //color que resulta
            Color colorOriginal = new Color(); //color que obtenemos de la imagen

            for (x = 0; x < current.Width; x++)
            {
                for (y = 0; y < current.Height; y++)
                {
                    //obtener el color del pixel
                    colorOriginal = current.GetPixel(x, y);
                    //procesamos y obtenemos el nuevo color
                    colorResultante = Color.FromArgb(255 - colorOriginal.R, 255 - colorOriginal.G, 255 - colorOriginal.B);
                    //colocar el color en resultante
                    current.SetPixel(x, y, colorResultante);
                }
            }

            return current;
        }

        private Bitmap MosaicoFiltro(Bitmap current)
        {
            //mosaico imagina que recorre un area de tal tamaño y saca el promedio de color de esa area
            int mosaico = 8;
            int xm = 0;
            int ym = 0;

            Color colorResultante;
            Color colorOriginal;

            //sumas
            int rs, bs, gs;

            int r, g, b;

            for (int x = 0; x < current.Width - mosaico; x += mosaico)
            {
                for (int y = 0; y < current.Height - mosaico; y += mosaico)
                {
                    rs = 0;
                    gs = 0;
                    bs = 0;
                    //promedio
                    for (xm = x; xm < (x + mosaico); xm++)
                    {
                        for (ym = y; ym < (y + mosaico); ym++)
                        {
                            colorOriginal = current.GetPixel(xm, ym);
                            rs += colorOriginal.R;
                            gs += colorOriginal.G;
                            bs += colorOriginal.B;
                        }
                    }


                    r = rs / (mosaico * mosaico);
                    g = gs / (mosaico * mosaico);
                    b = bs / (mosaico * mosaico);
                    colorResultante = Color.FromArgb(r, g, b);

                    //Dibujar mosaico
                    for (xm = x; xm < (x + mosaico); xm++)
                    {
                        for (ym = y; ym < (y + mosaico); ym++)
                        {
                            current.SetPixel(xm, ym, colorResultante);
                        }
                    }
                }
            }

            return current;
        }

        private Bitmap FlipFiltro(Bitmap current)
        {
            int x = 0;
            int y = 0;
            // current = new Bitmap(original.Width, original.Height);
            Color rColor = new Color();
            Color oColor = new Color();

            //  float g = 0;

            for (x = 0; x < current.Width; x++)
            {
                for (y = 0; y < current.Height; y++)
                {
                    oColor = current.GetPixel(x, y);

                    rColor = Color.FromArgb(oColor.R, oColor.G, oColor.B);

                    current.SetPixel(current.Width - x - 1, y, rColor);
                }
            }
            return current;
        }

        private Bitmap SupresionDFiltro(Bitmap current)
        {
            Color colorResultante;
            Color colorOriginal;

            for (int x = 0; x < current.Width; x++)
            {
                for (int y = 0; y < current.Height; y++)
                {
                    // Obtener el color original del pixel
                    colorOriginal = current.GetPixel(x, y);

                    // Establecer el canal rojo en 0 y mantener los canales verde y azul
                    colorResultante = Color.FromArgb(0, colorOriginal.G, colorOriginal.B);

                    // Asignar el nuevo color al pixel en la imagen resultado
                    current.SetPixel(x, y, colorResultante);
                }
            }
            return current;
        }

        private Bitmap DegradadoFiltro(Bitmap current)
        {
            float r1 = 120;
            float g1 = 230;
            float b1 = 120;

            float r2 = 230;
            float g2 = 100;
            float b2 = 230;

            int r = 0;
            int g = 0;
            int b = 0;

            float dr = (r2 - r1) / original.Width;
            float dg = (g2 - g1) / original.Width;
            float db = (b2 - b1) / original.Width;

            int x = 0;
            int y = 0;

            Color oColor;

            TonosdeGrisFiltro(current);

            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    oColor = current.GetPixel(x, y);

                    r = (int)((r1 / 255.0f) * oColor.R);
                    g = (int)((g1 / 255.0f) * oColor.G);
                    b = (int)((b1 / 255.0f) * oColor.B);

                    if (r > 255) r = 255;
                    else if (r < 0) r = 0;

                    if (g > 255) g = 255;
                    else if (g < 0) g = 0;

                    if (b > 255) b = 255;
                    else if (b < 0) b = 0;

                    current.SetPixel(x, y, Color.FromArgb(r, g, b));
                }

                r1 = (r1 + dr);
                g1 = (g1 + dg);
                b1 = (b1 + db);
            }
            return current;
        }

        private void aberracionCromaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter = 1;
        }

        private void colorizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter = 2;
        }

        private void contrasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter = 3;
        }

        private void ruidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter = 4;
        }

        private void InvertirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            filter = 5;
        }

        private void mosaicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter = 6;
        }

        private void flipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter = 7;
        }

        private void supresorDeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter = 8;
        }

        private void degradadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter = 9;
        }

        private void brilloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter = 10;
        }

        private void UpdateHistogram(Bitmap currentFrame)
        {
            if (currentFrame == null) return;
            
            // Clear the histogram arrays
            Array.Clear(histogramaR, 0, histogramaR.Length);
            Array.Clear(histogramaG, 0, histogramaG.Length);
            Array.Clear(histogramaB, 0, histogramaB.Length);
            
            // Calculate histogram
            Color colorOriginal;
            for (int x = 0; x < currentFrame.Width; x++)
            {
                for (int y = 0; y < currentFrame.Height; y++)
                {
                    colorOriginal = currentFrame.GetPixel(x, y);
                    histogramaR[colorOriginal.R]++;
                    histogramaG[colorOriginal.G]++;
                    histogramaB[colorOriginal.B]++;
                }
            }
        
            // Find maximum value for scaling
            int mayor = 0;
            for (int n = 0; n < 256; n++)
            {
                if (histogramaR[n] > mayor)
                    mayor = histogramaR[n];
                if (histogramaG[n] > mayor)
                    mayor = histogramaG[n];
                if (histogramaB[n] > mayor)
                    mayor = histogramaB[n];
            }
        
            // Create a temporary copy of the histogram arrays for scaling
            int[] scaledHistR = new int[256];
            int[] scaledHistG = new int[256];
            int[] scaledHistB = new int[256];
        
            // Apply the same scaling as in Form4
            for (int n = 0; n < 256; n++)
            {
                scaledHistR[n] = (int)((float)histogramaR[n] / (float)mayor * 256.0f);
                scaledHistG[n] = (int)((float)histogramaG[n] / (float)mayor * 256.0f);
                scaledHistB[n] = (int)((float)histogramaB[n] / (float)mayor * 256.0f);
            }
        
            // Create bitmap for histogram
            Bitmap histogramBitmap = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(histogramBitmap);
            
            // Clear background with form's background color instead of black
            g.Clear(this.BackColor);
            
            // Create pens
            Pen plumaR = new Pen(Color.Red);
            Pen plumaG = new Pen(Color.Green);
            Pen plumaB = new Pen(Color.Blue);
            Pen plumaEjes = new Pen(Color.Coral);
            
            // Draw axes - match Form4's coordinates
            g.DrawLine(plumaEjes, 19, 271, 277, 271);
            g.DrawLine(plumaEjes, 19, 270, 19, 14);
            
            // Draw histogram bars using the scaled values directly (like Form4)
            for (int n = 0; n < 256; n++)
            {
                g.DrawLine(plumaR, n + 20, 270, n + 20, 270 - scaledHistR[n]);
                g.DrawLine(plumaG, n + 20, 270, n + 20, 270 - scaledHistG[n]);
                g.DrawLine(plumaB, n + 20, 270, n + 20, 270 - scaledHistB[n]);
            }
            
            // Display histogram
            pictureBoxHistogram.Image = histogramBitmap;
            g.Dispose();
        }
    }
}
