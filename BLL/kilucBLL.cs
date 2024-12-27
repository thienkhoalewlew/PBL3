using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class kilucBLL
    {
        private static kilucBLL instance;
        public static kilucBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new kilucBLL();
                }
                return instance;
            }
            private set { }
        }
        private kilucBLL() { }
        public void AddExerciseCount(string MaBaiTap, string MaNguoiDung)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var kiluc = context.kilucs.FirstOrDefault(p => p.mabaitap == MaBaiTap);
                if (kiluc != null)
                {
                    kiluc.solanthuchien++;
                    context.SaveChanges();
                }
            }
        }

        public void AddKiLuc(string MaKiLuc, string MaNguoiDung, string MaBaiTap,float DiemBaiTap, int SoLanThucHien)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var kiluc = new kiluc()
                {
                    makiluc = MaKiLuc,
                    manguoidung = MaNguoiDung,
                    mabaitap = MaBaiTap,
                    diembaitap = DiemBaiTap,
                    solanthuchien = SoLanThucHien
                };
                context.kilucs.Add(kiluc);
                context.SaveChanges();
            }
        }
        public string CheckExist(string MaNguoiDung, string MaBaiTap)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var kiluc =  context.kilucs.FirstOrDefault(p => p.manguoidung == MaNguoiDung && p.mabaitap == MaBaiTap);
                if (kiluc != null)
                {
                    return kiluc.makiluc;
                }
                else
                {
                    return null;
                }
            }
        }

        public void EditKiLuc(string MaKiLuc, float DiemBaiTap)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var kiluc = context.kilucs.Find(MaKiLuc);
                if (kiluc != null)
                {
                    if(kiluc.diembaitap < DiemBaiTap) kiluc.diembaitap = DiemBaiTap;
                    kiluc.solanthuchien++;
                    context.SaveChanges();
                }
            }
        }

        public int GetRecordCount()
        {
            using( var context = new Typing_Practice_DBEntities())
            {
                return context.kilucs.Count();
            }
        }
        public string TimMaKiLucDuaTheoMaBTMaND(string MaNguoiDung,string MaBaiTap)
        {
            using(var context = new Typing_Practice_DBEntities())
            {
                return context.kilucs.Where
                    (p => p.mabaitap == MaBaiTap && p.manguoidung == MaNguoiDung).FirstOrDefault().makiluc;
            }
        }
        public int GetSoLanThucHien(string MaNguoiDung, string MaBaiTap)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var kiluc = context.kilucs.FirstOrDefault(k => k.manguoidung == MaNguoiDung && k.mabaitap == MaBaiTap);
                if (kiluc != null)
                {
                    return kiluc.solanthuchien.GetValueOrDefault();
                }
                else
                {
                    return 0;
                }
            }
        }
        public double? GetRecord(string MaNguoiDung, string MaBaiTap)
        {
            using(var context = new Typing_Practice_DBEntities())
            {
                var kiluc = context.kilucs.FirstOrDefault(p => p.manguoidung == MaNguoiDung && p.mabaitap == MaBaiTap);
                if(kiluc != null)
                {
                    return kiluc.diembaitap;
                }
                else { return 0; }
            }
        }
        public void DeleteKiluc(string MaBaiTap)
        {
            using( var context = new Typing_Practice_DBEntities())
            {
                var kiluc = context.kilucs.Find(MaBaiTap);
                context.kilucs.Remove(kiluc);
            }
        }
    }
}
