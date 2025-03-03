using Emgu.CV;
using Emgu.CV.Structure;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace _1erEntrega
{
    public partial class Form2 : Form
    {
        FilterInfoCollection filterInfoCollection;
        private VideoCapture camera;
        private bool OpenCamera = true;
        private Image<Gray, Byte> detectedFace = null;
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

        private int personCount = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            camera = new VideoCapture(comboBoxCamera.SelectedIndex);

            if (!camera.IsOpened)
            {
                MessageBox.Show("No hay cámaras disponibles.");
                return;
            }

            var haarCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");

            while (OpenCamera)
            {
                personCount = 0;
                using (var frame = camera.QueryFrame().ToImage<Bgr, Byte>())
                {
                    if (frame == null)
                        break;

                    var grayFrame = frame.Convert<Gray, Byte>();
                    var faces = haarCascade.DetectMultiScale(grayFrame, 1.1, 3, Size.Empty);

                    for (int i = 0; i < faces.Length; i++)
                    {
                        // Incrementar el contador de personas detectadas
                        personCount++;

                        // Obtener la cara actual
                        var face = faces[i];

                        // Dibujar un cuadro alrededor de la cara
                        frame.Draw(face, new Bgr(Color.Orange), 2);

                        // Dibujar el número de persona sobre el cuadro
                        CvInvoke.PutText(frame, "Persona" + (personCount == 1 ? "" : personCount.ToString()),
                                         new Point(face.X, face.Y - 10), 0, 0.5, new MCvScalar(255, 255, 255));

                        // Recortar la cara detectada
                        detectedFace = grayFrame.Copy(face).Convert<Gray, Byte>();
                    }

                    // Actualizar la imagen en CameraBox desde el hilo principal
                    CameraBox.Invoke((MethodInvoker)delegate {
                        CameraBox.Image = frame.ToBitmap();
                    });

                    // Salir si se presiona una tecla o si se cierra el formulario
                    if (CvInvoke.WaitKey(1) >= 0 || !OpenCamera)
                        break;

                    // Actualizar el contador de rostros
                    numFaces.Invoke((MethodInvoker)delegate {
                        numFaces.Text = personCount.ToString();
                    });
                }
            }

            camera.Dispose();
        }




        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCamera = false;
            if (camera != null)
            {
                camera.Dispose();
            }
            
            // Close the form - this will trigger the FormClosed event
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            camera = new VideoCapture(comboBoxCamera.SelectedIndex);

            if (!camera.IsOpened)
            {
                MessageBox.Show("No hay cámaras disponibles.");
                return;
            }

            var haarCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");

            while (OpenCamera)
            {
                personCount = 0;
                using (var frame = camera.QueryFrame().ToImage<Bgr, Byte>())
                {
                    if (frame == null)
                        break;

                    var grayFrame = frame.Convert<Gray, Byte>();
                    var faces = haarCascade.DetectMultiScale(grayFrame, 1.1, 3, Size.Empty);

                    for (int i = 0; i < faces.Length; i++)
                    {
                        // Incrementar el contador de personas detectadas
                        personCount++;

                        // Obtener la cara actual
                        var face = faces[i];

                        // Dibujar un cuadro alrededor de la cara
                        frame.Draw(face, new Bgr(Color.Orange), 2);

                        // Dibujar el número de persona sobre el cuadro
                        CvInvoke.PutText(frame, "Persona" + (personCount == 1 ? "" : personCount.ToString()),
                                         new Point(face.X, face.Y - 10), 0, 0.5, new MCvScalar(255, 255, 255));

                        // Recortar la cara detectada
                        detectedFace = grayFrame.Copy(face).Convert<Gray, Byte>();
                    }

                    // Actualizar la imagen en CameraBox desde el hilo principal
                    CameraBox.Invoke((MethodInvoker)delegate {
                        CameraBox.Image = frame.ToBitmap();
                    });

                    // Salir si se presiona una tecla o si se cierra el formulario
                    if (CvInvoke.WaitKey(1) >= 0 || !OpenCamera)
                        break;

                    // Actualizar el contador de rostros
                    numFaces.Invoke((MethodInvoker)delegate {
                        numFaces.Text = personCount.ToString();
                    });
                }
            }

            camera.Dispose();

        }

        private void CameraBox_Click(object sender, EventArgs e)
        {

        }
    }
}
