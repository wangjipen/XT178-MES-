using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.Moudle
{
    [Table("R_ASM_REWORK_WAY_T")]
    class AsmReworkWayObject
    {
        [Key]
        public virtual int ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }
        [Column("SN")]
        public string SN { get; set; }
        [Column("ST_NAME")]
        public string ST_NAME { get; set; }
        [Column("ST_ID")]
        public int ST_ID { get; set; }
        [Column("SERIAL_NO")]
        public int SERIAL_NO { get; set; }
    }
}
