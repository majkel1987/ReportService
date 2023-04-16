using EmailSender;
using ReportService.Core;
using ReportService.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailReceiver = "michal.sarnacki@gmail.com";
            var htmlEmail = new GenerateHtmlEmail();

             var email = new Email(new EmailParams
            {
                HostSmtp = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                SenderName = "Michał",
                SenderEmail = "kontodotestow.ms@gmail.com",
                SenderEmailPassword = "oxrtbffdfdblxdpd"
            });

            var report = new Report
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

            var errors = new List<Error>
            {
                new Error { Message = "Błąd testowy 1", Date = DateTime.Now},
                new Error { Message = "Błąd testowy 2", Date = DateTime.Now}
            };

            Console.WriteLine("Wysyłanie Email: Błędy w aplikacji");
            email.Send("Błędy w aplikacji", htmlEmail.GenerateErrors(errors, 2), emailReceiver).Wait();
            Console.WriteLine("Wysłano Email: Błędy w aplikacji");

            Console.WriteLine("Wysyłanie Email: Raport dobowy");
            email.Send("Raport dobowy", htmlEmail.GenerateReport(report), emailReceiver).Wait();
            Console.WriteLine("Wysłano Email: Raport dobowy");


        }
    }
}
