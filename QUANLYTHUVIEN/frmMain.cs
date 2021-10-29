using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

using QUANLYTHUVIEN.DBLayer;
namespace QUANLYTHUVIEN
{
    public partial class frmMain : Form
    {
        //frmDangNhap frm1;
        //string username, password;
        DBMain db = new DBMain();
        public string log1;
        public frmMain(int x)
        {
            InitializeComponent();
            if (x == 1)
            {
                panel1.Enabled = false;
                //panel1.ForeColor = Color.Black;
            }
            else panel1.Enabled = true;
        }
        //public frmMain(string user, string pass)
        //{
        //    InitializeComponent();
        //    username = user;
        //    password = pass;
        //}
        private void frmMain_Load(object sender, EventArgs e)
        {
            int countNV = layTongNhanVien();
            this.lbNhanVien.Text = countNV.ToString();

            int countDM = layTongDanhMucSach();
            this.lbDanhMucSach.Text = countDM.ToString();

            int countDG = layTongDocGia();
            this.lbDocGia.Text = countDG.ToString();

            int countTL = layTongTheLoaiSach();
            this.lbTheLoai.Text = countTL.ToString();
        }

        public int layTongTheLoaiSach()
        {
            try
            {
                return (int)db.ExecuteScalar("spLaySoLuongTheLoaiSach", CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int layTongNhanVien()
        {
            try
            {
                return (int)db.ExecuteScalar("spLaySoLuongNhanVien", CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int layTongDanhMucSach()
        {
            try
            {
                return (int)db.ExecuteScalar("spLaySoLuongDanhMucSach", CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int layTongDocGia()
        {
            try
            {
                return (int)db.ExecuteScalar("spLaySoLuongDocGia", CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return 0;
            }
        }




        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                Form login = new frmDangNhap();
                login.ShowDialog();
            }
            else if (dialog == DialogResult.No)
            {
                //
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form DMK = new frmDoiMatKhau();
            DMK.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form NV = new frmNhanVien();
            NV.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form TLS = new frmTheLoai();
            TLS.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form DG = new frmDocGia();
            DG.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form DMS = new frmDanhMucSach();
            DMS.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form Tra = new frmTraSach();
            Tra.ShowDialog();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form DG = new frmDocGia();
            DG.ShowDialog();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form S = new frmDanhMucSach();
            S.ShowDialog();
        }

        private void mượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Muon = new frmMuonSach();
            Muon.ShowDialog();
        }

        private void trảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Tra = new frmTraSach();
            Tra.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form NV = new frmNhanVien();
            NV.ShowDialog();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Form Muon = new frmMuonSach();
            Muon.ShowDialog();
        }
    }
}
