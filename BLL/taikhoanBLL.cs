using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class taikhoanBLL
    {
        private static taikhoanBLL instance;
        public static taikhoanBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new taikhoanBLL();
                }
                return instance;
            }
            private set { }
        }
        private taikhoanBLL() { }

        public bool CheckTaiKhoan(string email, string password)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                if (context == null) return false;
                bool check = context.taikhoans.FirstOrDefault(p => p.email == email && p.password == password) != null;
                return check;
            }
        }
        
        public void SaveTaiKhoan(string MaTaiKhoan, 
                                 string MaNguoiDung,
                                 string Email, 
                                 string Password,
                                 bool AddorEdit)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var taiKhoan = context.taikhoans.FirstOrDefault(t => t.mataikhoan == MaTaiKhoan);
                if (!AddorEdit)
                {
                    taiKhoan.manguoidung = MaNguoiDung;
                    taiKhoan.email = Email;
                    taiKhoan.password = Password;
                }
                else
                {
                    taiKhoan = new taikhoan()
                    {
                        mataikhoan = MaTaiKhoan,
                        manguoidung = MaNguoiDung,
                        email = Email,
                        password = Password,
                        role = false
                    };
                    context.taikhoans.Add(taiKhoan);
                }
                context.SaveChanges();
            }
        }
        public bool GetRoleUser(string MaNguoiDung)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var TaiKhoan = context.taikhoans.FirstOrDefault(p => p.manguoidung == MaNguoiDung);
                if (TaiKhoan == null) return false;
                return TaiKhoan.role== true;
            }
        }

        public string GetIDByEmail(string Email)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var NguoiDung = context.taikhoans.FirstOrDefault(p => p.email == Email);
                if (NguoiDung == null)  return null;
                return NguoiDung.manguoidung;
            }
        }

        public void DeleteAccount(string MaTaiKhoan)
        {
            using(var context = new Typing_Practice_DBEntities())
            {
                var taikhoan = context.taikhoans.FirstOrDefault(p => p.mataikhoan == MaTaiKhoan);
                context.taikhoans.Remove(taikhoan);
                context.SaveChanges();
            }
        }

        public bool CheckEmail(string Email)
        {
            using(var context = new Typing_Practice_DBEntities())
            {
                var check = context.taikhoans.FirstOrDefault(p => p.email == Email);
                if (check == null) return false;
                return true;
            }
        }
    }
}
