using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.Moudle
{
    [Table("C_ASM_ALARM_CODE_T")]
    class AsmAlarmCodeObject
    {
        [Key]
        public virtual int ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }
        [Column("ALARM_CODE")]
        public int ALARM_CODE { get; set; }
        [Column("ALARM_TEXT")]
        public string ALARM_TEXT { get; set; }
        [Column("ALARM_ENGLISH")]
        public string ALARM_ENGLISH { get; set; }
    }
}
