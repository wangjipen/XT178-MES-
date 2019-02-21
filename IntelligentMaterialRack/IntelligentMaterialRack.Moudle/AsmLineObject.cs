using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.Moudle
{
    [Table("C_PMS_LINE_T")] //映射User类
    class AsmLineObject
    {
        [Key]
        public virtual int ID { get; set; }
        [Column("DT")]
        public DateTime DT { get; set; }
        [Column("NAME")]
        public string NAME { get; set; }
        [Column("DSC")]
        public string DSC { get; set; }
    }
}
