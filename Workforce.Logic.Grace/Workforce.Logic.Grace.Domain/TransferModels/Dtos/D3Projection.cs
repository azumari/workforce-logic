﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Grace.Domain.TransferModels.Dtos
{
  public class D3Projection
  {
    //stuff from Batch
    public String Date{ get; set; }
    public int CurrentCapacity { get; set; }
    public int TotalMax { get; set; }
  }
}
