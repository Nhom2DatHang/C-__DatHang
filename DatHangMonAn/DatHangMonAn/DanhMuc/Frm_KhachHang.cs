using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatHangMonAn.DanhMuc
{
    public partial class Frm_KhachHang : Form
    {
        public Frm_KhachHang()
        {
            InitializeComponent();
        }
        private void HienThiDanhSachKhachHang()
        {
            dtDanhSachKhachHang = new DataTable();
            dtDanhSachKhachHang = bd.LayDanhSachKhachHang(ref err);//lay du lieu tu database len
            dgvdskhachhang.DataSource = dtDanhSachKhachHang;

        }

        private void btnthem_Click(object sender, EventArgs e)
        {

           Frm_KhachHangThem _frmKhachHang = new Frm_KhachHangThem();

            _frmKhachHang.them = true;
            _frmKhachHang.ShowDialog();
            HienThiDanhSachKhachHang();




        }

        private void Frm_KhachHang_Load(object sender, EventArgs e)
        {
            bd = new BLL_KhachHang(cls_Main.duongdanfileketnoi);
            HienThiDanhSachKhachHang();
        }
    }
}
