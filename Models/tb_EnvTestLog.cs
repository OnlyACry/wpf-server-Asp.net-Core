using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    [Table("tb_EnvTestLog")]
    public partial  class tb_EnvTestLog
    {
        [Key]
        /// <summary>
        /// 唯一ID
        /// </summary>
        public Guid TestUID { get; set; }
        [StringLength(30)]

        public DateTime TestTime { get; set; }
        [StringLength(30)]
        /// <summary>
        /// 监控区域
        /// </summary>
        public string TestArea { get; set; }
        [StringLength(30)]
        /// <summary>
        /// 监控剂量
        /// </summary>
        public string TestDosage { get; set; }
        [StringLength(30)]

        /// <summary>
        /// 监测剂量单位
        /// </summary>
        public string TestDosageUnit { get; set; }
        [StringLength(30)]

        /// <summary>
        /// 监测人
        /// </summary>
        public string Tester { get; set; }
        [StringLength(30)]
        /// <summary>
        /// 监测代号
        /// </summary>
        public string TesterCode { get; set; }
    }
}
