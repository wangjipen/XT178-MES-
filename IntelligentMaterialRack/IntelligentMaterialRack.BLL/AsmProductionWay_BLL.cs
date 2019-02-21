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
    class AsmProductionWay_BLL
    {
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="apwo"></param>
        public static void AddRoutingRecord(AsmProductionWayObject apwo)
        {
            AsmProductionWay_DAL.AddRoutingRecord(apwo);
        }

        /// <summary>
        /// 根究指定条件获取路线
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetWayByCondition(string sql)
        {
            DataTable dt = new DataTable();
            dt=  AsmProductionWay_DAL.GetWayByCondition(sql);
            return dt;
        }


        /// <summary>
        ///删除指定行
        /// </summary>
        /// <param name="sql"></param>
        public static void DeleteAllByCondition(string sql)
        {
            AsmProductionWay_DAL.DeleteAllByCondition(sql);
        }

    }
}
