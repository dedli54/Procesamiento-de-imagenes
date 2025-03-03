using System;
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

namespace _1erEntrega
{
    public partial class Form4 : Form
    {
        private int[] histograma = new int[256];
        private int[] histogramaR = new int[256];
        private int[] histogramaG = new int[256];
        private int[] histogramaB = new int[256];
        private int mayor;


        public Form4(int[] pHistogramaR, int[] pHistogramaG, int[] pHistogramaB)
        {
            InitializeComponent();

            histogramaR = pHistogramaR;
            histogramaG = pHistogramaG;
            histogramaB = pHistogramaB;
            int n = 0;
            //Encontramos cual es el valor que tiene la mayor cantidad de pixeles
            mayor = 0;
            for (n = 0; n < 256; n++)
            {
                if (histogramaR[n] > mayor)
                    mayor = histogramaR[n];
            }
            for (n = 0; n < 256; n++)
            {
                if (histogramaG[n] > mayor)
                    mayor = histogramaG[n];
            }
            for (n = 0; n < 256; n++)
            {
                if (histogramaB[n] > mayor)
                    mayor = histogramaB[n];
            }

            //escalamiento para que el histograma no ocupe tanto espacio
            for (n = 0; n < 256; n++)
                histogramaR[n] = (int)((float)histogramaR[n] / (float)mayor * 256.0f);
            for (n = 0; n < 256; n++)
                histogramaG[n] = (int)((float)histogramaG[n] / (float)mayor * 256.0f);
            for (n = 0; n < 256; n++)
                histogramaB[n] = (int)((float)histogramaB[n] / (float)mayor * 256.0f);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_Paint_1(object sender, PaintEventArgs e)
        {
            int n = 0;
            Graphics g = e.Graphics;
            Pen plumaH = new Pen(Color.Black);
            Pen plumaR = new Pen(Color.Red);
            Pen plumaB = new Pen(Color.Blue);
            Pen plumaG = new Pen(Color.Green);

            Pen plumaEjes = new Pen(Color.Coral);

            g.DrawLine(plumaEjes, 19, 271, 277, 271);
            g.DrawLine(plumaEjes, 19, 270, 19, 14);


            for (n = 0; n < 256; n++)
            {

                g.DrawLine(plumaH, n + 20, 270, n + 20, 270 - histograma[n]);
            }
            for (n = 0; n < 256; n++)
            {

                g.DrawLine(plumaR, n + 20, 270, n + 20, 270 - histogramaR[n]);
            }
            for (n = 0; n < 256; n++)
            {

                g.DrawLine(plumaG, n + 20, 270, n + 20, 270 - histogramaG[n]);
            }
            for (n = 0; n < 256; n++)
            {

                g.DrawLine(plumaB, n + 20, 270, n + 20, 270 - histogramaB[n]);
            }

        }
    }
}
