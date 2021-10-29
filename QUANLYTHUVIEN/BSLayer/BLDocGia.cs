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
    class BLDocGia
    {
        DBMain db = null;
        public BLDocGia()
        {
            db = new DBMain();
        }

        //Lấy dữ liệu bảng đọc giả
        public DataSet LayDocGia()
        {
            return db.ExecuteQueryDataSet("select * from viewDocGia", CommandType.Text);
        }

        //Thêm đọc giả 
        public bool ThemDocGia(string MaDocGia, string HoTen, int GioiTinh, DateTime NgaySinh, string DiaChi, string SDT, string Email, ref string err)
        {
            return db.MyExecuteNonQuery("spThemDocGia", CommandType.StoredProcedure, ref err,
              new SqlParameter("@MaDG", MaDocGia), new SqlParameter("@Hoten", HoTen),
              new SqlParameter("@GioiTinh", GioiTinh), new SqlParameter("@NgaySinh", NgaySinh),
              new SqlParameter("@DiaChi", DiaChi), new SqlParameter("@SDT", SDT),
              new SqlParameter("@Email", Email));

            //string sqlString = "Insert Into DocGia Values(" + "'" +
            //    MaDocGia + "',N'" +
            //    HoTen + "','" +
            //    GioiTinh + "','" +
            //    NgaySinh + "',N'" +
            //    DiaChi + "','" +
            //    SDT + "','"+
            //    Email+"')";
            //return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }
        public bool XoaDocGia(ref string err, string MaDocGia)
        {
            return db.MyExecuteNonQuery("spXoaDOcGia_TheoMa", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MaDG", MaDocGia));
        }
        public bool CapNhatDocGia(string MaDocGia, string HoTen, string GioiTinh, DateTime NgaySinh, string DiaChi, string SDT, string Email, ref string err)
        {
            return db.MyExecuteNonQuery("spCapNhatDocGia", CommandType.StoredProcedure, ref err,
              new SqlParameter("@MaDG", MaDocGia), new SqlParameter("@Hoten", HoTen),
              new SqlParameter("@GioiTinh", GioiTinh), new SqlParameter("@NgaySinh", NgaySinh),
              new SqlParameter("@DiaChi", DiaChi), new SqlParameter("@SDT", SDT),
              new SqlParameter("@Email", Email));
        }
    }
}
