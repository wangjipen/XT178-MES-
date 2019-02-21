using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.Moudle
{
    [Table("C_ASM_RECIPE_DATIL_T")]
    class AsmRecipeDetailObject
    {
        [Key]
        public virtual int RECIPE_DATIL_ID { get; set; }
        [Column("StepNo")]
        public string StepNo { get; set; }
        [Column("Step_Category")]
        public string Step_Category { get; set; }
        [Column("Material_Name")]
        public string Material_Name { get; set; }
        [Column("Number")]
        public string Number { get; set; }
        [Column("Gun_No")]
        public string Gun_No { get; set; }
        [Column("Program_No")]
        public string Program_No { get; set; }
        [Column("Photo_No")]
        public string Photo_No { get; set; }
        [Column("Sleeve_No")]
        public string Sleeve_No { get; set; }
        [Column("ReworkTimes")]
        public string ReworkTimes { get; set; }
        [Column("Feacode")]
        public string Feacode { get; set; }
        [Column("CheckOrNo")]
        public string CheckOrNo { get; set; }
        [Column("ReviewOrNo")]
        public string ReviewOrNo { get; set; }
        [Column("ExactOrNo")]
        public string ExactOrNo { get; set; }
        [Column("MaterialPn")]
        public string MaterialPn { get; set; }
        [Column("BoltEQS")]
        public string BoltEQS { get; set; }
        [Column("A_Limit")]
        public string A_Limit { get; set; }
        [Column("T_Limit")]
        public string T_Limit { get; set; }
        [Column("RECIPE_ID")]
        public int RECIPE_ID { get; set; }
        
        [Column("T_Target")]
        public string T_Target { get; set; }
        [Column("T_Limits")]
        public string T_Limits { get; set; }
        [Column("L_Program")]
        public string L_Program { get; set; }
        [Column("L_Rate")]
        public string L_Rate { get; set; }

        [Column("PICPath")]
        public string PICPath { get; set; }
    }
}
