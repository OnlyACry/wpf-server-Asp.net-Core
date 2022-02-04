using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("dict_PUnit")]
    public partial class dict_PUnit
    {
        [Key]
        public Guid PUnitUid { get; set; }
        [StringLength(10)]
        public string PUnitCode { get; set; }
        [StringLength(30)]
        public string PUnitName { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
