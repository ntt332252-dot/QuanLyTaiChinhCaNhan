using System.ComponentModel;

namespace QuanLyTaiChinh
{
    // Lớp đại diện cho bảng HangMuc trong SQL
    public class HangMuc
    {
        // Thuộc tính ánh xạ với cột MaHangMuc (INT IDENTITY PRIMARY KEY)
        public int MaHangMuc { get; set; }

        // Thuộc tính ánh xạ với cột MaTaiKhoan (INT NOT NULL, FK tới TaiKhoan)
        public int MaTaiKhoan { get; set; }

        // Thuộc tính ánh xạ với cột TenHangMuc (NVARCHAR(100) NOT NULL)
        [DisplayName("Tên hạng mục")]
        public string TenHangMuc { get; set; }

        // Thuộc tính ánh xạ với cột LoaiHangMuc (NVARCHAR(10) NOT NULL, CHECK ('Thu', 'Chi'))
        [DisplayName("Loại hạng mục")]
        public string LoaiHangMuc { get; set; }

        // Thuộc tính ánh xạ với cột BieuTuong (NVARCHAR(100) NOT NULL DEFAULT 'default.png')
        [DisplayName("Biểu tượng")]
        public string BieuTuong { get; set; }

        // Override ToString để hiển thị TenHangMuc trong ListBox
        public override string ToString()
        {
            return TenHangMuc;
        }
    }
}