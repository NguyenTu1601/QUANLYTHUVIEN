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
    class BLNhanVien
    {
        DBMain db = null;
        public BLNhanVien()
        {
            db = new DBMain();
        }
        public DataSet LayNhanVien()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM dbo.viewNhanVien", CommandType.Text);
        }
        public bool ThemNhanVien(string MaNhanVien, string HoTen, int GioiTinh, DateTime NgaySinh, string DiaChi, string SDT, ref string err)
        {
              return db.MyExecuteNonQuery("spThemNhan", CommandType.StoredProcedure, ref err,
              new SqlParameter("@MaNhanVien", MaNhanVien), new SqlParameter("@HoTen", HoTen),
              new SqlParameter("@GioiTinh", GioiTinh), new SqlParameter("@NgaySinh", NgaySinh), 
              new SqlParameter("@DiaChi", DiaChi), new SqlParameter("@SDT",SDT));

            //string sqlString = "Insert Into TTNhanVien Values(" + "'" +
            //    MaNhanVien + "',N'" +
            //    HoTen + "','" +
            //    GioiTinh + "','" +
            //    NgaySinh + "',N'" +
            //    DiaChi + "','" +
            //    SDT + "')";
            //return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }
        public bool XoaNhanVien(ref string err, string MaNhanVien)
        {
              return db.MyExecuteNonQuery("spXoaNhanVien_MaNV", CommandType.StoredProcedure, ref err,
              new SqlParameter("@maNV", MaNhanVien));
        }
            public bool CapNhatNhanVien(string MaNhanVien, string HoTen, string GioiTinh, DateTime NgaySinh, string DiaChi, string SDT, ref string err)
             {
              return db.MyExecuteNonQuery("spCapNhanVien", CommandType.StoredProcedure, ref err,
              new SqlParameter("@MaNV", MaNhanVien), new SqlParameter("@HoTen", HoTen),
              new SqlParameter("@GioiTinh", GioiTinh), new SqlParameter("@NgaySinh", NgaySinh),
              new SqlParameter("@DiaChi", DiaChi), new SqlParameter("@DienThoai",SDT));

            //string sqlString = "Update TTNhanVien Set HoTen = N'" +
            //    HoTen + "',GioiTinh='" +
            //    GioiTinh + "', NgaySinh = '" +
            //    NgaySinh + "', DiaChi=N'" +
            //    DiaChi + "',DienThoai='" +
            //    SDT + "' Where MaNV='" + MaNhanVien + "' ";
            //return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
