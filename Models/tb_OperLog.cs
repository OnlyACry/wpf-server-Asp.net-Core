using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("tb_OperLog")]
    public partial class tb_OperLog
    {
        [Key]
        public Guid OperLogUID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(30)]
        public string OperUser { get; set; }
        [StringLength(50)]
        public string OperType { get; set; }
        [StringLength(150)]
        public string OperContent { get; set; }
        public int? IsValid { get; set; }
    }
}
