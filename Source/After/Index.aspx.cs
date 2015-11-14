using System;
using After.Report;
using Microsoft.Reporting.WebForms;

namespace After
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var reportType = "B";
                var report = ReportFactory.Create(reportType);
                var mainData = new ReportDataSource("MainData", report.GetData());
                ReportViewer1.LocalReport.ReportPath = report.Path;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(mainData);
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}