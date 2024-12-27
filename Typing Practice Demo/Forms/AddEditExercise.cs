using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Typing_Practice_Demo.Forms
{
    public partial class AddEditExercise : Form
    {
        string ExerciseID;
        bool AddOrEdit;

        public AddEditExercise(string MaBaiTap = null)
        {
            ExerciseID = MaBaiTap;
            if (ExerciseID == null)
            {
                AddOrEdit = true;
            }
            else
            {
                AddOrEdit = false;
            }
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void AddEditExercise_Load(object sender, EventArgs e)
        {

            if(ExerciseID != null)
            {
                textBoxID.Enabled = false;
                baitap baitap = baitapBLL.Instance.GetInfoExercise(ExerciseID);
                TimeSpan? time = baitap.thoigian;
                if (baitap != null)
                {
                    textBoxID.Text = baitap.mabaitap;
                    textBoxTime.Text = time.ToString();
                    textBoxName.Text = baitap.tenbaitap;
                    comboBoxLevel.Text = baitap.dokho;
                    if (textBoxTime.Text.Length == 2 && textBoxTime.Text.IndexOf(":") < 0)
                    {
                        textBoxTime.Text += ":";
                        textBoxTime.SelectionStart = textBoxTime.Text.Length;
                    }
                    else if (textBoxTime.Text.Length == 5)
                    {
                        string[] timeComponents = textBoxTime.Text.Split(':');
                        if (timeComponents.Length == 2)
                        {
                            int minutes, seconds;
                            if (int.TryParse(timeComponents[0], out minutes) && int.TryParse(timeComponents[1], out seconds))
                            {
                                if (minutes >= 60)
                                {
                                    minutes %= 60;
                                    textBoxTime.Text = minutes.ToString("00") + ":" + seconds.ToString("00");
                                }
                            }
                        }
                    }
                    richTextBoxND.Text = baitap.noidung;
                    textBoxPoint.Text = baitap.diemmokhoa.ToString();
                }
            }
            if(AddOrEdit == false)
            {
                comboBoxLevel.Enabled = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string MaBaiTap = textBoxID.Text;
            string Name = textBoxName.Text;
            string Content = richTextBoxND.Text;
            string Level = comboBoxLevel.Text;
            String TimeString = textBoxTime.Text;
            TimeSpan? timeSpan = null;
            if (TimeSpan.TryParse(TimeString, out TimeSpan result))
            {
                timeSpan = result;
            }
            string pointString = textBoxPoint.Text;
            float diemMoKhoa = 0;
            if (float.TryParse(pointString, out float parsedResult))
            {
                diemMoKhoa = parsedResult;
            }
            baitapBLL.Instance.SaveExercise(MaBaiTap, Name, Content, Level, timeSpan, diemMoKhoa, AddOrEdit);
            if (AddOrEdit)
            {
                MessageBox.Show("Complete Add Exercise");
            }
            else
            {
                MessageBox.Show("Complete Edit Exercise");
            }
            this.Close();
        }

        private void richTextBoxND_Leave(object sender, EventArgs e)
        {
            textBoxTime.Text ="00:00:"+ (richTextBoxND.Text.Length / 3).ToString();
            if (textBoxTime.Text.Length == 2 && textBoxTime.Text.IndexOf(":") < 0)
            {
                textBoxTime.Text += ":";
                textBoxTime.SelectionStart = textBoxTime.Text.Length;
            }
            else if (textBoxTime.Text.Length == 5)
            {
                string[] timeComponents = textBoxTime.Text.Split(':');
                if (timeComponents.Length == 2)
                {
                    int minutes, seconds;
                    if (int.TryParse(timeComponents[0], out minutes) && int.TryParse(timeComponents[1], out seconds))
                    {
                        if (minutes >= 60)
                        {
                            minutes %= 60;
                            textBoxTime.Text = minutes.ToString("00") + ":" + seconds.ToString("00");
                        }
                    }
                }
            }
        }

        private void comboBoxLevel_Leave(object sender, EventArgs e)
        {
            string IDCu = textBoxID.Text;
            if(AddOrEdit == true)
            {
                textBoxID.Text = comboBoxLevel.Text.Substring(0, 3).ToUpper() 
                               + (baitapBLL.Instance.GetCountBaiTap() + 1).ToString();
            }
            if (baitapBLL.Instance.CheckIDBaiTap(textBoxID.Text) == false)
            {
                int So = Convert.ToInt32(textBoxID.Text.Substring(3))+1;
                textBoxID.Text = comboBoxLevel.Text.Substring(0, 3).ToUpper() + So.ToString();
            }
        }
    }
}
