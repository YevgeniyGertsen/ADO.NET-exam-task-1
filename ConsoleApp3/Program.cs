using ConsoleApp3.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConsoleApp3
{
    class Program
    {
        static EntityContext db = new EntityContext();

        static string path = @"C:\Users\ГерценЕ\source\repos\ConsoleApp3\ConsoleApp3\";
        static string pathTemplate = path + @"\Templates\OverallRepairList.xlsx";
        string fileName = path + @"\Report_" + DateTime.Now.ToShortDateString() + ".xlsx";

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите дату начала: ");
                DateTime df = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("");

                Console.Write("Введите дату заверешния: ");
                DateTime dt = Convert.ToDateTime(Console.ReadLine());

                GenerateExcelReport(GetReportData(df, dt));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Метод возвращаем список работ
        /// </summary>
        /// <param name="dateFrom">Дата начала</param>
        /// <param name="dateTo">Дата завершения</param>
        /// <returns>Список TrackEvaluation</returns>
        public static List<TrackEvaluation> GetReportData(DateTime dateFrom, DateTime dateTo)
        {
            using (EntityContext db = new EntityContext())
            {
                return db.TrackEvaluation
                    .Where(w=>w.dCreateDate >= dateFrom 
                           && w.dCreateDate <= dateTo).ToList();               
            }
        }

        public static void GenerateExcelReport(List<TrackEvaluation> data)
        {
            if (data == null || data.Count == 0)
                throw new Exception("Отсутствуют данные для формирование документа");

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(pathTemplate))
            {
                var sheet = package.Workbook.Worksheets[0];

                sheet.Cells["B1"].Value = DateTime.Now;

                int k = 3;

                System.Drawing.Color colFromHex = ColorTranslator.FromHtml("#1e6475");
              
                foreach (TrackEvaluation item in data)
                {
                    sheet.Cells[k, 1].Value = item.intEvalutionNumber;
                    if (item.dCreateDate.Value.Month == 01)
                    {
                        //int FromRow, int FromCol, int ToRow, int ToCol
                        sheet.Cells[k, 1, k, 27].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        sheet.Cells[k, 1, k, 27].Style.Fill.BackgroundColor.SetColor(colFromHex);
                    }
                    k++;
                }
                                
                package.SaveAs(path);
                SendMail(path);
            }
        }

        public static void SendMail(string path)
        {
            //@"C:\Users\ГерценЕ\source\repos\ConsoleApp3\ConsoleApp3\test.xlsx"

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Timeout = 20000;

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("gersen.e.a@gmail.com", "**");

            MailMessage message = new MailMessage();
            message.Subject = "Report";
            message.Body = "Report from MCS data base";
            message.To.Add("gertsen.e@hcsbk.kz");
            message.From = new MailAddress("gersen.e.a@gmail.com");

            Attachment attachment = new Attachment(path);
            message.Attachments.Add(attachment);

            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
