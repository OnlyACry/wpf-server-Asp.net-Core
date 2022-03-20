using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("dict_Company")]
    public partial class dict_Company
    {
        [Key]
        public Guid CompanyUid { get; set; }
        [StringLength(10)]
        public string CompanyCode { get; set; }
        [StringLength(30)]
        public string CompanyName { get; set; }
        [StringLength(150)]
        public string FilePath { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
