using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class ChiTietPhieuXuat
    {
        KetNoiDB kn = new KetNoiDB();

        public DataTable ShowCTPX(string DieuKien)
        {
            string sql = @"SELECT MaHH, SoLuong, DonGia, ThanhTien FROM CHITIETPHIEUXUAT " + DieuKien;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(dt);
            return dt;
        }

        public void InsertCTPX(string mapx, string mahh, int soluong, long dongia, long thanhtien)
        {
            string sql = "ThemCTPX";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@mapx", mapx);
            cmd.Parameters.AddWithValue("@mahh", mahh);
            cmd.Parameters.AddWithValue("@soluong", soluong);
            cmd.Parameters.AddWithValue("@dongia", dongia);
            cmd.Parameters.AddWithValue("@thanhtien", thanhtien);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }
        public DataTable ShowHangHoa(string DieuKien)
        {
            string sql = @"SELECT MaHH, TenHH, SoLuong, GiaNhap, GiaXuat, NSX, ThongTin
                                                    FROM dbo.HANGHOA " + DieuKien;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(KetNoiDB.getconnect());
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
        public DataTable HienThi(string DieuKien)
        {
            string sql = @"SELECT * FROM dbo.CHITIETPHIEUXUAT WHERE MaPX = '" + DieuKien + "'";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(KetNoiDB.getconnect());
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
        public DataTable ShowHangHoa(string DieuKien)
        {
            string sql = @"SELECT MaHH, TenHH, SoLuong, GiaNhap, GiaXuat, NSX, ThongTin
                                                    FROM dbo.HANGHOA " + DieuKien;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(KetNoiDB.getconnect());
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
        public DataTable ShowHangHoa(string DieuKien)
        {
            string sql = @"SELECT MaHH, TenHH, SoLuong, GiaNhap, GiaXuat, NSX, ThongTin
                                                    FROM dbo.HANGHOA " + DieuKien;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(KetNoiDB.getconnect());
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
        public DataTable HienThiTien(string DieuKien)
        {
            string sql = @"SELECT TongTien FROM dbo.PHIEUXUAT WHERE MaPX = '" + DieuKien + "'";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(dt);
            return dt;
        }
        
    }
}
