using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workforce.Logic.Felice.Rest.Infrastructure;
using Workforce.Logic.Felice.Rest.Models;

namespace Workforce.Logic.Felice.Rest.Controllers
{
  [RoutePrefix("api/accounts")]
  public class AccountsController : BaseApiController
  {
    /// <summary>
    /// return all registered users in our
    /// system by calling the ApplicationUserManager Class
    /// </summary>
    /// <returns></returns>
    [Route("user")]
    public IHttpActionResult GetUsers()
    {
      return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
    }

    /// <summary>
    /// Return just a single user by getting its
    /// ID and calling the FindByIdAsync to do it
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("user/{id:guid}", Name = "GetUserById")]
    public async Task<IHttpActionResult> GetUser(string Id)
    {
      var user = await this.AppUserManager.FindByIdAsync(Id);

      if(user != null)
      {
        return Ok(this.TheModelFactory.Create(user));
      }

      return NotFound();
    }


    /// <summary>
    /// Return just a single user by getting its
    /// username coming from the AppUserManager
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    [Route("user/{username}")]
    public async Task<IHttpActionResult> GetUserByName(string username)
    {
      var user = await this.AppUserManager.FindByNameAsync(username);

      if (user != null)
      {
        return Ok(this.TheModelFactory.Create(user));
      }

      return NotFound();
    }

    [Route("create")]
    public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var user = new ApplicationUser
      {
        UserName = createUserModel.Username,
        Email = createUserModel.Email,
        FirstName = createUserModel.FirstName,
        LastName = createUserModel.LastName,
        Level = 3,
        JoinDate = DateTime.Now.Date
      };

      IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);

      if(!addUserResult.Succeeded)
      {
        return GetErrorResult(addUserResult);
      }

      Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

      return Created(locationHeader, TheModelFactory.Create(user));
    }
  }
}