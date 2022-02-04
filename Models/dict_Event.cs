using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Keyless]
    [Table("dict_Event")]
    public partial class dict_Event
    {
        public Guid? EventUid { get; set; }
        [StringLength(10)]
        public string EventCode { get; set; }
        [StringLength(30)]
        public string EventName { get; set; }
        public int? EventNo { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
