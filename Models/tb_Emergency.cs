using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("tb_Emergency")]
    public partial class tb_Emergency
    {
        [Key]
        public Guid EmergencyUID { get; set; }
        [StringLength(10)]
        public string EventCode { get; set; }
        [StringLength(30)]
        public string EventName { get; set; }
        [StringLength(50)]
        public string EventNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EventTime { get; set; }
        [StringLength(50)]
        public string ProcessName { get; set; }
        [StringLength(30)]
        public string ProcessCode { get; set; }
        [StringLength(30)]
        public string SourceCode { get; set; }
        [StringLength(50)]
        public string SourceName { get; set; }
        [StringLength(50)]
        public string EventPosition { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProcessTime { get; set; }
        [StringLength(50)]
        public string ProcessUser { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
