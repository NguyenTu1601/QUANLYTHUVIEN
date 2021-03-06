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
    public partial class frmDoiMatKhau : Form
    {
        
        
        //string username, password;
        string err;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        //public frmDoiMatKhau(string user, string pass)
        //{
        //    InitializeComponent();
        //    username = user;
        //    password = pass;
        //}

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string ten = txtTaiKhoan.Text;
            if (ten == "")
            {
                MessageBox.Show("Bạn chưa nhập tên truy cập");
            }
            else
            {
                if (txtMatKhauCu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu");
                }
                else
                {
                    if (txtMatKhauMoi.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu mới");
                    }
                    else
                    {
                        if (txtXacNhanMatKhau.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập lại mật khẩu");
                        }
                        else
                        {
                            if ((txtMatKhauMoi.Text == txtXacNhanMatKhau.Text) && txtMatKhauCu.Text == BLDangNhap.password)
                            {
                                //Conn.executeQuery(update);
                                BLDoiMatKhau blDMK = new BLDoiMatKhau();
                                blDMK.CapNhatMatKhau(txtMatKhauMoi.Text, txtTaiKhoan.Text, txtMatKhauCu.Text, ref err);
                                MessageBox.Show("Bạn đã thay đổi mật khẩu thành công");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Bạn nhập lại mật khẩu không đúng");
                                txtXacNhanMatKhau.Text = "";
                                txtXacNhanMatKhau.Focus();
                            }
                        }
                    }
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                this.Hide();
            else if (dialog == DialogResult.No)
            {
                //
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = BLDangNhap.username;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
