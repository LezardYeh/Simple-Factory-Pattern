using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using After.Report.Interface;

namespace After.Report
{
    public static class ReportFactory
    {
        public static IReport Create(string reportType)
        {
            switch (reportType)
            {
                case "A":
                    return new ReportA();
                case "B":
                    return new ReportB();
                default:
                    return null;
            }
        }
    }
}