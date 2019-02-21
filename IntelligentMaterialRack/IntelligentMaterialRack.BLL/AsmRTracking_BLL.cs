using SKTraceablity.SKTraceablity.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.BLL
{
    class AsmRTracking_BLL
    {
        public static int AddAsmRTrackingByObject(AsmRTrackingObject arto)
        {
            int a = AsmRTracking_DAL.AddAsmRTrackingByObject(arto);
            return a;
        }
        public static int UpdateAsmRTrackingByObject(AsmRTrackingObject arto)
        {
            int a = AsmRTracking_DAL.UpdateAsmRTrackingByObject(arto);
            return a;
        }
        public static AsmRTrackingObject GetAsmRTrackingObjectBySn(string sql)
        {
            AsmRTrackingObject arto = AsmRTracking_DAL.GetAsmRTrackingObjectBySn(sql);
            return arto;
        }

        internal static int DeleteRTrackingByCondition(string sql)
        {
            int a = AsmRTracking_DAL.DeleteRTrackingByCondition(sql);
            return a;
        }
    }
}
