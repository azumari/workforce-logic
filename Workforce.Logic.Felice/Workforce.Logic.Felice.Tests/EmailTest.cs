using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Felice.Rest.App_Start;
using Xunit;

namespace Workforce.Logic.Felice.Tests
{
  public class EmailTest
  {
    [Fact]
    public async Task sendEmail()
    {
      EmailService send = new EmailService();
      var Destination = "wlopez.career@gmail.com";
      var Body = "Hello, how are you doing?";
      var Subject = "Welcome";
      await send.SendAsync(Destination, Body, Subject);    
     
    }
  }
}
