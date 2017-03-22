using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatHangMonAn.HeThong
{
    public partial class Frm_Thietlapchuoiketnoi : Form
    {
        public Frm_Thietlapchuoiketnoi()
        {
            InitializeComponent();
        }

        private void ckbquyenketnoi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbquyenketnoi.Checked == true)
            {
                txtuser.Enabled = true;
                txtpassword.Enabled = true;
                ckbquyenketnoi.Text = "Kết nối theo quyền SQL";
            }
            else
            {
                txtuser.Enabled = false;
                txtpassword.Enabled = false;
                ckbquyenketnoi.Text = "Kết nối theo quyền Windows";
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Thietlapchuoiketnoi_Load(object sender, EventArgs e)
        {
            if (File.Exists(Cls_Main.duongdanfileketnoi))
            {
                cls_DataLayer data = new cls_DataLayer(Cls_Main.duongdanfileketnoi);
                if (data.Demsothuoctinh > 2)
                {
                    ckbquyenketnoi.Checked = true;
                    txtservername.Text = data.Servername;
                    txtdatabasename.Text = data.Databasename;
                    txtuser.Text = data.Uid;
                    txtpassword.Text = data.Pwd;
                }
                else
                {
                    ckbquyenketnoi.Checked = false;
                    txtservername.Text = data.Servername;
                    txtdatabasename.Text = data.Databasename;
                }
            }
            else
            {
                //không tồn tại
                txtservername.Focus();
            }
        }
            private void luuchuoiketnoi(string path)
        {
            using (StreamWriter sw=new StreamWriter(path))
            {
                if (ckbquyenketnoi.Checked == true)
                {
                    //theo quyen sql
                    sw.WriteLine("servername="+txtservername.Text);
                    sw.WriteLine("database=" + txtdatabasename.Text);
                    sw.WriteLine("userid=" + txtuser.Text);
                    sw.Write("password=" + txtpassword.Text);
                }
                else
                {
                    //theo quyen windows
                    sw.WriteLine("servername=" + txtservername.Text);
                    sw.Write("database=" + txtdatabasename.Text);
                }
            }
        }

        private void btnluuketnoi_Click(object sender, EventArgs e)
        {
             luuchuoiketnoi(Cls_Main.duongdanfileketnoi);
        }
        string err = "";

        private void btnkiemtraketnoi_Click(object sender, EventArgs e)
        {
            cls_DataLayer data = new cls_DataLayer(Cls_Main.duongdanfileketnoi);
            if (data.kiemtraketnoi(ref err) == true)
            {
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }
        }




        }
    
