namespace QuanLyTaiChinhCaNhan
{
    partial class frmBaoCaoTongThuChi
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
            this.crvTongThuChi = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvTongThuChi
            // 
            this.crvTongThuChi.ActiveViewIndex = -1;
            this.crvTongThuChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvTongThuChi.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvTongThuChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvTongThuChi.Location = new System.Drawing.Point(0, 0);
            this.crvTongThuChi.Name = "crvTongThuChi";
            this.crvTongThuChi.Size = new System.Drawing.Size(800, 450);
            this.crvTongThuChi.TabIndex = 0;
            // 
            // frmBaoCaoTongThuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvTongThuChi);
            this.Name = "frmBaoCaoTongThuChi";
            this.Text = "frmBaoCaoTongThuChi";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvTongThuChi;
    }
}