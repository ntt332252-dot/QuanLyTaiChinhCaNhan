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
    public partial class frmBaoCaoTongThuChi : Form
    {
        private string chuoiketnoi = "Server = LAPTOP-O8Q0L0EF\\SQLEXPRESS; Database = QuanLyChiTieu; Integrated Security = True";
        private int maTaiKhoan;
        private DateTime thoiGian;
        private string loaiThoiGian;

        public frmBaoCaoTongThuChi(int maTaiKhoan, string thoiGian)
        {
            InitializeComponent();
            this.maTaiKhoan = maTaiKhoan;
            (this.thoiGian, this.loaiThoiGian) = ParseThoiGianToDateTime(thoiGian);
            Console.WriteLine($"[frmBaoCaoTongThuChi] Constructor called at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"[frmBaoCaoTongThuChi] Input thoiGian string: {thoiGian}, LoaiThoiGian: {loaiThoiGian}");
            Console.WriteLine($"[frmBaoCaoTongThuChi] Parsed thoiGian: {this.thoiGian:yyyy-MM-dd HH:mm:ss}");
        }

        private (DateTime, string) ParseThoiGianToDateTime(string thoiGian)
        {
            Console.WriteLine($"[frmBaoCaoTongThuChi] Parsing input thoiGian: {thoiGian}");
            try
            {
                if (string.IsNullOrWhiteSpace(thoiGian))
                    throw new ArgumentException("Chuỗi thời gian rỗng hoặc không hợp lệ.");

                if (thoiGian.Contains("/")) // Ngày hoặc Tháng
                {
                    if (thoiGian.Split('/').Length == 2 && !thoiGian.Contains("Tuần")) // Tháng
                    {
                        string[] parts = thoiGian.Split('/');
                        int month = int.Parse(parts[0].Trim());
                        int year = int.Parse(parts[1].Trim());
                        DateTime result = new DateTime(year, month, 1).Date;
                        Console.WriteLine($"[frmBaoCaoTongThuChi] Parsed month/year: {month}/{year}, Result: {result:yyyy-MM-dd}");
                        return (result, "Month");
                    }
                    else // Ngày
                    {
                        DateTime result = DateTime.ParseExact(thoiGian.Trim(), "MM/dd/yyyy", null).Date;
                        Console.WriteLine($"[frmBaoCaoTongThuChi] Parsed date: {result:yyyy-MM-dd}");
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
                    Console.WriteLine($"[frmBaoCaoTongThuChi] Parsed week: Week {weekNum} - {year}, Result: {result:yyyy-MM-dd}");
                    return (result, "Week");
                }
                else // Năm
                {
                    int year = int.Parse(thoiGian.Trim());
                    DateTime result = new DateTime(year, 1, 1).Date;
                    Console.WriteLine($"[frmBaoCaoTongThuChi] Parsed year: {year}, Result: {result:yyyy-MM-dd}");
                    return (result, "Year");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[frmBaoCaoTongThuChi] Error parsing thoiGian: {ex.Message}");
                throw;
            }
        }

        private void frmBaoCaoTongThuChi_Load(object sender, EventArgs e)
        {
            Console.WriteLine($"[frmBaoCaoTongThuChi] Load event started at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            try
            {
                if (crvIE == null)
                {
                    MessageBox.Show("CrystalReportViewer (crvIE) không được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("[frmBaoCaoTongThuChi] crvIE is null");
                    return;
                }
                Console.WriteLine("[frmBaoCaoTongThuChi] crvIE initialized");

                ReportDocument reportDocument = new ReportDocument();
                string reportPath = Path.Combine(Application.StartupPath, "Reports", "rptTongThuChi.rpt");

                Console.WriteLine($"[frmBaoCaoTongThuChi] Report Path: {reportPath}");
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"Không tìm thấy file báo cáo: {reportPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("[frmBaoCaoTongThuChi] Report file not found");
                    return;
                }
                Console.WriteLine("[frmBaoCaoTongThuChi] Report file found");

                reportDocument.Load(reportPath);
                Console.WriteLine("[frmBaoCaoTongThuChi] Report loaded");

                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    try
                    {
                        conn.Open();
                        Console.WriteLine($"[frmBaoCaoTongThuChi] Database connection successful at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi kết nối database: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine($"[frmBaoCaoTongThuChi] Database connection error: {ex.Message}");
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand("sp_TongThuChi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                        cmd.Parameters.AddWithValue("@ThoiGian", thoiGian.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@LoaiThoiGian", loaiThoiGian);
                        Console.WriteLine($"[frmBaoCaoTongThuChi] Parameters: MaTaiKhoan = {maTaiKhoan}, ThoiGian = {thoiGian:yyyy-MM-dd HH:mm:ss}, LoaiThoiGian = {loaiThoiGian}");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            Console.WriteLine($"[frmBaoCaoTongThuChi] Result set count: {ds.Tables.Count}");

                            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)

                            {
                                MessageBox.Show("Không có dữ liệu, vui lòng tạo giao dịch mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Console.WriteLine("[frmBaoCaoTongThuChi] No transaction data or MaGiaoDich is NULL");
                                Console.WriteLine($"[frmBaoCaoTongThuChi] Debug - MaTaiKhoan: {maTaiKhoan}, ThoiGian: {thoiGian:yyyy-MM-dd HH:mm:ss}, LoaiThoiGian: {loaiThoiGian}");
                                return;
                            }

                            // Debug: Hiển thị tên cột và dữ liệu
                            foreach (DataColumn col in ds.Tables[0].Columns)
                            {
                                Console.WriteLine($"[frmBaoCaoTongThuChi] Column: {col.ColumnName}");
                            }
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                Console.WriteLine($"[frmBaoCaoTongThuChi] Row: {string.Join(", ", row.ItemArray)}");
                            }

                            // Set toàn bộ dữ liệu chi tiết và tổng hợp
                            ds.Tables[0].TableName = "TongThuChi";
                            reportDocument.SetDataSource(ds.Tables[0]);

                            reportDocument.SetParameterValue("@ThoiGian", thoiGian.ToString("MM/dd/yyyy"));
                            reportDocument.SetParameterValue("@LoaiThoiGian", loaiThoiGian);
                            Console.WriteLine("[frmBaoCaoTongThuChi] Parameters set for Crystal Reports");
                        }
                    }
                }

                crvIE.ReportSource = reportDocument;
                crvIE.RefreshReport();
                Console.WriteLine($"[frmBaoCaoTongThuChi] Report refreshed at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chi tiết: {ex.ToString()}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"[frmBaoCaoTongThuChi] Exception: {ex.ToString()}");
            }
        }
    }
}