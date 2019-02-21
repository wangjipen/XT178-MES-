using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace IntelligentMaterialRack.IntelligentMaterialRack.Moudle
{
    [Table("C_ASM_PRODUCTION_WAY_T_Record")]
    public  class AsmProductionWayRecordObject
    {
        [Key]
        public virtual int ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }

        [Column("PRODUCTION_NAME")]
        public string PRODUCTION_NAME { get; set; }

        [Column("PRODUCTION_ID")]
        public int  PRODUCTION_ID { get; set; }

        [Column("ST_NAME")]
        public string ST_NAME { get; set; }

        [Column("ST_ID")]
        public int ST_ID { get; set; }

        [Column("SERIAL_NO")]
        public int SERIAL_NO { get; set; }
    }
}
