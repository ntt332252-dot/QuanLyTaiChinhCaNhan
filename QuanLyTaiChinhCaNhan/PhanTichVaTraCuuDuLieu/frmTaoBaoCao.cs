using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace QuanLyTaiChinhCaNhan
{
    public partial class frmTaoBaoCao : Form
    {
        private int _maTaiKhoan;
        private string chuoiketnoi = "Server = LAPTOP-O8Q0L0EF\\SQLEXPRESS; Database = QuanLyChiTieu; Integrated Security = True";

        public frmTaoBaoCao(int maTaiKhoan)
        {
            InitializeComponent();
            _maTaiKhoan = maTaiKhoan;

            // Khởi tạo ComboBox với các loại báo cáo
            cmbBaoCao.Items.Add("Báo cáo thu chi");
            cmbBaoCao.Items.Add("Báo cáo chi tiêu theo hạng mục");
            cmbBaoCao.SelectedIndex = 0; // Đặt mặc định là mục đầu tiên

            // Đặt mặc định là Ngày
            rdoImgDay.Checked = true;

        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ giao diện
                string loaiBaoCao = cmbBaoCao.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(loaiBaoCao))
                {
                    MessageBox.Show("Vui lòng chọn loại báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                (string thoiGian, string loaiThoiGian) = GetThoiGianAndType();
                if (string.IsNullOrEmpty(thoiGian) || string.IsNullOrEmpty(loaiThoiGian))
                {
                    MessageBox.Show("Vui lòng chọn loại thời gian báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Debug: In ra giá trị tham số
                Console.WriteLine($"maTaiKhoan: {_maTaiKhoan}, thoiGian: {thoiGian}, loaiThoiGian: {loaiThoiGian}");

                // Mở form báo cáo tương ứng dựa trên loại báo cáo được chọn
                switch (loaiBaoCao)
                {
                    case "Báo cáo thu chi":
                        frmBaoCaoTongThuChi frmThuChi = new frmBaoCaoTongThuChi(_maTaiKhoan, thoiGian);
                        frmThuChi.ShowDialog();
                        break;
                    case "Báo cáo chi tiêu theo hạng mục":
                        frmBaoCaoChiTieuTheoHangMuc frmChiTieu = new frmBaoCaoChiTieuTheoHangMuc(_maTaiKhoan, thoiGian);
                        frmChiTieu.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Exception in btnTaoBaoCao_Click: {ex.ToString()}");
            }
        }

        private (string thoiGian, string loaiThoiGian) GetThoiGianAndType()
        {
            DateTime now = DateTime.Now; // 05:37 AM +07, Friday, July 04, 2025
            try
            {
                if (rdoImgDay.Checked)
                    return (now.ToString("MM/dd/yyyy"), "Day"); // Ví dụ: ("07/04/2025", "Day")
                else if (rdoImgWeek.Checked)
                    return ($"Tuần {System.Globalization.CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(now, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)} - {now.Year}", "Week"); // Ví dụ: ("Tuần 27 - 2025", "Week")
                else if (rdoImgMonth.Checked)
                    return ($"{now.Month}/{now.Year}", "Month"); // Ví dụ: ("7/2025", "Month")
                else if (rdoImgYear.Checked)
                    return (now.Year.ToString(), "Year"); // Ví dụ: ("2025", "Year")
                return (null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetThoiGianAndType: {ex.Message}");
                return (null, null);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}