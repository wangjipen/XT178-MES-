using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.Moudle
{
    [Table("C_MATERIAL_TRACE_T")]
    class MaterialTraceObject
    {
        [Key]
        public virtual int ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }
        [Column("ST")]
        public string ST { get; set; }
        [Column("SN")]
        public string SN { get; set; }
        [Column("MATERIAL_NAME")]
        public string MATERIAL_NAME { get; set; }
        [Column("MATERIAL_NO")]
        public string MATERIAL_NO { get; set; }
        [Column("MATERIAL_NUM")]
        public int MATERIAL_NUM { get; set; }
    }
}
