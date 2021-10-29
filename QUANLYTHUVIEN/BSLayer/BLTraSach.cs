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
    class BLTraSach
    {
        DBMain db = null;
        public BLTraSach()
        {
            db = new DBMain();
        }
        //Hàm load dữ liệu trong cboxMaDG ở frmTraSach
        public DataTable Load_cbox()
        {
            return db.ExecuteQueryDataSet("select * from DocGia", CommandType.Text).Tables[0];
        }
        //Hàm load dữ liệu trong cboxMaDG ở frmTraSach khi giá trị ở cboxMaDG thay đổi
        public DataTable Load_cboxMaDG_SelectedIndexChanged(string MaDG)
        {
            return db.ExecuteQueryDataSet("select * from HoaDonMuon where MaDG='" + MaDG + "'", CommandType.Text).Tables[0];
        }
        //Hàm load dữ liệu trong cboxMaPM ở frmTraSach khi giá trị ở cboxMaPM thay đổi
        public DataTable Load_cboxMaPM_SelectedIndexChanged(string MaPM)
        {
            return db.ExecuteQueryDataSet("select * from ChiTietMuon where MaPM='" + MaPM + "'", CommandType.Text).Tables[0];
        }
        public DataSet LaySach()
        {
            return db.ExecuteQueryDataSet("select MaSach,TenSach from Sach", CommandType.Text);
        }
        public DataSet LaySachDaMuon(string MaPM, string NgayMuon)
        {
            return db.ExecuteQueryDataSet(@"select MaSach,TenSach from Sach 
                            where MaSach = (select MaSach from ChiTietMuon
                                where (ChiTietMuon.MaPM = '" + MaPM + "' " +
                                "and ChiTietMuon.NgayThue='" + NgayMuon + "' " +
                                "and Sach.MaSach=ChiTietMuon.MaSach))", CommandType.Text);
        }
        //Các hàm dùng trong sự kiện btnTra_Click
        //Các hàm khi trả hết (Kiemtra==1)
        public bool XoaHoaDonMuon1(string MaPM, string MaDG, ref string err)
        {
            string sqlString = @"update HoaDonMuon set TinhTrang=1 where MaPM='"
                + MaPM + "' and MaDG='" + MaDG + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool Tra1(string TenSach, string MaPM, string NgayMuon, ref string err)
        {
            string sqlString = @"delete from ChiTietMuon 
                    where MaSach=(select MaSach from Sach where Sach.TenSach=N'"
                    + TenSach + "' and ChiTietMuon.MaPM='" + MaPM +
                    "' and ChiTietMuon.NgayThue='" + NgayMuon + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        //public bool Update_TonTai1(string TenSach, ref string err)
        //{
        //    string sqlString = @"update tblSach set TonTai=(TonTai+1) 
        //            where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'"
        //            + TenSach + "')";
        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
        //public bool Update_SoLanMuon1(string TenSach, ref string err)
        //{
        //    string sqlString = @"update tblSach set SoLanMuon=(SoLanMuon-1) 
        //            where MaSach=(select MaSach from tblSach 
        //            where tblSach.TenSach=N'" + TenSach + "')";
        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
        //Các hàm khi  CHƯA trả hết (Kiemtra==0)
        public bool XoaHoaDonMuon0(string MaPM, string MaDG, ref string err)
        {
            string sqlString = @"update HoaDonMuon set TinhTrang=0 
                                where MaPM='" + MaPM + "' and MaDG='" + MaDG + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool Tra0(string TenSach, string MaPM, string NgayMuon, ref string err)
        {
            string sqlString = @"delete from ChiTietMuon 
                                where MaSach=(select MaSach from Sach 
                                where Sach.TenSach=N'" +
                                TenSach + "' and ChiTietMuon.MaPM='" +
                                MaPM + "' and ChiTietMuon.NgayThue='" +
                                NgayMuon + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        //public bool Update_TonTai0(string TenSach, ref string err)
        //{
        //    string sqlString = @"update tblSach set TonTai=(TonTai+1) 
        //                                where MaSach=(select MaSach from tblSach 
        //                                where tblSach.TenSach=N'" + TenSach + "')";
        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
        //public bool Update_SoLanMuon0(string TenSach, ref string err)
        //{
        //    string sqlString = @"update tblSach set SoLanMuon=(SoLanMuon-1) 
        //                                where MaSach=(select MaSach from tblSach 
        //                                where tblSach.TenSach=N'" + TenSach + "')";
        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
    }
}

