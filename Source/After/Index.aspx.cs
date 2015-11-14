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

                //透過Factory取得正確的報表物件
                var report = ReportFactory.Create(reportType);

                ReportViewer1.LocalReport.DataSources.Clear();

                //取得報表物件中的Rdlc Path
                ReportViewer1.LocalReport.ReportPath = report.Path;
                var mainData = new ReportDataSource("MainData", report.GetData());
                ReportViewer1.LocalReport.DataSources.Add(mainData);
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}