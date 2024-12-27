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
    public partial class Form_Attendance : Form
    {
        string IDNguoiDung;
        public Form_Attendance(string MaNguoiDung = null)
        {
            InitializeComponent();
            IDNguoiDung = MaNguoiDung;
        }
        private bool IsLastRowToday(DataGridView dataGridView)
        {
            int lastRowIndex = dataGridView.Rows.Count - 1;
            if (lastRowIndex < 0) return false; 
            DateTime lastRowDate = (DateTime)dataGridView.Rows[lastRowIndex].Cells["Ngày đã điểm danh"].Value;
            return lastRowDate.Date == DateTime.Now.Date;
        }

        private void dataGridViewAttendance_Load(object sender, EventArgs e)
        {
            var ngayDiemDanhBLL = DiemDanhBLL.Instance;
            var danhSachNgayDiemDanh = ngayDiemDanhBLL.getNgay(IDNguoiDung);
            dataGridViewAttendance.DataSource = danhSachNgayDiemDanh;
        }

        private void Form_Attendance_Load(object sender, EventArgs e)
        {
            dataGridViewAttendance_Load(sender, e);
        }

        private void buttonAttendance_Click(object sender, EventArgs e)
        {
            if(IsLastRowToday(dataGridViewAttendance))
            {
                MessageBox.Show("You have already marked your attendance for today!");
            }
            else
            {
                DiemDanhBLL.Instance.addNgayDiemDanh(IDNguoiDung);
                MessageBox.Show("Attendance recorded successfully!");
                dataGridViewAttendance_Load(sender, e);
            }
            ((Form_Start)this.Parent.Parent).Form_Start_Load(null, null);
        }
    }
}
