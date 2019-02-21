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
    class AsmReworkReson_BLL
    {
        public static int AddReworkReson(AsmReworkResonObject uo)
        {
            int a = AsmReworkReson_DAL.AddReworkReson(uo);
            return a;
        }
        public static bool IsExistReworkReson(String sql)
        {
            bool a = AsmReworkReson_DAL.IsExistReworkReson(sql);
            return a;
        }
        /// <summary>
        /// 通过指定条件获取reason
        /// </summary>
        /// <param name="sql"></param>
        public static DataTable  GetReasonByCondition(string sql)
        {
          DataTable  dt=  AsmReworkReson_DAL.GetReasonByCondition(sql);
            return dt;
        }

        public static void DeleteReasonByCondition(string sql)
        {
            AsmReworkReson_DAL.DeleteReasonByCondition(sql);
        }
    }
}
