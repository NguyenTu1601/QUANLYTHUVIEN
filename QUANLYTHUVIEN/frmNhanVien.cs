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
    public partial class frmNhanVien : Form
    {
        DataTable dtNhanVien = null;
        string err;
        BLNhanVien dbNV = new BLNhanVien();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();

                DataSet ds = dbNV.LayNhanVien();

                dtNhanVien = ds.Tables[0];
                //Đổ dữ liệu lên dgv dataNhanVien
                dataNhanVien.DataSource = dtNhanVien;
                //Xóa trống các đối tượng trong Panel1
                this.txtMaNV.ResetText();
                this.txtHoTen.ResetText();
                this.txtDiaChi.ResetText();
                this.txtSDT.ResetText();
                this.dateNgaySinh.ResetText();
                this.radioNam.ResetText();
                this.radioNu.ResetText();
                //
               

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng tblTTNhanVien!");
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
                    GioiTinh = 1; //Nữ           
                                  //string them = "EXEC dbo.uspInsertNhanVien '" + txtMaNV.Text + "',N'" + txtHoTen.Text + "','"
                                  //+ GioiTinh + "','" + dateNgaySinh.Text + "',N'" + txtDiaChi.Text + "','" + txtSDT.Text + "'"; 
                                  //
                BLNhanVien blNV = new BLNhanVien();
                DateTime ngaySinh = DateTime.Parse(this.dateNgaySinh.Text);
                bool b = blNV.ThemNhanVien(this.txtMaNV.Text, this.txtHoTen.Text, GioiTinh, ngaySinh, this.txtDiaChi.Text, this.txtSDT.Text, ref err);

                if (b == true)
                {
                    Load_Data();
                    MessageBox.Show("Đã thêm xong!");
                }
                else
                    MessageBox.Show("Không thể thêm mới! \nMã nhân viên đã tồn tại!!");

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
                int r = dataNhanVien.CurrentCell.RowIndex;
                // Lấy MaNV của record hiện hành
                string strMaNV =
                dataNhanVien.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbNV.XoaNhanVien(ref err, strMaNV);
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

                ////Chạy produce UpdateNhanVien
                //string capnhat = "EXEC dbo.uspUpdateNhanVien '" + txtMaNV.Text + "',N'" + txtHoTen.Text + "','"
                //+ GioiTinh + "','" + dateNgaySinh.Text + "','" + txtDiaChi.Text + "','" + txtSDT.Text + "'";
                //// Conn.executeQuery(capnhat); //Show lỗi SQLException 
               
                BLNhanVien blNV = new BLNhanVien();
                DateTime ngaySinh = DateTime.Parse(this.dateNgaySinh.Text);
                blNV.CapNhatNhanVien(this.txtMaNV.Text, this.txtHoTen.Text, GioiTinh, ngaySinh, this.txtDiaChi.Text, this.txtSDT.Text, ref err);
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
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            dateNgaySinh.Text = "01/01/1990";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void frmTTNhanVien_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_Data();
            radioNam.Checked = true;
        }

        private void dataNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataNhanVien.Rows[e.RowIndex];
                if (row.Cells[2].Value.ToString() == "0")
                    radioNam.Checked = true;
                else
                    radioNu.Checked = true;
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                dateNgaySinh.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtSDT.Text = row.Cells[5].Value.ToString();
            }
            catch (Exception)
            { }
        }
    }
}
