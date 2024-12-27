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

namespace Typing_Practice_Demo.Forms
{
    public partial class Form_DangNhap : Form
    {
        public Form_DangNhap()
        {
            InitializeComponent();
        }


        private void buttonLog_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string pass = textBoxPass.Text;
            if (taikhoanBLL.Instance.CheckTaiKhoan(email, pass) == true)
            {
                ((Form_Login)this.Parent.Parent).Close();
                this.Close();
                Form_Start formStart = new Form_Start(taikhoanBLL.Instance.GetIDByEmail(email));
                formStart.Show();
            }
            else
            {
                label1.Text = "Incorrect email or password";
                label1.ForeColor = Color.Red;
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_DangNhap_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }
}
