using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.Moudle
{
    [Table("C_ASM_RECIPE_T")]
    class AsmRecipeObject
    {
        [Key]
        public virtual int RECIPE_ID { get; set; }
        [Column("RECIPE_NAME")]
        public string RECIPE_NAME { get; set; }
        [Column("RECIPE_DISCRIPTION")]
        public string RECIPE_DISCRIPTION { get; set; }
    }
}
