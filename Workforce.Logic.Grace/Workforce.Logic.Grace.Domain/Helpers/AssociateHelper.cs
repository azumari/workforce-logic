using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Grace.Domain.BusinessModels.Dtos;
using Workforce.Logic.Grace.Domain.TransferModels.Dtos;

namespace Workforce.Logic.Grace.Domain.Helpers
{
  public class AssociateHelper
  {
    private readonly LogicHelper logicHelper = new LogicHelper();
    private readonly Consumers consumerHelper = new Consumers();

    public async Task<bool> InsertAssociateToRoom(InsertAssociateDto associate)
    {
      //FIND THE ASSOCIATE FROM A LIST OF ASSOCIATES
      AssociateDto assoc = (await consumerHelper.ConsumeAssociatesFromAPI()).Find(id => id.AssociateID.Equals(associate.AssociateId));
      //FIND THE APARTMENT
      ApartmentDto aptDto = (await logicHelper.ApartmentsGetAll()).Find(id => id.RoomID.Equals(associate.RoomId));

      HousingDataDto data = new HousingDataDto()
      {
        AssociateID = assoc.AssociateID,
        MoveInDate = DateTime.Now,
        MoveOutDate = DateTime.Now,
        RoomID = associate.RoomId,
        StatusID = 1
      };

      if (aptDto.CurrentCapacity < aptDto.MaxCapacity)
      {
        aptDto.CurrentCapacity++;
      }
      else
      {
        return false;
      }

      bool passed = await logicHelper.UpdateApartment(aptDto);
      bool passed2 = await logicHelper.AddHousingData(data);

      return (passed && passed2);
    }

    public async Task<bool> RemoveAssocFromRoom(InsertAssociateDto associate)
    {
      //FIND THE ASSOCIATE FROM A LIST OF ASSOCIATES
      AssociateDto assoc = (await consumerHelper.ConsumeAssociatesFromAPI()).Find(id => id.AssociateID.Equals(associate.AssociateId));
      //FIND THE APARTMENT
      ApartmentDto aptDto = (await logicHelper.ApartmentsGetAll()).Find(id => id.RoomID.Equals(associate.RoomId));

      //FIND THE HousingData
      HousingDataDto data = (await logicHelper.HousingDataGetAll()).Find(id => id.AssociateID.Equals(associate.AssociateId));

      //update the status to 3  WHERE THREE MEANS TO DELETE
      data.StatusID = 3;

      if (aptDto.CurrentCapacity > 0)
      {
        aptDto.CurrentCapacity--;
      }
      else
      {
        return false;
      }

      bool passed = await logicHelper.UpdateApartment(aptDto);
      bool passed2 = await logicHelper.UpdateHousingData(data);

      return (passed && passed2);

    }



    public async Task<bool> ChangeAssocToDifferentRoom(InsertAssociateDto associate)
    {
      throw new NotImplementedException();
    }







    public async Task<List<AssociateDto>> AssociatesGetActive()
    {
      throw new NotImplementedException();
    }

    public async Task<List<AssociateDto>> AssociatesGetAll()
    {
      throw new NotImplementedException();
    }
  }

}
