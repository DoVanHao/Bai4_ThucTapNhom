﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class ChiNhanh
    {
    // Hien thi khach hang

        public DataTable HienThiKhachHang()
        {
            string sql = @"SELECT * FROM dbo.CHINHANH ";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(dt);
            return dt;
        }
        //Chen khach hang
        public string InsertKhachHang(string TenKH, string Gioitinh, string Diachi, string SDT, string LoaiKH, string Ghichu)
        {
            string str = "";
            string sql = "InsertKH";
            //   string sql = "insert NhomSP values (@Manhom, @Tennhom, @NgayCN)";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TenKH", TenKH);
            cmd.Parameters.AddWithValue("@gt", Gioitinh);
            cmd.Parameters.AddWithValue("@DC", Diachi);
            cmd.Parameters.AddWithValue("@SDT", SDT);
            cmd.Parameters.AddWithValue("@LoaiKH", LoaiKH);
            cmd.Parameters.AddWithValue("@ghichu", Ghichu);

            //cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            str = dt.Rows[0].ItemArray[0].ToString();

            cmd.Dispose();
            con.Close();

            return str;
        }

        public void UpdateKhachHang(string MaKh, string TenKH, string Gioitinh, string Diachi, string SDT, string LoaiKH, string Ghichu)
        {
            string sql = "UpdateKH";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaKH", MaKh);
            cmd.Parameters.AddWithValue("@TenKH", TenKH);
            cmd.Parameters.AddWithValue("@gt", Gioitinh);
            cmd.Parameters.AddWithValue("@DC", Diachi);
            cmd.Parameters.AddWithValue("@SDT", SDT);
            cmd.Parameters.AddWithValue("@LoaiKH", LoaiKH);
            cmd.Parameters.AddWithValue("@ghichu", Ghichu);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        //Xoa mot khách hàng
       
        //Tim kiem khach hang
       
        //Tim kiem theo loai khach hang
        public DataTable SearchLoaiKH(string _LoaiKH)
        {
            DataTable dt = new DataTable();
            string sql = "SearchLoaiKH";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@str", _LoaiKH);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();
            cmd.Dispose();
            return dt;
        }
      
        //Show 10 khach hang
        public DataTable Show10KH()
        {
            DataTable dt = new DataTable();
            string sql = "Show10KH";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();
            cmd.Dispose();
            return dt;
        }
        //Show khach hang theo ngay
        public DataTable ShowKHTHeoNgay(DateTime date1, DateTime date2)
        {
            DataTable dt = new DataTable();
            string sql = "ShowKHNhieuNgay";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date1", date1);
            cmd.Parameters.AddWithValue("@date2", date2);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();
            cmd.Dispose();
            return dt;
        }
    }
}
