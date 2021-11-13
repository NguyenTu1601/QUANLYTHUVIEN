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
    class BLTheLoai
    {
        DBMain db = null;
        public BLTheLoai()
        {
            db = new DBMain();
        }
        public DataSet LayTheLoai()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM dbo.viewTheLoai", CommandType.Text);
        }
        public bool ThemTheLoai(string MaTheLoai, string TenTheLoai, ref string err)
        {
            return db.MyExecuteNonQuery("spThemTHeLoai", CommandType.StoredProcedure, ref err,
                  new SqlParameter("@MaTL", MaTheLoai), new SqlParameter("@TenTL", TenTheLoai));

        }
        public bool XoaTheLoai(ref string err, string MaTheLoai)
        {
           return db.MyExecuteNonQuery("spXoaTheLoai_TheoMaTL", CommandType.StoredProcedure, ref err,
               new SqlParameter("@maTL", MaTheLoai));
        }
        public bool CapNhatTheLoai(string MaTheLoai, string TenTheLoai, ref string err)
        {

            return db.MyExecuteNonQuery("spCapNhapTheLoai", CommandType.StoredProcedure, ref err,
                  new SqlParameter("@MaTL", MaTheLoai), new SqlParameter("@TenTL", TenTheLoai));

            //string sqlString = "Update TheLoai Set TenTL = N'" +
            //    TenTheLoai + "' Where MaTL='" + MaTheLoai + "' ";
            //return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
            //sdpfijdlds
        }
    }
}
