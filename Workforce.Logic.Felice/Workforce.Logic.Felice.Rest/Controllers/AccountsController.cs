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

    /// <summary>
    /// Creates the new user
    /// </summary>
    /// <param name="createUserModel"></param>
    /// <returns></returns>
    [Route("create")]
    public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
    {
      //If the model is valid,
      //We will use it to create
      //a new instance of ApplicationUser
      if(!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      //The user's credentials
      //By default, the user
      //will always be level 3
      var user = new ApplicationUser
      {
        UserName = createUserModel.Username,
        Email = createUserModel.Email,
        FirstName = createUserModel.FirstName,
        LastName = createUserModel.LastName,
        Level = 3,
        JoinDate = DateTime.Now.Date
      };

      //This will do the work for us to create the user
      //It will validate if the username or email has been used before
      //and will let us know if the password matches the policy we have set forth
      //If the request is valid, the user will be added to our table in
      //the database and return a successful result
      IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);


      //If the creation failed
      if(!addUserResult.Succeeded)
      {
        return GetErrorResult(addUserResult);
      }

      //This will have the token that is valid for 6 hours only when we call this method
      string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

      var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

      await this.AppUserManager.SendEmailAsync(user.Id, "Confirm Your Account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

      Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

      //returns the created user
      return Created(locationHeader, TheModelFactory.Create(user));
    }

    [HttpGet]
    [Route("ConfirmEmail", Name="ConfirmEmailRoute")]
    public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
    {
      if(string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
      {
        ModelState.AddModelError("", "User Id and Code are required");
        return BadRequest(ModelState);
      }

      //If email is opened and user clicks the link
      //as long as the token is still active 
      //the result will have a successful value.
      IdentityResult result = await this.AppUserManager.ConfirmEmailAsync(userId, code);

      if(result.Succeeded)
      {
        return Ok();
      }

      else
      {
        return GetErrorResult(result);
      }
    }

    [Route("ChangePassword")]
    public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IdentityResult result = await this.AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

      if(!result.Succeeded)
      {
        return GetErrorResult(result);
      }

      return Ok();
    }
  }
}