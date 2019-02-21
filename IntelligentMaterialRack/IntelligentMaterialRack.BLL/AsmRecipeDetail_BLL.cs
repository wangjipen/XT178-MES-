using SKTraceablity.SKTraceablity.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.BLL
{
    class AsmRecipeDetail_BLL
    {
        public static int AddRecipeDetail(AsmRecipeDetailObject ardo)
        {
            int a = AsmRecipeDetail_DAL.AddRecipeDetail(ardo);
            return a;
        }
        public static DataTable GetAllRecipeDetailByCondition(string bomId)
        {
            DataTable dt = AsmRecipeDetail_DAL.GetAllRecipeDetailByCondition(bomId);
            return dt;
        }
        public static int UpdateProductionBOM(AsmRecipeDetailObject pbo)
        {
            int a = AsmRecipeDetail_DAL.UpdateProductionBOM(pbo);
            return a;
        }
        public static int DeleteProductionBomByObject(AsmRecipeDetailObject pbo)
        {
            int a = AsmRecipeDetail_DAL.DeleteProductionBomByObject(pbo);
            return a;
        }
        public static int DeleteRecieDetailByCondition(string sql)
        {
            int a = AsmRecipeDetail_DAL.DeleteRecieDetailByCondition(sql);
            return a;
        }
        public static DataTable GetRecipeDetailByStationAndProduction(string stationId, string productionId)
        {
            DataTable dt = AsmRecipeDetail_DAL.GetRecipeDetailByStationAndProduction(stationId,productionId);
            return dt;
        }
    }
}
