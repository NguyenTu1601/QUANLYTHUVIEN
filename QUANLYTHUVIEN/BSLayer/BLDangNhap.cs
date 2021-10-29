using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// TRUYEN NE
using System.Data;
using System.Data.SqlClient;

using QUANLYTHUVIEN.DBLayer;
namespace QUANLYTHUVIEN.BSLayer
{
    class BLDangNhap
    {
        public static string username;
        public static string password;
        DBMain db = null;
        public BLDangNhap()
        {
            db = new DBMain();
        }
        //Tạo tài khoản mới
        //public bool ThemUser(string UserName, string Password, ref string err)
        //{
        //    string sqlString = "Insert Into User(ID,Password,PhanQuyen) Values(" + "'" +
        //        UserName + "','" +
        //        Password + "','3')";
        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
        //Lấy thông tin tài khoản đã có trong bảng SQL để đăng nhập
        public DataTable LayUser(string UserName, string Password, ref string err)
        {
            string sqlString = "Select * from UserName where ID='"+ UserName+"' and Password = '" + Password
                +"'";
            return db.GetDataTable(sqlString, CommandType.Text, ref err);
        }
        public DataTable KTraPhanQUyen(string UserName, ref string err)
        {
            string sqlString = "Select * from UserName where ID='" + UserName + "' and PhanQuyen = '" + 0
               + "'";
            return db.GetDataTable(sqlString, CommandType.Text, ref err);
        }
    }
}
