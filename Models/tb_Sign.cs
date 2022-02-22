using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    [Table("tb_Sign")]
    public partial class tb_Sign
    {
        [Key]
        public Guid SignUID { get; set; }
        [StringLength(30)]
        public string SignCode { get; set; }
        [StringLength(30)]
        public string SignSym { get; set; }
        public int? IsOpen { get; set; }
        [StringLength(30)]
        public string SignExplain { get; set; }
        [StringLength(30)]
        public string Memo { get; set; }
    }
}
