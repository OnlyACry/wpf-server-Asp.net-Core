using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Common.Models
{
    [Table("dict_Comm")]
    public partial class DictComm
    {
        [Key]
        public Guid CommUid { get; set; }
        [StringLength(10)]
        public string CommCode { get; set; }
        [StringLength(30)]
        public string CommName { get; set; }
        public int? CommNo { get; set; }
        [StringLength(10)]
        public string CommMode { get; set; }
        public int? ComIndex { get; set; }
        public int? AsServer { get; set; }
        [Column("LocalTcpIP")]
        [StringLength(20)]
        public string LocalTcpIp { get; set; }
        [StringLength(10)]
        public string LocalTcpPort { get; set; }
        [Column("RemoteTcpIP")]
        [StringLength(20)]
        public string RemoteTcpIp { get; set; }
        [StringLength(10)]
        public string RemoteTcpPort { get; set; }
        public int? IsValid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OperTime { get; set; }
        [StringLength(18)]
        public string OperUser { get; set; }
        [StringLength(150)]
        public string Memo { get; set; }
    }
}
