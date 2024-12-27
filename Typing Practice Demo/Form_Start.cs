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

namespace Typing_Practice_Demo
{
    public partial class Form_Start : Form
    {
        private string IDNguoiDung;
        private Form activateForm;

        public Form_Start(string MaNguoiDung = null)
        {
            InitializeComponent();
            IDNguoiDung = MaNguoiDung;
        }

        private void OpenChildForm(Form childForm)
        {
            if(activateForm != null)
            {
                activateForm.Close();
            }
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelChildForm.Controls.Add(childForm);
            this.panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitle.Text = childForm.Text;
        }

        private void buttonExercise_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Form_ListExercise(IDNguoiDung));
        }

        private void buttonAttendance_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Form_Attendance(IDNguoiDung));
        }

        private void buttonManageUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Form_ManageUser());
        }

        private void buttonManageExe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Form_ManageExe());
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Form_Login formLog = new Form_Login();
            formLog.Show();
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Form_Start_Load(object sender, EventArgs e)
        {
            labelInforUser.Text = "Welcome " + nguoidungBLL.Instance.GetNameByID(IDNguoiDung) + " to Typing Practice!!!";
            if(taikhoanBLL.Instance.GetRoleUser(IDNguoiDung) == false)
            {
                buttonManageExe.Visible = false;
                buttonManageUser.Visible = false;
            }
            labelTongDiem.Text = "Score: " + ((double)nguoidungBLL.Instance.SetScoreTotal(IDNguoiDung)).ToString("0");
        }
    }
}
