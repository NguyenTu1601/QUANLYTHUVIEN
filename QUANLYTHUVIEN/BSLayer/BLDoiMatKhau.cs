using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using QUANLYTHUVIEN.DBLayer;
namespace QUANLYTHUVIEN.BSLayer
{
    class BLDoiMatKhau
    {
        DBMain db = null;
        public BLDoiMatKhau()
        {
            db = new DBMain();
        }
        //
        public bool CapNhatMatKhau(string matkhaumoi,string taikhoan,string matkhaucu, ref string err)
        {
        return db.MyExecuteNonQuery("spCapNhatMatKhau", CommandType.StoredProcedure, ref err,
              new SqlParameter("@MatKhauMoi", matkhaumoi), new SqlParameter("@TaiKhoan ", taikhoan),
              new SqlParameter("@MatKhauCu ", matkhaucu));

            //string strSQL = "update User set Password='" +
            //    matkhaumoi + "' where(ID=N'" +
            //    taikhoan + "' and Password='" +
            //    matkhaucu + "')";
            //return db.MyExecuteNonQuery(strSQL, CommandType.Text, ref err);
        }
    }
}
