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
    public partial class frmDocGia : Form
    {
        DataTable dtDocGia = null;
        string err;
        BLDocGia dbDG = new BLDocGia();
        public frmDocGia()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {
                dtDocGia = new DataTable();
                dtDocGia.Clear();

                DataSet ds = dbDG.LayDocGia();

                dtDocGia = ds.Tables[0];
                //Đổ dữ liệu lên dgv dataDocGia
                dataDocGia.DataSource = dtDocGia;
                //Xóa trống các đối tượng trong Panel1
                this.txtMaDG.ResetText();
                this.txtHoTen.ResetText();
                this.txtDiaChi.ResetText();
                this.txtSDT.ResetText();
                this.dateNgaySinh.ResetText();
                this.radioNam.ResetText();
                this.radioNu.ResetText();
                this.txtEmail.ResetText();
                //


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng tblDocGia!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int GioiTinh;
                if (radioNam.Checked == true)
                    GioiTinh = 0; //Nam
                else
                    GioiTinh = 1;
                BLDocGia BLDG = new BLDocGia();
                DateTime ngaySinh = DateTime.Parse(this.dateNgaySinh.Text);

                bool add = BLDG.ThemDocGia(this.txtMaDG.Text, this.txtHoTen.Text, GioiTinh, ngaySinh, this.txtDiaChi.Text, this.txtSDT.Text,this.txtEmail.Text, ref err);

                Load_Data();

                if (add == true)
                    MessageBox.Show("Đã thêm xong!");
                else
                    MessageBox.Show("Không thể thêm mới!\nMã độc giả đã tồn tại!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thêm được. Lỗi rồi!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành
                int r = dataDocGia.CurrentCell.RowIndex;
                // Lấy MaNV của record hiện hành
                string strMaDG =
                dataDocGia.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc muốn xóa độc giả này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbDG.XoaDocGia(ref err, strMaDG);
                    // Cập nhật lại DataGridView
                    Load_Data();
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string GioiTinh;
                if (radioNam.Checked == true)
                    GioiTinh = "0"; //Nam
                else
                    GioiTinh = "1"; //Nữ
                BLDocGia BLDG = new BLDocGia();
                DateTime ngaySinh = DateTime.Parse(this.dateNgaySinh.Text);
                BLDG.CapNhatDocGia(this.txtMaDG.Text, this.txtHoTen.Text, GioiTinh, ngaySinh, this.txtDiaChi.Text.Trim(), this.txtSDT.Text,this.txtEmail.Text, ref err);

                Load_Data();
                MessageBox.Show("Đã sửa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không sửa được. Lỗi rồi!");
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaDG.Text = "";
            txtHoTen.Text = "";
            dateNgaySinh.Text = "01/01/1990";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }

        private void frmDocGia_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_Data();
            radioNam.Checked = true;
        }

        private void dataDocGia_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataDocGia.Rows[e.RowIndex];
                if (row.Cells[2].Value.ToString() == "0")
                    radioNam.Checked = true;
                else
                    radioNu.Checked = true;
                txtMaDG.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                dateNgaySinh.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtSDT.Text = row.Cells[5].Value.ToString();
                txtEmail.Text = row.Cells[6].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void frmDocGia_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
