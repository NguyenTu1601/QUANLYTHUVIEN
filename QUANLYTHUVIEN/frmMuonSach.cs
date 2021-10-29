using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Data.SqlClient;
using QUANLYTHUVIEN.BSLayer;

namespace QUANLYTHUVIEN
{
    public partial class frmMuonSach : Form
    {
        DataTable dtSach = null;
        DataTable dtTheLoai = null;
        string err;
        BLMuonSach dbMuonSach = new BLMuonSach();
        public frmMuonSach()
        {
            InitializeComponent();
        }
        public void Load_Sach()
        {
            try
            {
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet ds = dbMuonSach.LaySach();
                dtSach = ds.Tables[0];
                //Đổ dữ liệu lên dgv dataSach
                dataSach.DataSource = dtSach;

                //Load cbox
                //load_cbox();
                //Xóa trống các đối tượng trong Panel


                //thây đổi độ rộng cột
                dataSach.AutoResizeColumns();
                //


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng tblSach!");
            }
        }
        public void Load_TheLoai()
        {
            try
            {
                dtTheLoai = new DataTable();
                dtTheLoai.Clear();
                DataSet ds = dbMuonSach.LayTheLoai();
                dtTheLoai = ds.Tables[0];
                //Đổ dữ liệu lên dgv dataTheLoai
                dataTL.DataSource = dtTheLoai;

                //Load cbox
                //load_cbox();
                //Xóa trống các đối tượng trong Panel


                //thây đổi độ rộng cột
                dataTL.AutoResizeColumns();
                //


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng tblTheLoai!");
            }
        }
        public void load_cbox()
        {
            BLMuonSach blMS = new BLMuonSach();
            cboxMaDG.DisplayMember = "MaDG";
            cboxMaDG.DataSource = blMS.Load_cbox();
        }

        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.load_cbox();
            Load_TheLoai();
            Load_Sach();
        }

        private void txtTimTL_TextChanged(object sender, EventArgs e)
        {
            BLMuonSach MS = new BLMuonSach();
            DataTable dt = MS.TimTheLoai(txtTimTL.Text, ref err);
            dataTL.DataSource = dt;
        }

        private void txtTimSach_TextChanged(object sender, EventArgs e)
        {
            BLMuonSach MS = new BLMuonSach();
            DataTable dt = MS.TimSach(txtTimSach.Text, ref err);
            dataSach.DataSource = dt;
        }

        private void dataTL_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataTL.Rows[e.RowIndex];
                txtChonMaTL.Text = row.Cells[0].Value.ToString();
            }
            catch (Exception)
            {

            }
            BLMuonSach MS = new BLMuonSach();
            DataTable dt = MS.ShowSach(txtChonMaTL.Text, ref err);
            dataSach.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataSach.SelectedRows)
            {
                listBox1.Items.Add(row.Cells[0].Value.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
                this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            //bool flagMuon = false;
            if (txtMaPM.Text == "")
                MessageBox.Show("Mã Phiếu mượn không được trống!!");
            else
            {
                //flagMuon = true;
                BLMuonSach MS = new BLMuonSach();
                MS.MuonSach(txtMaPM.Text, cboxMaDG.Text, ref err);
                // Thêm thông tin sách được mượn vào bảng chi tiết Mượn
                foreach (var listBoxItem in listBox1.Items)
                {
                    BLMuonSach blMS = new BLMuonSach();
                    blMS.ThemVaotblChiTietMuon(txtMaPM.Text, listBoxItem.ToString(), dateNgayMuon.Text, dateNgayTra.Text, ref err);

                    //blMS.TinhSoSachTonTai(listBoxItem.ToString(),ref err);

                    //blMS.TinhSoLanMuon(listBoxItem.ToString(), ref err);

                }
                MessageBox.Show("Mượn thành công!!");
            }


            listBox1.Items.Clear();
        }

        private void txtMaPM_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8);
        }

        private void cboxMaDG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateNgayTra_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

