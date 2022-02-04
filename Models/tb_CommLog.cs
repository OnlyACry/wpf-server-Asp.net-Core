using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("tb_CommLog")]
    public partial class tb_CommLog
    {
        [Key]
        public Guid CommLogUID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CommTime { get; set; }
        [StringLength(30)]
        public string CommType { get; set; }
        [StringLength(550)]
        public string CommContent { get; set; }
        [StringLength(30)]
        public string CommFlow { get; set; }
        public int? CommResult { get; set; }
    }
}
