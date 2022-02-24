using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("tb_Pollutant_zs_yt")]
    public partial class tb_Pollutant_zs_yt
    {
        [Key]
        public Guid PollutantUID { get; set; }
        [StringLength(10)]
        public string PollutantCode { get; set; }
        [StringLength(30)]
        public string PollutantName { get; set; }
        [StringLength(50)]
        public string PollutantNo { get; set; }
        [StringLength(50)]
        public string PollutantCount { get; set; }
        [StringLength(30)]
        public string UnitCode { get; set; }
        [StringLength(50)]
        public string UnitName { get; set; }
        [StringLength(30)]
        public string PositionCode { get; set; }
        [StringLength(50)]
        public string PositionName { get; set; }
        [StringLength(50)]
        public string SourceCode { get; set; }
        [StringLength(50)]
        public string SourceName { get; set; }
        [StringLength(30)]
        public string ContainerCode { get; set; }
        [StringLength(50)]
        public string ContainerName { get; set; }
        [StringLength(30)]
        public string MedCode { get; set; }
        [StringLength(50)]
        public string MedName { get; set; }
        [StringLength(30)]
        public string MedClearTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProcessTime { get; set; }
        [StringLength(50)]
        public string ProcessUser { get; set; }

        public string ProcessName { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
