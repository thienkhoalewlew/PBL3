using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Practice_Demo.Forms
{
    public partial class Form_Exercise : Form
    {
        string MaBaiTap;
        string text;
        int missword;
        int seconds;
        int ExeCount;
        string MaNguoiDung;

        public Form_Exercise(string manguoidung,string maBaiTap = null)
        {
            MaBaiTap = maBaiTap;
            MaNguoiDung = manguoidung;
            InitializeComponent();
        }

        private void OpenForm_Score(object sender, EventArgs e)
        {
            Form_Score frmScore = new Form_Score(MaNguoiDung, ExeCount,missword ,seconds, MaBaiTap);
            frmScore.Parentform = this;
            frmScore.TopLevel = false;
            frmScore.FormBorderStyle = FormBorderStyle.None;
            frmScore.Dock = DockStyle.Fill;
            this.Controls.Add(frmScore);
            this.Tag = frmScore.Tag;
            frmScore.BringToFront();
            frmScore.Show();
        }

        private void Form_Exercise_Load(object sender, EventArgs e)
        {
            text = baitapBLL.Instance.GetNoiDung(MaBaiTap);
            ExeCount = text.Length;
            richTextBox.Focus();
            richTextBox.Text = text + " ";
            ToMau10ngon("1 q a z Q A Z", Color.Red, richTextBox);
            ToMau10ngon("2 w s x W S X", Color.Orange, richTextBox);
            ToMau10ngon("3 e d c E D C", Color.Green, richTextBox);
            ToMau10ngon("4 r f v 5 t g b R F V T G B", Color.LightSkyBlue, richTextBox);
            ToMau10ngon("6 y h n 7 u j m Y H N U J M", Color.DarkSlateBlue, richTextBox);
            ToMau10ngon("8 i k , I K", Color.DeepSkyBlue, richTextBox);
            ToMau10ngon("9 o l O L", Color.LightGoldenrodYellow, richTextBox);
            ToMau10ngon("0 p P", Color.DarkOliveGreen, richTextBox);
            richTextBox.SelectionStart = 0;
            richTextBox.Select(0, 1);
            timer1.Enabled = true;
            labelClock.Text = "00:00";
        }
        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            int currentPosition = richTextBox.SelectionStart;
            char currentChar = richTextBox.Text[currentPosition];
            float rate = ((float)(richTextBox.TextLength - missword)/richTextBox.TextLength)*100;
            e.SuppressKeyPress = true;
            e.Handled = true;

            if (char.IsLetterOrDigit((char)e.KeyValue) || e.KeyValue == (int)Keys.Space)
            {
                char inputChar = e.Shift ? (char)e.KeyValue : char.ToLower((char)e.KeyValue);
                if (currentChar == inputChar)
                {
                    richTextBox.Select(currentPosition, 1);
                    richTextBox.SelectionColor = Color.DimGray;
                    richTextBox.Select(currentPosition + 1, 1);
                }
                else if(currentChar != inputChar && currentPosition != text.Length - 1)
                {
                    richTextBox.Select(currentPosition, 1);
                    richTextBox.SelectionColor = Color.Red;
                    richTextBox.Select(currentPosition + 1, 1);
                    missword += 1;
                }
                e.SuppressKeyPress = true;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
            if (currentPosition == text.Length - 1)
            {
                timer1.Stop();
                OpenForm_Score(sender, e);
                panelBar.Hide();
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            labelClock.Text = time.ToString("mm':'ss");
        }
        private void ToMau10ngon(string characters, Color color, RichTextBox richTextBox)
        {
            string[] words = richTextBox.Text
                            .Split(new char[] { ' ', '\t', '\n', '\r' },
                             StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];
                    if (characters.Contains(c))
                    {
                        richTextBox.Select(richTextBox.Text.IndexOf(word) + i, 1);
                        richTextBox.SelectionColor = color;
                    }
                }
            }
        }

        private void buttonTamDung_Click(object sender, EventArgs e)
        {
            TrangThaiTamDung(true);
        }

        private void richTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            TrangThaiTamDung(true);
        }
        private void TrangThaiTamDung(bool tamDung)
        {
            if (tamDung)
            {
                timer1.Stop();
                richTextBox.Enabled = false;                
            }
            else
            {
                timer1.Start();
                richTextBox.Enabled = true;
            }
        }

        private void buttonTiepTuc_Click(object sender, EventArgs e)
        {
            TrangThaiTamDung(false);
            richTextBox.Focus();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}