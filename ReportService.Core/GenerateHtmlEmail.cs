using ReportService.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Core
{
    public class GenerateHtmlEmail
    {
        public string GenerateErrors(List<Error> errors, int interval)
        {
            if (errors == null)
                throw new ArgumentNullException(nameof(errors));

            if (!errors.Any())
                return string.Empty;

            var html = $"Błędy z oststnich {interval} minut. <br /><br />";
            
            html +=
                @"
                    <table border=1 cellpadding=5 cellspacing=1
                        <tr>
                            <th align=center bgcolor=lightgrey>Wiadomość</th>
                            <th align=center bgcolor=lightgrey>Data</th>
                        </tr>
                ";
            foreach (var error in errors)
            {
                html +=
               $@"
                        <tr>
                            <th align=center>{error.Message}</th>
                            <th align=center>{error.Date.ToString("dd-MM-yyyy HH:mm")}</th>
                        </tr>
                ";
            }

            html += @"</table><br /><br /><i>Automatyczna wiadomość wysłana z aplikacji ReportSerwice</i>";

            return html;
        }

        public string GenerateReport(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));

            var html = $"Raport {report.Title} z dnia {report.Date.ToString("dd-MM-yyyy")}. <br /><br />";

            if (report.Positions != null && report.Positions.Any())
            {

            html +=
                @"
                    <table border=1 cellpadding=5 cellspacing=1
                        <tr>
                            <th align=center bgcolor=lightgrey>Tytuł</th>
                            <th align=center bgcolor=lightgrey>Opis</th>
                            <th align=center bgcolor=lightgrey>Wartość</th>
                        </tr>
                ";
               
                foreach (var position in report.Positions)
                {
                    html +=
                   $@"
                        <tr>
                            <th align=center>{position.Title}</th>
                            <th align=center>{position.Description}</th>
                            <th align=center>{position.Value.ToString("0,00")} zł</th>
                        </tr>
                    ";
                }
                html += @"</table>";
            }
            else
                html += "--- Barak danych do wyświetlenia ---";

            html += @"</table><br /><br /><i>Automatyczna wiadomość wysłana z aplikacji ReportSerwice</i>";

            return html;

        }
    }
}
