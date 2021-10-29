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
//using QUANLYTHUVIEN.DBLayer;

namespace QUANLYTHUVIEN
{
    public partial class frmDanhMucSach : Form
    {
        DataTable dtSach = null;
        string err;
        BLDanhMucSach dbSach = new BLDanhMucSach();
        public frmDanhMucSach()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {
                dtSach = new DataTable();
                dtSach.Clear();
                DataSet ds = dbSach.LaySach();
                dtSach = ds.Tables[0];
                //Đổ dữ liệu lên dgv dataSach
                dataSach.DataSource = dtSach;

                //
                load_cbox();
                //Xóa trống các đối tượng trong Panel
                this.txtMaSach.ResetText();
                this.cboxMaTL.ResetText();
                this.txtNhaXB.ResetText();
                this.txtSoLanMuon.ResetText();
                this.txtTacGia.ResetText();
                this.txtTonTai.ResetText();
                this.dateNgayMua.ResetText();

                //thây đổi độ rộng cột
                dataSach.AutoResizeColumns();
                //
                dataSach_CellClick(null, null);


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng tblSach!");
            }
        }
        public void load_cbox()
        {
            BLDanhMucSach blDMS = new BLDanhMucSach();
            cboxMaTL.DisplayMember = "MaTL";
            cboxMaTL.DataSource = blDMS.Load_cbox(cboxMaTL.Text, ref err);
        }

        private void frmDanhMucSach_Load(object sender, EventArgs e)
        {
            this.load_cbox();
            Load_Data();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.txtMaSach.Focus();
            //thực hiện lệnh
            BLDanhMucSach blDMS = new BLDanhMucSach();
            DateTime ngayMua = DateTime.Parse(this.dateNgayMua.Text);
            blDMS.ThemSach(this.txtMaSach.Text, this.cboxMaTL.Text, this.txtTenSach.Text, this.txtTacGia.Text, this.txtNhaXB.Text, ngayMua, this.txtTonTai.Text, this.txtSoLanMuon.Text, ref err);
            Load_Data();
            MessageBox.Show("Đã thêm xong :>");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataSach.CurrentCell.RowIndex;
                string strSach = dataSach.Rows[r].Cells[0].Value.ToString();
                DialogResult trloi;
                trloi = MessageBox.Show("Chắc xóa này không ?", "trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (trloi == DialogResult.Yes)
                {
                    dbSach.XoaSach(ref err, strSach);
                    //cập nhật lại data
                    Load_Data();
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            this.cboxMaTL.Focus();
            BLDanhMucSach blDMS = new BLDanhMucSach();
            DateTime NgayMua = DateTime.Parse(this.dateNgayMua.Text);
            blDMS.CapNhatSach(this.txtMaSach.Text, this.cboxMaTL.Text, this.txtTenSach.Text, this.txtTacGia.Text, this.txtNhaXB.Text, NgayMua, this.txtTonTai.Text, this.txtSoLanMuon.Text, ref err);
            Load_Data();
            MessageBox.Show("Đã sửa xong");
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            cboxMaTL.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNhaXB.Text = "";
            dateNgayMua.Text = "1/1/2016";
            txtTonTai.Text = "";
            txtSoLanMuon.Text = "";
        }

        private void dataSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //thứ tự hiện hành
            int r = dataSach.CurrentCell.RowIndex;
            //chuyển thông tin lên panel
            this.txtMaSach.Text = dataSach.Rows[r].Cells[0].Value.ToString();
            this.cboxMaTL.Text = dataSach.Rows[r].Cells[1].Value.ToString();
            this.txtTenSach.Text = dataSach.Rows[r].Cells[2].Value.ToString();
            this.txtTacGia.Text = dataSach.Rows[r].Cells[3].Value.ToString();
            this.txtNhaXB.Text = dataSach.Rows[r].Cells[4].Value.ToString();
            this.dateNgayMua.Text = dataSach.Rows[r].Cells[5].Value.ToString();
            this.txtTonTai.Text = dataSach.Rows[r].Cells[6].Value.ToString();
            this.txtSoLanMuon.Text = dataSach.Rows[r].Cells[7].Value.ToString();
        }

        private void txtTonTai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Bạn hãy nhập số!");
                e.Handled = true;
            }
        }

        private void txtSoLanMuon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Bạn hãy nhập số!");
                e.Handled = true;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            BLDanhMucSach DMS = new BLDanhMucSach();
            DataTable dt = DMS.TimSach(txtTimKiem.Text, ref err);
            dataSach.DataSource = dt;
            //Load_Data();

        }

        private void txtTonTai_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
