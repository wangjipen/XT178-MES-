using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.Moudle
{
    [Table("R_PMS_PLAN_T")] //映射User类
   public  class AsmPlanObject
    {
        [Key]
        public virtual int ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }
        [Column("NAME")]
        public string NAME { get; set; }
        [Column("PRODUCTION_ID")]
        public int PRODUCTION_ID { get; set; }
        [Column("NUMBER")]
        public int NUMBER { get; set; }
        [Column("COMPLETE_NUMBER")]
        public int COMPLETE_NUMBER { get; set; }
        [Column("REMAIND_NUMBER")]
        public int REMAIND_NUMBER { get; set; }
        [Column("OK_NUMBER")]
        public int OK_NUMBER { get; set; }
        [Column("NG_NUMBER")]
        public int NG_NUMBER { get; set; }
        [Column("LINE_ID")]
        public int LINE_ID { get; set; }
        [Column("PLAN_LEVEL")]
        public int PLAN_LEVEL { get; set; }
        [Column("COMPLETE_FLAG")]
        public string COMPLETE_FLAG { get; set; }
        [Column("OPREATION_USER")]
        public string OPREATION_USER { get; set; }
        [Column("CREATE_BARCODE_FLAG")]
        public string CREATE_BARCODE_FLAG { get; set; }

    }
}
