using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYTHUVIEN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain(0));
            Application.Run(new frmDangNhap());
            //Application.Run(new frmAddUser());
            //Application.Run(new frmDoiMatKhau());
            //Application.Run(new frmNhanVien());
            //Application.Run(new frmMuonSach());
            //Application.Run(new frmDeleteUser());
        }
    }
}
