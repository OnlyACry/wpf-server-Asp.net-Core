using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("dict_Comm")]
    public partial class dict_Comm
    {
        [Key]
        public Guid CommUid { get; set; }
        [StringLength(10)]
        public string CommCode { get; set; }
        [StringLength(30)]
        public string CommName { get; set; }
        public int? CommNo { get; set; }
        [StringLength(10)]
        public string CommMode { get; set; }
        public int? ComIndex { get; set; }
        public int? AsServer { get; set; }
        [StringLength(20)]
        public string LocalTcpIP { get; set; }
        [StringLength(10)]
        public string LocalTcpPort { get; set; }
        [StringLength(20)]
        public string RemoteTcpIP { get; set; }
        [StringLength(10)]
        public string RemoteTcpPort { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
