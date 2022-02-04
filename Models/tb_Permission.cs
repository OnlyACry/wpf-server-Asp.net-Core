using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Keyless]
    [Table("tb_Permission")]
    public partial class tb_Permission
    {
        [StringLength(30)]
        public string ryCode { get; set; }
        public int? WriteData { get; set; }
        public int? Search { get; set; }
        public int? StaOut { get; set; }
        public int? DicSet { get; set; }
        public int? RyADUS { get; set; }
        public int? Normal { get; set; }
        public int? NormalDel { get; set; }
    }
}
