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
    class BLMuonSach
    {
        DBMain db = null;
        public BLMuonSach()
        {
            db = new DBMain();
        }
        public DataSet LayTheLoai()
        {
            return db.ExecuteQueryDataSet("select MaTL,TenTL from TheLoai", CommandType.Text);
        }
        public DataSet LaySach()
        {
            return db.ExecuteQueryDataSet("select TenSach,TacGia,NhaXuatBan from Sach", CommandType.Text);
        }
        public DataTable Load_cbox()
        {
            return db.ExecuteQueryDataSet("select * from DocGia", CommandType.Text).Tables[0];
        }
        public DataTable TimSach(string TenSach, ref string err)
        {
            string sqlString = "Select * from Sach where TenSach like N'%" + TenSach + "%' ";
            return db.GetDataTable(sqlString, CommandType.Text, ref err);
        }
        public DataTable TimTheLoai(string TenTheLoai, ref string err)
        {
            string sqlString = "Select * from TheLoai where TenTL like N'%" + TenTheLoai + "%' ";
            return db.GetDataTable(sqlString, CommandType.Text, ref err);
        }
        //Hàm lấy thông tin sách theo mã thể loại
        public DataTable ShowSach(string MaTheLoai, ref string err)
        {
            string sqlString = "select TenSach,TacGia,NhaXuatBan from Sach where MaTL='" + MaTheLoai + "'";
            return db.GetDataTable(sqlString, CommandType.Text, ref err);
        }
        //Hàm mượn sách
        public bool MuonSach(string MaPhieuMuon, string MaDocGia, ref string err)
        {
            string sqlString = "Insert Into HoaDonMuon(MaPM,MaDG,TinhTrang) Values(" + "'" +
                MaPhieuMuon + "','" +
                MaDocGia + "','0')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }
        //Hàm thêm thông tin mượn vào bảng chi tiết mượn
        public bool ThemVaotblChiTietMuon(string MaPhieuMuon, string TenSach, string NgayMuon, string NgayTra, ref string err)
        {
            string sqlString = @"Insert Into ChiTietMuon(MaPM,MaSach,NgayThue,NgayTra) 
                    values('" + MaPhieuMuon + "', (select MaSach from Sach where Sach.TenSach = N'"
                    + TenSach + "'),'" + NgayMuon + "','" + NgayTra + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);

        }
        //Hàm tính lại số lượng sách còn tồn tại
        //public bool TinhSoSachTonTai(string TenSach, ref string err)
        //{
        //    string sqlString = @"update Sach set TonTai=(TonTai-1)
        //            where MaSach=(select MaSach from Sach where Sach.TenSach=N'"
        //            + TenSach + "')";
        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
        //Hàm tính lại số lần mượn
        //public bool TinhSoLanMuon(string TenSach, ref string err)
        //{
        //    string sqlString = @"update Sach set SoLanMuon=(SoLanMuon+1)
        //            where MaSach=(select MaSach from Sach where Sach.TenSach=N'"
        //             +TenSach+ "')";
        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
        //Hàm lấy thông tin độc giả để in phiếu mượn
        public DataTable LayHoTenDocGia(string MaDG, ref string err)
        {
            string sqlString = @"Select HoTen from DocGia where DocGia.MaDG=" + MaDG + "";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text).Tables[0];
        }
        public DataTable LayHT(string MaDG)
        {
            return db.ExecuteQueryDataSet("select * from DocGia where DocGia.MaDG=" + MaDG + "", CommandType.Text).Tables[0];
        }
        public string LayGioiTinhDocGia(string MaDG)
        {
            return db.ExecuteQueryDataSet("Select GioiTinh from DocGia where DocGia.MaDG=" + MaDG + "", CommandType.Text).ToString();
        }
        public DataSet LayDiaChiDocGia(string MaDG)
        {
            return db.ExecuteQueryDataSet("Select DiaChi from DocGia where DocGia.MaDG=" + MaDG + "", CommandType.Text);
        }
    }
}





