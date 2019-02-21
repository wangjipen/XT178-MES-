using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using System.Data;
using System.Windows.Forms;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmPTracking_BLL
    {

        /// <summary>
        /// 获取各个下线产品的种类
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetNumOfProduct(string sql)
        {
            Dictionary<int, string> dic = AsmPTracking_DAL.GetNumOfProduct(sql);
            return dic;
        }


        /// <summary>
        /// 获取合格百分比
        /// </summary>
        /// <param name="sql"></param>
        public static double GetPercentOfOK(string sql)
        {
            Dictionary<string, int> dic = AsmPTracking_DAL.GetPercentOfOK(sql);
            double a = (double)dic["OK"] / dic["ALL"];
            return a;
        }

        /// <summary>
        /// 获取合格量以及下线总量
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetProduct_OKAndALL(string sql)
        {
            Dictionary<string, int> dic = AsmPTracking_DAL.GetPercentOfOK(sql);
            return dic;
        }

        /// <summary>
        /// 获取每年每个月的产量
        /// </summary>
        /// <param name="sql"></param>
        public static Dictionary<int, int> GetMonthTurnoutByYear(string sql)
        {
            Dictionary<int, int> dic = AsmPTracking_DAL.GetMonthTurnoutByYear(sql);
            return dic;
        }


        /// <summary>
        /// 通过指定的条件获取各时间的下线数量
        /// </summary>
        /// <param name="sql"></param>
        public static Dictionary<int, int> GetOfflineNumByCondition(string sql)
        {
            Dictionary<int, int> dic = AsmPTracking_DAL.GetOfflineNumByCondition(sql);
            return dic;
        }
        public static AsmPTrackingObject GetPTrackingObjectByCondition(string sql)
        {
            AsmPTrackingObject apo = AsmPTracking_DAL.GetPTrackingObjectByCondition(sql);
            return apo;
        }
        public static int AddPTrackingObject(AsmPTrackingObject uo)
        {
            int a = AsmPTracking_DAL.AddPTrackingObject(uo);
            return a;
        }
        public static AsmPTrackingObject GetOfflineSnForNg(string sql)
        {
            AsmPTrackingObject apo = AsmPTracking_DAL.GetOfflineSnForNg(sql);
            return apo;
        }
    }
}
