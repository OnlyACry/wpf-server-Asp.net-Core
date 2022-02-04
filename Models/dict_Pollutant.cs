using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("dict_Pollutant")]
    public partial class dict_Pollutant
    {
        [Key]
        public Guid PollutantUid { get; set; }
        [StringLength(30)]
        public string PollutantType { get; set; }
        [StringLength(10)]
        public string PollutantCode { get; set; }
        [StringLength(30)]
        public string PollutantName { get; set; }
        [StringLength(50)]
        public string PollutantCompany { get; set; }
        [StringLength(20)]
        public string PollutantStandard { get; set; }
        [StringLength(10)]
        public string PollutantUnit { get; set; }
        [StringLength(10)]
        public string PollutantVolume { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
