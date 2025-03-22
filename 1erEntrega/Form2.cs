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
        private Label clickedPixelHeaderLabel;

        // Track el ultimo punto clickeado
        private Point lastClickedPoint = new Point(-1, -1);
        private bool hasClickedPoint = false;

        
        
        public Form2()
        {
            InitializeComponent();
            
            // Crear la info del cuadrante cuando se inicialican las cosas
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                comboBoxCamera.Items.Add(filterInfo.Name);
            
            if (comboBoxCamera.Items.Count > 0)
                comboBoxCamera.SelectedIndex = 0;
            
            // Initialize the HSV wheel
            DrawHSVWheel();
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

                    // Update the image in CameraBox
                    CameraBox.Invoke((MethodInvoker)delegate
                    {
                        CameraBox.Image = frame.ToBitmap();
                        
                        // Only clear the color display if no pixel has been clicked
                        if (!hasClickedPoint)
                        {
                            // Clear color display when no pixel is selected .
                            colorDisplayPanel.BackColor = Color.Gray;
                            colorNameLabel.Text = "Color: (Ninguno)";
                            rgbValuesLabel.Text = "RGB: --";
                        }
                    });

                    // Exit if a key is pressed or the form is closed
                    if (CvInvoke.WaitKey(1) >= 0 || !OpenCamera)
                        break;
                }
            }

            camera.Dispose();
        }


