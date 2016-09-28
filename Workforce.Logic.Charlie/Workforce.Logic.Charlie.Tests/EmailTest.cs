using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using Workforce.Logic.Charlie.Domain.Services;

namespace Workforce.Logic.Charlie.Tests
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
    public async Task Test_sendEmail()
    {
      EmailService send = new EmailService();

      //The person the email is being sent to
      var Destination = "charlestester3@gmail.com";

      //The message being sent
      var Body = "Hello, how are you doing?";

      //The subject of the email
      var Subject = "whoomp, there it is";

      //Calls the method to send the email
      await send.SendAsync(Destination, Body, Subject);
      Assert.True(true);
    }
  }
}
