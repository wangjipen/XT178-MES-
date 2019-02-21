using SKTraceablity.SKTraceablity.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.BLL
{
    class AsmRecipe_BLL
    {
        public static int AddAsmRecipeByObject(AsmRecipeObject aro)
        {
            int a = AsmRecipe_DAL.AddAsmRecipeByObject(aro);
            return a;
        }  
        public static int UpdateAsmRecipeByObject(AsmRecipeObject pcb)
        {
            int a = AsmRecipe_DAL.UpdateAsmRecipeByObject(pcb);
            return a;
        }
        public static AsmRecipeObject GetAsmRecipeByObject(string sql)
        {
            AsmRecipeObject aro = AsmRecipe_DAL.GetAsmRecipeByObject(sql);
            return aro;
        }
        public static DataTable GetAllRecipeByCondition()
        {
            DataTable dt = AsmRecipe_DAL.GetAllRecipeByCondition();
            return dt;
        }
        public static AsmRecipeObject GetRecipeByCondition(string sql)
        {
            AsmRecipeObject aro = AsmRecipe_DAL.GetRecipeByCondition(sql);
            return aro;
        }
        public static int DeleteRecipeByObject(AsmRecipeObject pcb)
        {
            int a = AsmRecipe_DAL.DeleteRecipeByObject(pcb);
            return a;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="aro"></param>
        /// <returns></returns>
        public static int DeleteProductionRecipe(AsmRecipeObject aro)
        {
            int a = AsmRecipe_DAL.DeleteProductionRecipe(aro);
            return a;
        }
    }
}
