using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyTaiChinhCaNhan
{
    public partial class frmBaoCaoChiTieuTheoHangMuc : Form
    {
        private string chuoiketnoi = "Server = LAPTOP-O8Q0L0EF\\SQLEXPRESS; Database = QuanLyChiTieu; Integrated Security = True";
        private int maTaiKhoan;
        private DateTime thoiGian;
        private string loaiThoiGian;

        public frmBaoCaoChiTieuTheoHangMuc(int maTaiKhoan, string thoiGian)
        {
            InitializeComponent();
            this.maTaiKhoan = maTaiKhoan;
            (this.thoiGian, this.loaiThoiGian) = ParseThoiGianToDateTime(thoiGian);
            Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Constructor called at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Input thoiGian string: {thoiGian}, LoaiThoiGian: {loaiThoiGian}");
            Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Parsed thoiGian: {this.thoiGian:yyyy-MM-dd HH:mm:ss}");
        }

        private (DateTime, string) ParseThoiGianToDateTime(string thoiGian)
        {
            Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Parsing input thoiGian: {thoiGian}");
            try
            {
                

                if (thoiGian.Contains("/")) // Ngày hoặc Tháng
                {
                    if (thoiGian.Split('/').Length == 2 && !thoiGian.Contains("Tuần")) // Tháng
                    {
                        string[] parts = thoiGian.Split('/');
                        int month = int.Parse(parts[0].Trim());
                        int year = int.Parse(parts[1].Trim());
                        DateTime result = new DateTime(year, month, 1).Date;
                        Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Parsed month/year: {month}/{year}, Result: {result:yyyy-MM-dd}");
                        return (result, "Month");
                    }
                    else // Ngày
                    {
                        DateTime result = DateTime.ParseExact(thoiGian.Trim(), "MM/dd/yyyy", null).Date;
                        Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Parsed date: {result:yyyy-MM-dd}");
                        return (result, "Day");
                    }
                }
                else if (thoiGian.Contains("Tuần")) // Tuần
                {
                    // Sử dụng regex để tách "Tuần X - YYYY"
                    var match = Regex.Match(thoiGian.Trim(), @"Tuần\s+(\d+)\s*-\s*(\d{4})");
                    if (!match.Success)
                        throw new ArgumentException($"Định dạng tuần không hợp lệ: {thoiGian}");

                    int weekNum = int.Parse(match.Groups[1].Value);
                    int year = int.Parse(match.Groups[2].Value);
                    DateTime jan1 = new DateTime(year, 1, 1);
                    int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;
                    if (daysOffset > 0) daysOffset -= 7;
                    DateTime firstMonday = jan1.AddDays(daysOffset);
                    DateTime result = firstMonday.AddDays((weekNum - 1) * 7).Date;
                    Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Parsed week: Week {weekNum} - {year}, Result: {result:yyyy-MM-dd}");
                    return (result, "Week");
                }
                else // Năm
                {
                    int year = int.Parse(thoiGian.Trim());
                    DateTime result = new DateTime(year, 1, 1).Date;
                    Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Parsed year: {year}, Result: {result:yyyy-MM-dd}");
                    return (result, "Year");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Error parsing thoiGian: {ex.Message}");
                throw;
            }
        }

        private void frmBaoCaoChiTieuTheoHangMuc_Load(object sender, EventArgs e)
        {
            Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Load event started at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            try
            {
                if (crvCategory == null)
                {
                    MessageBox.Show("CrystalReportViewer (crvCategory) không được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("[frmBaoCaoChiTieuTheoHangMuc] crvCategory is null");
                    return;
                }
                Console.WriteLine("[frmBaoCaoChiTieuTheoHangMuc] crvCategory initialized");

                ReportDocument reportDocument = new ReportDocument();
                string reportPath = Path.Combine(Application.StartupPath, "Reports", "rptChiTieuTheoHangMuc.rpt");

                Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Report Path: {reportPath}");
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"Không tìm thấy file báo cáo: {reportPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("[frmBaoCaoChiTieuTheoHangMuc] Report file not found");
                    return;
                }
                Console.WriteLine("[frmBaoCaoChiTieuTheoHangMuc] Report file found");

                reportDocument.Load(reportPath);
                Console.WriteLine("[frmBaoCaoChiTieuTheoHangMuc] Report loaded");

                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    try
                    {
                        conn.Open();
                        Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Database connection successful at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi kết nối database: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Database connection error: {ex.Message}");
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand("sp_ChiTieuTheoHangMuc", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                        cmd.Parameters.AddWithValue("@ThoiGian", thoiGian.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@LoaiThoiGian", loaiThoiGian);
                        Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Parameters: MaTaiKhoan = {maTaiKhoan}, ThoiGian = {thoiGian:yyyy-MM-dd HH:mm:ss}, LoaiThoiGian = {loaiThoiGian}");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Result set count: {ds.Tables.Count}");

                            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                            {
                                MessageBox.Show("Không có dữ liệu, vui lòng tạo giao dịch mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Console.WriteLine("[frmBaoCaoChiTieuTheoHangMuc] No data from stored procedure");
                                Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Debug - MaTaiKhoan: {maTaiKhoan}, ThoiGian: {thoiGian:yyyy-MM-dd HH:mm:ss}, LoaiThoiGian: {loaiThoiGian}");
                                return;
                            }

                            // Debug: Hiển thị tên cột và dữ liệu
                            foreach (DataColumn col in ds.Tables[0].Columns)
                            {
                                Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Column: {col.ColumnName}");
                            }
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Row: {string.Join(", ", row.ItemArray)}");
                            }

                            ds.Tables[0].TableName = "ChiTieuTheoHangMuc";
                            reportDocument.SetDataSource(ds.Tables[0]);

                            reportDocument.SetParameterValue("@ThoiGian", thoiGian.ToString("MM/dd/yyyy"));
                            reportDocument.SetParameterValue("@LoaiThoiGian", loaiThoiGian);
                            Console.WriteLine("[frmBaoCaoChiTieuTheoHangMuc] Parameters set for Crystal Reports");
                        }
                    }
                }

                crvCategory.ReportSource = reportDocument;
                crvCategory.RefreshReport();
                Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Report refreshed at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chi tiết: {ex.ToString()}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"[frmBaoCaoChiTieuTheoHangMuc] Exception: {ex.ToString()}");
            }
        }
    }
}