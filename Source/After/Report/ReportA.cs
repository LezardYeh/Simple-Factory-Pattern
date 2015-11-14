using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using After.Report.Interface;
using After.Report.Model;

namespace After.Report
{
    public class ReportA:IReport
    {
        public string Path
        {
            get { return "Report/Rdlc/ReportA.rdlc"; }
        }

        public System.Collections.IEnumerable GetData()
        {
            var result = new List<ReportAModel>
            {
                new ReportAModel()
                {
                    CompanyId = "Test",
                    Value = 100
                }
            };
            return result;
        }
    }
}