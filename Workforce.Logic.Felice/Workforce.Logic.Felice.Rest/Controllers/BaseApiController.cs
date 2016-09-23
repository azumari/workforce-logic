using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workforce.Logic.Felice.Rest.Infrastructure;
using Workforce.Logic.Felice.Rest.Models;

namespace Workforce.Logic.Felice.Rest.Controllers
{
  public class BaseApiController : ApiController
  {
    private ModelFactory modelFactory;
    private ApplicationUserManager appUserManager = null;

    /// <summary>
    /// Gets instance of ApplicationUserManager that
    /// we already set up in the Startup class
    /// </summary>
    protected ApplicationUserManager AppUserManager
    {
      get
      {
        return appUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
      }
    }

    public BaseApiController()
    {
    }


    /// <summary>
    /// Returns an instance of ModelFactory class
    /// This pattern will help us in controlling
    /// the response returned to the client.
    /// This is important because we don't want to leak
    /// sensitive information such as the Password Hash to the client
    /// </summary>
    protected ModelFactory TheModelFactory
    {
      get
      {
        if(modelFactory == null)
        {
          modelFactory = new ModelFactory(this.Request, this.AppUserManager);
        }

        return modelFactory;
      }
    }

    /// <summary>
    /// Takes Identity Result as a constructor
    /// and formats the error message returned to the client
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    protected IHttpActionResult GetErrorResult(IdentityResult result)
    {
      if (result == null)
      {
        return InternalServerError();
      }

      if (!result.Succeeded)
      {
        if (result.Errors != null)
        {
          foreach (string error in result.Errors)
          {
            ModelState.AddModelError("", error);
          }
        }

        if (ModelState.IsValid)
        {
          // No ModelState errors are available to send, so just return an empty BadRequest.
          return BadRequest();
        }

        return BadRequest(ModelState);
      }

      return null;
    }

  }
}
