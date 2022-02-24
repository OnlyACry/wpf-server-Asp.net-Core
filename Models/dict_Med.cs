using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("dict_Med")]
    public partial class dict_Med
    {
        [Key]
        public Guid MedUid { get; set; }
        [StringLength(30)]
        public string MedName { get; set; }
        [StringLength(10)]
        public string MedHalfTime { get; set; }
        [StringLength(30)]
        public string MedCode { get; set; }
        public int? IsValid { get; set; }
        [StringLength(50)]
        public string MedCompany { get; set; }
        [StringLength(20)]
        public string MedStandard { get; set; }
        [StringLength(10)]
        public string MedUnit { get; set; }
        [StringLength(10)]
        public string MedVolume { get; set; }
        [StringLength(20)]
        public string MedType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(20)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }

        public string CnName { get; set; }
    }
}
