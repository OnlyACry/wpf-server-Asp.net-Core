using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("dict_Area")]
  public  class dict_Area
    {
        [Key]
        public Guid AreaUid { get; set; } = new Guid();
        [StringLength(30)]
        public string AreaCode { get; set; }
        [StringLength(30)]
        public string AreaName { get; set; }
        public int? AreaNo { get; set; }
        [StringLength(30)]
        public string Memo { get; set; }
    }
}
