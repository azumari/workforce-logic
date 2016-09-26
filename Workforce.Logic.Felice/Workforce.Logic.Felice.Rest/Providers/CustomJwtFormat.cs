using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using Thinktecture.IdentityModel.Tokens;

namespace Workforce.Logic.Felice.Rest.Providers
{
  public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
  {
    private readonly string issuer = string.Empty;

    public CustomJwtFormat(string Issuer)
    {
      issuer = Issuer;
    }

    public string Protect(AuthenticationTicket data)
    {
      if (data == null)
      {
        throw new ArgumentNullException("data");
      }
      string plaintext = ConfigurationManager.AppSettings["AudienceID"] + DateTime.Now;
      string secretText = ConfigurationManager.AppSettings["AudienceSecret"];
      //var secKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.Default.GetBytes(plaintext));
      var keyByteArray = TextEncodings.Base64Url.Decode(secretText);
      //var signKey = new Microsoft.IdentityModel.Tokens.SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
      var signKey = new HmacSigningCredentials(keyByteArray);
      var issued = data.Properties.IssuedUtc;
      var expires = data.Properties.ExpiresUtc;
      var token = new JwtSecurityToken(issuer, plaintext, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signKey);
      var handler = new JwtSecurityTokenHandler();
      var jwt = handler.WriteToken(token);
      return jwt;
    }

    public AuthenticationTicket Unprotect(string protectedText)
    {
      throw new NotImplementedException();
    }
  }
}