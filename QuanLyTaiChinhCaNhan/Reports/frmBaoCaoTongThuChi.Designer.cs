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
            this.crvIE = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvIE
            // 
            this.crvIE.ActiveViewIndex = -1;
            this.crvIE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvIE.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvIE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvIE.Location = new System.Drawing.Point(0, 0);
            this.crvIE.Name = "crvIE";
            this.crvIE.Size = new System.Drawing.Size(1275, 768);
            this.crvIE.TabIndex = 0;
            // 
            // frmBaoCaoTongThuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 768);
            this.Controls.Add(this.crvIE);
            this.Name = "frmBaoCaoTongThuChi";
            this.Text = "frmBaoCaoTongThuChi";
            this.Load += new System.EventHandler(this.frmBaoCaoTongThuChi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvIE;
    }
}