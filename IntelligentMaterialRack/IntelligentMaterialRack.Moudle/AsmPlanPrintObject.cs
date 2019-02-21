using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace IntelligentMaterialRack.IntelligentMaterialRack.Moudle
{
    [Table("R_PLAN_PRINT_T")]
    class AsmPlanPrintObject
    {
        [Key]
        public virtual int ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }

        [Column("SN")]
        public string SN { get; set; }

        [Column("PLAN_ID")]
        public int PLAN_ID { get; set; }

        [Column("LINE_ID")]
        public int LINE_ID { get; set; }

        [Column("PRODUCTION_ID")]
        public int PRODUCTION_ID { get; set; }

        [Column("SERIAL_NO")]
        public int SERIAL_NO { get; set; }


        [Column("PRINT_FLAG")]
        public string PRINT_FLAG { get; set; }
    }
}
