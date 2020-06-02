using Microsoft.Extensions.Configuration;  
using System.Net.Mail;  
using System.Text;  
using HomeFood.Entities.Email;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Net;
using System;
using HomeFood.Helpers;

namespace HomeFood.Helpers
{
    public class EmailHelpers: IEmailSender
    {
        public EmailEntity _emailEntities { get; }

        public EmailHelpers(IOptions<EmailEntity> emailSettings)
        {
            _emailEntities = emailSettings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {

            Execute (email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string email, string subject, string message)
        {
          try
          {
            string toEmail = string.IsNullOrEmpty(email) 
                             ? _emailEntities.ToEmail 
                             : email;
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailEntities.UsernameEmail, "Muhammad Hassan Tariq")
            };
            mail.To.Add(new MailAddress(toEmail));
            //mail.CC.Add(new MailAddress(_emailEntities.CcEmail));

            mail.Subject = "Personal Management System - " + subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            using (SmtpClient smtp = new SmtpClient(_emailEntities.PrimaryDomain, _emailEntities.PrimaryPort))
            {
                smtp.Credentials = new NetworkCredential(_emailEntities.UsernameEmail, _emailEntities.UsernamePassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
          }
          catch(Exception ex)
          {
             //do something here
          }
        }
        
    }
}