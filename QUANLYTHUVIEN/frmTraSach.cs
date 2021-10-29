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
using QUANLYTHUVIEN.BSLayer;

namespace QUANLYTHUVIEN
{
    public partial class frmTraSach : Form
    {
        DataTable dtSach = null;
        string err;
        BLTraSach dbTraSach = new BLTraSach();
        public frmTraSach()
        {
            InitializeComponent();
        }
        public void load_cbox()
        {
            BLTraSach blTS = new BLTraSach();
            cboxMaDG.DisplayMember = "MaDG";
            cboxMaDG.DataSource = blTS.Load_cbox();
        }
        public void Load_Sach()
        {
            dtSach = new DataTable();
            dtSach.Clear();
            DataSet ds = dbTraSach.LaySach();
            dtSach = ds.Tables[0];
            //Đổ dữ liệu lên dgv dataSach
            dataSach.DataSource = dtSach;
            //Thay đổi độ rộng cột
            dataSach.AutoResizeColumns();
            //
        }
        public void LoadSachDaMuon()
        {
            dtSach = new DataTable();
            dtSach.Clear();
            DataSet ds = dbTraSach.LaySachDaMuon(cboxMaPM.Text, cboxNgayMuon.Text);
            dtSach = ds.Tables[0];
            //Đổ dữ liệu lên dgv dataSach
            dataSach.DataSource = dtSach;
            //Thay đổi độ rộng cột
            dataSach.AutoResizeColumns();
        }
        public int Kiemtra()
        {
            int check = 1; // 0--->chưa trả đủ
            int TongSoMuon, TongSoTra;
            TongSoMuon = dataSach.Rows.Count - 1;
            TongSoTra = Int16.Parse(listBox1.Items.Count.ToString());
            if (TongSoMuon > TongSoTra)
            {
                //MessageBox.Show("->> in phiếu mới!!");
                check = 0;
            }
            else
                if (TongSoMuon == TongSoTra)
            {
                //MessageBox.Show("thành công");
                check = 1;
            }
            return check;
        }

        private void frmTraSach_Load(object sender, System.EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.load_cbox();
        }

        private void cboxMaDG_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            BLTraSach blTS = new BLTraSach();
            cboxMaPM.DisplayMember = "MaPM";
            cboxMaPM.DataSource = blTS.Load_cboxMaDG_SelectedIndexChanged(cboxMaDG.Text);
        }

        private void btnHienThi_Click(object sender, System.EventArgs e)
        {
            LoadSachDaMuon();
        }

        private void cboxMaPM_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            BLTraSach blTS = new BLTraSach();
            cboxNgayMuon.DisplayMember = "NgayThue";
            cboxNgayMuon.DataSource = blTS.Load_cboxMaPM_SelectedIndexChanged(cboxMaPM.Text);
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {

            foreach (DataGridViewRow row in dataSach.SelectedRows)
            {
                listBox1.Items.Add(row.Cells[1].Value.ToString());
            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
                this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
        }

        private void btnTra_Click(object sender, System.EventArgs e)
        {
            if (Kiemtra() == 1)
            {
                BLTraSach blTS1 = new BLTraSach();
                blTS1.XoaHoaDonMuon1(cboxMaPM.Text, cboxMaDG.Text, ref err);
                foreach (var listBoxItem in listBox1.Items)
                {
                    BLTraSach TS1 = new BLTraSach();
                    //TS1.Update_TonTai1(listBoxItem.ToString(),ref err);
                    //TS1.Update_SoLanMuon1(listBoxItem.ToString(),ref err);
                    TS1.Tra1(listBoxItem.ToString(), cboxMaPM.Text, cboxNgayMuon.Text, ref err);
                }
                MessageBox.Show("Bạn đã trả hết sách thành công!! Bạn có thể mượn ở lần tới.");
                listBox1.Items.Clear();
            }
            else     //Kiemtra() == 0
            {
                BLTraSach blTS0 = new BLTraSach();
                blTS0.XoaHoaDonMuon0(cboxMaPM.Text, cboxMaDG.Text, ref err);
                foreach (var listBoxItem in listBox1.Items)
                {
                    BLTraSach TS0 = new BLTraSach();
                    //TS0.Update_TonTai0(listBoxItem.ToString(), ref err);
                    //TS0.Update_SoLanMuon0(listBoxItem.ToString(), ref err);
                    TS0.Tra0(listBoxItem.ToString(), cboxMaPM.Text, cboxNgayMuon.Text, ref err);
                }
                MessageBox.Show("Bạn đã trả sách thành công nhưng chưa đủ!!");
                listBox1.Items.Clear();
            }

        }
    }
}
