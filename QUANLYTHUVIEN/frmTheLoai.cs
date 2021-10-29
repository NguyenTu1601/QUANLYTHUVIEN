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
    public partial class frmTheLoai : Form
    {
        DataTable dtTheLoai = null;
        string err;
        BLTheLoai dbTL = new BLTheLoai();
        public frmTheLoai()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            try
            {
                dtTheLoai = new DataTable();
                dtTheLoai.Clear();
                DataSet ds = dbTL.LayTheLoai();
                dtTheLoai = ds.Tables[0];
                //Đổ dữ liệu lên dgv dataTheLoai
                dataTheLoai.DataSource = dtTheLoai;
                //Xóa trống các đối tượng trong Panel
                this.txtMaTL.ResetText();
                this.txtTenTL.ResetText();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng tblTheLoai!");
            }
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_Data();
        }

        private void dataTheLoai_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // thay đổi txt khi chọn dòng trong dgv
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataTheLoai.Rows[e.RowIndex];
                txtMaTL.Text = row.Cells[0].Value.ToString();
                txtTenTL.Text = row.Cells[1].Value.ToString();
            }
            catch (Exception)
            { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                BLTheLoai BLTL = new BLTheLoai();
                BLTL.ThemTheLoai(this.txtMaTL.Text, this.txtTenTL.Text, ref err);
                Load_Data();
                MessageBox.Show("Đã thêm xong!");
            }
            catch(SqlException)
            {
                MessageBox.Show("Không thêm được. Lỗi rồi!!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành
                int r = dataTheLoai.CurrentCell.RowIndex;
                // Lấy MaNV của record hiện hành
                string strMaTL =
                dataTheLoai.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc muốn xóa thể loại sách này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbTL.XoaTheLoai(ref err, strMaTL);
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
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                BLTheLoai BLTL = new BLTheLoai();
                BLTL.CapNhatTheLoai(this.txtMaTL.Text, this.txtTenTL.Text, ref err);
                Load_Data();
                MessageBox.Show("Đã sửa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không sửa được. Lỗi rồi!!!");
            }
        }
    }
}
