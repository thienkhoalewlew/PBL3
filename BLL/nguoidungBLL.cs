using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class nguoidungBLL
    {
        private static nguoidungBLL instance;
        public static nguoidungBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new nguoidungBLL();
                }
                return instance;
            }
            private set { }
        }
        private nguoidungBLL() { }

        public string GetRandomMa()
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                Random random = new Random();
                string Ma = "USER" + random.Next(0, 1000);
                while (context.nguoidungs.FirstOrDefault(p => p.manguoidung == Ma) != null)
                {
                    Ma = "USER" + random.Next(0, 1000);
                }
                return Ma;
            }
        }
        public string GetNameByID(string IDNguoiDung)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var Nguoidung = context.nguoidungs.FirstOrDefault(p => p.manguoidung == IDNguoiDung);
                if (Nguoidung == null) { return null; }
                return Nguoidung.hoten;
            }
        }
        public List<nguoidung> GetAllNguoiDung()
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var nguoiDungList = context.nguoidungs.ToList();
                return nguoiDungList;
            }
        }
        public void SaveNguoiDung(string MaNguoiDung,
                         string HoTen,
                         bool GioiTinh,
                         string NgaySinh,
                         string SDT,
                         float TongDiem,
                         bool AddorEdit)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var nguoiDung = context.nguoidungs.FirstOrDefault(n => n.manguoidung == MaNguoiDung);
                if (AddorEdit == false)
                {
                    nguoiDung.hoten = HoTen;
                    nguoiDung.gioitinh = GioiTinh;
                    nguoiDung.ngaysinh = Convert.ToDateTime(NgaySinh);
                    nguoiDung.sdt = SDT;
                    nguoiDung.tongdiem = TongDiem;
                }
                else
                {
                    nguoiDung = new nguoidung()
                    {
                        manguoidung = MaNguoiDung,
                        hoten = HoTen,
                        gioitinh = GioiTinh,
                        ngaysinh = Convert.ToDateTime(NgaySinh),
                        sdt = SDT,
                        tongdiem = TongDiem
                    };
                    context.nguoidungs.Add(nguoiDung);
                }
                context.SaveChanges();
            }
        }

        public DataTable getListUser()
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var query = from nguoidung in context.nguoidungs
                            join taikhoan in context.taikhoans
                                          on nguoidung.manguoidung
                                          equals taikhoan.manguoidung
                            select new
                            {
                                nguoidung.hoten,
                                nguoidung.ngaysinh,
                                nguoidung.sdt,
                                taikhoan.email,
                                taikhoan.password,
                                nguoidung.tongdiem,
                                taikhoan.role
                            };

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Họ tên");
                dataTable.Columns.Add("Ngày sinh");
                dataTable.Columns.Add("Số điện thoại");
                dataTable.Columns.Add("Email");
                dataTable.Columns.Add("Mật khẩu");
                dataTable.Columns.Add("Tổng điểm");
                dataTable.Columns.Add("Chức vụ");

                foreach (var taikhoan in query)
                {
                    bool Role = taikhoan.role ?? false;
                    string ChucVu = Role ? "Admin" : "Người dùng";
                    dataTable.Rows.Add(taikhoan.hoten,
                                       taikhoan.ngaysinh,
                                       taikhoan.sdt,
                                       taikhoan.email,
                                       taikhoan.password,
                                       taikhoan.tongdiem,
                                       ChucVu
                                      );
                }

                return dataTable;
            }
        }

        public dynamic GetInFoUser(string MaNguoiDung)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var userInfo = (from nguoidung in context.nguoidungs
                                join taikhoan in context.taikhoans on nguoidung.manguoidung equals taikhoan.manguoidung
                                where nguoidung.manguoidung == MaNguoiDung
                                select new 
                                {
                                    manguoidung = nguoidung.manguoidung,
                                    hoten = nguoidung.hoten,
                                    gioitinh = nguoidung.gioitinh,
                                    ngaysinh = nguoidung.ngaysinh,
                                    sdt = nguoidung.sdt,
                                    mataikhoan = taikhoan.mataikhoan,
                                    email = taikhoan.email,
                                    password = taikhoan.password
                                }).FirstOrDefault();
                return userInfo;
            }
        }

        public void DeleteUser(string MaNguoiDung)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var nguoidung = context.nguoidungs.FirstOrDefault(p => p.manguoidung == MaNguoiDung);
                context.nguoidungs.Remove(nguoidung);
                context.SaveChanges();
            }
        }

        public void SavePointTotal(string MaNguoiDung, double? ScoreTotal)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var nguoidung = context.nguoidungs.FirstOrDefault(p => p.manguoidung == MaNguoiDung);
                if( nguoidung != null)
                {
                    nguoidung.tongdiem = ScoreTotal;
                }
                context.SaveChanges();
            }
        }
        public double? GetScoreTotal(string MaNguoiDung)
        {
            using(var context = new Typing_Practice_DBEntities())
            {
                var nguoidung = context.nguoidungs.Find(MaNguoiDung);
                if(nguoidung != null)
                {
                    return nguoidung.tongdiem;
                }
                return null;
            }
        }
        public double? SetScoreTotal(string MaNguoiDUng)
        {
            using(var context = new Typing_Practice_DBEntities())
            {
                double? tongdiem= 0;
                foreach(var kiluc in context.kilucs.Where(p => p.manguoidung == MaNguoiDUng))
                {
                    tongdiem += kiluc.diembaitap;
                }
                foreach(var diemdanh in context.diemdanhs.Where(p => p.manguoidung == MaNguoiDUng))
                {
                    tongdiem += 10;
                }
                context.nguoidungs.Find(MaNguoiDUng).tongdiem= tongdiem;
                context.SaveChanges();
                return tongdiem;
            }
        }
    }
}
