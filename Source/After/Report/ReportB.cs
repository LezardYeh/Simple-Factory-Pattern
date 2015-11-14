using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using After.Report.Interface;
using After.Report.Model;

namespace After.Report
{
    public class ReportB:IReport
    {
        public string Path
        {
            get { return "Report/Rdlc/ReportB.rdlc"; }
        }

        public System.Collections.IEnumerable GetData()
        {
            var result = new List<ReportBModel>()
            {
                new ReportBModel()
                {
                    CompanyId = "Test",
                    Time = DateTime.Now,
                    Address = "Taipei"
                },
                new ReportBModel()
                {
                    CompanyId = "Test2",
                    Time = DateTime.Now,
                    Address = "Taipei"
                }
            };

            return result;
        }
    }
}