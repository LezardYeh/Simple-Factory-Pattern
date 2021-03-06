﻿using System;
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
        public IEnumerable<ReportAModel> GetReportAData()
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

        //取得報表Ｂ資料
        public IEnumerable<ReportBModel> GetReportBData()
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