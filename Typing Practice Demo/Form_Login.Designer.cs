namespace Typing_Practice_Demo
{
    partial class Form_Login
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
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panel_DangKy = new System.Windows.Forms.Panel();
            this.buttonDangky = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelChildForm.SuspendLayout();
            this.panel_DangKy.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChildForm
            // 
            this.panelChildForm.Controls.Add(this.panel_DangKy);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelChildForm.Location = new System.Drawing.Point(1, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(500, 553);
            this.panelChildForm.TabIndex = 0;
            // 
            // panel_DangKy
            // 
            this.panel_DangKy.Controls.Add(this.label2);
            this.panel_DangKy.Controls.Add(this.buttonDangky);
            this.panel_DangKy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_DangKy.Location = new System.Drawing.Point(0, 501);
            this.panel_DangKy.Name = "panel_DangKy";
            this.panel_DangKy.Size = new System.Drawing.Size(500, 52);
            this.panel_DangKy.TabIndex = 0;
            // 
            // buttonDangky
            // 
            this.buttonDangky.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonDangky.FlatAppearance.BorderSize = 0;
            this.buttonDangky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDangky.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonDangky.ForeColor = System.Drawing.Color.Goldenrod;
            this.buttonDangky.Location = new System.Drawing.Point(275, 7);
            this.buttonDangky.Name = "buttonDangky";
            this.buttonDangky.Size = new System.Drawing.Size(101, 39);
            this.buttonDangky.TabIndex = 17;
            this.buttonDangky.Text = "Sign Up";
            this.buttonDangky.UseVisualStyleBackColor = false;
            this.buttonDangky.Click += new System.EventHandler(this.buttonDangky_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Goldenrod;
            this.label2.Location = new System.Drawing.Point(119, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "No account yet?";
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(501, 553);
            this.ControlBox = false;
            this.Controls.Add(this.panelChildForm);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form_Login_Load);
            this.panelChildForm.ResumeLayout(false);
            this.panel_DangKy.ResumeLayout(false);
            this.panel_DangKy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel panel_DangKy;
        private System.Windows.Forms.Button buttonDangky;
        private System.Windows.Forms.Label label2;
    }
}