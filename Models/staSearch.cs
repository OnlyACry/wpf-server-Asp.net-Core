﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public partial class staSearch
    {
        public string RecordNo { get; set; }
        public double TotalWater { get; set; }
        public DateTime PoolTime { get; set; }
    }
}
