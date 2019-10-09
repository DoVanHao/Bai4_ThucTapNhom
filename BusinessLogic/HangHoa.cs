using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class HangHoa
    {
        KetNoiDB db = new KetNoiDB();
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

        public string InsertHangHoa(string tenhh, int soluong, long giannhap, long giaxuat, string nsx, string thongtin)
        {
            string sql = "ThemHH";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenhh", tenhh);
            cmd.Parameters.AddWithValue("@soluong", soluong);
            cmd.Parameters.AddWithValue("@gianhap", giannhap);
            cmd.Parameters.AddWithValue("@giaxuat", giaxuat);
            cmd.Parameters.AddWithValue("@nsx", nsx);
            cmd.Parameters.AddWithValue("@thongtin", thongtin);

            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            string ma = dt.Rows[0].ItemArray[0].ToString();
            cmd.Dispose();
            con.Close();
            return ma;
        }
        public DataTable TKHH_TenHH(string TenHH)
        {
            string sql = "SELECT * FROM dbo.HANGHOA WHERE TenHH LIKE N'%' + @TenHH + '%'";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(KetNoiDB.getconnect());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();

            cmd.Parameters.AddWithValue("@TenHH",TenHH);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public DataTable TKHH_NSX(string NSX)
        {
            string sql = "SELECT * FROM dbo.HANGHOA WHERE NSX LIKE N'%' + @NSX + '%'";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();

            cmd.Parameters.AddWithValue("@NSX", NSX);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public void UpdateSanPham(EC_SANPHAM et)
        {
            string sql = "SuaSP";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@masp", et.MaSP);
            cmd.Parameters.AddWithValue("@tensp", et.TenSP);
            cmd.Parameters.AddWithValue("@malh", et.MaLH);
            cmd.Parameters.AddWithValue("@soluong", et.SoLuong);
            cmd.Parameters.AddWithValue("@loinhuan", et.LoiNhuan);
            cmd.Parameters.AddWithValue("@gianhap", et.GiaNhap);
            cmd.Parameters.AddWithValue("@mota", et.MoTa);
            cmd.Parameters.AddWithValue("@nsx", et.NSX);
            cmd.Parameters.AddWithValue("@hinhanh", et.HinhAnh);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }
        public void UpdateSoLuong(EC_SANPHAM et)
        {
            string sql = "SuaSL";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@masp", et.MaSP);
            cmd.Parameters.AddWithValue("@sl", et.SoLuong);
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
    }
}
