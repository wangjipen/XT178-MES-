using SKTraceablity.SKTraceablity.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.BLL
{
    class AsmProductionRecipe_BLL
    {
        public static int AddProductionRecipeByObject(AsmProductionRecipeObject apro)
        {
            int a = AsmProductionRecipe_DAL.AddProductionRecipeByObject(apro);
            return a;
        }
        public static int UpdateProductionRecipeByObject(AsmProductionRecipeObject apro)
        {
            int a = AsmProductionRecipe_DAL.UpdateProductionRecipeByObject(apro);
            return a;
        }
        public static int DeleteProductionRecipeByCondition(string sql)
        {
            int a = AsmProductionRecipe_DAL.DeleteProductionRecipeByCondition(sql);
            return a;
        }
        public static DataTable GetAllProductionRecipe()
        {
            DataTable dt = new DataTable();
            dt = AsmProductionRecipe_DAL.GetAllProductionRecipe();
            return dt;
        }
        public static AsmProductionRecipeObject GetProductionRecipeCondition(string sl)
        {
            AsmProductionRecipeObject apro = AsmProductionRecipe_DAL.GetProductionRecipeCondition(sl);
            return apro;
        }
        public static List<AsmProductionRecipeObject> GetManyProductionRecipeObjectByCondition(string sql)
        {
            List<AsmProductionRecipeObject> ap = AsmProductionRecipe_DAL.GetManyProductionRecipeObjectByCondition(sql);
            return ap;
        }
        public static DataTable GetManyProductionRecipeByCondition(string sl)
        {
            DataTable dt = AsmProductionRecipe_DAL.GetManyProductionRecipeByCondition(sl);
            return dt;
        }
        public static List<AsmRecipeDetailObject> GetRecipesByProductionAndStation(string productionVr, string stationName)
        {
            List<AsmRecipeDetailObject> l = AsmProductionRecipe_DAL.GetRecipesByProductionAndStation(productionVr, stationName);
            return l;
        }
        public static AsmProductionRecipeObject GetProductionRecipeByProAndSta(int productionId, string stationName)
        {
            AsmProductionRecipeObject apro = AsmProductionRecipe_DAL.GetProductionRecipeByProAndSta(productionId, stationName);
            return apro;
        }
        public static int DeleteProductionRecipeByObject(AsmProductionRecipeObject pcb)
        {
            int a = AsmProductionRecipe_DAL.DeleteProductionRecipeByObject(pcb);
            return a;
        }
    }
}
