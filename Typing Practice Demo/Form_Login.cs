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
using Typing_Practice_Demo.Forms;

namespace Typing_Practice_Demo
{
    public partial class Form_Login : Form
    {
        private Form activateForm;
        private Form formDangNhap = new Form_DangNhap();
        public Form_Login()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {
            if (activateForm != null)
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
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            OpenChildForm( formDangNhap);
        }

        private void FormDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            activateForm = null;
            formDangNhap = new Forms.Form_DangNhap();
            OpenChildForm(formDangNhap);
            panel_DangKy.Show();
        }

        private void buttonDangky_Click(object sender, EventArgs e)
        {
            FormDangKy formDangKy = new FormDangKy();
            OpenChildForm(formDangKy);
            formDangKy.FormClosed += FormDangKy_FormClosed;
            panel_DangKy.Hide();
        }
    }
}
