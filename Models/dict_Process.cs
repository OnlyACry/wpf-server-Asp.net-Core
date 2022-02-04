using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("dict_Process")]
    public partial class dict_Process
    {
        [Key]
        public Guid ProcessUid { get; set; }
        [StringLength(10)]
        public string ProcessType { get; set; }
        [StringLength(10)]
        public string ProcessCode { get; set; }
        [StringLength(30)]
        public string ProcessName { get; set; }
        [StringLength(30)]
        public string ProcessNext { get; set; }
        [StringLength(50)]
        public string ProcessNo { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
