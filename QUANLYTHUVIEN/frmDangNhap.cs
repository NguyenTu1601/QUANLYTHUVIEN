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
    public partial class frmDangNhap : Form
    {
        
        //frmMain frma = new frmMain();
        public string IPText;
        public string log = "";
        //
        
        //DataTable dtDangNhap = null;
        string err;
        BLDangNhap dbDN = new BLDangNhap();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            //txtID.Focus();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên đăng nhập hoặc mật khẩu!", "Thông báo");
                    return;
                }
                
                //
                BLDangNhap blDN = new BLDangNhap();
                DataTable dt = blDN.LayUser(this.txtID.Text, this.txtPass.Text, ref err);
                
                if (dt.Rows.Count > 0)  // Nếu tài khoản và mật khẩu đúng thì bảng sẽ có hàng mới
                {
                    //
                    BLDangNhap.username = txtID.Text;
                    BLDangNhap.password = txtPass.Text;
                    //
                    MessageBox.Show("Xin chào " + txtID.Text + "! \nBạn đã đăng nhập thành công!", "Thông báo");
                    this.Hide();
                    DataTable ktra = blDN.KTraPhanQUyen(this.txtID.Text, ref err);
                    if(ktra.Rows.Count>0)
                    {
                        Form main = new frmMain(0);

                        main.Show();
                    }
                    else
                    {
                        Form main = new frmMain(1);

                        main.Show();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công!", "Thông báo");
                    txtID.Clear();
                    txtPass.Clear();
                    txtID.Focus();
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi SQL!!!");
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
                //Application.Exit();
                
            }
            else if (dialog == DialogResult.No)
            {
                //
            }
        }
        
        //Code đăng ký tài khoản mới

        //private void btnDangKy_Click(object sender, EventArgs e)
        //{
        //    if (txtTaiKhoanDK.Text == "")
        //    {
        //        MessageBox.Show("Vui lòng nhập tên tài khoản!");
        //        return;
        //    }
        //    if (txtMatKhauDK.Text == "")
        //    {
        //        MessageBox.Show("Vui lòng nhập mật khẩu!");
        //        return;
        //    }
        //    else
        //        if (txtMatKhauDK.Text != txtReMatKhauDK.Text)
        //        MessageBox.Show("Hai mật khẩu không khớp!");
        //    else
        //    {
        //        //Thêm dữ liệu vào bảng User trên SQL
        //        BLDangNhap blDN = new BLDangNhap();
        //        blDN.ThemUser(this.txtTaiKhoanDK.Text, this.txtMatKhauDK.Text, ref err);
        //        MessageBox.Show("Bạn đã đăng kí thành công!");
        //        this.Height = 435;

        //    }
        //}
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Height = 435;
            txtID.Focus();
        }

        private void lbDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Height = 751;
        }

        private void txtID_Click(object sender, EventArgs e)
        {
            pictureUser.BackgroundImage = Properties.Resources.iconUser;
            txtID.Text = "";
            pictureBox2.BackColor = Color.Blue;

            picturePass.BackgroundImage = Properties.Resources.icon_pass_white;
            pictureBox4.BackColor = Color.White;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            picturePass.BackgroundImage = Properties.Resources.icon_pass;
            txtPass.Text = "";
            pictureBox4.BackColor = Color.Blue;
            txtPass.PasswordChar = '*';

            pictureUser.BackgroundImage = Properties.Resources.icon_user_white;
            pictureBox2.BackColor = Color.White;
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
