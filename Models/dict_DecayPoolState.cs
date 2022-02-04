using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("dict_DecayPoolState")]
    public partial class dict_DecayPoolState
    {
        [Key]
        public Guid StateUid { get; set; }
        [StringLength(10)]
        public string StateCode { get; set; }
        [StringLength(30)]
        public string StateName { get; set; }
        public int? StateNo { get; set; }
        public int? IsValid { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
