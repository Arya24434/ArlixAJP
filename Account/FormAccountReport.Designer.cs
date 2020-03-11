namespace ArlixAJP
{
    partial class FormAccountReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccountReport));
            this.reportAccountDetail = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportAccountDetail
            // 
            this.reportAccountDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportAccountDetail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportAccountDetail.LocalReport.ReportEmbeddedResource = "";
            this.reportAccountDetail.Location = new System.Drawing.Point(0, 0);
            this.reportAccountDetail.Name = "reportAccountDetail";
            this.reportAccountDetail.ServerReport.BearerToken = null;
            this.reportAccountDetail.Size = new System.Drawing.Size(790, 450);
            this.reportAccountDetail.TabIndex = 0;
            // 
            // FormAccountReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(790, 450);
            this.Controls.Add(this.reportAccountDetail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAccountReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Report  ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAccountReport_Load);
            this.ResumeLayout(false);

        }


        #endregion
        public Microsoft.Reporting.WinForms.ReportViewer reportAccountDetail;
    }
}