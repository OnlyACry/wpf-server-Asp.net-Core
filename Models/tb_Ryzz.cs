using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#nullable disable
namespace Common.Models
{
    [Table("tb_Ryzz")]
    public partial class tb_Ryzz
    {
        [Key]
        public Guid RyzzUID { get; set; }
        [StringLength(30)]
        public string DocumentCode { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(100)]
        public string FilePath { get; set; }
        public DateTime? UploadTime { get; set; }
        [StringLength(30)]
        public string UploadOper { get; set; }
    }
}
