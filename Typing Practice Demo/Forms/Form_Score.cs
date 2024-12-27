using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Practice_Demo.Forms
{
    public partial class Form_Score : Form
    {
        string MaBaiTap;
        int MissWord;
        int Seconds;
        int ExerCount;
        float PointExe;
        string MaNguoiDung;
        public Form Parentform { get; set; }
        public Form_Score(string manguoidung,int exeCount,int missword, int seconds, string mabaitap = null)
        {
            InitializeComponent();
            MaBaiTap = mabaitap;
            ExerCount = exeCount;
            MissWord = missword;
            Seconds = seconds;
            MaNguoiDung = manguoidung;
        }

        private void Form_Score_Load(object sender, EventArgs e)
        {
            string Rate = ((((float)ExerCount - MissWord) / ExerCount * 100)).ToString("f2") ;
            string Speed = ((float)ExerCount / Seconds).ToString("f2");
            labelName.Text = "Exercise Name: " + baitapBLL.Instance.GetNameBT(MaBaiTap);
            labelLevel.Text = "Exercise Level: " + baitapBLL.Instance.GetLeverBT(MaBaiTap);
            labelRate.Text = Rate + "%";
            labelSpeed.Text = Speed + " word/second";
            if(Seconds > baitapBLL.Instance.GetTime(MaBaiTap))
            {
                PointExe = ((float.Parse(Rate) / 100) * 5) + ((baitapBLL.Instance.GetTime(MaBaiTap) / Seconds ) * 5);
            }
            else
            {
                PointExe = ((float.Parse(Rate) / 100) * 5) + 5;
            }
            labelPoint.Text = PointExe.ToString("f2");
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (kilucBLL.Instance.CheckExist(MaNguoiDung, MaBaiTap) != null)
            {
                string MaKiLuc = kilucBLL.Instance.TimMaKiLucDuaTheoMaBTMaND(MaNguoiDung, MaBaiTap).ToString();
                kilucBLL.Instance.EditKiLuc(MaKiLuc, PointExe);
            }
            else
            {
                string MaKiLuc = (kilucBLL.Instance.GetRecordCount()+1).ToString();
                kilucBLL.Instance.AddKiLuc(MaKiLuc, MaNguoiDung, MaBaiTap, PointExe,1);
            }
            this.Close();
            if (Parentform != null && Parentform is Form_Exercise)
            {
                ((Form_Exercise)Parentform).Close();
            };
        }
    }
}
