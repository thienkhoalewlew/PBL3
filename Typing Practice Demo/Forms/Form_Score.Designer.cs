namespace Typing_Practice_Demo.Forms
{
    partial class Form_Score
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
            this.labelComplite = new System.Windows.Forms.Label();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelLevel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPoint = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelComplite
            // 
            this.labelComplite.AutoSize = true;
            this.labelComplite.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelComplite.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelComplite.Location = new System.Drawing.Point(375, 28);
            this.labelComplite.Name = "labelComplite";
            this.labelComplite.Size = new System.Drawing.Size(193, 23);
            this.labelComplite.TabIndex = 0;
            this.labelComplite.Text = "Complete Exercise!!!";
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.labelLevel);
            this.groupBoxResult.Controls.Add(this.label1);
            this.groupBoxResult.Controls.Add(this.labelRate);
            this.groupBoxResult.Controls.Add(this.label3);
            this.groupBoxResult.Controls.Add(this.label2);
            this.groupBoxResult.Controls.Add(this.labelPoint);
            this.groupBoxResult.Controls.Add(this.labelSpeed);
            this.groupBoxResult.Controls.Add(this.labelName);
            this.groupBoxResult.Location = new System.Drawing.Point(189, 68);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(555, 297);
            this.groupBoxResult.TabIndex = 1;
            this.groupBoxResult.TabStop = false;
            // 
            // buttonOK
            // 
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.buttonOK.ForeColor = System.Drawing.Color.Goldenrod;
            this.buttonOK.Location = new System.Drawing.Point(435, 382);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonOK.Size = new System.Drawing.Size(63, 29);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelLevel.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelLevel.Location = new System.Drawing.Point(121, 99);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(140, 22);
            this.labelLevel.TabIndex = 0;
            this.labelLevel.Text = "Exercise Level:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(121, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rate: ";
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelRate.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelRate.Location = new System.Drawing.Point(267, 147);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(42, 22);
            this.labelRate.TabIndex = 0;
            this.labelRate.Text = "rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Goldenrod;
            this.label3.Location = new System.Drawing.Point(121, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Point:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Goldenrod;
            this.label2.Location = new System.Drawing.Point(121, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Typing Speed: ";
            // 
            // labelPoint
            // 
            this.labelPoint.AutoSize = true;
            this.labelPoint.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelPoint.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelPoint.Location = new System.Drawing.Point(267, 235);
            this.labelPoint.Name = "labelPoint";
            this.labelPoint.Size = new System.Drawing.Size(51, 22);
            this.labelPoint.TabIndex = 0;
            this.labelPoint.Text = "point";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelSpeed.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelSpeed.Location = new System.Drawing.Point(267, 190);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(64, 22);
            this.labelSpeed.TabIndex = 0;
            this.labelSpeed.Text = "speed";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelName.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelName.Location = new System.Drawing.Point(121, 51);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(144, 22);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Exercise Name:";
            // 
            // Form_Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(964, 436);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.labelComplite);
            this.Name = "Form_Score";
            this.Text = "Score";
            this.Load += new System.EventHandler(this.Form_Score_Load);
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelComplite;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPoint;
        private System.Windows.Forms.Button buttonOK;
    }
}