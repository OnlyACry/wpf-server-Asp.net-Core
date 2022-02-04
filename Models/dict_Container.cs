using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("dict_Container")]
    public partial class dict_Container
    {
        [Key]
        public Guid ContainerUid { get; set; }
        [StringLength(10)]
        public string ContainerCode { get; set; }
        [StringLength(30)]
        public string ContainerName { get; set; }
        [StringLength(50)]
        public string ContainerNo { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
