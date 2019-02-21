using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.Moudle
{
    [Table("P_ASM_REWORK_RESON_T")]
    public class AsmReworkResonObject
    { 
        [Key]
        public virtual int ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }
        [Column("SN")]
        public string SN { get; set; }
        [Column("TYPE")]
        public string Type { get; set; }
        [Column("RESON")]
        public string Reson { get; set; }
    }
}
