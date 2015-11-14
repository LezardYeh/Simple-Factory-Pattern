using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Before.Report.Model;

namespace Before
{
    public class Service
    {
        //報表數量擴充，必須修改程式

        //取得報表Ａ資料
        public IEnumerable<ReportA> GetReportAData()
        {
            var result = new List<ReportA>
            {
                new ReportA()
                {
                    CompanyId = "Test",
                    Value = 100
                }
            };
            return result;
        }

        //取得報表Ｂ資料
        public IEnumerable<ReportB> GetReportBData()
        {
            var result = new List<ReportB>()
            {
                new ReportB()
                {
                    CompanyId = "Test",
                    Time = DateTime.Now,
                    Address = "Taipei"
                },
                new ReportB()
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