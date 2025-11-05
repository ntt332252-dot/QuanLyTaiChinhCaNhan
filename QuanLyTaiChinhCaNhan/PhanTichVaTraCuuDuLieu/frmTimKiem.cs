using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyTaiChinhCaNhan
{
    public partial class frmTimKiem : Form
    {
        private int _maTaiKhoan;
        private string chuoiketnoi = "Server = LAPTOP-O8Q0L0EF\\SQLEXPRESS; Database = QuanLyChiTieu; Integrated Security = True";
        private string _initialKeyword;

        public frmTimKiem(int maTaiKhoan, string initialKeyword)
        {
            InitializeComponent();
            _maTaiKhoan = maTaiKhoan;
            _initialKeyword = initialKeyword ?? "";
            LoadLoaiGiaoDich();
            LoadHangMuc();
            SetInitialControl(_initialKeyword);
            LoadInitialData();
        }

        private void LoadLoaiGiaoDich()
        {
            try
            {
                cbLoaiGiaoDich.Items.Clear();
                cbLoaiGiaoDich.Items.Add(""); // Thêm tùy chọn trống
                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT LoaiGiaoDich FROM GiaoDich WHERE MaTaiKhoan = @MaTaiKhoan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbLoaiGiaoDich.Items.Add(reader["LoaiGiaoDich"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải loại giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHangMuc()
        {
            try
            {
                cbTenHangMuc.Items.Clear();
                cbTenHangMuc.Items.Add(""); // Thêm tùy chọn trống
                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    conn.Open();
                    string query = "SELECT TenHangMuc FROM HangMuc WHERE MaTaiKhoan = @MaTaiKhoan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbTenHangMuc.Items.Add(reader["TenHangMuc"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hạng mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInitialData()
        {
            dgvKetQua.Rows.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            gd.NgayGiaoDich,
                            gd.GhiChu,
                            gd.LoaiGiaoDich,
                            hm.TenHangMuc,
                            gd.SoTien
                        FROM 
                            GiaoDich gd
                        INNER JOIN 
                            HangMuc hm ON gd.MaHangMuc = hm.MaHangMuc
                        WHERE 
                            gd.MaTaiKhoan = @MaTaiKhoan
                            AND (
                                (gd.GhiChu LIKE '%' + @Keyword + '%' OR @Keyword = '')
                                OR (gd.LoaiGiaoDich LIKE '%' + @Keyword + '%' OR @Keyword = '')
                                OR (hm.TenHangMuc LIKE '%' + @Keyword + '%' OR @Keyword = '')
                                OR (CAST(gd.SoTien AS NVARCHAR) LIKE '%' + @Keyword + '%' OR @Keyword = '')
                                OR (CAST(gd.NgayGiaoDich AS NVARCHAR) LIKE '%' + @Keyword + '%' OR @Keyword = '')
                            )
                        ORDER BY 
                            gd.NgayGiaoDich DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
                        cmd.Parameters.AddWithValue("@Keyword", _initialKeyword);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvKetQua.Rows.Add(
                                    reader["NgayGiaoDich"].ToString(),
                                    reader["GhiChu"].ToString(),
                                    reader["LoaiGiaoDich"].ToString(),
                                    reader["TenHangMuc"].ToString(),
                                    Convert.ToDecimal(reader["SoTien"]).ToString("N0") + " VND"
                                );
                            }
                        }
                    }
                }
                if (dgvKetQua.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy giao dịch nào với từ khóa: " + _initialKeyword, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (string query, List<SqlParameter> parameters) BuildFilterQuery()
        {
            string query = @"
                SELECT 
                    gd.NgayGiaoDich,
                    gd.GhiChu,
                    gd.LoaiGiaoDich,
                    hm.TenHangMuc,
                    gd.SoTien
                FROM 
                    GiaoDich gd
                INNER JOIN 
                    HangMuc hm ON gd.MaHangMuc = hm.MaHangMuc
                WHERE 
                    gd.MaTaiKhoan = @MaTaiKhoan";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaTaiKhoan", _maTaiKhoan)
            };

            if (!string.IsNullOrEmpty(_initialKeyword))
            {
                query += @" AND (
                    (gd.GhiChu LIKE '%' + @InitialKeyword + '%' OR @InitialKeyword = '')
                    OR (gd.LoaiGiaoDich LIKE '%' + @InitialKeyword + '%' OR @InitialKeyword = '')
                    OR (hm.TenHangMuc LIKE '%' + @InitialKeyword + '%' OR @InitialKeyword = '')
                    OR (CAST(gd.SoTien AS NVARCHAR) LIKE '%' + @InitialKeyword + '%' OR @InitialKeyword = '')
                    OR (CAST(gd.NgayGiaoDich AS NVARCHAR) LIKE '%' + @InitialKeyword + '%' OR @InitialKeyword = '')
                )";
                parameters.Add(new SqlParameter("@InitialKeyword", _initialKeyword));
            }

            if (!string.IsNullOrEmpty(txtKeyword.Text))
            {
                query += " AND gd.GhiChu LIKE '%' + @Keyword + '%'";
                parameters.Add(new SqlParameter("@Keyword", txtKeyword.Text.Trim()));
            }

            // Kiểm tra và thêm điều kiện ngày tháng
            if (dtpTuNgay.Value != dtpTuNgay.MinDate)
            {
                query += " AND gd.NgayGiaoDich >= @TuNgay";
                parameters.Add(new SqlParameter("@TuNgay", dtpTuNgay.Value.Date));
            }
            if (dtpDenNgay.Value != dtpDenNgay.MinDate)
            {
                query += " AND gd.NgayGiaoDich < @DenNgay";
                parameters.Add(new SqlParameter("@DenNgay", dtpDenNgay.Value.Date.AddDays(1))); // Thêm 1 ngày để bao gồm cả ngày cuối
            }

            if (!string.IsNullOrEmpty(cbLoaiGiaoDich.Text))
            {
                query += " AND gd.LoaiGiaoDich = @LoaiGiaoDich";
                parameters.Add(new SqlParameter("@LoaiGiaoDich", cbLoaiGiaoDich.Text.Trim()));
            }
            if (!string.IsNullOrEmpty(cbTenHangMuc.Text))
            {
                query += " AND hm.TenHangMuc = @TenHangMuc";
                parameters.Add(new SqlParameter("@TenHangMuc", cbTenHangMuc.Text.Trim()));
            }
            if (nudTuSoTien.Value > 0)
            {
                query += " AND gd.SoTien >= @TuSoTien";
                parameters.Add(new SqlParameter("@TuSoTien", nudTuSoTien.Value));
            }
            if (nudDenSoTien.Value < 1000000000)
            {
                query += " AND gd.SoTien <= @DenSoTien";
                parameters.Add(new SqlParameter("@DenSoTien", nudDenSoTien.Value));
            }

            query += " ORDER BY gd.NgayGiaoDich DESC";
            return (query, parameters);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Kiểm tra hợp lệ ngày tháng
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FilterData();
        }

        private void FilterData()
        {
            dgvKetQua.Rows.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    conn.Open();
                    var (query, parameters) = BuildFilterQuery();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvKetQua.Rows.Add(
                                    reader["NgayGiaoDich"].ToString(),
                                    reader["GhiChu"].ToString(),
                                    reader["LoaiGiaoDich"].ToString(),
                                    reader["TenHangMuc"].ToString(),
                                    Convert.ToDecimal(reader["SoTien"]).ToString("N0") + " VND"
                                );
                            }
                        }
                    }
                }
                if (dgvKetQua.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy giao dịch nào theo bộ lọc hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Khôi phục dữ liệu ban đầu
            LoadInitialData();
            SetInitialControl(_initialKeyword);

        }
        private void SetInitialControl(string keyword)
        {
            // Đặt lại các control về giá trị mặc định
            txtKeyword.Text = "";
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // Ngày đầu tháng
            dtpDenNgay.Value = DateTime.Today; // Ngày hiện tại
            cbLoaiGiaoDich.SelectedIndex = -1; // Đặt về không chọn
            cbTenHangMuc.SelectedIndex = -1; // Đặt về không chọn
            nudTuSoTien.Value = 0;
            nudDenSoTien.Value = 1000000000; // Giả sử 1000000000 là giá trị mặc định tối đa
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}