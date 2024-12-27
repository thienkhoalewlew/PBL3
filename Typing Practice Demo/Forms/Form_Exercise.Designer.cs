namespace Typing_Practice_Demo.Forms
{
    partial class Form_Exercise
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
            this.components = new System.ComponentModel.Container();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelClock = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonTamDung = new System.Windows.Forms.Button();
            this.buttonTiepTuc = new System.Windows.Forms.Button();
            this.panelBar = new System.Windows.Forms.Panel();
            this.buttonEnd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.richTextBox.ForeColor = System.Drawing.Color.Black;
            this.richTextBox.Location = new System.Drawing.Point(12, 76);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(940, 186);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            this.richTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyDown);
            this.richTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelClock
            // 
            this.labelClock.AutoSize = true;
            this.labelClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelClock.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelClock.Location = new System.Drawing.Point(422, 9);
            this.labelClock.Name = "labelClock";
            this.labelClock.Size = new System.Drawing.Size(64, 25);
            this.labelClock.TabIndex = 3;
            this.labelClock.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Typing_Practice_Demo.Properties.Resources.go_10_ngon;
            this.pictureBox1.Location = new System.Drawing.Point(325, 268);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 179);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // buttonTamDung
            // 
            this.buttonTamDung.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonTamDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTamDung.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonTamDung.ForeColor = System.Drawing.Color.Goldenrod;
            this.buttonTamDung.Location = new System.Drawing.Point(0, 0);
            this.buttonTamDung.Name = "buttonTamDung";
            this.buttonTamDung.Size = new System.Drawing.Size(110, 41);
            this.buttonTamDung.TabIndex = 5;
            this.buttonTamDung.Text = "Pause";
            this.buttonTamDung.UseVisualStyleBackColor = true;
            this.buttonTamDung.Click += new System.EventHandler(this.buttonTamDung_Click);
            // 
            // buttonTiepTuc
            // 
            this.buttonTiepTuc.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonTiepTuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTiepTuc.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonTiepTuc.ForeColor = System.Drawing.Color.Goldenrod;
            this.buttonTiepTuc.Location = new System.Drawing.Point(110, 0);
            this.buttonTiepTuc.Name = "buttonTiepTuc";
            this.buttonTiepTuc.Size = new System.Drawing.Size(110, 41);
            this.buttonTiepTuc.TabIndex = 5;
            this.buttonTiepTuc.Text = "Resume";
            this.buttonTiepTuc.UseVisualStyleBackColor = true;
            this.buttonTiepTuc.Click += new System.EventHandler(this.buttonTiepTuc_Click);
            // 
            // panelBar
            // 
            this.panelBar.Controls.Add(this.buttonEnd);
            this.panelBar.Controls.Add(this.buttonTiepTuc);
            this.panelBar.Controls.Add(this.labelClock);
            this.panelBar.Controls.Add(this.buttonTamDung);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(964, 41);
            this.panelBar.TabIndex = 6;
            // 
            // buttonEnd
            // 
            this.buttonEnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEnd.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonEnd.ForeColor = System.Drawing.Color.Goldenrod;
            this.buttonEnd.Location = new System.Drawing.Point(220, 0);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(110, 41);
            this.buttonEnd.TabIndex = 6;
            this.buttonEnd.Text = "End";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // Form_Exercise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(964, 436);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBox);
            this.Name = "Form_Exercise";
            this.Text = "Exercise";
            this.Load += new System.EventHandler(this.Form_Exercise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBar.ResumeLayout(false);
            this.panelBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelClock;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonTamDung;
        private System.Windows.Forms.Button buttonTiepTuc;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button buttonEnd;
    }
}