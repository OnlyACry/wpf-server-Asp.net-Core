using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("tb_DecayPool")]
    public partial class tb_DecayPool
    {
        [Key]
        public Guid DecayPoolUID { get; set; }
        [StringLength(10)]
        public string DecayPoolCode { get; set; }
        [StringLength(30)]
        public string DecayPoolName { get; set; }
        [StringLength(50)]
        /// <summary>
        /// 记录日期
        /// </summary>
        public DateTime? DecayPoolTime { get; set; }
        [StringLength(18)]
        public string RecordNo { get; set; }
        [StringLength(30)]
        public string WorkMode { get; set; }
        public int? PatientNum { get; set; }
        [StringLength(30)]
        public string PreWater { get; set; }
        [StringLength(50)]
        public string OtherWater { get; set; }
        [StringLength(30)]
        public string WaterTotal { get; set; }
        [StringLength(50)]
        public string ReferValue { get; set; }
        [StringLength(50)]
        public string IntervalTime { get; set; }
        public int? State { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        public int? IsValid { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
