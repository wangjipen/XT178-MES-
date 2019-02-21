using SKTrackClient.SKTrackClient.DAL;
using SKTrackClient.SKTrackClient.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SKTrackClient.SKTrackClient.BLL
{
    class AsmLeakage_BLL
    {
        public static int AddLeakageByObject(AsmLeakageObject alko)
        {
            int a = AsmLeakage_DAL.AddLeakageByObject(alko);
            return a;
        }
        public static int UpdateLeakageByObject(AsmLeakageObject aso)
        {
            int a = AsmLeakage_DAL.UpdateLeakageByObject(aso);
            return a;
        }
        public static AsmLeakageObject GetLeakageByCondition(string sql)
        {
            AsmLeakageObject alo = AsmLeakage_DAL.GetLeakageByCondition(sql);
            return alo;
        }
        public static List<AsmLeakageObject> GetManyLeakageByCondition(string sql)
        {
            List<AsmLeakageObject> l = AsmLeakage_DAL.GetManyLeakageByCondition(sql);
            return l;
        }
        public static DataTable GetLeakageBySn(string ql)
        {
            DataTable dt = AsmLeakage_DAL.GetLeakageBySn(ql);
            return dt;
        }
    }
}
