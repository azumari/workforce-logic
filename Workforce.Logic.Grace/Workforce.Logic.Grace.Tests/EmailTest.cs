using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.Services;
using Xunit;

namespace Workforce.Logic.Grace.Tests
{
  /// <summary>
  /// The Unit Test for
  /// sending an email.
  /// Will call the method
  /// that sends the email
  /// </summary>
  public class EmailTest
  {
    [Fact]
    public async Task sendEmail()
    {
      EmailService send = new EmailService();

      //The person the email is being sent to
      var Destination = "wlopez.career@gmail.com";

      //The message being sent
      var Body = "Hello, how are you doing?";

      //The subject of the email
      var Subject = "Welcome Mr. Dango";

      //Calls the method to send the email
      await send.SendAsync(Destination, Body, Subject);

    }
  }
}
