using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Table("tb_Ry")]
    public partial class tb_Ry
    {
        [Key]
        public Guid ryId { get; set; }
        [StringLength(30)]
        public string ryCode { get; set; }
        [StringLength(30)]
        public string ryName { get; set; }
        [StringLength(20)]
        public string rySex { get; set; }
        [StringLength(20)]
        public string ryAge { get; set; }
        [StringLength(20)]
        public string ryZc { get; set; }
        public int? ryIsValid { get; set; }
        [StringLength(20)]
        public string ryMemo { get; set; }
    }
}
