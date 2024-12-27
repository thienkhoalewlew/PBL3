using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Practice_Demo.Forms
{
    public partial class FormDangKy : Form
    {

        public FormDangKy()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            string MaNguoiDung = nguoidungBLL.Instance.GetRandomMa();
            string HoVaTen = textBoxName.Text;
            bool GioiTinh;
            DateTime ngaySinh = dateTimePicker_NgaySinh.Value;
            string MaTaiKhoan = "ACC" + MaNguoiDung.Substring(4, MaNguoiDung.Length - 4);
            string NgaySinh = dateTimePicker_NgaySinh.Value.ToString("dd/MM/yyyy");
            string sdt = textBox_SDT.Text;
            float TongDiem = 0;
            string email = textBox_Email.Text;
            string pass = textBox_Pass.Text;

            if (String.IsNullOrWhiteSpace(textBoxName.Text) || 
                String.IsNullOrWhiteSpace(dateTimePicker_NgaySinh.Text) || 
                String.IsNullOrWhiteSpace(textBox_SDT.Text) || 
                String.IsNullOrWhiteSpace(textBox_Email.Text ) || 
                String.IsNullOrWhiteSpace(textBox_Pass.Text) || 
                String.IsNullOrWhiteSpace(textBox_Pass2.Text))
            {
                label8.Text = "Please fill in all the required information";
                label8.ForeColor = Color.Red;
                return;
            }

            if(!radioButton_Nam.Checked && !radioButton_Nu.Checked)
            {
                label8.Text = "Please choose your gender";
                label8.ForeColor = Color.Red;
                return;
            }

            if(IsValidEmail(email) == false)
            {
                label8.Text = "Please make sure to enter a valid email format, such as username@example.com";
                label8.ForeColor = Color.Red;
                textBox_Email.Text = "";
                return;
            }

            if (IsValidPhoneNumber(textBox_SDT.Text) == false)
            {
                label8.Text = "Please enter a complete phone number consisting of 10 digits starting with 0";
                label8.ForeColor = Color.Red;
                textBox_SDT.Text = "";
                return;
            }

            if(IsPasswordValid(textBox_Pass.Text) == false)
            {
                label8.Text = "The password must be more than 6 characters long and include both letters and numbers";
                label8.ForeColor = Color.Red;
                textBox_Pass.Text = "";
                textBox_Pass2.Text = "";
                return;
            }

            if (taikhoanBLL.Instance.CheckEmail(email))
            {
                label8.Text = "This email is already used for another account";
                label8.ForeColor = Color.Red;
            }
            if (radioButton_Nam.Checked) GioiTinh = true; 
            else GioiTinh = false; 

            if(textBox_Pass2.Text == textBox_Pass.Text)
            {
                nguoidungBLL.Instance.SaveNguoiDung(MaNguoiDung, HoVaTen, GioiTinh, NgaySinh, sdt, TongDiem, true);
                taikhoanBLL.Instance.SaveTaiKhoan(MaTaiKhoan, MaNguoiDung, email, pass, true);
                MessageBox.Show("Registration successful");
                this.Close();   
            }
            else
            {
                labelCheckPass.Text = "Please provide the confirmation password again";
                labelCheckPass.ForeColor= Color.Red;
            }
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {
            label8.Text = "";
            labelCheckPass.Text = "";
        }
        public bool IsValidEmail(string email)
        {
            try
            {   
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^0\d{9}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }

        public bool IsPasswordValid(string password)
        {
            if (password.Length <= 6)
            {
                return false;
            }
            string pattern = @"^(?=.*[a-zA-Z])(?=.*\d).+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }
    }
}
