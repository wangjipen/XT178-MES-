using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.Moudle
{
    [Table("R_ASM_TRACKING_T")]
    class AsmRTrackingObject
    {
        [Key]
        public virtual int R_TRACKING_ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }
        [Column("ST")]
        public string ST { get; set; }
        [Column("BST")]
        public string BST { get; set; }
        [Column("SN")]
        public string SN { get; set; }
        [Column("EngineSN")]
        public string EngineSN { get; set; }
        [Column("GearboxSN")]
        public string GearboxSN { get; set; }
        [Column("TypeName")]
        public string TypeName { get; set; }
        [Column("TrayNum")]
        public string TrayNum { get; set; }
        [Column("ProductNum")]
        public string ProductNum { get; set; }
        [Column("STATUS")]
        public string STATUS { get; set; }
        [Column("PLAN_ID")]
        public int PLAN_ID { get; set; }
        [Column("REWORK_FLAG")]
        public string REWORK_FLAG { get; set; }
    }
}
