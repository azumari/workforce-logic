using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Workforce.Logic.Grace.Domain.Helpers;
using Workforce.Logic.Grace.Domain.TransferModels.Dtos;

namespace Workforce.Logic.Grace.Rest.Controllers
{
  public class AssociateController : ApiController
  {

    //AssociatesGetByApartment()AssociatesGetRoomless

    AssociateHelper associateHelper = new AssociateHelper();

    public async Task<HttpResponseMessage> Get([FromUri] InsertAssociateDto associate)
    {
      if (associate.AssociateId.Equals(-1))
      {
        return Request.CreateResponse(HttpStatusCode.OK, await associateHelper.AssociatesGetRoomless());
      }
      return Request.CreateResponse(HttpStatusCode.OK, await associateHelper.AssociatesGetByApartment(associate));
    }


    public async Task<HttpResponseMessage> Post([FromBody]InsertAssociateDto associate)
    {
      if (await associateHelper.InsertAssociateToRoom(associate))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "Successfully registered associate into a apartment room");
      }
      return Request.CreateResponse(HttpStatusCode.OK, "failed to insert associate into a apartment room");
    }

    public async Task<HttpResponseMessage> Put([FromBody]InsertAssociateDto associate)
    {
      if (await associateHelper.ChangeAssocToDifferentRoom(associate))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successfully moved associate to another apartment room");
      }
      return Request.CreateResponse(HttpStatusCode.OK, "failed to move associate to another apartment room");
    }

    public async Task<HttpResponseMessage> Delete([FromBody]InsertAssociateDto associate)
    {
      if (await associateHelper.RemoveAssocFromRoom(associate))
      {
        return Request.CreateResponse(HttpStatusCode.OK, "successfully removed associate from apartment room");
      }
      return Request.CreateResponse(HttpStatusCode.OK, "failed to remove assocaiate from apartment room");
    }
  }
}
