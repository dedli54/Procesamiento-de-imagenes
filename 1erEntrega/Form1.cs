﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace _1erEntrega
{
    public partial class Form1 : Form
    {
        private Bitmap original;
        private Bitmap resultado;
        private Bitmap apilado;
        private string rutaAux;
        private int[] histogramaR = new int[256];
        private int[] histogramaG = new int[256];
        private int[] histogramaB = new int[256];
        // No need to add a histogramaCombinado array since we're just displaying the three channels together
        private int porcentaje;
        int contraste;
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Form2 newWindow = new Form2();
            
         
            newWindow.FormClosed += (s, args) => this.Show();
            
          
            this.Hide();
            
        
            newWindow.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Form3 newWindow = new Form3();
            
        
            newWindow.FormClosed += (s, args) => this.Show();
            
  
            this.Hide();
            
          
            newWindow.Show();
        }

    
      
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void filtroDeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            resultado = new Bitmap(original.Width, original.Height);
            Color rColor = new Color();
            Color oColor = new Color();

            //  float g = 0;

            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);

                    rColor = Color.FromArgb(oColor.R, oColor.G, oColor.B);

                    resultado.SetPixel(original.Width - x - 1, y, rColor);
                }
            }
            pictureBox1.Image = resultado;
            apilado = resultado;
            UpdateHistogram();

            this.Invalidate();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                original = (Bitmap)(Bitmap.FromFile(openFileDialog1.FileName));
                rutaAux = openFileDialog1.FileName;
                resultado = original;
                apilado = resultado;
                
                // Remove the bg image wehn an image is loaded
                pictureBox1.BackgroundImage = null;
                
                UpdateHistogram();
            }

            if (original != null)
            {
                filtrosToolStripMenuItem1.Enabled = true;
                pictureBox1.Image = resultado;
                UpdateHistogram();
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                resultado.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            double rc = 120 / 255.0;
            double gc = 200 / 255.0;
            double bc = 120 / 255.0;
            Color miColor = new Color();
            int r, g, b;

            //Crear la imagen en tonos de gris
            tonosDeGrisToolStripMenuItem_Click(sender, e);

            for (int x = 0; x < apilado.Width; x++)
            {
                for (int y = 0; y < apilado.Height; y++)
                {
                    miColor = resultado.GetPixel(x, y);

                    r = (int)(miColor.R * rc);
                    g = (int)(miColor.G * gc);
                    b = (int)(miColor.B * bc);

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            pictureBox1.Image = resultado;
            apilado = resultado;
            UpdateHistogram();

        }

        private void tonosDeGrisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color colorResultante;
            Color colorOriginal;

            float Grises;

            for (int x = 0; x < apilado.Width; x++)
            {
                for (int y = 0; y < apilado.Height; y++)
                {
                    colorOriginal = apilado.GetPixel(x, y);

                    Grises = colorOriginal.R * 0.267f + colorOriginal.G * 0.678f + colorOriginal.B * 0.0593f;
                    
                    Grises = Clamp(Grises, 0, 255);
                    // Create the grayscale color
                    colorResultante = Color.FromArgb((int)Grises, (int)Grises, (int)Grises);
                    resultado.SetPixel(x, y, colorResultante);
                }
            }

            pictureBox1.Image = resultado;
            apilado = resultado;
        }

        private float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private void fContrast(object sender, EventArgs e, int Sporcentaje)
        {
            //diferenciar entre areas mas iluminadas y más oscuras
            //el valor va de -100 a 100
            float totalContraste = (100.0f + contraste) / 100.0f;
            totalContraste *= totalContraste;
            int x, y;

            Color colorResultante = new Color();
            Color colorOriginal = new Color();

            float r, g, b;

            for (x = 0; x < apilado.Width; x++)
            {
                for (y = 0; y < apilado.Height; y++)
                {
                    //Get pixel color
                    colorOriginal = apilado.GetPixel(x, y);
                    //process and get the new colorxdd
                    r = ((((colorOriginal.R / 255.0f) - 0.5f) * totalContraste) + 0.5f) * 255;
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;

                    g = ((((colorOriginal.G / 255.0f) - 0.5f) * totalContraste) + 0.5f) * 255;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;

                    b = ((((colorOriginal.B / 255.0f) - 0.5f) * totalContraste) + 0.5f) * 255;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;

                    colorResultante = Color.FromArgb((int)r, (int)g, (int)b);
                    resultado.SetPixel(x, y, colorResultante);
                }
            }


            pictureBox1.Image = resultado;
            apilado = resultado;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            contraste = 50;
            fContrast(sender, e, contraste);
            UpdateHistogram();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            contraste = -50;
            fContrast(sender, e, contraste);
            UpdateHistogram();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rutaAux))
            {
                original = (Bitmap)(Bitmap.FromFile(rutaAux));
                resultado = original;
                apilado = resultado;
                pictureBox1.Image = original;
                
                // Keep the background image cleared since we're still showing an image
                pictureBox1.BackgroundImage = null;
                
                UpdateHistogram();
            }
        }

        private void invertirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            Color colorResultante = new Color(); //color que resulta
            Color colorOriginal = new Color(); //color que obtenemos de la imagen

            for (x = 0; x < resultado.Width; x++)
            {
                for (y = 0; y < resultado.Height; y++)
                {
                    //obtener el color del pixel
                    colorOriginal = apilado.GetPixel(x, y);
                    //procesamos y obtenemos el nuevo color
                    colorResultante = Color.FromArgb(255 - colorOriginal.R, 255 - colorOriginal.G, 255 - colorOriginal.B);
                    //colocar el color en resultante
                    resultado.SetPixel(x, y, colorResultante);
                }
            }

            pictureBox1.Image = resultado;
            apilado = resultado;
            UpdateHistogram();

        }

        private void mosaicoToolStripMenuItem_Click(object sender, EventArgs e)
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

            for (int x = 0; x < apilado.Width - mosaico; x += mosaico)
            {
                for (int y = 0; y < apilado.Height - mosaico; y += mosaico)
                {
                    rs = 0;
                    gs = 0;
                    bs = 0;
                    //promedio
                    for (xm = x; xm < (x + mosaico); xm++)
                    {
                        for (ym = y; ym < (y + mosaico); ym++)
                        {
                            colorOriginal = apilado.GetPixel(xm, ym);
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
                            resultado.SetPixel(xm, ym, colorResultante);
                        }
                    }
                }
            }

            pictureBox1.Image = resultado;
            apilado = resultado;
            UpdateHistogram();

        }

        private void fRuido(object sender, EventArgs e, int Sporcentaje)
        {
            int rangoMin = 50;
            int rangoMax = 195;
            float pBrillo;

            Random random = new Random();

            Color colorResultante;
            Color colorOriginal;

            int r, g, b;

            for (int x = 0; x < apilado.Width; x++)
            {
                for (int y = 0; y < apilado.Height; y++)
                {
                    if (random.Next(1, 100) <= Sporcentaje)
                    {
                        //metodo 1 al color resultante le creamos un color al azar
                        colorResultante = Color.FromArgb(random.Next(rangoMin, rangoMax),
                            random.Next(rangoMin, rangoMax), random.Next(rangoMin, rangoMax));

                        //metodo2
                        pBrillo = random.Next(rangoMin, rangoMax) / 100.0f;
                        colorOriginal = apilado.GetPixel(x, y);
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
                        colorResultante = apilado.GetPixel(x, y);
                    }

                    resultado.SetPixel(x, y, colorResultante);
                }
            }

            pictureBox1.Image = resultado;
            apilado = resultado;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            porcentaje = 15;
            fRuido(sender, e, porcentaje);
            UpdateHistogram();

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            porcentaje = 45;
            fRuido(sender, e, porcentaje);
            UpdateHistogram();

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            porcentaje = 75;
            fRuido(sender, e, porcentaje);
            UpdateHistogram();

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            porcentaje = 90;
            fRuido(sender, e, porcentaje);
            UpdateHistogram();

        }

        private void aberracionCromaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            int a = 4;

            int r = 0;
            int g = 0;
            int b = 0;

            resultado = new Bitmap(original.Width, original.Height);

            for (x = 0; x < original.Width; x++)
                for (y = 0; y < original.Height; y++)
                {

                    //verde
                    g = original.GetPixel(x, y).G;

                    //rojo
                    if (x + a < original.Width)
                        r = original.GetPixel(x + a, y).R;
                    else
                        r = 0;

                    //azul
                    if (x - a >= 0)
                        b = original.GetPixel(x - a, y).B;
                    else
                        b = 0;

                    //colocamos el pixel
                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                    pictureBox1.Image = resultado;
                    apilado = resultado;
                }
            UpdateHistogram();
            this.Invalidate();

        }

        private void rojoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Color colorResultante;
            Color colorOriginal;

            for (int x = 0; x < apilado.Width; x++)
            {
                for (int y = 0; y < apilado.Height; y++)
                {
                    // Obtener el color original del pixel
                    colorOriginal = apilado.GetPixel(x, y);

                    // Establecer el canal rojo en 0 y mantener los canales verde y azul
                    colorResultante = Color.FromArgb(0, colorOriginal.G, colorOriginal.B);

                    // Asignar el nuevo color al pixel en la imagen resultado
                    resultado.SetPixel(x, y, colorResultante);
                }
            }

            // Actualizar la imagen en el PictureBox
            pictureBox1.Image = resultado;
            apilado = resultado;
            UpdateHistogram();

        }

        private void verdeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Color colorResultante;
            Color colorOriginal;

            for (int x = 0; x < apilado.Width; x++)
            {
                for (int y = 0; y < apilado.Height; y++)
                {
                    // Obtener el color original del pixel
                    colorOriginal = apilado.GetPixel(x, y);

                    // Establecer el canal verde en 0 y mantener los canales rojo y azul
                    colorResultante = Color.FromArgb(colorOriginal.R, 0, colorOriginal.B);

                    // Asignar el nuevo color al pixel en la imagen resultado
                    resultado.SetPixel(x, y, colorResultante);
                }
            }

            // Actualizar la imagen en el PictureBox
            pictureBox1.Image = resultado;
            apilado = resultado;
            UpdateHistogram();

        }

        private void azulToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Color colorResultante;
            Color colorOriginal;

            for (int x = 0; x < apilado.Width; x++)
            {
                for (int y = 0; y < apilado.Height; y++)
                {
                    // Obtener el color original del pixel
                    colorOriginal = apilado.GetPixel(x, y);

                    // Establecer el canal azul en 0 y mantener los canales rojo y verde
                    colorResultante = Color.FromArgb(colorOriginal.R, colorOriginal.G, 0);

                    // Asignar el nuevo color al pixel en la imagen resultado
                    resultado.SetPixel(x, y, colorResultante);
                }
            }

            // Actualizar la imagen en el PictureBox
            pictureBox1.Image = resultado;
            apilado = resultado;
            UpdateHistogram();

        }

        private void degradadoToolStripMenuItem_Click(object sender, EventArgs e)
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

            tonosDeGrisToolStripMenuItem_Click(sender, e);

            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    oColor = resultado.GetPixel(x, y);

                    r = (int)((r1 / 255.0f) * oColor.R);
                    g = (int)((g1 / 255.0f) * oColor.G);
                    b = (int)((b1 / 255.0f) * oColor.B);

                    if (r > 255) r = 255;
                    else if (r < 0) r = 0;

                    if (g > 255) g = 255;
                    else if (g < 0) g = 0;

                    if (b > 255) b = 255;
                    else if (b < 0) b = 0;

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }

                r1 = (r1 + dr);
                g1 = (g1 + dg);
                b1 = (b1 + db);
            }
            pictureBox1.Image = resultado;
            apilado = resultado;
            UpdateHistogram();

            this.Invalidate();
        }

        private void brilloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int brillo = 64;
            //   float pBrillo = 1.2f;

            int x = 0;
            int y = 0;

            resultado = new Bitmap(original.Width, original.Height);
            Color rColor = new Color();
            Color oColor = new Color();

            int r = 0;
            int g = 0;
            int b = 0;

            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);

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

                    resultado.SetPixel(x, y, rColor);
                    pictureBox1.Image = resultado;
                    apilado = resultado;
                }
            }
            UpdateHistogram();
            this.Invalidate();
        }

        private void UpdateHistogram()
        {
            // Clear the histogram arrays
            Array.Clear(histogramaR, 0, histogramaR.Length);
            Array.Clear(histogramaG, 0, histogramaG.Length);
            Array.Clear(histogramaB, 0, histogramaB.Length);
            
            // Calculate histogram
            if (resultado != null)
            {
                Color colorOriginal;
                for (int x = 0; x < resultado.Width; x++)
                {
                    for (int y = 0; y < resultado.Height; y++)
                    {
                        colorOriginal = resultado.GetPixel(x, y);
                        histogramaR[colorOriginal.R]++;
                        histogramaG[colorOriginal.G]++;
                        histogramaB[colorOriginal.B]++;
                    }
                }

                // Find max for the values of rgb
                int mayorR = 0, mayorG = 0, mayorB = 0;
                for (int n = 0; n < 256; n++)
                {
                    if (histogramaR[n] > mayorR)
                        mayorR = histogramaR[n];
                    
                    if (histogramaG[n] > mayorG)
                        mayorG = histogramaG[n];
                    
                    if (histogramaB[n] > mayorB)
                        mayorB = histogramaB[n];
                }

                // Scale histograms for each channel
                int[] scaledHistR = new int[256];
                int[] scaledHistG = new int[256];
                int[] scaledHistB = new int[256];

                for (int n = 0; n < 256; n++)
                {
                    scaledHistR[n] = mayorR > 0 ? (int)((float)histogramaR[n] / (float)mayorR * 80.0f) : 0;
                    scaledHistG[n] = mayorG > 0 ? (int)((float)histogramaG[n] / (float)mayorG * 80.0f) : 0;
                    scaledHistB[n] = mayorB > 0 ? (int)((float)histogramaB[n] / (float)mayorB * 80.0f) : 0;
                }

                // Create and display Red histogram
                Bitmap histogramBitmapR = new Bitmap(301, 100);
                Graphics gR = Graphics.FromImage(histogramBitmapR);
                gR.Clear(this.BackColor);
                Pen plumaR = new Pen(Color.Red, 1);
                Pen plumaEjesR = new Pen(Color.White);
                
                gR.DrawLine(plumaEjesR, 19, 81, 277, 81); // X axis
                gR.DrawLine(plumaEjesR, 19, 80, 19, 10);  // Y axis
                
                for (int n = 0; n < 256; n++)
                {
                    gR.DrawLine(plumaR, n + 20, 80, n + 20, 80 - scaledHistR[n]);
                }
                
                pictureBoxHistogramR.Image = histogramBitmapR;
                gR.Dispose();

                // Same Green
                Bitmap histogramBitmapG = new Bitmap(301, 100);
                Graphics gG = Graphics.FromImage(histogramBitmapG);
                gG.Clear(this.BackColor);
                Pen plumaG = new Pen(Color.Green, 1);
                Pen plumaEjesG = new Pen(Color.White);
                
                gG.DrawLine(plumaEjesG, 19, 81, 277, 81); // X axis
                gG.DrawLine(plumaEjesG, 19, 80, 19, 10);  // Y axis
                
                for (int n = 0; n < 256; n++)
                {
                    gG.DrawLine(plumaG, n + 20, 80, n + 20, 80 - scaledHistG[n]);
                }
                
                pictureBoxHistogramG.Image = histogramBitmapG;
                gG.Dispose();

                // Same blue 
                Bitmap histogramBitmapB = new Bitmap(301, 100);
                Graphics gB = Graphics.FromImage(histogramBitmapB);
                gB.Clear(this.BackColor);
                Pen plumaB = new Pen(Color.Blue, 1);
                Pen plumaEjesB = new Pen(Color.White);
                
                gB.DrawLine(plumaEjesB, 19, 81, 277, 81); // X axis
                gB.DrawLine(plumaEjesB, 19, 80, 19, 10);  // Y axis
                
                for (int n = 0; n < 256; n++)
                {
                    gB.DrawLine(plumaB, n + 20, 80, n + 20, 80 - scaledHistB[n]);
                }
                
                pictureBoxHistogramB.Image = histogramBitmapB;
                gB.Dispose();
                
                // New combined histogram
                DisplayCombinedHistogram(histogramaR, histogramaG, histogramaB, mayorR, mayorG, mayorB);
            }
        }

        // Add this new method to create the combined histogram
        private void DisplayCombinedHistogram(int[] histogramR, int[] histogramG, int[] histogramB, 
                                            int maxValueR, int maxValueG, int maxValueB)
        {
            // Find the overall maximum value across all channels
            int maxOverall = Math.Max(maxValueR, Math.Max(maxValueG, maxValueB));
            
            // Scale the histogram values
            int[] scaledHistR = new int[256];
            int[] scaledHistG = new int[256];
            int[] scaledHistB = new int[256];
            
            for (int n = 0; n < 256; n++)
            {
                // Scale all channels against the overall maximum for consistent view
                scaledHistR[n] = maxOverall > 0 ? (int)((float)histogramR[n] / (float)maxOverall * 80.0f) : 0;
                scaledHistG[n] = maxOverall > 0 ? (int)((float)histogramG[n] / (float)maxOverall * 80.0f) : 0;
                scaledHistB[n] = maxOverall > 0 ? (int)((float)histogramB[n] / (float)maxOverall * 80.0f) : 0;
            }

            // Create histogram bitmap
            Bitmap histogramBitmap = new Bitmap(301, 100);
            Graphics g = Graphics.FromImage(histogramBitmap);
            g.Clear(this.BackColor);
            
            // Create pens
            Pen plumaR = new Pen(Color.Red, 1);
            Pen plumaG = new Pen(Color.Green, 1);
            Pen plumaB = new Pen(Color.Blue, 1);
            Pen plumaEjes = new Pen(Color.White);
            
            // Draw axes
            g.DrawLine(plumaEjes, 19, 81, 277, 81); // X axis
            g.DrawLine(plumaEjes, 19, 80, 19, 10);  // Y axis
            
            
            // Draw all three histograms with some transparency
            for (int n = 0; n < 256; n++)
            {
                // Draw histograms from shortest to tallest for better visibility
                g.DrawLine(plumaR, n + 20, 80, n + 20, 80 - scaledHistR[n]);
                g.DrawLine(plumaG, n + 20, 80, n + 20, 80 - scaledHistG[n]);
                g.DrawLine(plumaB, n + 20, 80, n + 20, 80 - scaledHistB[n]);
            }
            
            // Set the image to the picturebox
            pictureBoxHistogramCombined.Image = histogramBitmap;
            g.Dispose();
        }

        public static class ImageConverter
        {
            public static byte[] BitmapToByteArray(Bitmap bitmap)
            {
                // Convertir el Bitmap a un arreglo de bytes
                int width = bitmap.Width;
                int height = bitmap.Height;
                byte[] imageData = new byte[width * height * 3]; // Tamaño del arreglo unidimensional

                int index = 0; // Índice para recorrer el arreglo unidimensional

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);
                        imageData[index++] = pixelColor.B;
                        imageData[index++] = pixelColor.G;
                        imageData[index++] = pixelColor.R;
                    }
                }

                return imageData;
            }

            public static Image<Bgr, byte> ByteArrayToImage(byte[] byteArray, int width, int height)
            {
                // Convertir el arreglo de bytes a un objeto Image<Emgu.CV.Structure.Bgr, byte>
                Mat mat = new Mat();
                CvInvoke.Imdecode(byteArray, ImreadModes.Color, mat);
                Image<Bgr, byte> emguImage = mat.ToImage<Bgr, byte>();

                return emguImage;
            }
        }

        private void ruidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supresorDeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Dispose histogram images if they exist
            if (pictureBoxHistogramR.Image != null)
            {
                pictureBoxHistogramR.Image.Dispose();
                pictureBoxHistogramR.Image = null;
            }
            
            if (pictureBoxHistogramG.Image != null)
            {
                pictureBoxHistogramG.Image.Dispose();
                pictureBoxHistogramG.Image = null;
            }
            
            if (pictureBoxHistogramB.Image != null)
            {
                pictureBoxHistogramB.Image.Dispose();
                pictureBoxHistogramB.Image = null;
            }
            
            if (pictureBoxHistogramCombined.Image != null)
            {
                pictureBoxHistogramCombined.Image.Dispose();
                pictureBoxHistogramCombined.Image = null;
            }
            
            Application.Exit();
        }

        private void buttonOpenManual_Click(object sender, EventArgs e)
        {
            try
            {
                string manualPath = string.Empty;
                
                
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", "Manual de usuario.pdf");
                if (File.Exists(resourcePath))
                {
                    manualPath = resourcePath;
                }
                else
                {
                    string projectPath = Path.GetDirectoryName(Application.StartupPath);
                    if (projectPath != null)
                    {
                        string altPath = Path.Combine(projectPath, "Resources", "Manual de usuario.pdf");
                        if (File.Exists(altPath))
                        {
                            manualPath = altPath;
                        }
                    }
                }
                
                if (string.IsNullOrEmpty(manualPath))
                {
                    string directPath = Path.Combine(Application.StartupPath, "..", "..", "Resources", "Manual de usuario.pdf");
                    directPath = Path.GetFullPath(directPath);
                    if (File.Exists(directPath))
                    {
                        manualPath = directPath;
                    }
                }
                
                if (string.IsNullOrEmpty(manualPath))
                {
                    MessageBox.Show("Manual not found at: " + Path.Combine(Application.StartupPath, "Resources", "Manual de usuario.pdf") + 
                                  "\nMake sure the file exists or add it to the Resources folder.",
                                  "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                Process.Start(manualPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening manual: " + ex.Message, 
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
