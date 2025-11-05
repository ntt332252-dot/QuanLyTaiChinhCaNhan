using QuanLyTaiChinhCaNhan;
using System;
using System.Windows.Forms;

namespace QuanLyGiaoDich
{
    public partial class frmThemGiaoDich : Form
    {
        public string HangMuc { get; private set; }
        public decimal SoTien { get; private set; }
        public string GhiChu { get; private set; }
        public DateTime NgayGD { get; private set; }
        private readonly int _maTaiKhoan;
        private readonly GiaoDichDataHelper dbHelper;

        public frmThemGiaoDich(int maTaiKhoan)
        {
            InitializeComponent();
            _maTaiKhoan = maTaiKhoan;
            dbHelper = new GiaoDichDataHelper(maTaiKhoan);
        }

        public frmThemGiaoDich(int maTaiKhoan, string loai, string HangMuc = "", decimal soTien = 0, string ghiChu = "", DateTime? ngayGD = null)
            : this(maTaiKhoan)
        {
            cbLoaiGiaoDich.SelectedItem = loai == "Chi" ? "Giao dịch chi" : "Giao dịch thu";
            cbHangMuc.Text = HangMuc;
            txtSoTien.Text = soTien > 0 ? soTien.ToString("N0") : "";
            txtGhiChu.Text = ghiChu;
            dtNgay.Value = ngayGD ?? DateTime.Now;
        }

        private void frmThemGiaoDich_Load(object sender, EventArgs e)
        {
            cbLoaiGiaoDich.Items.AddRange(new[] { "Giao dịch thu", "Giao dịch chi" });
            cbLoaiGiaoDich.SelectedIndex = 0;
            cbLoaiGiaoDich.SelectedIndexChanged += cbLoaiGiaoDich_SelectedIndexChanged;
            LoadHangMuc();
        }

        private void cbLoaiGiaoDich_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHangMuc();
        }

        private void LoadHangMuc()
        {
            try
            {
                string loaiHangMuc = cbLoaiGiaoDich.SelectedItem.ToString() == "Giao dịch thu" ? "Thu" : "Chi";
                var hangMucList = dbHelper.GetHangMuc(_maTaiKhoan, loaiHangMuc);
                cbHangMuc.Items.Clear();
                cbHangMuc.Items.AddRange(hangMucList.ToArray());
                if (cbHangMuc.Items.Count > 0)
                {
                    cbHangMuc.SelectedIndex = 0;
                    btnLuu.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không có hạng mục phù hợp. Vui lòng tạo hạng mục trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnLuu.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi tải hạng mục: {ex.Message}");
                MessageBox.Show($"Lỗi khi tải hạng mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLuu.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cbHangMuc.Text))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtSoTien.Text, out decimal soTien) || soTien <= 0)
                {
                    MessageBox.Show("Số tiền không hợp lệ. Vui lòng nhập số tiền lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string loaiHangMuc = cbLoaiGiaoDich.SelectedItem.ToString() == "Giao dịch thu" ? "Thu" : "Chi";
                if (!dbHelper.KiemTraHangMucTonTai(_maTaiKhoan, cbHangMuc.Text.Trim(), loaiHangMuc))
                {
                    DialogResult result = MessageBox.Show($"Hạng mục '{cbHangMuc.Text.Trim()}' chưa tồn tại. Bạn có muốn tạo mới không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dbHelper.EnsureHangMucExists(_maTaiKhoan, cbHangMuc.Text.Trim(), loaiHangMuc);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn hạng mục hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                HangMuc = cbHangMuc.Text.Trim();
                SoTien = soTien;
                GhiChu = txtGhiChu.Text.Trim();
                NgayGD = dtNgay.Value;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi lưu giao dịch: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi khi lưu giao dịch: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}