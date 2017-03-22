using DatHangMonAn.TacVu;
using DatHangMonAn.HeThong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatHangMonAn.DanhMuc;

namespace DatHangMonAn
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void btn_datmon_Click(object sender, EventArgs e)
        {
            Frm_DatMon datmon = new Frm_DatMon();
            datmon.Show();
        }

        private void mnu_saoluu_Click(object sender, EventArgs e)
        {
            Frm_SaoLuuPhucHoi saoluu = new Frm_SaoLuuPhucHoi();
            saoluu.ShowDialog();
 
        }

        private void btn_xemsua_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
        }

        private void mnu_khachhang_Click(object sender, EventArgs e)
        {
            Frm_KhachHang khachHang = new Frm_KhachHang();
            khachHang.Show();
        }

    }
}
