using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("tb_FlowLog")]
    public partial class tb_FlowLog
    {
        [Key]
        public Guid FlowLogUID { get; set; }
        public Guid ParentUID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FlowTime { get; set; }
        [StringLength(30)]
        public string FlowType { get; set; }
        [StringLength(30)]
        public string FlowName { get; set; }
        [StringLength(550)]
        public string FlowContent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FlowResult { get; set; }
        [StringLength(30)]
        public string OperUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
    }
}
