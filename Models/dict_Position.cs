using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("dict_Position")]
    public partial class dict_Position
    {
        [Key]
        public Guid PositionUid { get; set; }
        [StringLength(10)]
        public string PositionCode { get; set; }
        [StringLength(30)]
        public string PositionName { get; set; }
        [StringLength(50)]
        public string PositionNo { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
