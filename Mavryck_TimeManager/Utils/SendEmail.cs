//using System;
//using System.IO;
//using System.Net;
//using System.Net.Mail;

//class SendEmail
//{

//    static void Main()
//    {
//        SendEmailWithReport();
//    }

//    static void SendEmailWithReport()
//    {
//        try
//        {
//            string fromEmail = "swenatasha@gmail.com";
//            string password = "Parwasha@123";
//            string toEmail = "natasha.javed@supersoft.com.pk";
//            string subject = "Automation Test Report";
//            string body = "Hi,\n\nPlease find the attached automation test report.\n\nBest Regards,\nQA Team";
//            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
//            string reportsFolderPath = Path.Combine(projectDirectory, "report");
//            string ReportPath = reportsFolderPath;
//            MailMessage message = new MailMessage();
//            message.From = new MailAddress(fromEmail);
//            message.To.Add(new MailAddress(toEmail));
//            message.Subject = subject;
//            message.Body = body;
//            message.IsBodyHtml = false;

//            // Attach the report
//            Attachment attachment = new Attachment(ReportPath);
//            message.Attachments.Add(attachment);

//            // Configure SMTP client
//            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
//            smtpClient.Credentials = new NetworkCredential(fromEmail, password);
//            smtpClient.EnableSsl = true;

//            // Send the email
//            smtpClient.Send(message);

//            Console.WriteLine("Email sent successfully!");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("Error sending email: " + ex.Message);
//        }
//    }
//}
