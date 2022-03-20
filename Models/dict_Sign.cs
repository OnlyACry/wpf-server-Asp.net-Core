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
    [Table("dict_Sign")]
   public partial class dict_Sign
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Key]
        public Guid SignUID { get; set; }
        /// <summary>
        /// 记录编号
        /// </summary>
        [StringLength(30)]
        public string SignCode { get; set; }
        /// <summary>
        /// 记录标志
        /// </summary>
        [StringLength(30)]
        public string SignSym { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int? IsOpen { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [StringLength(30)]
        public string SignExplain { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(30)]
        public string Memo { get; set; }
    }
}
