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
    public partial class Form_ListExercise : Form
    {
        string MaBaiTap;
        string MaNguoiDung;
        public Form_ListExercise(string manguoidung)
        {
            InitializeComponent();
            MaNguoiDung = manguoidung;
        }

        private void OpenForm_Exercise(object sender, EventArgs e)
        {
            MaBaiTap = ((Button)sender).Tag.ToString();
            Form_Exercise frmExe = new Form_Exercise(MaNguoiDung, MaBaiTap);
            frmExe.TopLevel = false;
            frmExe.FormBorderStyle = FormBorderStyle.None;
            frmExe.Dock = DockStyle.Fill;
            this.Controls.Add(frmExe);
            this.Tag = frmExe.Tag;
            frmExe.BringToFront();
            frmExe.Show();
            frmExe.FormClosed += Form_ListExercise_Load;
            frmExe.FormClosed += ((Form_Start)this.Parent.Parent).Form_Start_Load;

        }


        private void SetTagButton()
        {
            List<string> listMaBaiTap = baitapBLL.Instance.GetListMaBaiTap();
            for (int i = 0; i < panelListBT.Controls.Count; i++)
            {
                Button button = (Button)panelListBT.Controls[i];
                if (i < listMaBaiTap.Count)
                {
                    button.Tag = listMaBaiTap[i];
                }
                else
                {
                    button.Tag = null;
                    button.Hide();
                }
            }
            for (int i = 0; i < panelListBT.Controls.Count; i++)
            {
                Button button = (Button)panelListBT.Controls[i];
                if(button.Tag != null)
                if (!baitapBLL.Instance.CheckScoreUnlock(button.Tag.ToString(), nguoidungBLL.Instance.GetScoreTotal(MaNguoiDung)))
                {
                    button.Hide();
                };
            }
        }
        private void Form_ListExercise_Load(object sender, EventArgs e)
        {
            SetTagButton();
            SetNameButton();
        }

        private void SetNameButton()
        {
            for (int i = 0; i < panelListBT.Controls.Count; i++)
            {
                Button button = (Button)panelListBT.Controls[i];
                if (button.Tag != null)
                {
                    button.Text = baitapBLL.Instance.GetNameBT(button.Tag.ToString())
                        +"       Lever: " + baitapBLL.Instance.GetLeverBT(button.Tag.ToString())
                        + "       Record: " + kilucBLL.Instance.GetRecord(MaNguoiDung, button.Tag.ToString())
                        + "       Done: " + kilucBLL.Instance.GetSoLanThucHien(MaNguoiDung, button.Tag.ToString()) + " times";
                }
            }
        }
    }
}
