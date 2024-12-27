using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class baitapBLL
    {
        private static baitapBLL instance;
        public static baitapBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new baitapBLL();
                }
                return instance;
            }
            private set { }
        }
        public string GetNoiDung(string Mabaitap)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var Baitap = context.baitaps.FirstOrDefault(p => p.mabaitap == Mabaitap);
                if (Baitap == null) return null;
                return Baitap.noidung;
            }
        }
        public string GetNameBT(string Mabaitap)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var BaiTap = context.baitaps.FirstOrDefault(p => p.mabaitap == Mabaitap);
                if (BaiTap == null) return null;
                return BaiTap.tenbaitap;
            }
        }
        public string GetLeverBT(string Mabaitap)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var BaiTap = context.baitaps.FirstOrDefault(p => p.mabaitap == Mabaitap);
                if (BaiTap == null) return null;
                return BaiTap.dokho;
            }
        }

        public List<string> GetListMaBaiTap()
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var ListBaiTap = context.baitaps.Where(p => p.Xoa == true).Select(p => p.mabaitap).ToList();
                return ListBaiTap;
            }
        }
        public int GetTime(string Mabaitap)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var baitap = context.baitaps.FirstOrDefault(p => p.mabaitap == Mabaitap);
                if (baitap != null)
                {
                    TimeSpan? time = baitap.thoigian;
                    if (time.HasValue)
                    {
                        return (int)time.Value.TotalSeconds;
                    }
                }
                return 0;
            }
        }
        public DataTable GetListExercise()
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var ListExercise = context.baitaps.Where(p => p.Xoa == true);
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã bài tập");
                dt.Columns.Add("Tên bài tập");
                dt.Columns.Add("Độ khó");
                dt.Columns.Add("Thời gian");
                dt.Columns.Add("Nội dung ");
                dt.Columns.Add("Ngày tạo");
                foreach (var baitap in ListExercise)
                {
                    string maBaiTap = baitap.mabaitap;
                    dt.Rows.Add(maBaiTap,
                                baitap.tenbaitap,
                                baitap.dokho,
                                baitap.thoigian,
                                baitap.noidung,
                                baitap.ngaytao
                                );
                }
                return dt;
            }
        }
        public baitap GetInfoExercise(string MaBaiTap)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var InfoExercise = context.baitaps.FirstOrDefault(p => p.mabaitap == MaBaiTap);
                if (InfoExercise == null) return null;
                return InfoExercise;
            }
        }

        public void SaveExercise(string MaBaiTap,
                                 string Name,
                                 string Content,
                                 string Level,
                                 TimeSpan? Time,
                                 float DiemMoKhoa,
                                 bool AddOrEdit)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var baitap = context.baitaps.FirstOrDefault(p => p.mabaitap == MaBaiTap);
                if (AddOrEdit == false)
                {
                    baitap.tenbaitap = Name;
                    baitap.noidung = Content;
                    baitap.dokho = Level;
                    baitap.thoigian = Time;
                    baitap.ngaytao = DateTime.Today;
                    baitap.diemmokhoa = DiemMoKhoa;
                }
                else
                {
                    baitap baitapnewblabla = new baitap()
                    {
                        mabaitap = MaBaiTap,
                        tenbaitap = Name,
                        noidung = Content,
                        dokho = Level,
                        thoigian = Time,
                        ngaytao = DateTime.Today,
                        diemmokhoa = DiemMoKhoa,
                        Xoa = true
                    };
                    context.baitaps.Add(baitapnewblabla);
                }
                context.SaveChanges();
            }
        }

        public bool CheckScoreUnlock(string MaBaiTap, double? tongdiem)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var baitap = context.baitaps.Find(MaBaiTap);
                if(baitap == null) return false;
                if(tongdiem >= baitap.diemmokhoa)
                {
                    return true;
                }
                else return false;
            }
        }
        public int GetCountBaiTap()
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                return context.baitaps.Count();
            }
        }
        public bool CheckIDBaiTap(string MaBaiTap)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var baitap = context.baitaps.Find(MaBaiTap);
                if (baitap == null)
                {
                    return true;
                }
                else return false;
            }
        }
        public void DeleteBaiTap(string MaBaiTap)
        {
            using (var context = new Typing_Practice_DBEntities())
            {
                var baitap = context.baitaps.FirstOrDefault(p => p.mabaitap == MaBaiTap);
                baitap.Xoa = false;
                context.SaveChanges();
            }
        }
    }
}
