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
    class BLDanhMucSach
    {
        DBMain db = null;
        public BLDanhMucSach()
        {
            db = new DBMain();
        }

        //Lấy dữ liệu bảng sách
        public DataSet LaySach()
        {
            return db.ExecuteQueryDataSet("select * from viewSach", CommandType.Text);
        }
        public bool ThemSach(string MaSach, string MaTheLoai, string TenSach, string TacGia, string NXB, DateTime NgayMua,
            string Ton,string SoLanMuon, ref string err)
        {
            return db.MyExecuteNonQuery("spThemSach", CommandType.StoredProcedure, ref err,
               new SqlParameter("@maSach", MaSach), new SqlParameter("@maTL", MaTheLoai),
               new SqlParameter("@tenSach", TenSach), new SqlParameter("@tacGia", TacGia),
               new SqlParameter("@nhaXuatBan", NXB), new SqlParameter("@ngayMuaSach", NgayMua),
               new SqlParameter("@tonTai", Ton), new SqlParameter("@soLanMuon", SoLanMuon));

        }
        //xóa sách
        public bool XoaSach(ref string err, string MaSach)
        {
            return db.MyExecuteNonQuery("spXoaSach_TheoMaSach", CommandType.StoredProcedure, ref err,
                new SqlParameter("@maSach", MaSach));

        }

        //Cập nhật sách
        public bool CapNhatSach(string MaSach, string MaTheLoai, string TenSach, string TacGia, 
            string NXB, DateTime NgayMua, string Ton,string SoLanMuon, ref string err)
        {
                return db.MyExecuteNonQuery("spCapNhatSach", CommandType.StoredProcedure, ref err,
                 new SqlParameter("@maSach", MaSach), new SqlParameter("@maTL", MaTheLoai),
               new SqlParameter("@tenSach", TenSach), new SqlParameter("@tacGia", TacGia),
               new SqlParameter("@nhaXuatBan", NXB), new SqlParameter("@ngayMuaSach", NgayMua),
               new SqlParameter("@tonTai", Ton), new SqlParameter("@soLanMuon", SoLanMuon));

            //string sqlString = "Update Sach Set MaTL = '" +
            //    MaTheLoai + "',TenSach=N'" +
            //    TenSach + "', TacGia = N'" +
            //    TacGia + "', NhaXuatBan=N'" +
            //    NXB + "',NgayMuaSach='" +
            //    NgayMua + "',TonTai='"+Ton+"',SoLanMuon='"+SoLanMuon+"' Where MaSach='" + MaSach + "' ";
            //return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        //Tìm sách
        public DataTable TimSach(string TenSach,ref string err)
        {
            string sqlString = "Select * from Sach where TenSach like N'%" + TenSach + "%' ";
            return db.GetDataTable(sqlString, CommandType.Text, ref err);
        }
        public DataTable Load_cbox(string MaTL, ref string err)
        {
            return db.ExecuteQueryDataSet("select * from viewTheLoai", CommandType.Text).Tables[0];
        }

        //public DataSet KiemSach(string TenSach)
        //{
        //    return db.ExecuteQueryDataSet("Select * from tblSach where TenSach like N'%" + TenSach + "%' ",CommandType.Text);
        //}
    }
}
