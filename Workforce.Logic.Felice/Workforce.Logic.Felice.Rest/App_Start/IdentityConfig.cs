using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Workforce.Logic.Felice.Rest
{
  public class EmailService : IIdentityMessageService
  {
    public async Task SendAsync(IdentityMessage message)
    {
      await configSendEmailasync(message);
    }


    private Task configSendEmailasync(IdentityMessage message)
    {
      var email = new MailMessage();

      email.To.Add(message.Destination);
      email.From = new System.Net.Mail.MailAddress("revature.projectliberate@gmail.com", "Revature");
      email.Subject = message.Subject;
      email.Body = message.Body;
      email.IsBodyHtml = true;

      System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
      {
        Host = ConfigurationManager.AppSettings["GmailHost"],
        Port = Int32.Parse(ConfigurationManager.AppSettings["GmailPort"]),
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(ConfigurationManager.AppSettings["GmailUserName"], ConfigurationManager.AppSettings["GmailPassword"])

      };
      return Task.Run(() => smtp.SendMailAsync(email));
    }
  }
}