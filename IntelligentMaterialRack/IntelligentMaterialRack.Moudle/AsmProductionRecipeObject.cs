using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.Moudle
{
    [Table("C_ASM_PRODUCTION_RECIPE_T")]
    class AsmProductionRecipeObject
    {
        [Key]
        public virtual int PRODUCTION_RECIPE_ID { get; set; }
        [Column("PRODUCTION_ID")]
        public int PRODUCTION_ID { get; set; }
        [Column("RECIPE_ID")]
        public int RECIPE_ID { get; set; }
        [Column("STATION_ID")]
        public int STATION_ID { get; set; }
    }
}
