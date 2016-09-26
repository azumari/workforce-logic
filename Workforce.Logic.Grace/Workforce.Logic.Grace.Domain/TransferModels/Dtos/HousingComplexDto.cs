using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Grace.Domain.BusinessModels.Dtos
{
  public class HousingComplexDto
  {
    //public int HousingComplexId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public bool IsHotel { get; set; }
    public string PhoneNumber { get; set; }
    public int HotelID { get; set; }
    public bool ActiveBit { get; set; }

  }
}
 