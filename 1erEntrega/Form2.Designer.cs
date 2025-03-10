namespace _1erEntrega
{
    partial class Form2
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
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CameraBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.hsvWheelPictureBox = new System.Windows.Forms.PictureBox();
            this.colorDisplayPanel = new System.Windows.Forms.Panel();
            this.colorNameLabel = new System.Windows.Forms.Label();
            this.rgbValuesLabel = new System.Windows.Forms.Label();
            this.hsvValuesLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxCamera = new System.Windows.Forms.ComboBox();
            this.ColorIdentity = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hsvWheelPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(959, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.cerrarToolStripMenuItem.Text = "Regresar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CameraBox);
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 331);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CameraBox
            // 
            this.CameraBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraBox.Location = new System.Drawing.Point(0, 0);
            this.CameraBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CameraBox.Name = "CameraBox";
            this.CameraBox.Size = new System.Drawing.Size(397, 331);
            this.CameraBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CameraBox.TabIndex = 0;
            this.CameraBox.TabStop = false;
            this.CameraBox.Click += new System.EventHandler(this.CameraBox_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.colorDisplayPanel);
            this.panel2.Controls.Add(this.colorNameLabel);
            this.panel2.Controls.Add(this.rgbValuesLabel);
            this.panel2.Controls.Add(this.hsvValuesLabel);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.comboBoxCamera);
            this.panel2.Controls.Add(this.ColorIdentity);
            this.panel2.Location = new System.Drawing.Point(401, 26);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 330);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // hsvWheelPictureBox
            // 
            this.hsvWheelPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hsvWheelPictureBox.Location = new System.Drawing.Point(604, 26);
            this.hsvWheelPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hsvWheelPictureBox.Name = "hsvWheelPictureBox";
            this.hsvWheelPictureBox.Size = new System.Drawing.Size(344, 331);
            this.hsvWheelPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hsvWheelPictureBox.TabIndex = 4;
            this.hsvWheelPictureBox.TabStop = false;
            this.hsvWheelPictureBox.Click += new System.EventHandler(this.hsvWheelPictureBox_Click);
            // 
            // colorDisplayPanel
            // 
            this.colorDisplayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorDisplayPanel.Location = new System.Drawing.Point(15, 64);
            this.colorDisplayPanel.Name = "colorDisplayPanel";
            this.colorDisplayPanel.Size = new System.Drawing.Size(80, 80);
            this.colorDisplayPanel.TabIndex = 0;
            // 
            // colorNameLabel
            // 
            this.colorNameLabel.AutoSize = true;
            this.colorNameLabel.Location = new System.Drawing.Point(15, 225);
            this.colorNameLabel.Name = "colorNameLabel";
            this.colorNameLabel.Size = new System.Drawing.Size(37, 13);
            this.colorNameLabel.TabIndex = 1;
            this.colorNameLabel.Text = "Color: ";
            // 
            // rgbValuesLabel
            // 
            this.rgbValuesLabel.AutoSize = true;
            this.rgbValuesLabel.Location = new System.Drawing.Point(15, 245);
            this.rgbValuesLabel.Name = "rgbValuesLabel";
            this.rgbValuesLabel.Size = new System.Drawing.Size(36, 13);
            this.rgbValuesLabel.TabIndex = 2;
            this.rgbValuesLabel.Text = "RGB: ";
            // 
            // hsvValuesLabel
            // 
            this.hsvValuesLabel.AutoSize = true;
            this.hsvValuesLabel.Location = new System.Drawing.Point(15, 265);
            this.hsvValuesLabel.Name = "hsvValuesLabel";
            this.hsvValuesLabel.Size = new System.Drawing.Size(35, 13);
            this.hsvValuesLabel.TabIndex = 3;
            this.hsvValuesLabel.Text = "HSV: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(71, 293);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 3;
            this.button2.Text = "abrir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // comboBoxCamera
            // 
            this.comboBoxCamera.FormattingEnabled = true;
            this.comboBoxCamera.Location = new System.Drawing.Point(15, 18);
            this.comboBoxCamera.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxCamera.Name = "comboBoxCamera";
            this.comboBoxCamera.Size = new System.Drawing.Size(176, 21);
            this.comboBoxCamera.TabIndex = 2;
            // 
            // ColorIdentity
            // 
            this.ColorIdentity.AutoSize = true;
            this.ColorIdentity.Location = new System.Drawing.Point(136, 12);
            this.ColorIdentity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ColorIdentity.Name = "ColorIdentity";
            this.ColorIdentity.Size = new System.Drawing.Size(0, 13);
            this.ColorIdentity.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(959, 366);
            this.Controls.Add(this.hsvWheelPictureBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Camara";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hsvWheelPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxCamera;
        private System.Windows.Forms.Label ColorIdentity;
        private System.Windows.Forms.PictureBox CameraBox;
        private System.Windows.Forms.Panel colorDisplayPanel;
        private System.Windows.Forms.Label colorNameLabel;
        private System.Windows.Forms.Label rgbValuesLabel;
        private System.Windows.Forms.Label hsvValuesLabel;
        private System.Windows.Forms.PictureBox hsvWheelPictureBox;
    }
}