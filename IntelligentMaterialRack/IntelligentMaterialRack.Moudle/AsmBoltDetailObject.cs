using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.Moudle
{
    [Table("C_ASM_BOLT_DETAIL_T")]
    class AsmBoltDetailObject
    {
        [Key]
        public virtual int ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }
        [Column("SN")]
        public string SN { get; set; }
        [Column("ST")]
        public string ST { get; set; }
        [Column("T")]
        public string T { get; set; }
        [Column("A")]
        public string A { get; set; }
        [Column("P")]
        public string P { get; set; }
        [Column("C")]
        public string C { get; set; }
        [Column("R")]
        public string R { get; set; }
        [Column("EQS")]
        public string EQS { get; set; }
        [Column("A_LIMIT")]
        public string A_LIMIT { get; set; }
        [Column("T_LIMIT")]
        public string T_LIMIT { get; set; }
        [Column("WID")]
        public string WID { get; set; }
        [Column("TID")]
        public string TID { get; set; }
        [Column("KEYPART_ID")]
        public int KEYPART_ID { get; set; }
        [Column("KEYPART_NAME")]
        public string KEYPART_NAME { get; set; }
    }
}
