using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("Tab_operator")]
    public partial class Tab_operator
    {
        [Key]
        public int opid { get; set; }
        [StringLength(10)]
        public string op_code { get; set; }
        [StringLength(30)]
        public string op_name { get; set; }
        public int? op_psw { get; set; }
        [StringLength(10)]
        public string op_sex { get; set; }
        public int? op_valid { get; set; }
        [StringLength(50)]
        public string Memo { get; set; }
        public int? age { get; set; }
        [StringLength(50)]
        public string zc { get; set; }
    }
}
