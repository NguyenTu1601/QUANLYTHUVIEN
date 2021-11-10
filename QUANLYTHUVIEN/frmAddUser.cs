using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYTHUVIEN
{
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                this.Hide();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length >= 10) 
            {
                MessageBox.Show("Tên đăng nhập quá dài!", "Thông báo", MessageBoxButtons.OK);                           
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
                MessageBox.Show("Vui Lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK);
            else
            {
                if(txtPass.Text == "")
                {
                    MessageBox.Show("Vui Lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    if(txtRePass.Text == "")
                    {
                        MessageBox.Show("Vui Lòng nhập lại mật khẩu!", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if(txtPass.Text != txtRePass.Text)
                        {
                            MessageBox.Show("Mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (ktraUser() == false) 
                            {
                                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                            }
                            else
                            {

                            }    
                        }
                    }
                }
            }

        }
        //ktra user đã có chưa
        private bool ktraUser()
        {
            bool f = true;



            return f;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length >= 10)
            {
                MessageBox.Show("Mật khẩu quá dài!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void txtRePass_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length >= 10)
            {
                MessageBox.Show("Mật khẩu nhập lại quá dài!", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
