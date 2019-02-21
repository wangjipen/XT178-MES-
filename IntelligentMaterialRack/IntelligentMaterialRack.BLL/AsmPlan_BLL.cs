using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmPlan_BLL
    {
        public static int AddPlan(AsmPlanObject uo)
        {
            int a = AsmPlan_DAL.AddPlan(uo);
            return a;
        }
        public static int UpdatePlan(AsmPlanObject uo)
        {
            int a = AsmPlan_DAL.UpdatePlan(uo);
            return a;
        }

        public static DataTable GetAllPlan()
        {
            DataTable dt=   AsmPlan_DAL.GetAllPlan();
            return dt;
        }

        public static List<AsmPlanObject> GetPlanByCondition(string sqlCondition)
        {
            List<AsmPlanObject> list = AsmPlan_DAL.GetPlanByCondition(sqlCondition);
            return list;
        }

        public static DataTable GetPlanByName(string sql)
        {
            DataTable dt = AsmPlan_DAL.GetPlanByName(sql);
            return dt;
        }
        public static DataTable GetMaxLevelPlanByCondition()
        {
            DataTable dt = AsmPlan_DAL.GetMaxLevelPlanByCondition();
            return dt;
        }
        public static DataTable GetPlansByCondition(string sql)
        {
            DataTable dt = AsmPlan_DAL.GetPlansByCondition(sql);
            return dt;
        }
        public static DataTable GetFinishPlansByCondition(string sql)
        {
            DataTable dt = AsmPlan_DAL.GetFinishPlansByCondition(sql);
            return dt;
        }
        public static DataTable GetClosePlansByCondition(string sql)
        {
            DataTable dt = AsmPlan_DAL.GetClosePlansByCondition(sql);
            return dt;
        }
        public static AsmPlanObject GetPlanObjectByCondition(string sql)
        {
            AsmPlanObject apo = AsmPlan_DAL.GetPlanObjectByCondition(sql);
            return apo;
        }
        public static DataTable GetPlanObjectByConditionToPrint()
        {
            DataTable dt = AsmPlan_DAL.GetPlanObjectByConditionToPrint();
            return dt;
        }
        /// <summary>
        /// 获取指定日期范围内的SN
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<string> GetSnByTime(string sql)
        {
            List<string> list = AsmPlan_DAL.GetSnByTime(sql);
            return list;
        }
        public static int DeleteRPlanByCondition(string sql)
        {
            int a = AsmPlan_DAL.DeleteRPlanByCondition(sql);
            return a;
        }

        public static void SetBarcodeIdentification(string sql)
        {
            AsmPlan_DAL.SetBarcodeIdentification(sql);
        }
        public static DataTable GetPlanObjectByInputConditionToPrint(string sql)
        {
            DataTable dt=  AsmPlan_DAL.GetPlanObjectByInputConditionToPrint(sql);
            return dt;
        }
    }
}
