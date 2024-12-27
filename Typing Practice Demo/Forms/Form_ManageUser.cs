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
    public partial class Form_ManageUser : Form
    {
        private Form_AddEditUser formAddEditUser;

        public Form_ManageUser()
        {
            InitializeComponent();
        }

        private void dataGridView_Load(object sender, EventArgs e)
        {
            var ListNguoiDungBLL = nguoidungBLL.Instance;
            var ListUser = ListNguoiDungBLL.getListUser();
            dataGridView1.DataSource = ListUser;
        }

        private void Form_ManageUser_Load(object sender, EventArgs e)
        {
            dataGridView_Load(null, null);
        }

        private void OpenForm_AddEditUser(object sender, EventArgs e,string MaNguoiDung)
        {
            formAddEditUser = new Form_AddEditUser(MaNguoiDung);
            formAddEditUser.FormClosed += FormAddEditUser_FormClosed;
            formAddEditUser.TopLevel = false;
            formAddEditUser.FormBorderStyle = FormBorderStyle.None;
            formAddEditUser.Dock = DockStyle.Fill;
            this.Controls.Add(formAddEditUser);
            this.Tag = formAddEditUser.Tag;
            formAddEditUser.BringToFront();
            formAddEditUser.Show();
            panel1.Hide();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenForm_AddEditUser(null, null, null);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MaNguoiDung = taikhoanBLL.Instance.
                                      GetIDByEmail(dataGridView1.SelectedRows[0].
                                                   Cells["Email"].Value.ToString());
                OpenForm_AddEditUser(null, null, MaNguoiDung);
            }
        }

        private void FormAddEditUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            formAddEditUser.Dispose();
            dataGridView_Load(null, null);
            panel1.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string MaNguoiDung = taikhoanBLL.Instance.
                                      GetIDByEmail(dataGridView1.SelectedRows[0].
                                                   Cells["Email"].Value.ToString());
            string MaTaiKhoan = "ACC" + MaNguoiDung.Substring(4);
            
            DialogResult result = MessageBox.Show("Are you sure you want to delete the user?"
                                                  ,"", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                taikhoanBLL.Instance.DeleteAccount(MaTaiKhoan);
                nguoidungBLL.Instance.DeleteUser(MaNguoiDung);
                MessageBox.Show("Compele Delete User");
                dataGridView_Load(null,null);
            }
            else if(result == DialogResult.Cancel)
            {
                return;
            }
        }
    }
}
