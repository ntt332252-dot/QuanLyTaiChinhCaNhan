namespace QuanLyGiaoDich
{
    partial class frmQuanLyGiaoDich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyGiaoDich));
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageThu = new System.Windows.Forms.TabPage();
            this.btnXoa = new Siticone.UI.WinForms.SiticoneButton();
            this.btnSua = new Siticone.UI.WinForms.SiticoneButton();
            this.btnThem = new Siticone.UI.WinForms.SiticoneButton();
            this.dgvGiaoDich = new System.Windows.Forms.DataGridView();
            this.txtTongThu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbGiaoDichThu = new System.Windows.Forms.ComboBox();
            this.lblGiaoDichThu = new System.Windows.Forms.Label();
            this.tabPageChi = new System.Windows.Forms.TabPage();
            this.btnXoaChi = new Siticone.UI.WinForms.SiticoneButton();
            this.btnSuaChi = new Siticone.UI.WinForms.SiticoneButton();
            this.btnThemChi = new Siticone.UI.WinForms.SiticoneButton();
            this.dgvGiaoDichChi = new System.Windows.Forms.DataGridView();
            this.txtTongChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGiaoDichChi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.siticoneShadowPanel1 = new Siticone.UI.WinForms.SiticoneShadowPanel();
            this.siticonePictureBox1 = new Siticone.UI.WinForms.SiticonePictureBox();
            this.btnSync = new Siticone.UI.WinForms.SiticoneButton();
            this.btnQuayLai = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.tabControl1.SuspendLayout();
            this.tabPageThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.tabPageChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDichChi)).BeginInit();
            this.siticoneShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(114)))));
            this.label1.Location = new System.Drawing.Point(436, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Giao Dịch ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageThu);
            this.tabControl1.Controls.Add(this.tabPageChi);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(49, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1031, 469);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageThu
            // 
            this.tabPageThu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPageThu.Controls.Add(this.btnXoa);
            this.tabPageThu.Controls.Add(this.btnSua);
            this.tabPageThu.Controls.Add(this.btnThem);
            this.tabPageThu.Controls.Add(this.dgvGiaoDich);
            this.tabPageThu.Controls.Add(this.txtTongThu);
            this.tabPageThu.Controls.Add(this.label3);
            this.tabPageThu.Controls.Add(this.cbGiaoDichThu);
            this.tabPageThu.Controls.Add(this.lblGiaoDichThu);
            this.tabPageThu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageThu.Location = new System.Drawing.Point(4, 26);
            this.tabPageThu.Name = "tabPageThu";
            this.tabPageThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageThu.Size = new System.Drawing.Size(1023, 439);
            this.tabPageThu.TabIndex = 0;
            this.tabPageThu.Text = "Giao Dịch Thu ";
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 22;
            this.btnXoa.CheckedState.Parent = this.btnXoa;
            this.btnXoa.CustomImages.Parent = this.btnXoa;
            this.btnXoa.FillColor = System.Drawing.Color.Salmon;
            this.btnXoa.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(114)))));
            this.btnXoa.HoveredState.Parent = this.btnXoa;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(631, 381);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ShadowDecoration.Parent = this.btnXoa;
            this.btnXoa.Size = new System.Drawing.Size(99, 45);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 22;
            this.btnSua.CheckedState.Parent = this.btnSua;
            this.btnSua.CustomImages.Parent = this.btnSua;
            this.btnSua.FillColor = System.Drawing.Color.LightPink;
            this.btnSua.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(114)))));
            this.btnSua.HoveredState.Parent = this.btnSua;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Location = new System.Drawing.Point(451, 384);
            this.btnSua.Name = "btnSua";
            this.btnSua.ShadowDecoration.Parent = this.btnSua;
            this.btnSua.Size = new System.Drawing.Size(99, 45);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 22;
            this.btnThem.CheckedState.Parent = this.btnThem;
            this.btnThem.CustomImages.Parent = this.btnThem;
            this.btnThem.FillColor = System.Drawing.Color.LightGreen;
            this.btnThem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(114)))));
            this.btnThem.HoveredState.Parent = this.btnThem;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(271, 384);
            this.btnThem.Name = "btnThem";
            this.btnThem.ShadowDecoration.Parent = this.btnThem;
            this.btnThem.Size = new System.Drawing.Size(99, 45);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvGiaoDich
            // 
            this.dgvGiaoDich.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoDich.GridColor = System.Drawing.Color.LightGray;
            this.dgvGiaoDich.Location = new System.Drawing.Point(17, 81);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.RowHeadersWidth = 51;
            this.dgvGiaoDich.RowTemplate.Height = 24;
            this.dgvGiaoDich.Size = new System.Drawing.Size(986, 294);
            this.dgvGiaoDich.TabIndex = 4;
            // 
            // txtTongThu
            // 
            this.txtTongThu.BackColor = System.Drawing.Color.White;
            this.txtTongThu.Location = new System.Drawing.Point(496, 33);
            this.txtTongThu.Name = "txtTongThu";
            this.txtTongThu.Size = new System.Drawing.Size(120, 30);
            this.txtTongThu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Tiền Đã Thu ";
            // 
            // cbGiaoDichThu
            // 
            this.cbGiaoDichThu.BackColor = System.Drawing.Color.White;
            this.cbGiaoDichThu.FormattingEnabled = true;
            this.cbGiaoDichThu.Location = new System.Drawing.Point(156, 33);
            this.cbGiaoDichThu.Name = "cbGiaoDichThu";
            this.cbGiaoDichThu.Size = new System.Drawing.Size(121, 31);
            this.cbGiaoDichThu.TabIndex = 1;
            this.cbGiaoDichThu.SelectedIndexChanged += new System.EventHandler(this.cbGiaoDichThu_SelectedIndexChanged);
            // 
            // lblGiaoDichThu
            // 
            this.lblGiaoDichThu.AutoSize = true;
            this.lblGiaoDichThu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGiaoDichThu.ImageKey = "(none)";
            this.lblGiaoDichThu.Location = new System.Drawing.Point(23, 36);
            this.lblGiaoDichThu.Name = "lblGiaoDichThu";
            this.lblGiaoDichThu.Size = new System.Drawing.Size(127, 23);
            this.lblGiaoDichThu.TabIndex = 0;
            this.lblGiaoDichThu.Text = "Giao Dịch Thu ";
            // 
            // tabPageChi
            // 
            this.tabPageChi.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPageChi.Controls.Add(this.btnXoaChi);
            this.tabPageChi.Controls.Add(this.btnSuaChi);
            this.tabPageChi.Controls.Add(this.btnThemChi);
            this.tabPageChi.Controls.Add(this.dgvGiaoDichChi);
            this.tabPageChi.Controls.Add(this.txtTongChi);
            this.tabPageChi.Controls.Add(this.label5);
            this.tabPageChi.Controls.Add(this.cbGiaoDichChi);
            this.tabPageChi.Controls.Add(this.label4);
            this.tabPageChi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageChi.Location = new System.Drawing.Point(4, 26);
            this.tabPageChi.Name = "tabPageChi";
            this.tabPageChi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChi.Size = new System.Drawing.Size(1023, 439);
            this.tabPageChi.TabIndex = 1;
            this.tabPageChi.Text = "Giao Dịch Chi ";
            // 
            // btnXoaChi
            // 
            this.btnXoaChi.BorderRadius = 22;
            this.btnXoaChi.CheckedState.Parent = this.btnXoaChi;
            this.btnXoaChi.CustomImages.Parent = this.btnXoaChi;
            this.btnXoaChi.FillColor = System.Drawing.Color.Salmon;
            this.btnXoaChi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(114)))));
            this.btnXoaChi.HoveredState.Parent = this.btnXoaChi;
            this.btnXoaChi.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaChi.Image")));
            this.btnXoaChi.Location = new System.Drawing.Point(628, 378);
            this.btnXoaChi.Name = "btnXoaChi";
            this.btnXoaChi.ShadowDecoration.Parent = this.btnXoaChi;
            this.btnXoaChi.Size = new System.Drawing.Size(104, 45);
            this.btnXoaChi.TabIndex = 7;
            this.btnXoaChi.Text = "Xóa";
            this.btnXoaChi.Click += new System.EventHandler(this.btnXoaChi_Click);
            // 
            // btnSuaChi
            // 
            this.btnSuaChi.BorderRadius = 22;
            this.btnSuaChi.CheckedState.Parent = this.btnSuaChi;
            this.btnSuaChi.CustomImages.Parent = this.btnSuaChi;
            this.btnSuaChi.FillColor = System.Drawing.Color.LightPink;
            this.btnSuaChi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(114)))));
            this.btnSuaChi.HoveredState.Parent = this.btnSuaChi;
            this.btnSuaChi.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaChi.Image")));
            this.btnSuaChi.Location = new System.Drawing.Point(449, 378);
            this.btnSuaChi.Name = "btnSuaChi";
            this.btnSuaChi.ShadowDecoration.Parent = this.btnSuaChi;
            this.btnSuaChi.Size = new System.Drawing.Size(104, 45);
            this.btnSuaChi.TabIndex = 6;
            this.btnSuaChi.Text = "Sửa";
            this.btnSuaChi.Click += new System.EventHandler(this.btnSuaChi_Click);
            // 
            // btnThemChi
            // 
            this.btnThemChi.BorderRadius = 22;
            this.btnThemChi.CheckedState.Parent = this.btnThemChi;
            this.btnThemChi.CustomImages.Parent = this.btnThemChi;
            this.btnThemChi.FillColor = System.Drawing.Color.LightGreen;
            this.btnThemChi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(114)))));
            this.btnThemChi.HoveredState.Parent = this.btnThemChi;
            this.btnThemChi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemChi.Image")));
            this.btnThemChi.Location = new System.Drawing.Point(270, 378);
            this.btnThemChi.Name = "btnThemChi";
            this.btnThemChi.ShadowDecoration.Parent = this.btnThemChi;
            this.btnThemChi.Size = new System.Drawing.Size(104, 45);
            this.btnThemChi.TabIndex = 5;
            this.btnThemChi.Text = "Thêm";
            this.btnThemChi.Click += new System.EventHandler(this.btnThemChi_Click);
            // 
            // dgvGiaoDichChi
            // 
            this.dgvGiaoDichChi.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvGiaoDichChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoDichChi.GridColor = System.Drawing.Color.LightGray;
            this.dgvGiaoDichChi.Location = new System.Drawing.Point(29, 74);
            this.dgvGiaoDichChi.Name = "dgvGiaoDichChi";
            this.dgvGiaoDichChi.RowHeadersWidth = 51;
            this.dgvGiaoDichChi.RowTemplate.Height = 24;
            this.dgvGiaoDichChi.Size = new System.Drawing.Size(988, 298);
            this.dgvGiaoDichChi.TabIndex = 4;
            // 
            // txtTongChi
            // 
            this.txtTongChi.BackColor = System.Drawing.Color.White;
            this.txtTongChi.Location = new System.Drawing.Point(506, 25);
            this.txtTongChi.Name = "txtTongChi";
            this.txtTongChi.Size = new System.Drawing.Size(126, 30);
            this.txtTongChi.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Số Tiền Đã Chi ";
            // 
            // cbGiaoDichChi
            // 
            this.cbGiaoDichChi.BackColor = System.Drawing.Color.White;
            this.cbGiaoDichChi.FormattingEnabled = true;
            this.cbGiaoDichChi.Location = new System.Drawing.Point(183, 22);
            this.cbGiaoDichChi.Name = "cbGiaoDichChi";
            this.cbGiaoDichChi.Size = new System.Drawing.Size(121, 31);
            this.cbGiaoDichChi.TabIndex = 1;
            this.cbGiaoDichChi.SelectedIndexChanged += new System.EventHandler(this.cbGiaoDichChi_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giao Dịch Chi";
            // 
            // siticoneShadowPanel1
            // 
            this.siticoneShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneShadowPanel1.Controls.Add(this.siticonePictureBox1);
            this.siticoneShadowPanel1.Controls.Add(this.btnSync);
            this.siticoneShadowPanel1.Controls.Add(this.btnQuayLai);
            this.siticoneShadowPanel1.Controls.Add(this.tabControl1);
            this.siticoneShadowPanel1.Controls.Add(this.label1);
            this.siticoneShadowPanel1.FillColor = System.Drawing.Color.White;
            this.siticoneShadowPanel1.Location = new System.Drawing.Point(12, 12);
            this.siticoneShadowPanel1.Name = "siticoneShadowPanel1";
            this.siticoneShadowPanel1.Radius = 22;
            this.siticoneShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.siticoneShadowPanel1.Size = new System.Drawing.Size(1125, 594);
            this.siticoneShadowPanel1.TabIndex = 2;
            // 
            // siticonePictureBox1
            // 
            this.siticonePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("siticonePictureBox1.Image")));
            this.siticonePictureBox1.Location = new System.Drawing.Point(335, 22);
            this.siticonePictureBox1.Name = "siticonePictureBox1";
            this.siticonePictureBox1.ShadowDecoration.Parent = this.siticonePictureBox1;
            this.siticonePictureBox1.Size = new System.Drawing.Size(104, 65);
            this.siticonePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.siticonePictureBox1.TabIndex = 23;
            this.siticonePictureBox1.TabStop = false;
            // 
            // btnSync
            // 
            this.btnSync.BorderRadius = 22;
            this.btnSync.CheckedState.Parent = this.btnSync;
            this.btnSync.CustomImages.Parent = this.btnSync;
            this.btnSync.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSync.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(114)))));
            this.btnSync.HoveredState.Parent = this.btnSync;
            this.btnSync.Image = ((System.Drawing.Image)(resources.GetObject("btnSync.Image")));
            this.btnSync.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSync.Location = new System.Drawing.Point(954, 68);
            this.btnSync.Name = "btnSync";
            this.btnSync.ShadowDecoration.Parent = this.btnSync;
            this.btnSync.Size = new System.Drawing.Size(119, 45);
            this.btnSync.TabIndex = 22;
            this.btnSync.Text = "Đồng bộ";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
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
            this.btnQuayLai.Location = new System.Drawing.Point(53, 33);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.ShadowDecoration.Parent = this.btnQuayLai;
            this.btnQuayLai.Size = new System.Drawing.Size(60, 45);
            this.btnQuayLai.TabIndex = 20;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // frmQuanLyGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1153, 619);
            this.Controls.Add(this.siticoneShadowPanel1);
            this.Name = "frmQuanLyGiaoDich";
            this.Text = "Quản lý giao dịch";
            this.Load += new System.EventHandler(this.frmQuanLyGiaoDich_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageThu.ResumeLayout(false);
            this.tabPageThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.tabPageChi.ResumeLayout(false);
            this.tabPageChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDichChi)).EndInit();
            this.siticoneShadowPanel1.ResumeLayout(false);
            this.siticoneShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageThu;
        private System.Windows.Forms.DataGridView dgvGiaoDich;
        private System.Windows.Forms.TextBox txtTongThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGiaoDichThu;
        private System.Windows.Forms.Label lblGiaoDichThu;
        private System.Windows.Forms.TabPage tabPageChi;
        private System.Windows.Forms.DataGridView dgvGiaoDichChi;
        private System.Windows.Forms.TextBox txtTongChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGiaoDichChi;
        private System.Windows.Forms.Label label4;
        private Siticone.UI.WinForms.SiticoneShadowPanel siticoneShadowPanel1;
        private Siticone.UI.WinForms.SiticoneRoundedButton btnQuayLai;
        private Siticone.UI.WinForms.SiticoneButton btnSync;
        private Siticone.UI.WinForms.SiticonePictureBox siticonePictureBox1;
        private Siticone.UI.WinForms.SiticoneButton btnXoa;
        private Siticone.UI.WinForms.SiticoneButton btnSua;
        private Siticone.UI.WinForms.SiticoneButton btnThem;
        private Siticone.UI.WinForms.SiticoneButton btnXoaChi;
        private Siticone.UI.WinForms.SiticoneButton btnSuaChi;
        private Siticone.UI.WinForms.SiticoneButton btnThemChi;
    }
}

