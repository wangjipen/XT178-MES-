using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmAlarmCode_BLL
    {
        public static DataTable GetAlarmCodes()
        {
            DataTable dt = AsmAlarmCode_DAL.GetAlarmCodes();
            return dt;
        }
        public static DataTable GetAlarmCodesByCondition(string sql)
        {
            DataTable dt = AsmAlarmCode_DAL.GetAlarmCodesByCondition(sql);
            return dt;
        }
        public static bool IsExistCode(String sql)
        {
            bool a = AsmAlarmCode_DAL.IsExistCode(sql);
            return a;
        }
        public static int AddAlarmCode(AsmAlarmCodeObject uo)
        {
            int a = AsmAlarmCode_DAL.AddAlarmCode(uo);
            return a;
        }
        public static int UpdateAlarmCode(AsmAlarmCodeObject uo)
        {
            int a = AsmAlarmCode_DAL.UpdateAlarmCode(uo);
            return a;
        }
        public static AsmAlarmCodeObject GetAlarmCodeObjectByCondition(string sql)
        {
            AsmAlarmCodeObject aaco = AsmAlarmCode_DAL.GetAlarmCodeObjectByCondition(sql);
            return aaco;
        }
        public static int DeleteAlarmCodeByCondition(String sql)
        {
            int a = AsmAlarmCode_DAL.DeleteAlarmCodeByCondition(sql);
            return a;
        }
    }
}
