using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLYTHUVIEN.BSLayer;

namespace QUANLYTHUVIEN
{
    public partial class frmDeleteUser : Form
    {
        string err;
        public frmDeleteUser()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (ktraTonTai() == false)
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    BLDeleteUser bLDeleteUser = new BLDeleteUser();
                    bLDeleteUser.deleteUser(txtUser.Text, ref err);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    txtUser.Text = "";
                    txtUser.Focus();
                }
            }
        }


        private bool ktraTonTai()
        {
            bool f;
            BLDeleteUser bLDeleteUser = new BLDeleteUser();
            f = bLDeleteUser.isExist(txtUser.Text, ref err);

            return f;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.Text.Length >= 10)
            {
                MessageBox.Show("Tên đăng nhập quá dài!", "Thông báo", MessageBoxButtons.OK);

            }
        }
    }
}
