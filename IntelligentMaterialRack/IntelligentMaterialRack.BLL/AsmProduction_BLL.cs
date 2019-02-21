using SKTraceablity.SKTraceablity.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.BLL
{
    class AsmProduction_BLL
    {
        public static DataTable GetAllAsmProduction()
        {
            DataTable dt = new DataTable();
            dt = AsmProduction_DAL.GetAllAsmProduction();
            return dt;
        }
        public static DataTable GetAsmProduction()
        {
            DataTable dt = new DataTable();
            dt = AsmProduction_DAL.GetAsmProduction();
            return dt;
        }
        public static int AddAsmProductionByObjectReturnId(AsmProductionObject apo)
        {
            int id = AsmProduction_DAL.AddAsmProductionByObjectReturnId(apo);
            return id;
        }
        public static int AddAsmProductionByObject(AsmProductionObject apo)
        {
            int a = AsmProduction_DAL.AddAsmProductionByObject(apo);
            return a;
        }
        public static int UpdateAsmProductionById(AsmProductionObject apo)
        {
            int a = AsmProduction_DAL.UpdateAsmProductionById(apo);
            return a;
        }
        public static int DeleteAamProductionById(AsmProductionObject apo)
        {
            int a = AsmProduction_DAL.DeleteAamProductionByObject(apo);
            return a;
        }
        public static int DeleteAamProductionByID(int id)
        {
            int a = AsmProduction_DAL.DeleteAamProductionByID(id);
            return a;
        }
        public static AsmProductionObject GetAsmProductionByCondition(string sql)
        {
            AsmProductionObject apo = null;
            apo = AsmProduction_DAL.GetAsmProductionByCondition(sql);
            return apo;
        }
    }
}
