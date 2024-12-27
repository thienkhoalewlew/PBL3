using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Practice_Demo.Forms
{
    public partial class Form_AddEditUser : Form
    {
        string maNguoiDung;
        bool AddOrEdit; //true => add, false => edit
        public Form_AddEditUser(string MaNguoiDung = null)
        {
            maNguoiDung=MaNguoiDung;
            if (string.IsNullOrEmpty(maNguoiDung))
            {
                AddOrEdit = true;
            }
            else
            {
                 AddOrEdit = false;
            }
            InitializeComponent();

        }

        private void Form_AddEditUser_Load(object sender, EventArgs e)
        {
            label8.Text = "";
            dynamic user = nguoidungBLL.Instance.GetInFoUser(maNguoiDung);
            if (user != null)
            {
                textBoxName.Text = user.GetType().GetProperty("hoten").GetValue(user, null);
                if (user.GetType().GetProperty("gioitinh").GetValue(user, null) == true)
                {
                    radioButton_Nam.Checked = true;
                }
                else
                {
                    radioButton_Nu.Checked = true;
                }
                dateTimePicker_DateOfBirth.Value = DateTime.Parse(user.GetType().GetProperty("ngaysinh").GetValue(user, null).ToString());
                textBox_PhoneNumber.Text = user.GetType().GetProperty("sdt").GetValue(user, null);
                textBox_Email.Text = user.GetType().GetProperty("email").GetValue(user, null);
                textBox_Pass.Text = user.GetType().GetProperty("password").GetValue(user, null);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string MaNguoiDung = nguoidungBLL.Instance.GetRandomMa();
            string HoVaTen = textBoxName.Text;
            bool GioiTinh;
            DateTime ngaySinh = dateTimePicker_DateOfBirth.Value;
            string MaTaiKhoan = "ACC" + MaNguoiDung.Substring(4, MaNguoiDung.Length - 4);
            string NgaySinh = dateTimePicker_DateOfBirth.Value.ToString("dd/MM/yyyy");
            string sdt = textBox_PhoneNumber.Text;
            float TongDiem = 0;
            string email = textBox_Email.Text;
            string pass = textBox_Pass.Text;

            if (String.IsNullOrWhiteSpace(textBoxName.Text) ||
                String.IsNullOrWhiteSpace(dateTimePicker_DateOfBirth.Text) ||
                String.IsNullOrWhiteSpace(textBox_PhoneNumber.Text) ||
                String.IsNullOrWhiteSpace(textBox_Email.Text) ||
                String.IsNullOrWhiteSpace(textBox_Pass.Text))
            {
                label8.Text = "Please fill in all the required information";
                label8.ForeColor = Color.Red;
                return;
            }
            if (taikhoanBLL.Instance.CheckEmail(email))
            {
                label8.Text = "This email is already used for another account";
                label8.ForeColor = Color.Red;
            }
            if (!radioButton_Nam.Checked && !radioButton_Nu.Checked)
            {
                label8.Text = "Please choose your gender";
                label8.ForeColor = Color.Red;
                return;
            }

            if (IsValidEmail(email) == false)
            {
                label8.Text = "Please re-enter your email";
                label8.ForeColor = Color.Red;
                textBox_Email.Text = "";
                return;
            }

            if (IsValidPhoneNumber(textBox_PhoneNumber.Text) == false)
            {
                label8.Text = "Please re-enter your phone number";
                label8.ForeColor = Color.Red;
                textBox_PhoneNumber.Text = "";
                return;
            }

            if (IsPasswordValid(textBox_Pass.Text) == false)
            {
                label8.Text = "The password must be more than 6 characters long and include both letters and numbers";
                label8.ForeColor = Color.Red;
                textBox_Pass.Text = "";
                return;
            }

            if (radioButton_Nam.Checked) GioiTinh = true;
            else GioiTinh = false;
            if (AddOrEdit)
            {
                nguoidungBLL.Instance.SaveNguoiDung(MaNguoiDung, HoVaTen, GioiTinh, NgaySinh, sdt, TongDiem, AddOrEdit);
                taikhoanBLL.Instance.SaveTaiKhoan(MaTaiKhoan, MaNguoiDung, email, pass, AddOrEdit);
                MessageBox.Show("Complete Add User");
            }
            else
            {
                nguoidungBLL.Instance.SaveNguoiDung(maNguoiDung, HoVaTen, GioiTinh, NgaySinh, sdt, TongDiem, AddOrEdit);
                taikhoanBLL.Instance.SaveTaiKhoan("ACC" + maNguoiDung.Substring(4, maNguoiDung.Length - 4), 
                                                   maNguoiDung, 
                                                   email, 
                                                   pass, 
                                                   AddOrEdit);
                MessageBox.Show("Complete Edit User");
            }
            this.Close();
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}