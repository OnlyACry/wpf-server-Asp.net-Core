using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("dict_DecayPool")]
    public partial class dict_DecayPool
    {
        [Key]
        public Guid DecayPoolUid { get; set; }
        [StringLength(30)]
        public string DecayPoolType { get; set; }
        [StringLength(10)]
        public string DecayPoolCode { get; set; }
        [StringLength(30)]
        public string DecayPoolName { get; set; }
        [StringLength(50)]
        public string DecayPoolRecord { get; set; }
        [StringLength(30)]
        public string DecayPoolPosition { get; set; }
        [StringLength(20)]
        public string DecayPoolStandard { get; set; }
        [StringLength(10)]
        public string DecayPoolUnit { get; set; }
        [StringLength(10)]
        public string DecayPoolVolume { get; set; }
        [StringLength(10)]
        public string DecayPoolMax { get; set; }
        [StringLength(10)]
        public string DecayPoolMin { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
        public int? Holdtime { get; set; }
    }
}
