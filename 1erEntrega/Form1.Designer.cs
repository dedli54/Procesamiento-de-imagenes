namespace _1erEntrega
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filtrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.invertirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mosaicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.aberracionCromaticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtroDeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supresorDeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rojoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verdeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.azulToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.degradadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brilloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxHistogram = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtrosToolStripMenuItem,
            this.filtrosToolStripMenuItem1,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1291, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filtrosToolStripMenuItem
            // 
            this.filtrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            this.filtrosToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.filtrosToolStripMenuItem.Text = "Imagen";
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.cargarToolStripMenuItem.Text = "Cargar";
            this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // filtrosToolStripMenuItem1
            // 
            this.filtrosToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.contrasteToolStripMenuItem,
            this.invertirToolStripMenuItem,
            this.mosaicoToolStripMenuItem,
            this.ruidoToolStripMenuItem,
            this.aberracionCromaticaToolStripMenuItem,
            this.filtroDeColorToolStripMenuItem,
            this.supresorDeColorToolStripMenuItem,
            this.degradadoToolStripMenuItem,
            this.brilloToolStripMenuItem});
            this.filtrosToolStripMenuItem1.Enabled = false;
            this.filtrosToolStripMenuItem1.Name = "filtrosToolStripMenuItem1";
            this.filtrosToolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.filtrosToolStripMenuItem1.Text = "Filtros";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // contrasteToolStripMenuItem
            // 
            this.contrasteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contrasteToolStripMenuItem.Name = "contrasteToolStripMenuItem";
            this.contrasteToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.contrasteToolStripMenuItem.Text = "Contraste";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(91, 22);
            this.toolStripMenuItem2.Text = "50";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(91, 22);
            this.toolStripMenuItem3.Text = "-50";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // invertirToolStripMenuItem
            // 
            this.invertirToolStripMenuItem.Name = "invertirToolStripMenuItem";
            this.invertirToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.invertirToolStripMenuItem.Text = "Invertir";
            this.invertirToolStripMenuItem.Click += new System.EventHandler(this.invertirToolStripMenuItem_Click);
            // 
            // mosaicoToolStripMenuItem
            // 
            this.mosaicoToolStripMenuItem.Name = "mosaicoToolStripMenuItem";
            this.mosaicoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.mosaicoToolStripMenuItem.Text = "Mosaico";
            this.mosaicoToolStripMenuItem.Click += new System.EventHandler(this.mosaicoToolStripMenuItem_Click);
            // 
            // ruidoToolStripMenuItem
            // 
            this.ruidoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this.ruidoToolStripMenuItem.Name = "ruidoToolStripMenuItem";
            this.ruidoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.ruidoToolStripMenuItem.Text = "Ruido";
            this.ruidoToolStripMenuItem.Click += new System.EventHandler(this.ruidoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(96, 22);
            this.toolStripMenuItem4.Text = "15%";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(96, 22);
            this.toolStripMenuItem5.Text = "45%";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(96, 22);
            this.toolStripMenuItem6.Text = "75%";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(96, 22);
            this.toolStripMenuItem7.Text = "90%";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // aberracionCromaticaToolStripMenuItem
            // 
            this.aberracionCromaticaToolStripMenuItem.Name = "aberracionCromaticaToolStripMenuItem";
            this.aberracionCromaticaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.aberracionCromaticaToolStripMenuItem.Text = "Aberracion cromatica";
            this.aberracionCromaticaToolStripMenuItem.Click += new System.EventHandler(this.aberracionCromaticaToolStripMenuItem_Click);
            // 
            // filtroDeColorToolStripMenuItem
            // 
            this.filtroDeColorToolStripMenuItem.Name = "filtroDeColorToolStripMenuItem";
            this.filtroDeColorToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.filtroDeColorToolStripMenuItem.Text = "Flip";
            this.filtroDeColorToolStripMenuItem.Click += new System.EventHandler(this.filtroDeColorToolStripMenuItem_Click);
            // 
            // supresorDeColorToolStripMenuItem
            // 
            this.supresorDeColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rojoToolStripMenuItem1,
            this.verdeToolStripMenuItem1,
            this.azulToolStripMenuItem1});
            this.supresorDeColorToolStripMenuItem.Name = "supresorDeColorToolStripMenuItem";
            this.supresorDeColorToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.supresorDeColorToolStripMenuItem.Text = "Supresor de color";
            this.supresorDeColorToolStripMenuItem.Click += new System.EventHandler(this.supresorDeColorToolStripMenuItem_Click);
            // 
            // rojoToolStripMenuItem1
            // 
            this.rojoToolStripMenuItem1.Name = "rojoToolStripMenuItem1";
            this.rojoToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.rojoToolStripMenuItem1.Text = "Rojo";
            this.rojoToolStripMenuItem1.Click += new System.EventHandler(this.rojoToolStripMenuItem1_Click);
            // 
            // verdeToolStripMenuItem1
            // 
            this.verdeToolStripMenuItem1.Name = "verdeToolStripMenuItem1";
            this.verdeToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.verdeToolStripMenuItem1.Text = "Verde";
            this.verdeToolStripMenuItem1.Click += new System.EventHandler(this.verdeToolStripMenuItem1_Click);
            // 
            // azulToolStripMenuItem1
            // 
            this.azulToolStripMenuItem1.Name = "azulToolStripMenuItem1";
            this.azulToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.azulToolStripMenuItem1.Text = "Azul";
            this.azulToolStripMenuItem1.Click += new System.EventHandler(this.azulToolStripMenuItem1_Click);
            // 
            // degradadoToolStripMenuItem
            // 
            this.degradadoToolStripMenuItem.Name = "degradadoToolStripMenuItem";
            this.degradadoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.degradadoToolStripMenuItem.Text = "Degradado";
            this.degradadoToolStripMenuItem.Click += new System.EventHandler(this.degradadoToolStripMenuItem_Click);
            // 
            // brilloToolStripMenuItem
            // 
            this.brilloToolStripMenuItem.Name = "brilloToolStripMenuItem";
            this.brilloToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.brilloToolStripMenuItem.Text = "Brillo";
            this.brilloToolStripMenuItem.Click += new System.EventHandler(this.brilloToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Menu;
            this.button2.Location = new System.Drawing.Point(18, 60);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "Borrar filtros";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 133);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 27);
            this.button4.TabIndex = 6;
            this.button4.Text = "Camara";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(18, 209);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 27);
            this.button5.TabIndex = 7;
            this.button5.Text = "Video";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::_1erEntrega.Properties.Resources.Insert_Image_Here_400x200;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(331, 44);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(960, 643);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBoxHistogram
            // 
            this.pictureBoxHistogram.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxHistogram.Location = new System.Drawing.Point(11, 405);
            this.pictureBoxHistogram.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxHistogram.Name = "pictureBoxHistogram";
            this.pictureBoxHistogram.Size = new System.Drawing.Size(301, 310);
            this.pictureBoxHistogram.TabIndex = 6;
            this.pictureBoxHistogram.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1291, 726);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBoxHistogram);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Kamakho";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filtrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtrosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem invertirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mosaicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ruidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem aberracionCromaticaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtroDeColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supresorDeColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rojoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verdeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem azulToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem degradadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brilloToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBoxHistogram;
    }
}

