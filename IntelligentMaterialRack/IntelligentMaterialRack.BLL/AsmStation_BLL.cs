using SKTraceablity.SKTraceablity.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.BLL
{
    class AsmStation_BLL
    {
        public static int AddStationByObject(AsmStationObject aso)
        {
            int a = AsmStation_DAL.AddStationByObject(aso);
            return a;
        }
        public static int UpdateStationByObject(AsmStationObject aso)
        {
            int a = AsmStation_DAL.UpdateStationByObject(aso);
            return a;
        }
        public static AsmStationObject GetStationByCondition(string sql)
        {
            AsmStationObject aso = AsmStation_DAL.GetStationByCondition(sql);
            return aso;
        }
        public static int DeleteStationByCondition(string sql)
        {
            int a = AsmStation_DAL.DeleteStationByCondition(sql);
            return a;
        }
        public static DataTable GetAllStation()
        {
            DataTable dt = AsmStation_DAL.GetAllStation();
            return dt;
        }
        public static DataTable GetOtherStation()
        {
            DataTable dt = AsmStation_DAL.GetOtherStation();
            return dt;
        }
        public static DataTable GetFirstStation()
        {
            DataTable dt = AsmStation_DAL.GetFirstStation();
            return dt;
        }
    }
}
