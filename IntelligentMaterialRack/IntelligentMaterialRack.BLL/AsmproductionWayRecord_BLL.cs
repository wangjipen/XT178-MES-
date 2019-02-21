using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmproductionWayRecord_BLL
    {

        /// <summary>
        /// 添加纪录
        /// </summary>
        /// <param name="apwo"></param>
        public static void AddRecord(AsmProductionWayRecordObject apwo)
        {
            AsmProductionWayRecord_DAL.AddRecord(apwo);
        }

        /// <summary>
        /// 根据指定条件获取指定记录
        /// </summary>
        /// <param name="sql"></param>
        public static DataTable GetAllByCondition(string sql)
        {
           DataTable  dt= AsmProductionWayRecord_DAL.GetAllByCondition(sql);
            return dt;
        }

        /// <summary>
        ///删除指定行
        /// </summary>
        /// <param name="sql"></param>
        public static void DeleteAllByCondition(string sql)
        {
            AsmProductionWayRecord_DAL.DeleteAllByCondition(sql); 
        }

        /// <summary>
        /// 获取指定记录
        /// </summary>
        public static DataTable  GetAllRecordByCondition(string sql)
        {
          DataTable dt=  AsmProductionWayRecord_DAL.GetAllRecordByCondition(sql);
            return dt;
        }
    }
}
