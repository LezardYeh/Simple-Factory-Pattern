using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace Before
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var service = new Service();
                ReportDataSource mainData;
                var reportType = "B";

                //報表數量擴充，必須修改程式
                switch (reportType)
                {
                    case "A":
                        ReportViewer1.LocalReport.ReportPath = "Report/ReportA.rdlc";
                        mainData = new ReportDataSource("MainData", service.GetReportAData());
                        break;
                    case "B":
                        ReportViewer1.LocalReport.ReportPath = "Report/ReportB.rdlc";
                        mainData = new ReportDataSource("MainData", service.GetReportBData());
                        break;
                    //case "C":
                        //   ....
                    //break;
                   
                    //case "Z":
                        //   ....
                    //break;

                    default:
                        mainData = null;
                        break;
                }

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(mainData);
                ReportViewer1.LocalReport.Refresh();
            }
           
        }
    }
}