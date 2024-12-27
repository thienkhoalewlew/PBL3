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
    public partial class Form_ManageExe : Form
    {
        private AddEditExercise formAddEditExercise;
        public Form_ManageExe()
        {
            InitializeComponent();
        }

        private void dataGridView_Load(object sender, EventArgs e)
        {
            var ListExerciseBLL = baitapBLL.Instance;
            var ListExercise = ListExerciseBLL.GetListExercise();
            dataGridView1.DataSource = ListExercise;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_Load(null, null);
        }

        private void OpenForm_AddEditUser(object sender, EventArgs e, string MaBaiTap)
        {
            formAddEditExercise = new AddEditExercise(MaBaiTap);
            formAddEditExercise.FormClosed += FormAddEditExercise_FormClosed;
            formAddEditExercise.TopLevel = false;
            formAddEditExercise.FormBorderStyle = FormBorderStyle.None;
            formAddEditExercise.Dock = DockStyle.Fill;
            this.Controls.Add(formAddEditExercise);
            this.Tag = formAddEditExercise.Tag;
            formAddEditExercise.BringToFront();
            formAddEditExercise.Show();
            panel1.Hide();
        }

        private void FormAddEditExercise_FormClosed(object sender, FormClosedEventArgs e)
        {
            formAddEditExercise.Dispose();
            dataGridView_Load(null, null);
            panel1.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenForm_AddEditUser(null,null,null);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maBaiTap = selectedRow.Cells["Mã bài tập"].Value.ToString();
                OpenForm_AddEditUser(null, null, maBaiTap);
            }
            else
            {
                MessageBox.Show("Please select only one row for editing");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string MaBaiTap = dataGridView1.SelectedRows[0].Cells["Mã bài tập"].Value.ToString();
            DialogResult result = MessageBox.Show("Are you sure you want to delete the exercise?"
                                                , "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                baitapBLL.Instance.DeleteBaiTap(MaBaiTap);
                MessageBox.Show("Compele Delete Exercise");
                dataGridView_Load(null, null);
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }
    }
}
