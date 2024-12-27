using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DiemDanhBLL
    {
        private static DiemDanhBLL instance;
        public static DiemDanhBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DiemDanhBLL();
                }
                return instance;
            }
            private set { }
        }

        public DiemDanhBLL() { }

        public DataTable getNgay(string MaNguoiDung)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Ngày đã điểm danh", typeof(DateTime));
                var NgayDiemDanhList = context.diemdanhs
                    .Where(p => p.manguoidung == MaNguoiDung)
                    .Select(p => p.ngay).ToList();
                foreach (var ngay in NgayDiemDanhList)
                {
                    DataRow row = dt.NewRow();
                    row["Ngày đã điểm danh"] = ngay;
                    dt.Rows.Add(row);
                }
                return dt;
            }
        }
        public void addNgayDiemDanh(string MaNguoiDung)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var ngayDiemDanh = context.diemdanhs
                    .FirstOrDefault(p => p.manguoidung == MaNguoiDung && p.ngay == DateTime.Today);
                if (ngayDiemDanh == null)
                {
                    ngayDiemDanh = new diemdanh()
                    {
                        manguoidung = MaNguoiDung,
                        ngay = DateTime.Today
                    };
                    context.diemdanhs.Add(ngayDiemDanh);
                    context.SaveChanges();
                }
            }
        }
    }
}
