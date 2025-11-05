namespace QuanLyTaiChinhCaNhan
{
    partial class frmBaoCaoChiTieuTheoHangMuc
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
            this.crvCategory = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCategory
            // 
            this.crvCategory.ActiveViewIndex = -1;
            this.crvCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCategory.Location = new System.Drawing.Point(0, 0);
            this.crvCategory.Name = "crvCategory";
            this.crvCategory.Size = new System.Drawing.Size(1291, 696);
            this.crvCategory.TabIndex = 0;
            // 
            // frmBaoCaoChiTieuTheoHangMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 696);
            this.Controls.Add(this.crvCategory);
            this.Name = "frmBaoCaoChiTieuTheoHangMuc";
            this.Text = "frmBaoCaoChiTieuTheoHangMuc";
            this.Load += new System.EventHandler(this.frmBaoCaoChiTieuTheoHangMuc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCategory;
    }
}