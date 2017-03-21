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
            datmon.MdiParent = this;
            datmon.Show();
            datmon.Dock = DockStyle.Fill;
            datmon.WindowState = FormWindowState.Maximized;
        }

        private void mnu_saoluu_Click(object sender, EventArgs e)
        {
            Frm_SaoLuuPhucHoi saoluu = new Frm_SaoLuuPhucHoi();
 
        }

    }
}
