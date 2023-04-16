using ReportService.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Core.Repositories
{
    public class ReportRepository
    {
        public Report GetLastNotSentReport()
        {
            
            return new Report
            {
                Id = 1,
                Title = "Nowy raport 1",
                Date = new DateTime(2023, 4, 1, 12, 0, 0),
                Positions = new List<ReportPosition>
                {
                    new ReportPosition
                    {
                        Id = 1,
                        ReportId =1,
                        Title = "Position 1",
                        Description = "Desc 1",
                        Value = 32.91m
                    },
                    new ReportPosition
                    {
                        Id = 2,
                        ReportId = 2,
                        Title = "Position 2",
                        Description = "Desc 2",
                        Value = 332.91m
                    },
                    new ReportPosition
                    {
                        Id = 3,
                        ReportId = 3,
                        Title = "Position 3",
                        Description = "Desc 3",
                        Value = 533.91m
                    }
                }
            };
        }

        public void ReportSent(Report report) 
        {
            report.IsSend = true;
           
            //zapis do bazy danych
        }
 
    }
}
