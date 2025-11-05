namespace QuanLyGiaoDich
{
    partial class frmThemGiaoDich
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemGiaoDich));
            this.label1 = new System.Windows.Forms.Label();
            this.cbHangMuc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoaiGiaoDich = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.siticoneShadowPanel1 = new Siticone.UI.WinForms.SiticoneShadowPanel();
            this.siticonePictureBox1 = new Siticone.UI.WinForms.SiticonePictureBox();
            this.btnHuy = new Siticone.UI.WinForms.SiticoneButton();
            this.btnLuu = new Siticone.UI.WinForms.SiticoneButton();
            this.btnQuayLai = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.siticoneShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(209, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hạng Mục ";
            // 
            // cbHangMuc
            // 
            this.cbHangMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbHangMuc.FormattingEnabled = true;
            this.cbHangMuc.Location = new System.Drawing.Point(387, 77);
            this.cbHangMuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbHangMuc.Name = "cbHangMuc";
            this.cbHangMuc.Size = new System.Drawing.Size(253, 33);
            this.cbHangMuc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số Tiền ";
            // 
            // txtSoTien
            // 
            this.txtSoTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtSoTien.ForeColor = System.Drawing.Color.Black;
            this.txtSoTien.Location = new System.Drawing.Point(387, 144);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(253, 30);
            this.txtSoTien.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(209, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại Giao Dịch ";
            // 
            // cbLoaiGiaoDich
            // 
            this.cbLoaiGiaoDich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbLoaiGiaoDich.FormattingEnabled = true;
            this.cbLoaiGiaoDich.Location = new System.Drawing.Point(387, 208);
            this.cbLoaiGiaoDich.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLoaiGiaoDich.Name = "cbLoaiGiaoDich";
            this.cbLoaiGiaoDich.Size = new System.Drawing.Size(253, 33);
            this.cbLoaiGiaoDich.TabIndex = 5;
            this.cbLoaiGiaoDich.SelectedIndexChanged += new System.EventHandler(this.cbLoaiGiaoDich_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(209, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ghi Chú ";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtGhiChu.ForeColor = System.Drawing.Color.Black;
            this.txtGhiChu.Location = new System.Drawing.Point(387, 275);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(253, 30);
            this.txtGhiChu.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(209, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày Giao Dịch ";
            // 
            // dtNgay
            // 
            this.dtNgay.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtNgay.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtNgay.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgay.Location = new System.Drawing.Point(387, 339);
            this.dtNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(253, 30);
            this.dtNgay.TabIndex = 9;
            // 
            // siticoneShadowPanel1
            // 
            this.siticoneShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneShadowPanel1.Controls.Add(this.siticonePictureBox1);
            this.siticoneShadowPanel1.Controls.Add(this.btnHuy);
            this.siticoneShadowPanel1.Controls.Add(this.btnLuu);
            this.siticoneShadowPanel1.Controls.Add(this.btnQuayLai);
            this.siticoneShadowPanel1.Controls.Add(this.dtNgay);
            this.siticoneShadowPanel1.Controls.Add(this.label5);
            this.siticoneShadowPanel1.Controls.Add(this.txtGhiChu);
            this.siticoneShadowPanel1.Controls.Add(this.label4);
            this.siticoneShadowPanel1.Controls.Add(this.cbLoaiGiaoDich);
            this.siticoneShadowPanel1.Controls.Add(this.label3);
            this.siticoneShadowPanel1.Controls.Add(this.txtSoTien);
            this.siticoneShadowPanel1.Controls.Add(this.label2);
            this.siticoneShadowPanel1.Controls.Add(this.cbHangMuc);
            this.siticoneShadowPanel1.Controls.Add(this.label1);
            this.siticoneShadowPanel1.FillColor = System.Drawing.Color.White;
            this.siticoneShadowPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneShadowPanel1.Location = new System.Drawing.Point(15, 14);
            this.siticoneShadowPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.siticoneShadowPanel1.Name = "siticoneShadowPanel1";
            this.siticoneShadowPanel1.Radius = 22;
            this.siticoneShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.siticoneShadowPanel1.Size = new System.Drawing.Size(723, 466);
            this.siticoneShadowPanel1.TabIndex = 12;
            // 
            // siticonePictureBox1
            // 
            this.siticonePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("siticonePictureBox1.Image")));
            this.siticonePictureBox1.Location = new System.Drawing.Point(29, 85);
            this.siticonePictureBox1.Name = "siticonePictureBox1";
            this.siticonePictureBox1.ShadowDecoration.Parent = this.siticonePictureBox1;
            this.siticonePictureBox1.Size = new System.Drawing.Size(155, 237);
            this.siticonePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.siticonePictureBox1.TabIndex = 24;
            this.siticonePictureBox1.TabStop = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 22;
            this.btnHuy.CheckedState.Parent = this.btnHuy;
            this.btnHuy.CustomImages.Parent = this.btnHuy;
            this.btnHuy.FillColor = System.Drawing.Color.LightSalmon;
            this.btnHuy.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(114)))));
            this.btnHuy.HoveredState.Parent = this.btnHuy;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(396, 407);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ShadowDecoration.Parent = this.btnHuy;
            this.btnHuy.Size = new System.Drawing.Size(112, 45);
            this.btnHuy.TabIndex = 23;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 22;
            this.btnLuu.CheckedState.Parent = this.btnLuu;
            this.btnLuu.CustomImages.Parent = this.btnLuu;
            this.btnLuu.FillColor = System.Drawing.Color.LightGreen;
            this.btnLuu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(114)))));
            this.btnLuu.HoveredState.Parent = this.btnLuu;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(177, 407);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ShadowDecoration.Parent = this.btnLuu;
            this.btnLuu.Size = new System.Drawing.Size(112, 45);
            this.btnLuu.TabIndex = 22;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.CheckedState.Parent = this.btnQuayLai;
            this.btnQuayLai.CustomImages.Parent = this.btnQuayLai;
            this.btnQuayLai.FillColor = System.Drawing.Color.White;
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.HoveredState.Parent = this.btnQuayLai;
            this.btnQuayLai.Image = ((System.Drawing.Image)(resources.GetObject("btnQuayLai.Image")));
            this.btnQuayLai.ImageSize = new System.Drawing.Size(70, 70);
            this.btnQuayLai.Location = new System.Drawing.Point(48, 32);
            this.btnQuayLai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.ShadowDecoration.Parent = this.btnQuayLai;
            this.btnQuayLai.Size = new System.Drawing.Size(60, 46);
            this.btnQuayLai.TabIndex = 21;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // frmThemGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(752, 490);
            this.Controls.Add(this.siticoneShadowPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmThemGiaoDich";
            this.Text = "frmThemGiaoDich";
            this.Load += new System.EventHandler(this.frmThemGiaoDich_Load);
            this.siticoneShadowPanel1.ResumeLayout(false);
            this.siticoneShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbHangMuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLoaiGiaoDich;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private Siticone.UI.WinForms.SiticoneShadowPanel siticoneShadowPanel1;
        private Siticone.UI.WinForms.SiticoneRoundedButton btnQuayLai;
        private Siticone.UI.WinForms.SiticoneButton btnLuu;
        private Siticone.UI.WinForms.SiticoneButton btnHuy;
        private Siticone.UI.WinForms.SiticonePictureBox siticonePictureBox1;
    }
}