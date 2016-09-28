using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Grace.Domain.TransferModels.Dtos
{
  public class D3Projection
  {
    //stuff from Batch
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int count { get; set; }
    //stuff from both TRAINEE and BATCH
    public int BatchID { get; set; }

    public DateTime TestDate { get; set; }
  }
}
