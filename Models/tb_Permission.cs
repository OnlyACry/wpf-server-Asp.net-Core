using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Common.Models
{
    [Keyless]
    [Table("tb_Permission")]
    public partial class tb_Permission
    {
        [StringLength(30)]
        public Guid PermissionUID { get; set; }

        public string RoleName { get; set; }

        public string PermissionValue { get; set; }
    
    }
}
