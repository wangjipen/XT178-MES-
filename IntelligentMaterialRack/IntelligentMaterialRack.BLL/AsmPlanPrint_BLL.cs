using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using System.Data;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmPlanPrint_BLL
    {
        public static void AddPlanPrint(AsmPlanPrintObject appo)
        {
            AsmPlanPrint_DAL.AddPlanPrint(appo);
        }

        public static DataTable GetBarcodeByCondition(string sql)
        {
           DataTable dt= AsmPlanPrint_DAL.GetBarcodeByCondition(sql);
            return dt;
        }

    }
}