private string GetColorName(Color color)
{
    // Convertir valores RGB a valores entre 0 y 1
    double r = color.R / 255.0;
    double g = color.G / 255.0;
    double b = color.B / 255.0;
    
    // Calcular valor máximo y mínimo
    double max = Math.Max(r, Math.Max(g, b));
    double min = Math.Min(r, Math.Min(g, b));
    double delta = max - min;
    
    // Calcular luminancia (brightness)
    double brightness = max;
    
    // Calcular saturación
    double saturation = max == 0 ? 0 : delta / max;
    
    // Verificar si es un color gris (baja saturación)
    if (saturation < 0.1)
    {
        if (brightness > 0.9) return "Blanco";
        if (brightness > 0.6) return "Gris Claro";
        if (brightness > 0.4) return "Gris";
        if (brightness > 0.15) return "Gris Oscuro";
        return "Negro";
    }
    
    // Calcular tono (hue)
    double hue = 0;
    if (delta > 0)
    {
        if (max == r)
        {
            hue = ((g - b) / delta) % 6;
        }
        else if (max == g)
        {
            hue = (b - r) / delta + 2;
        }
        else // max == b
        {
            hue = (r - g) / delta + 4;
        }
        
        hue *= 60; // Convertir a grados (0-360)
        if (hue < 0) hue += 360;
    }
    
    // Determinar color basado en tono, saturación y brillo
    
    // Rojos (hue: 0-20 o 330-360)
    if ((hue >= 0 && hue < 20) || (hue >= 330 && hue <= 360))
    {
        if (saturation > 0.7 && brightness > 0.7) return "Rojo";
        if (saturation > 0.7 && brightness > 0.5 && brightness <= 0.7) return "Rojo Oscuro";
        if (saturation > 0.4 && saturation <= 0.7 && brightness > 0.7) return "Rojo Claro";
        if (saturation > 0.4 && brightness > 0.4 && brightness <= 0.6) return "Rojo Vino";
        if (saturation > 0.3 && brightness > 0.25 && brightness <= 0.4) return "Rojo Carmesí";
        if (saturation <= 0.4 && brightness > 0.6) return "Rosa Pálido";
        return "Rojo";
    }
    
    // Naranjas (hue: 20-40)
    if (hue >= 20 && hue < 40)
    {
        if (saturation > 0.7 && brightness > 0.8) return "Naranja";
        if (saturation > 0.7 && brightness > 0.6 && brightness <= 0.8) return "Naranja Oscuro";
        if (saturation > 0.7 && brightness <= 0.6) return "Marrón";
        if (saturation > 0.4 && saturation <= 0.7 && brightness > 0.7) return "Ámbar";
        if (saturation <= 0.4 && brightness > 0.8) return "Durazno";
        return "Naranja";
    }
    
    // Amarillos (hue: 40-60)
    if (hue >= 40 && hue < 60)
    {
        if (saturation > 0.7 && brightness > 0.8) return "Amarillo";
        if (saturation > 0.7 && brightness > 0.5 && brightness <= 0.8) return "Amarillo Oscuro";
        if (saturation > 0.4 && saturation <= 0.7 && brightness > 0.5) return "Mostaza";
        if (saturation <= 0.4 && brightness > 0.8) return "Crema";
        return "Amarillo";
    }
    
    // Verdes (hue: 60-140)
    if (hue >= 60 && hue < 140)
    {
        if (hue < 80)
        {
            if (saturation > 0.7 && brightness > 0.7) return "Verde Limón";
            if (saturation > 0.7 && brightness > 0.4 && brightness <= 0.7) return "Verde Oliva";
            if (saturation <= 0.7 && brightness > 0.7) return "Verde Pálido";
            return "Verde Amarillento";
        }
        else if (hue < 100)
        {
            if (saturation > 0.7 && brightness > 0.7) return "Verde";
            if (saturation > 0.7 && brightness > 0.4 && brightness <= 0.7) return "Verde Oscuro";
            if (saturation > 0.4 && saturation <= 0.7 && brightness > 0.5) return "Verde Bosque";
            return "Verde";
        }
        else
        {
            if (saturation > 0.7 && brightness > 0.7) return "Verde Agua";
            if (saturation > 0.7 && brightness > 0.4 && brightness <= 0.7) return "Verde Esmeralda";
            if (saturation > 0.4 && saturation <= 0.7 && brightness > 0.5) return "Verde Menta";
            if (saturation <= 0.4 && brightness > 0.8) return "Verde Pálido";
            return "Verde Azulado";
        }
    }
    
    // Cianes (hue: 140-200)
    if (hue >= 140 && hue < 200)
    {
        if (saturation > 0.7 && brightness > 0.7) return "Cian";
        if (hue < 170)
        {
            if (saturation > 0.7 && brightness > 0.4 && brightness <= 0.7) return "Verde Agua";
            if (saturation > 0.4 && saturation <= 0.7 && brightness > 0.7) return "Turquesa";
            return "Turquesa";
        }
        else
        {
            if (saturation > 0.7 && brightness > 0.4 && brightness <= 0.7) return "Azul Verdoso";
            if (saturation > 0.4 && saturation <= 0.7 && brightness > 0.7) return "Azul Celeste";
            return "Azul Celeste";
        }
    }
    
    // Azules (hue: 200-260)
    if (hue >= 200 && hue < 260)
    {
        if (saturation > 0.8 && brightness > 0.8) return "Azul";
        if (saturation > 0.8 && brightness > 0.5 && brightness <= 0.8) return "Azul Medio";
        if (saturation > 0.8 && brightness > 0.2 && brightness <= 0.5) return "Azul Oscuro";
        if (saturation > 0.4 && saturation <= 0.8 && brightness > 0.7) return "Azul Cielo";
        if (saturation > 0.4 && saturation <= 0.8 && brightness <= 0.7) return "Azul Marino";
        if (saturation <= 0.4 && brightness > 0.7) return "Azul Pálido";
        return "Azul";
    }
    
    // Púrpuras (hue: 260-300)
    if (hue >= 260 && hue < 300)
    {
        if (saturation > 0.7 && brightness > 0.7) return "Púrpura";
        if (saturation > 0.7 && brightness > 0.4 && brightness <= 0.7) return "Púrpura Oscuro";
        if (saturation > 0.4 && saturation <= 0.7 && brightness > 0.7) return "Lila";
        if (saturation <= 0.4 && brightness > 0.6) return "Lavanda";
        return "Violeta";
    }
    
    // Magentas (hue: 300-330)
    if (hue >= 300 && hue < 330)
    {
        if (saturation > 0.7 && brightness > 0.8) return "Magenta";
        if (saturation > 0.7 && brightness > 0.6 && brightness <= 0.8) return "Fucsia";
        if (saturation > 0.7 && brightness <= 0.6) return "Púrpura Rojizo";
        if (saturation > 0.4 && saturation <= 0.7 && brightness > 0.7) return "Rosa";
        if (saturation <= 0.4 && brightness > 0.8) return "Rosa Pálido";
        return "Magenta";
    }
    
    // Si llegamos aquí, usar los valores RGB para identificar colores especiales
    
    // Colores metálicos y especiales
    if (color.R > 180 && color.G > 160 && color.B > 120 && color.G < color.R && color.B < color.G)
        return "Dorado";
    if (color.R > 160 && color.G > 160 && color.B > 160 && 
        Math.Abs(color.R - color.G) < 10 && Math.Abs(color.G - color.B) < 10)
        return "Plateado";
    if (color.R > 140 && color.G > 90 && color.B > 40 && color.G < color.R && color.B < color.G)
        return "Bronce";
    
    // Marrones especiales 
    if (color.R > 140 && color.G > 80 && color.G < 120 && color.B < 80)
        return "Marrón Rojizo";
    if (color.R > 80 && color.R < 130 && color.G > 50 && color.G < 90 && color.B > 0 && color.B < 40)
        return "Marrón Sepia";
    if (color.R > 100 && color.R < 150 && color.G > 70 && color.G < 110 && color.B > 40 && color.B < 70)
        return "Marrón Café";
    
    // Valor desconocido
    return "No identificado";
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
            
            // Dispose of the HSV wheel image
            if (hsvWheelPictureBox.Image != null)
            {
                hsvWheelPictureBox.Image.Dispose();
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
            // Only process the clicks if the camara is active
            if (CameraBox.Image == null)
                return;

            // Get the mouse position
            Point mousePos = CameraBox.PointToClient(Cursor.Position);
            
            // Convert the clicked coordinates to actual image coordinates
            double ratioX = (double)CameraBox.Image.Width / CameraBox.Width;
            double ratioY = (double)CameraBox.Image.Height / CameraBox.Height;
            
            int imageX = (int)(mousePos.X * ratioX);
            int imageY = (int)(mousePos.Y * ratioY);
            
            // Make sure the click is within image bounds
            if (imageX < 0 || imageX >= CameraBox.Image.Width || 
                imageY < 0 || imageY >= CameraBox.Image.Height)
                return;
            
            // Save the clicked position
            lastClickedPoint = new Point(imageX, imageY);
            hasClickedPoint = true;
            
            // Get the color at the clicked point
            Bitmap bitmap = new Bitmap(CameraBox.Image);
            Color pixelColor = bitmap.GetPixel(imageX, imageY);
            
            // Get the color name and HSV values
            string colorName = GetColorName(pixelColor);
            
            // Calculate HSV values
            double r = pixelColor.R / 255.0;
            double g = pixelColor.G / 255.0;
            double b = pixelColor.B / 255.0;
            
            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;
            
            double hue = 0;
            if (delta > 0)
            {
                if (max == r)
                {
                    hue = ((g - b) / delta) % 6;
                }
                else if (max == g)
                {
                    hue = (b - r) / delta + 2;
                }
                else // max == b
                {
                    hue = (r - g) / delta + 4;
                }
                
                hue *= 60; // Convert to degrees (0-360)
                if (hue < 0) hue += 360;
            }
            
            double saturation = max == 0 ? 0 : delta / max;
            double value = max;
            
            // Determine HSV quadrant
            string hsvQuadrant = GetHSVQuadrant(hue, saturation, value);
            
            // Update the UI 
            colorDisplayPanel.BackColor = pixelColor;
            colorNameLabel.Text = $"Color: {colorName}";
            rgbValuesLabel.Text = $"RGB: R:{pixelColor.R}, G:{pixelColor.G}, B:{pixelColor.B}";
            hsvValuesLabel.Text = $"HSV: H:{hue:F0}°, S:{saturation:P0}, V:{value:P0} ({hsvQuadrant})";
            
            // Update the HSV wheel with the selected color position
            HighlightColorOnWheel(hue, saturation, value);
            
            // Clean up
            bitmap.Dispose();
        }

        // Add this new method to determine the HSV quadrant
        private string GetHSVQuadrant(double hue, double saturation, double value)
        {
            // Determine the hue quadrant
            string hueRange;
            if ((hue >= 0 && hue < 20) || (hue >= 330 && hue <= 360))
                hueRange = "Rojo";
            else if (hue >= 20 && hue < 40)
                hueRange = "Naranja";
            else if (hue >= 40 && hue < 60)
                hueRange = "Amarillo";
            else if (hue >= 60 && hue < 140)
            {
                if (hue < 80)
                    hueRange = "Verde-Amarillo";
                else if (hue < 100)
                    hueRange = "Verde";
                else
                    hueRange = "Verde-Cian";
            }
            else if (hue >= 140 && hue < 200)
            {
                if (hue < 170)
                    hueRange = "Cian-Verde";
                else
                    hueRange = "Cian-Azul";
            }
            else if (hue >= 200 && hue < 260)
                hueRange = "Azul";
            else if (hue >= 260 && hue < 300)
                hueRange = "Púrpura";
            else // hue >= 300 && hue < 330
                hueRange = "Magenta";

            // Determine the saturation and value description
            string intensityDesc;
            if (saturation < 0.1)
            {
                if (value > 0.9)
                    return "Blanco";
                else if (value > 0.6)
                    return "Gris Claro";
                else if (value > 0.4)
                    return "Gris";
                else if (value > 0.15)
                    return "Gris Oscuro";
                else
                    return "Negro";
            }
            else
            {
                if (saturation > 0.7)
                {
                    if (value > 0.7)
                        intensityDesc = "Brillante";
                    else if (value > 0.4)
                        intensityDesc = "Profundo";
                    else
                        intensityDesc = "Oscuro";
                }
                else
                {
                    if (value > 0.7)
                        intensityDesc = "Pálido";
                    else if (value > 0.4)
                        intensityDesc = "Moderado";
                    else
                        intensityDesc = "Sombrío";
                }
            }
            
            return $"{hueRange} {intensityDesc}";
        }

private void DrawHSVWheel()
{
    // Create a bitmap for the HSV wheel
    int width = hsvWheelPictureBox.Width;
    int height = hsvWheelPictureBox.Height;
    Bitmap hsvWheel = new Bitmap(width, height);
    
    // Calculate center and radius
    int centerX = width / 2;
    int centerY = height / 2;
    int radius = Math.Min(centerX, centerY) - 2; // Leave a small margin
    
    using (Graphics g = Graphics.FromImage(hsvWheel))
    {
        g.Clear(panel2.BackColor);
        
        // Draw the HSV wheel
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Calculate distance from center
                double dx = x - centerX;
                double dy = y - centerY;
                double distance = Math.Sqrt(dx * dx + dy * dy);
                
                if (distance <= radius)
                {
                    // Convert to polar coordinates
                    double angle = Math.Atan2(dy, dx);
                    // Convert angle to degrees (0-360)
                    double hue = ((angle * 180.0 / Math.PI) + 90) % 360;
                    // Calculate saturation (0-1) based on distance from center
                    double saturation = distance / radius;
                    // Set value/brightness to 1
                    double value = 1.0;
                    
                    // Convert HSV to RGB
                    Color pixelColor = HSVToRGB(hue, saturation, value);
                    hsvWheel.SetPixel(x, y, pixelColor);
                }
            }
        }
        
        // Draw quadrant dividing lines for visual reference
        Pen linePen = new Pen(Color.FromArgb(120, Color.White), 1);
        g.DrawLine(linePen, centerX, 0, centerX, height);
        g.DrawLine(linePen, 0, centerY, width, centerY);
        g.DrawEllipse(linePen, centerX - radius, centerY - radius, radius * 2, radius * 2);
    }
    
    // Set as the picture box image
    if (hsvWheelPictureBox.Image != null)
    {
        hsvWheelPictureBox.Image.Dispose();
    }
    hsvWheelPictureBox.Image = hsvWheel;
}
        private Color HSVToRGB(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);
            
            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));
            
            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        private void HighlightColorOnWheel(double hue, double saturation, double value)
        {
            // Always create a fresh wheel to avoid accumulating markers
            DrawHSVWheel();
            
            // Create a copy of the fresh HSV wheel
            Bitmap wheelWithMarker = new Bitmap(hsvWheelPictureBox.Image);
            
            int width = wheelWithMarker.Width;
            int height = wheelWithMarker.Height;
            int centerX = width / 2;
            int centerY = height / 2;
            int radius = Math.Min(centerX, centerY) - 2;
            
            // Convert HSV to position on wheel
            // Adjust angle calculation: hue degrees to radians, then adjust for wheel orientation
            double angleRad = ((hue - 90) * Math.PI) / 180.0;
            int x = centerX + (int)(saturation * radius * Math.Cos(angleRad));
            int y = centerY + (int)(saturation * radius * Math.Sin(angleRad));
            
            // Draw marker
            using (Graphics g = Graphics.FromImage(wheelWithMarker))
            {
                // Draw crosshair
                g.DrawEllipse(new Pen(Color.White, 2), x - 5, y - 5, 10, 10);
                g.DrawLine(new Pen(Color.Black, 1), x - 6, y, x + 6, y);
                g.DrawLine(new Pen(Color.Black, 1), x, y - 6, x, y + 6);
            }
            
            // Update the picture box
            hsvWheelPictureBox.Image = wheelWithMarker;
        }

      
        //private void DrawClickedPointMarker(Image<Bgr, byte> frame)
        //{
        //    if (!hasClickedPoint)
        //        return;
                
        //    int size = 10;
        //    CvInvoke.Line(frame,
        //                  new Point(lastClickedPoint.X - size, lastClickedPoint.Y),
        //                  new Point(lastClickedPoint.X + size, lastClickedPoint.Y),
        //                  new MCvScalar(0, 255, 255), 2); 
                          
        //    CvInvoke.Line(frame,
        //                  new Point(lastClickedPoint.X, lastClickedPoint.Y - size),
        //                  new Point(lastClickedPoint.X, lastClickedPoint.Y + size),
        //                  new MCvScalar(0, 255, 255), 2);
                          
        //    CvInvoke.Circle(frame,
        //                   lastClickedPoint,
        //                   size + 2,
        //                   new MCvScalar(0, 255, 255), 2);
        //}

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hsvWheelPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
    
}
