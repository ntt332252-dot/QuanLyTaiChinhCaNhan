using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace QuanLyTaiChinh    
{

    public partial class frmQuanLyHangMuc : Form
    {
        private int _maTaiKhoan;
        private string loaiDangChon = "Thu"; // Loại danh mục mặc định
        private readonly DatabaseHelper _dbHelper;

        public frmQuanLyHangMuc(int maTaiKhoan)
        {
            InitializeComponent();
            _maTaiKhoan = maTaiKhoan;
            _dbHelper = new DatabaseHelper();
            listBoxHangMuc.DrawItem += listBoxHangMuc_DrawItem;
            LoadHangMuc();
        }

        private void LoadHangMuc()
        {
            try
            {
                listBoxHangMuc.Items.Clear();
                var HangMucs = HangMucService.LayHangMucTheoLoai(_maTaiKhoan, loaiDangChon);
                foreach (var hm in HangMucs)
                {
                    listBoxHangMuc.Items.Add(hm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuanLyThu_Click(object sender, EventArgs e)
        {
            loaiDangChon = "Thu";
            LoadHangMuc();
        }

        private void btnQuanLyChi_Click(object sender, EventArgs e)
        {
            loaiDangChon = "Chi";
            LoadHangMuc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (frmThemHangMuc frm = new frmThemHangMuc(loaiDangChon))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var hm = new HangMuc
                    {
                        MaTaiKhoan = _maTaiKhoan,
                        TenHangMuc = frm.TenHangMucMoi,
                        LoaiHangMuc = loaiDangChon,
                        BieuTuong = frm.TenBieuTuong
                    };
                    try
                    {
                        HangMucService.ThemHangMuc(hm);
                        LoadHangMuc();
                        MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listBoxHangMuc.SelectedItem is HangMuc hm)
            {
                using (frmThemHangMuc frm = new frmThemHangMuc(loaiDangChon, hm.TenHangMuc, hm.BieuTuong))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        hm.TenHangMuc = frm.TenHangMucMoi;
                        hm.BieuTuong = frm.TenBieuTuong;
                        try
                        {
                            HangMucService.CapNhatHangMuc(hm);
                            LoadHangMuc();
                            MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi cập nhật danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listBoxHangMuc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var hm = listBoxHangMuc.SelectedItem as HangMuc;
                try
                {
                    HangMucService.XoaHangMuc(hm.MaHangMuc, _maTaiKhoan);
                    LoadHangMuc();
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBoxHangMuc_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            HangMuc hm = listBoxHangMuc.Items[e.Index] as HangMuc;
            if (hm == null) return;

            string iconPath = Path.Combine("Icons", hm.BieuTuong);
            if (File.Exists(iconPath))
            {
                using (Image img = Image.FromFile(iconPath))
                {
                    int iconY = e.Bounds.Top + (e.Bounds.Height - 30) / 2;
                    e.Graphics.DrawImage(img, e.Bounds.Left + 5, iconY, 30, 30);
                }
            }
            else
            {
                Console.WriteLine($"Không tìm thấy biểu tượng: {iconPath}");
            }

            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                float textY = e.Bounds.Top + (e.Bounds.Height - e.Font.Height) / 2;
                e.Graphics.DrawString(hm.TenHangMuc, e.Font, brush, e.Bounds.Left + 40, textY);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}