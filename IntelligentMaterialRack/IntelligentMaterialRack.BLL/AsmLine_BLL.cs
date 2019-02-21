using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmLine_BLL
    {
        public static int AddLineByObject(AsmLineObject aso)
        {
            int a = AsmLine_DAL.AddLineByObject(aso);
            return a;
        }
        public static int UpdateLineByObject(AsmLineObject aso)
        {
            int a = AsmLine_DAL.UpdateLineByObject(aso);
            return a;
        }
        public static AsmLineObject GetLineByCondition(string sql)
        {
            AsmLineObject ao = AsmLine_DAL.GetLineByCondition(sql);
            return ao;
        }
        public static int DeleteLineByCondition(string sql)
        {
            int a = AsmLine_DAL.DeleteLineByCondition(sql);
            return a;
        }
        public static DataTable GetAllLines()
        {
            DataTable dt = AsmLine_DAL.GetAllLines();
            return dt;
        }
    }
}
