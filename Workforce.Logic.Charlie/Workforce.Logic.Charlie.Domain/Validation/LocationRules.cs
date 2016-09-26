using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Charlie.Domain.BusinessModels;
using Workforce.Logic.Charlie.Domain.WorkforceService;

namespace Workforce.Logic.Charlie.Domain.Validation
{
    public class LocationRules
    {
        public bool Test (LocationDao loc)
        {
            return true;
        }
    }
}
