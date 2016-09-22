using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Workforce.Logic.Felice.Rest.App_Start
{
  public class EmailService
  {
    /// <summary>
    /// This method will call the
    /// configSendEmailasync method
    /// so that an email can be sent
    /// to the designated person(s)
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task SendAsync(string Destination, string emailMessage, string subject)
    {
      IdentityMessage message = new IdentityMessage();
      message.Destination = Destination;
      message.Body = emailMessage;
      message.Subject = subject;
      return Task.Run(() => configSendEmailasync(message));
    }


    /// <summary>
    /// Email method to send emails to the
    /// designated person(s) using the
    /// Gmail settings we have in the Web.Config
    /// Class is private as only the SendAsync
    /// method needs to call/use it
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    private Task configSendEmailasync(IdentityMessage message)
    {
      var email = new MailMessage();

      email.To.Add(message.Destination);
      email.From = new System.Net.Mail.MailAddress("revature@projectliberate.com", "Revature");
      email.Subject = message.Subject;
      email.Body = message.Body;
      email.IsBodyHtml = true;

      System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
      smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["GmailUserName"], ConfigurationManager.AppSettings["GmailPassword"]);
      smtp.Port = 587;
      smtp.EnableSsl = true;

      var port = smtp.Port;
      //{
      //  Host = ConfigurationManager.AppSettings["GmailHost"],
      //  Port = Int32.Parse(ConfigurationManager.AppSettings["GmailPort"]),
      //  EnableSsl = true,
      //  DeliveryMethod = SmtpDeliveryMethod.Network,
      //  UseDefaultCredentials = false,
      //  Credentials = new NetworkCredential(ConfigurationManager.AppSettings["GmailUserName"], ConfigurationManager.AppSettings["GmailPassword"])

      //};
      return Task.Run(() => smtp.SendMailAsync(email));
    }
  }
}