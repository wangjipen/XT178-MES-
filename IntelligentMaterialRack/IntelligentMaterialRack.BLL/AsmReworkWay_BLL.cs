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
    class AsmReworkWay_BLL
    {
        public static int AddReworkWay(AsmReworkWayObject uo)
        {
            int a = AsmReworkWay_DAL.AddReworkWay(uo);
            return a;
        }

        /// <summary>
        /// 按指定条件查修路线
        /// </summary>
        /// <param name="sql"></param>
        public static DataTable SelectWayByCondition(string sql)
        {
            DataTable  dt=  AsmReworkWay_DAL.SelectWayByCondition(sql);
            return dt;
        }


        public static void DeleteWayBycondition(string sql)
        {
            AsmReworkWay_DAL.DeleteWayBycondition(sql);
        }
    }
}
