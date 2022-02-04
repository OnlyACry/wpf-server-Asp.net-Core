using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("tb_QCFile")]
    public partial class tb_QCFile
    {
        [Key]
        public Guid QCUID { get; set; }
        [StringLength(30)]
        public string QCCode { get; set; }
        [StringLength(30)]
        public string QCName { get; set; }
        [StringLength(30)]
        public string QCType { get; set; }
        [StringLength(30)]
        public string QCFormat { get; set; }
        [StringLength(150)]
        public string QCRoot { get; set; }
        [StringLength(550)]
        public string QCPath { get; set; }
        [StringLength(30)]
        public string QCFile { get; set; }
        [StringLength(30)]
        public string OperUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
    }
}
