using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmPPlan_BLL
    {
        public static int AddPPlan(AsmPPlanObject uo)
        {
            int a = AsmPPlan_DAL.AddPPlan(uo);
            return a;
        }
    }
}
