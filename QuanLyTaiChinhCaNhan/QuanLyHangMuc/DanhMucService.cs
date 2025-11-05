using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace QuanLyTaiChinh
{
    public static class HangMucService
    {
        private static string chuoiketnoi = "Server = LAPTOP-O8Q0L0EF\\SQLEXPRESS; Database = QuanLyChiTieu; Integrated Security = True";

        public static List<HangMuc> LayHangMucTheoLoai(int maTaiKhoan, string loaiHangMuc)
        {
            var list = new List<HangMuc>();
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                string sql = @"
                    SELECT MaHangMuc, MaTaiKhoan, TenHangMuc, LoaiHangMuc, BieuTuong 
                    FROM HangMuc 
                    WHERE MaTaiKhoan = @MaTaiKhoan AND LoaiHangMuc = @LoaiHangMuc";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cmd.Parameters.AddWithValue("@LoaiHangMuc", loaiHangMuc);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new HangMuc
                            {
                                MaHangMuc = reader.GetInt32(0),
                                MaTaiKhoan = reader.GetInt32(1),
                                TenHangMuc = reader.GetString(2),
                                LoaiHangMuc = reader.GetString(3),
                                BieuTuong = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static void ThemHangMuc(HangMuc hm)
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                string sql = @"
                    INSERT INTO HangMuc (MaTaiKhoan, TenHangMuc, LoaiHangMuc, BieuTuong)
                    VALUES (@MaTaiKhoan, @TenHangMuc, @LoaiHangMuc, @BieuTuong)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", hm.MaTaiKhoan);
                    cmd.Parameters.AddWithValue("@TenHangMuc", hm.TenHangMuc);
                    cmd.Parameters.AddWithValue("@LoaiHangMuc", hm.LoaiHangMuc);
                    cmd.Parameters.AddWithValue("@BieuTuong", hm.BieuTuong ?? "default.png");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CapNhatHangMuc(HangMuc hm)
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                string sql = @"
                    UPDATE HangMuc 
                    SET TenHangMuc = @TenHangMuc, LoaiHangMuc = @LoaiHangMuc, BieuTuong = @BieuTuong 
                    WHERE MaHangMuc = @MaHangMuc AND MaTaiKhoan = @MaTaiKhoan";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHangMuc", hm.MaHangMuc);
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", hm.MaTaiKhoan);
                    cmd.Parameters.AddWithValue("@TenHangMuc", hm.TenHangMuc);
                    cmd.Parameters.AddWithValue("@LoaiHangMuc", hm.LoaiHangMuc);
                    cmd.Parameters.AddWithValue("@BieuTuong", hm.BieuTuong ?? "default.png");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void XoaHangMuc(int maHangMuc, int maTaiKhoan)
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                string sql = "DELETE FROM HangMuc WHERE MaHangMuc = @MaHangMuc AND MaTaiKhoan = @MaTaiKhoan";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHangMuc", maHangMuc);
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}