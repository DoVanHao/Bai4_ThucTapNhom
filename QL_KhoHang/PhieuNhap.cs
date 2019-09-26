﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class PhieuNhap
    {
        KetNoiDB da = new KetNoiDB();

        public DataTable ShowPN(string DieuKien)
        {
            string sql = @"SELECT MaPN, MaNCC, NgayNhap FROM PHIEUNHAP " + DieuKien;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(dt);
            return dt;
        }
        public DataTable ShowPN(DateTime _NgayDau, DateTime _NgayCuoi)
        {
            string sql = "ThongKeHDN";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ngaydau", _NgayDau);
            cmd.Parameters.AddWithValue("@ngaycuoi", _NgayCuoi);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            return dt;
        }

        public void addTien(string MaPN)
        {
            string sql = "TienNhap";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPN", MaPN);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public DataTable HT_PN(string ngay1, string ngay2)
        {
            string str = "TK_PN";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ngay1", DateTime.Parse(ngay1));
            cmd.Parameters.AddWithValue("@Ngay2", DateTime.Parse(ngay2));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable HT_CTPN(string ngay1, string ngay2)
        {
            string str = "HT_TK_CTPN";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ngay1", DateTime.Parse(ngay1));
            cmd.Parameters.AddWithValue("@Ngay2", DateTime.Parse(ngay2));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
     
        public string InsertPN(string mancc, DateTime ngaynhap)
        {
            string sql = "ThemPN";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@mancc", mancc);
            cmd.Parameters.AddWithValue("@ngaynhap", ngaynhap);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            string ma = dt.Rows[0].ItemArray[0].ToString();

            cmd.Dispose();
            con.Close();
            if (ma != null) return ma;
            return "error";
        }
        public bool them_nhanvien(string hoTen, bool gioiTinh, DateTime ngaySinh, string soChungMinh, string diaChi, string soDienThoai, DateTime ngayVaoLam)
        {
            SqlConnection cnn = ketnoi.Get();
            SqlCommand cmd = new SqlCommand("them_nhanvien", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("hoTen", hoTen);
            cmd.Parameters.AddWithValue("gioiTinh", gioiTinh);
            cmd.Parameters.AddWithValue("ngaySinh", ngaySinh);
            cmd.Parameters.AddWithValue("soChungMinh", soChungMinh);
            cmd.Parameters.AddWithValue("diaChi", diaChi);
            cmd.Parameters.AddWithValue("soDienThoai", soDienThoai);
            cmd.Parameters.AddWithValue("ngayVaoLam", ngayVaoLam);

            int i = cmd.ExecuteNonQuery();
            cnn.Close();
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
