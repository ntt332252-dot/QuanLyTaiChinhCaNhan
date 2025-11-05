using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace QuanLyTaiChinhCaNhan
{
    public partial class frmBaoCaoTongThuChi : Form
    {
        // Chuỗi kết nối database
        private string chuoiketnoi = "Server = LAPTOP-O8Q0L0EF\\SQLEXPRESS; Database = QuanLyChiTieu; Integrated Security = True";

        // Tham số truyền vào stored procedure
        private int maTaiKhoan;
        private DateTime tuNgay;
        private DateTime denNgay;

        public frmBaoCaoTongThuChi(int maTaiKhoan, DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            this.maTaiKhoan = maTaiKhoan;
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
            Console.WriteLine("Constructor called at " + DateTime.Now);
        }

        private void frmBaoCaoTongThuChi_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Load event started at " + DateTime.Now);
            MessageBox.Show("Load event triggered.", "Debug");

            try
            {
                if (crvTongThuChi == null)
                {
                    MessageBox.Show("CrystalReportViewer (crvTongThuChi) không được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("crvTongThuChi is null");
                    return;
                }
                Console.WriteLine("crvTongThuChi initialized");

                ReportDocument reportDocument = new ReportDocument();
                string reportPath = Path.Combine(Application.StartupPath, "Reports", "rptTongThuChi.rpt");

                Console.WriteLine("Report Path: " + reportPath);
                MessageBox.Show("Report Path: " + reportPath);

                if (!File.Exists(reportPath))
                {
                    MessageBox.Show("Không tìm thấy file báo cáo: " + reportPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Report file not found");
                    return;
                }
                Console.WriteLine("Report file found");

                reportDocument.Load(reportPath);
                Console.WriteLine("Report loaded");

                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    try
                    {
                        conn.Open();
                        Console.WriteLine("Database connection successful at " + DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("Database connection error: " + ex.Message);
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand("sp_TongThuChi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                        cmd.Parameters.AddWithValue("@ThoiGianBatDau", tuNgay);
                        cmd.Parameters.AddWithValue("@ThoiGianKetThuc", denNgay);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            Console.WriteLine("Data rows count: " + dt.Rows.Count);

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("Không có dữ liệu từ stored procedure.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Console.WriteLine("No data from stored procedure");
                                return;
                            }

                            // Debug: Hiển thị tên cột
                            foreach (DataColumn col in dt.Columns)
                            {
                                Console.WriteLine("Column: " + col.ColumnName);
                            }

                            dt.TableName = "TongThuChi";
                            reportDocument.SetDataSource(dt);

                            // Gán tham số cho báo cáo
                            reportDocument.SetParameterValue("MaTaiKhoan", maTaiKhoan);
                            reportDocument.SetParameterValue("ThoiGianBatDau", tuNgay.ToString("yyyy-MM-dd"));
                            reportDocument.SetParameterValue("ThoiGianKetThuc", denNgay.ToString("yyyy-MM-dd"));
                            Console.WriteLine("Parameters set");
                        }
                    }
                }

                crvTongThuChi.ReportSource = reportDocument;
                crvTongThuChi.RefreshReport();
                Console.WriteLine("Report refreshed at " + DateTime.Now);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chi tiết: " + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
}