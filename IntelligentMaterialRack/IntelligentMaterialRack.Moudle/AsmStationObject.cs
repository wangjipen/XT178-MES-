using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.Moudle
{
    [Table("C_ASM_STATION_T")]
    class AsmStationObject
    {
        [Key]
        public virtual int STATION_ID { get; set; }
        [Column("STATION_INDEX")]
        public string STATION_INDEX { get; set; }
        [Column("STATION_NAME")]
        public string STATION_NAME { get; set; }
        [Column("STATION_PROCESSOK")]
        public string STATION_PROCESSOK { get; set; }
        [Column("STATION_DATAOK")]
        public string STATION_DATAOK { get; set; }
        [Column("STATION_TYPE")]
        public string STATION_TYPE { get; set; }
        [Column("STATION_RECIPEORNOT")]
        public string STATION_RECIPEORNOT { get; set; }
        [Column("STATION_AGVORNOT")]
        public string STATION_AGVORNOT { get; set; }
        [Column("STATION_REQUSTOUTLINE")]
        public string STATION_REQUSTOUTLINE { get; set; }
        [Column("STATION_LIGHTORNOT")]
        public string STATION_LIGHTORNOT { get; set; }
        [Column("STATION_REQUSTIN")]
        public string STATION_REQUSTIN { get; set; }
        [Column("STATION_REVIEWORNOT")]
        public string STATION_REVIEWORNOT { get; set; }
        [Column("STATION_PRINTORNOT")]
        public string STATION_PRINTORNOT { get; set; }
        [Column("STATION_UPLOADMES")]
        public string STATION_UPLOADMES { get; set; }
        [Column("STATION_ENDORNOT")]
        public string STATION_ENDORNOT { get; set; }
        [Column("STATION_GUNORNOT")]
        public string STATION_GUNORNOT { get; set; }
        [Column("STATION_AUTOORNOT")]
        public string STATION_AUTOORNOT { get; set; }
        [Column("STATION_TIME")]
        public int STATION_TIME { get; set; }
    }
}
