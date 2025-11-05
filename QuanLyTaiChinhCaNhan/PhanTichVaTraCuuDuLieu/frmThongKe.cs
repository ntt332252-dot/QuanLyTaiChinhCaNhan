using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyTaiChinhCaNhan
{
    public partial class frmThongKe : Form
    {
        // Chuỗi kết nối SQL Server
        private string connectionString = "Server = LAPTOP-O8Q0L0EF\\SQLEXPRESS; Database = QuanLyChiTieu; Integrated Security = True";
        private int _maTaiKhoan; // Biến lưu mã tài khoản

        public frmThongKe(int maTaiKhoan)
        {
            InitializeComponent();
            _maTaiKhoan = maTaiKhoan; // Gán mã tài khoản từ tham số
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            // Khởi tạo ComboBox
            KhoiTaoComboBox();
            // Load dữ liệu mặc định khi form mở
            ThongKe(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void KhoiTaoComboBox()
        {
            // Khởi tạo ComboBox tháng
            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i.ToString("D2")); // Format 2 chữ số: 01, 02,...
            }
            cboThang.SelectedItem = DateTime.Now.Month.ToString("D2");

            // Khởi tạo ComboBox năm
            cboNam.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 5; i <= currentYear + 5; i++)
            {
                cboNam.Items.Add(i.ToString());
            }
            cboNam.SelectedItem = currentYear.ToString();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy tháng và năm từ ComboBox
            if (int.TryParse(cboThang.SelectedItem?.ToString(), out int thang) &&
                int.TryParse(cboNam.SelectedItem?.ToString(), out int nam))
            {
                ThongKe(thang, nam);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tháng và năm hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ThongKe(int thang, int nam)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Tính tổng thu, tổng chi, số dư
                    string queryTong = @"SELECT 
                        SUM(CASE WHEN g.LoaiGiaoDich = 'Thu' THEN g.SoTien ELSE 0 END) as TongThu,
                        SUM(CASE WHEN g.LoaiGiaoDich = 'Chi' THEN g.SoTien ELSE 0 END) as TongChi
                        FROM GiaoDich g
                        WHERE MONTH(g.NgayGiaoDich) = @Thang AND YEAR(g.NgayGiaoDich) = @Nam AND g.MaTaiKhoan = @MaTaiKhoan";

                    using (SqlCommand cmd = new SqlCommand(queryTong, conn))
                    {
                        cmd.Parameters.AddWithValue("@Thang", thang);
                        cmd.Parameters.AddWithValue("@Nam", nam);
                        cmd.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal tongThu = reader["TongThu"] != DBNull.Value ? Convert.ToDecimal(reader["TongThu"]) : 0;
                                decimal tongChi = reader["TongChi"] != DBNull.Value ? Convert.ToDecimal(reader["TongChi"]) : 0;

                                lblTongThu.Text = $"Tổng thu: {tongThu:N0} VNĐ";
                                lblTongChi.Text = $"Tổng chi: {tongChi:N0} VNĐ";
                                lblSoDu.Text = $"Số dư: {(tongThu - tongChi):N0} VNĐ";
                            }
                        }
                    }

                    // 2. Load danh sách giao dịch vào DataGridView
                    string queryGiaoDich = @"SELECT g.NgayGiaoDich, g.LoaiGiaoDich, h.TenHangMuc, g.GhiChu, g.SoTien
                                          FROM GiaoDich g
                                          INNER JOIN HangMuc h ON g.MaHangMuc = h.MaHangMuc
                                          WHERE MONTH(g.NgayGiaoDich) = @Thang AND YEAR(g.NgayGiaoDich) = @Nam AND g.MaTaiKhoan = @MaTaiKhoan
                                          ORDER BY g.NgayGiaoDich DESC";

                    using (SqlCommand cmd = new SqlCommand(queryGiaoDich, conn))
                    {
                        cmd.Parameters.AddWithValue("@Thang", thang);
                        cmd.Parameters.AddWithValue("@Nam", nam);
                        cmd.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvGiaoDich.DataSource = dt;

                            // Định dạng DataGridView
                            dgvGiaoDich.Columns["NgayGiaoDich"].HeaderText = "Ngày";
                            dgvGiaoDich.Columns["LoaiGiaoDich"].HeaderText = "Loại";
                            dgvGiaoDich.Columns["TenHangMuc"].HeaderText = "Hạng mục";
                            dgvGiaoDich.Columns["SoTien"].HeaderText = "Số tiền";
                            dgvGiaoDich.Columns["GhiChu"].HeaderText = "Mô tả";
                            dgvGiaoDich.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                        }
                    }

                    // 3. Vẽ biểu đồ vùng số dư tích lũy theo ngày
                    string querySoDu = @"SELECT DAY(g.NgayGiaoDich) as Ngay,
                                            SUM(CASE WHEN g.LoaiGiaoDich = 'Thu' THEN g.SoTien ELSE 0 END) -
                                            SUM(CASE WHEN g.LoaiGiaoDich = 'Chi' THEN g.SoTien ELSE 0 END) as SoDuNgay
                                        FROM GiaoDich g
                                        WHERE MONTH(g.NgayGiaoDich) = @Thang AND YEAR(g.NgayGiaoDich) = @Nam AND g.MaTaiKhoan = @MaTaiKhoan
                                        GROUP BY DAY(g.NgayGiaoDich)
                                        ORDER BY DAY(g.NgayGiaoDich)";

                    chartChiTieu.Series.Clear();
                    chartChiTieu.Series.Add("SoDu");
                    chartChiTieu.Series["SoDu"].ChartType = SeriesChartType.Area;
                    chartChiTieu.Series["SoDu"].Color = Color.FromArgb(120, 255, 182, 193);
                    chartChiTieu.Series["SoDu"].BorderColor = Color.HotPink;
                    chartChiTieu.Series["SoDu"].BorderWidth = 2;
                    chartChiTieu.Legends.Clear();
                    chartChiTieu.Legends.Add(new Legend("LegendSoDu"));
                    chartChiTieu.Legends["LegendSoDu"].Font = new Font("Arial", 10);
                    chartChiTieu.Series["SoDu"].Legend = "LegendSoDu";
                    chartChiTieu.Series["SoDu"].LegendText = "Số dư tích lũy";

                    // Tính số dư tích lũy
                    decimal soDuTichLuy = 0;
                    int daysInMonth = DateTime.DaysInMonth(nam, thang);
                    decimal[] soDuTheoNgay = new decimal[daysInMonth + 1]; // Mảng lưu số dư mỗi ngày

                    using (SqlCommand cmd = new SqlCommand(querySoDu, conn))
                    {
                        cmd.Parameters.AddWithValue("@Thang", thang);
                        cmd.Parameters.AddWithValue("@Nam", nam);
                        cmd.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int ngay = Convert.ToInt32(reader["Ngay"]);
                                decimal soDuNgay = Convert.ToDecimal(reader["SoDuNgay"]);
                                soDuTichLuy += soDuNgay;
                                soDuTheoNgay[ngay] = soDuTichLuy;
                            }
                        }
                    }

                    // Điền số dư cho tất cả các ngày trong tháng
                    for (int i = 1; i <= daysInMonth; i++)
                    {
                        if (i > 1 && soDuTheoNgay[i] == 0)
                        {
                            soDuTheoNgay[i] = soDuTheoNgay[i - 1]; // Giữ số dư của ngày trước nếu không có giao dịch
                        }
                        chartChiTieu.Series["SoDu"].Points.AddXY(i, soDuTheoNgay[i]);
                        chartChiTieu.Series["SoDu"].Points[i - 1].ToolTip = $"Ngày {i}: {soDuTheoNgay[i]:N0} VNĐ";
                    }

                    // Tùy chỉnh biểu đồ vùng
                    chartChiTieu.Titles.Clear();
                    chartChiTieu.Titles.Add($"Số dư tích lũy tháng {thang}/{nam}");
                    chartChiTieu.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);
                    chartChiTieu.ChartAreas[0].AxisX.Title = "Ngày";
                    chartChiTieu.ChartAreas[0].AxisY.Title = "Số dư (VNĐ)";
                    chartChiTieu.ChartAreas[0].AxisX.Interval = 1;
                    chartChiTieu.ChartAreas[0].AxisX.Minimum = 1;
                    chartChiTieu.ChartAreas[0].AxisX.Maximum = daysInMonth;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}