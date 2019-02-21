using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.Moudle
{
    [Table("C_ASM_PRODUCTION_T")]
    class AsmProductionObject
    {
        [Key]
        public virtual int PRODUCTION_ID { set; get; }
        [Column("PRODUCTION_NAME")]
        public string PRODUCTION_NAME { set; get; }
        [Column("PRODUCTION_TYPE")]
        public string PRODUCTION_TYPE { set; get; }
        [Column("PRODUCTION_TRADEMARK")]
        public string PRODUCTION_TRADEMARK { set; get; }
        [Column("PRODUCTION_SERIES")]
        public string PRODUCTION_SERIES { set; get; }
        [Column("PRODUCTION_VR")]
        public string PRODUCTION_VR { set; get; }
        [Column("PRODUCTION_DISCRIPTION")]
        public string PRODUCTION_DISCRIPTION { set; get; }
        [Column("STATION_NAME")]
        public string STATION_NAME { set; get; }
        [Column("PRODUCTION_ET")]
        public string PRODUCTION_ET { set; get; }
        [Column("PRODUCTION_GT")]
        public string PRODUCTION_GT { set; get; }
        [Column("PRODUCTION_STE")]
        public string PRODUCTION_STE { set; get; }
    }
}
