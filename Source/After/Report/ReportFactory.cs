using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using After.Report.Interface;

namespace After.Report
{
    public static class ReportFactory
    {
        public static IReport Create(string reportType)
        {
            //使用Reflection後，只要報表Class的命名原則符合"Report"+reportType 即可
            string className = "Report" + reportType;
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            Type typeToCreate = thisAssembly.GetTypes().FirstOrDefault(t => t.Name == className);

            return Activator.CreateInstance(typeToCreate) as IReport;

            //尚未使用Reflection的寫法，要增加新的報表必須擴充對應規則
            //switch (reportType)
            //{
            //    case "A":
            //        return new ReportA();
            //    case "B":
            //        return new ReportB();
            //    default:
            //        return null;
            //}
        }
    }
}