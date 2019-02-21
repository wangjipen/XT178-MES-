using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTrackClient.SKTrackClient.Moudle
{
    [Table("P_ASM_LEAKAGE_T")]
    class AsmLeakageObject
    {
        [Key]
        public virtual int ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }
        [Column("ST")]
        public string ST { get; set; }
        [Column("SN")]
        public string SN { get; set; }
        [Column("LEAKAGE_NAME")]
        public string LEAKAGE_NAME { get; set; }
        [Column("LEAKAGE_PV")]
        public string LEAKAGE_PV { get; set; }
        [Column("LEAKAGE_LV")]
        public string LEAKAGE_LV { get; set; }
        [Column("LEAKAGE_R")]
        public string LEAKAGE_R { get; set; }
        [Column("EMP")]
        public string EMP { get; set; }
        [Column("Transfer")]
        public int Transfer { get; set; }
    }
}
