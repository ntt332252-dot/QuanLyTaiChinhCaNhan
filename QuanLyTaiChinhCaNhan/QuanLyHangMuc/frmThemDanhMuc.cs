using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyTaiChinh
{
    public partial class frmThemHangMuc : Form
    {
        private string loai;
        public string TenHangMucMoi { get; private set; }
        public string TenBieuTuong { get; private set; }

        public frmThemHangMuc(string loai)
        {
            InitializeComponent();
            this.loai = loai;
            SetupIconsFlowLayout();
        }

        // Constructor cho chế độ sửa
        public frmThemHangMuc(string loai, string tenCu, string iconCu) : this(loai)
        {
            txtTen.Text = tenCu;
            TenBieuTuong = iconCu; // Gán biểu tượng cũ cho thuộc tính TenBieuTuong
            this.Text = "Sửa hạng mục";

            // Chọn và hiển thị biểu tượng cũ khi ở chế độ sửa
            foreach (PictureBox pb in flowLayoutPanelIcons.Controls)
            {
                // SỬA LỖI: So sánh Tag (tên file icon) với iconCu (tên file icon)
                // Chứ không phải so sánh với tenCu (tên hạng mục)
                if (pb.Tag != null && pb.Tag.ToString() == iconCu)
                {
                    pb.BorderStyle = BorderStyle.FixedSingle;
                    string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", iconCu);
                    if (File.Exists(iconPath))
                    {
                        pictureBoxPreview.Image = Image.FromFile(iconPath);
                    }
                    break;
                }
            }
        }

        private void SetupIconsFlowLayout()
        {
            // Đảm bảo các file ảnh này tồn tại trong thư mục Resources\Icons của dự án
            string[] iconFiles = {
                "anuong.png", "giaothong.png", "luong.png", "muasam.png",
                "phucap.png", "thuong.png", "giaitri.png", "hoadon.png",
                "suckhoe.png"
                , "quatang.png", "dienthoai.png", "sachvo.png","tietkiem.png","nha.png"
            };

            flowLayoutPanelIcons.Controls.Clear();

            foreach (string icon in iconFiles)
            {
                PictureBox pb = new PictureBox();
                // Đường dẫn đầy đủ của biểu tượng
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", icon);
                Console.WriteLine($"Đường dẫn biểu tượng: {iconPath}"); // Debug

                if (File.Exists(iconPath))
                {
                    pb.Image = Image.FromFile(iconPath);
                }
                else
                {
                    // Không dùng MessageBox.Show trong vòng lặp có thể gây phiền nhiễu
                    // Thay vào đó, có thể ghi log hoặc hiển thị placeholder icon
                    Console.WriteLine($"Không tìm thấy file biểu tượng: {iconPath}");
                    // pb.Image = Properties.Resources.DefaultIcon; // Nếu bạn có một icon mặc định
                }
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Width = pb.Height = 40;
                pb.Margin = new Padding(5);
                pb.Tag = icon; // Lưu tên file icon vào Tag
                pb.Cursor = Cursors.Hand;
                pb.Click += Pb_Click;

                flowLayoutPanelIcons.Controls.Add(pb);
            }
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                TenBieuTuong = pb.Tag.ToString(); // Lấy tên file icon đã chọn

                // Bỏ viền cho tất cả các PictureBox khác
                foreach (PictureBox item in flowLayoutPanelIcons.Controls)
                {
                    item.BorderStyle = BorderStyle.None;
                }
                // Đặt viền cho PictureBox được chọn
                pb.BorderStyle = BorderStyle.FixedSingle;

                // Hiển thị biểu tượng đã chọn trong pictureBoxPreview
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", TenBieuTuong);
                Console.WriteLine($"Đường dẫn biểu tượng chọn: {iconPath}");
                if (File.Exists(iconPath))
                {
                    pictureBoxPreview.Image = Image.FromFile(iconPath);
                }
                else
                {
                    pictureBoxPreview.Image = null; // Hoặc một icon mặc định
                    MessageBox.Show($"Không tìm thấy biểu tượng: {TenBieuTuong}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hạng mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(TenBieuTuong))
            {
                MessageBox.Show("Vui lòng chọn biểu tượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TenHangMucMoi = txtTen.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
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
