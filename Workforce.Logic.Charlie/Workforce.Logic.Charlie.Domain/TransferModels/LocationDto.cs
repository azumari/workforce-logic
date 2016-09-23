﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Charlie.Domain.BusinessModels
{
    public class LocationDto
    {

        public int LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [StringLength(100),Required]
        public string Address { get; set; }
        [StringLength(50),Required]
        public string StopName { get; set; }
    }
}
