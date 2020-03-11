using Microsoft.Reporting.WinForms;
using Arlix_SQL;
using Arlix_UI;
using ArlixAJP.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArlixAJP
{
    public partial class FormAccountReport : Form
    {
        #region Additional Set
        SQLGetData sqLGetData = new SQLGetData();

        public void SettingPagePotrait(System.Drawing.Printing.PageSettings pageSettings)
        {
            pageSettings.Margins.Top = 0;
            pageSettings.Margins.Bottom = 0;
            pageSettings.Margins.Left = 0;
            pageSettings.Margins.Right = 0;
        }

        public void SettingPageLandScape(System.Drawing.Printing.PageSettings pageSettings)
        {
            pageSettings.Margins.Top = 1;
            pageSettings.Margins.Bottom = 1;
            pageSettings.Margins.Left = 1;
            pageSettings.Margins.Right = 1;
            pageSettings.Landscape = true;

        }
        #endregion

        public FormAccountReport(bool Mode)
        {
            InitializeComponent();
            if (Mode == true)
            {
                System.Drawing.Printing.PageSettings pageSettings = new System.Drawing.Printing.PageSettings();
                SettingPagePotrait(pageSettings);
                reportAccountDetail.SetPageSettings(pageSettings);                
                DataTable dataTable = sqLGetData.AccountSearch(FormAccount.Forms.textBoxAccountID.Text);
                reportAccountDetail.LocalReport.DataSources.Clear();
                reportAccountDetail.LocalReport.DataSources.Add(new ReportDataSource("ReportDataSet", dataTable));
                reportAccountDetail.LocalReport.ReportEmbeddedResource = "ArlixAJP.Account.ReportAccountDetail.rdlc";
                ReportParameter[] reportParameters = new ReportParameter[4];
                reportParameters[0] = new ReportParameter("ReParCompName", Properties.Settings.Default.CompName, true);
                reportParameters[1] = new ReportParameter("ReParCompAddress", Properties.Settings.Default.CompAddress, true);
                reportParameters[2] = new ReportParameter("ReParCompPhone", Properties.Settings.Default.CompPhone, true);
                reportParameters[3] = new ReportParameter("ReParCompEmail", Properties.Settings.Default.CompEmail, true);
                reportAccountDetail.LocalReport.SetParameters(reportParameters);                
                reportAccountDetail.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportAccountDetail.RefreshReport();
            }
            else
            {
                System.Drawing.Printing.PageSettings pageSettings = new System.Drawing.Printing.PageSettings();
                SettingPageLandScape(pageSettings);
                reportAccountDetail.SetPageSettings(pageSettings);
                DataTable dataTable = sqLGetData.AccountList();
                reportAccountDetail.LocalReport.DataSources.Clear();
                reportAccountDetail.LocalReport.DataSources.Add(new ReportDataSource("ReportDataSet", dataTable));
                reportAccountDetail.LocalReport.ReportEmbeddedResource = "ArlixAJP.Account.ReportAccount.rdlc";
                ReportParameter[] reportParameters = new ReportParameter[4];
                reportParameters[0] = new ReportParameter("ReParCompName", Properties.Settings.Default.CompName, true);
                reportParameters[1] = new ReportParameter("ReParCompAddress", Properties.Settings.Default.CompAddress, true);
                reportParameters[2] = new ReportParameter("ReParCompPhone", Properties.Settings.Default.CompPhone, true);
                reportParameters[3] = new ReportParameter("ReParCompEmail", Properties.Settings.Default.CompEmail, true);
                reportAccountDetail.LocalReport.SetParameters(reportParameters);
                reportAccountDetail.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportAccountDetail.RefreshReport();
            }
        }

        private void FormAccountReport_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }
    }
}
