using Dapper;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class AsmPlan_DAL
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="aak"></param>
        /// <returns></returns>
        public static int AddPlan(AsmPlanObject uo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(uo);
                return Convert.ToInt32(result);
            }
        }
        /// <summary>
        /// 更新单个用户
        /// </summary>
        /// <param name="uo"></param>
        /// <returns></returns>
        public static int UpdatePlan(AsmPlanObject uo)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(uo);
            }
            return Convert.ToInt32(result);
        }
        /// <summary>
        /// 根据条件查询多个对象
        /// </summary>
        /// <param name="sqlCondition"></param>
        /// <returns></returns>
        public static List<AsmPlanObject> GetPlanByCondition(string sqlCondition)
        {
            IEnumerable<AsmPlanObject> user = null;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {

                user = conn.GetList<AsmPlanObject>(sqlCondition);
            }
            return user.ToList();
        }

        public static DataTable GetPlanByName(string sql)
        {
            string sl = "select * from  R_PMS_PLAN_T where NAME='"+sql+"'";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        /// <summary>
        /// 根据条件查询单个对象必须要ID
        /// </summary>
        /// <param name="sqlCondition"></param>
        /// <returns></returns>
        public static AsmPlanObject GetOnePlanByCondition(string sqlCondition)
        {
            AsmPlanObject uo;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                uo = conn.Get<AsmPlanObject>(sqlCondition);
            }
            return uo;
        }
        /// <summary>
        /// 根据条件更新多个用户
        /// </summary>
        /// <param name="sqlCondition"></param>
        /// <returns></returns>
        public static int UpdatePlanByCondition(string sqlCondition)
        {
            var a = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                a = conn.Update(sqlCondition);
            }
            return Convert.ToInt32(a);
        }
        public static DataTable GetMaxLevelPlanByCondition()
        {
            string sl = "SELECT MAX(PLAN_LEVEL) AS LEVEL  FROM dbo.R_PMS_PLAN_T";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        public static DataTable GetPlansByCondition(string sql)
        {
            string sl = "SELECT RPP.ID,RPP.NAME,RPP.DT,CPL.NAME AS LineName,RPP.PRODUCTION_ID,APT.PRODUCTION_NAME,RPP.NUMBER,RPP.COMPLETE_NUMBER,RPP.LINE_ID,RPP.PLAN_LEVEL,RPP.COMPLETE_FLAG  FROM dbo.R_PMS_PLAN_T RPP,dbo.C_ASM_PRODUCTION_T APT,dbo.C_PMS_LINE_T CPL WHERE RPP.PRODUCTION_ID=APT.PRODUCTION_ID AND RPP.LINE_ID=CPL.ID AND RPP.COMPLETE_FLAG IN ('0','1','2') " +  sql;
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        /// <summary>
        /// 获取所有的工单
        /// </summary>
        public static DataTable GetAllPlan()
        {
            string sl = "select * from  dbo.R_PMS_PLAN_T";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }

        /// <summary>
        /// 对已完成的工单进行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetFinishPlansByCondition(string sql)
        {
            string sl = "SELECT PPP.ID,PPP.NAME,PPP.DT,CPL.NAME AS LineName,PPP.PRODUCTION_ID,APT.PRODUCTION_VR,PPP.NUMBER,PPP.COMPLETE_NUMBER,PPP.LINE_ID,PPP.PLAN_LEVEL,PPP.COMPLETE_FLAG  FROM dbo.P_PMS_PLAN_T PPP,dbo.C_ASM_PRODUCTION_T APT,dbo.C_PMS_LINE_T CPL WHERE PPP.PRODUCTION_ID=APT.PRODUCTION_ID AND PPP.LINE_ID=CPL.ID AND PPP.COMPLETE_FLAG IN ('4') " + sql;
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        /// <summary>
        ///  对强制关闭的工单进行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetClosePlansByCondition(string sql)
        {
            string sl = "SELECT PPP.ID,PPP.NAME,PPP.DT,CPL.NAME AS LineName,PPP.PRODUCTION_ID,APT.PRODUCTION_VR,PPP.NUMBER,PPP.COMPLETE_NUMBER,PPP.LINE_ID,PPP.PLAN_LEVEL,PPP.COMPLETE_FLAG  FROM dbo.P_PMS_PLAN_T PPP,dbo.C_ASM_PRODUCTION_T APT,dbo.C_PMS_LINE_T CPL WHERE PPP.PRODUCTION_ID=APT.PRODUCTION_ID AND PPP.LINE_ID=CPL.ID AND PPP.COMPLETE_FLAG IN ('3') " + sql;
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }

        public static AsmPlanObject GetPlanObjectByCondition(string sql)
        {
            AsmPlanObject apo = null;
            string sl = "SELECT ID,DT,NAME,PRODUCTION_ID,NUMBER,COMPLETE_NUMBER,REMAIND_NUMBER,OK_NUMBER,NG_NUMBER,LINE_ID,PLAN_LEVEL,COMPLETE_FLAG,OPREATION_USER,CREATE_BARCODE_FLAG  FROM dbo.R_PMS_PLAN_T  " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                apo = new AsmPlanObject();
                apo.ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                apo.DT = Convert.ToDateTime(dt.Rows[0]["DT"].ToString());
                apo.PRODUCTION_ID = Convert.ToInt32(dt.Rows[0]["PRODUCTION_ID"].ToString());
                apo.NAME = dt.Rows[0]["NAME"].ToString();
                apo.NUMBER = Convert.ToInt32(dt.Rows[0]["NUMBER"].ToString());
                apo.COMPLETE_NUMBER = Convert.ToInt32(dt.Rows[0]["COMPLETE_NUMBER"].ToString());
                apo.REMAIND_NUMBER = Convert.ToInt32(dt.Rows[0]["REMAIND_NUMBER"].ToString());
                apo.OK_NUMBER = Convert.ToInt32(dt.Rows[0]["OK_NUMBER"].ToString());
                apo.NG_NUMBER = Convert.ToInt32(dt.Rows[0]["NG_NUMBER"].ToString());
                apo.LINE_ID = Convert.ToInt32(dt.Rows[0]["LINE_ID"].ToString());
                apo.PLAN_LEVEL = Convert.ToInt32(dt.Rows[0]["PLAN_LEVEL"].ToString());
                apo.COMPLETE_FLAG = dt.Rows[0]["COMPLETE_FLAG"].ToString();
                apo.OPREATION_USER = dt.Rows[0]["OPREATION_USER"].ToString();
                apo.CREATE_BARCODE_FLAG = dt.Rows[0]["CREATE_BARCODE_FLAG"].ToString();
            }
            return apo;
        }
        public static DataTable GetPlanObjectByConditionToPrint()
        {
            string sl = "SELECT ID,DT,NAME,R_PMS_PLAN_T.PRODUCTION_ID,C_ASM_PRODUCTION_T.PRODUCTION_VR, NUMBER,COMPLETE_NUMBER,REMAIND_NUMBER,OK_NUMBER,NG_NUMBER,LINE_ID,PLAN_LEVEL,COMPLETE_FLAG,OPREATION_USER,CREATE_BARCODE_FLAG  FROM dbo.R_PMS_PLAN_T,dbo.C_ASM_PRODUCTION_T   WHERE COMPLETE_FLAG='1'  and C_ASM_PRODUCTION_T.PRODUCTION_ID=R_PMS_PLAN_T.PRODUCTION_ID ORDER BY PLAN_LEVEL ASC";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);         
            return dt;
        }
        public static int DeleteRPlanByCondition(string sql)
        {
            string sl = "DELETE FROM dbo.R_PMS_PLAN_T WHERE " + sql;
            int a = ClsCommon.dbSql.ExecuteNonQuery(sl);
            return a;
        }

        public static List<string> GetSnByTime(string sql)
        {
            List<string> list = new List<string>();
            string sl = "select * from R_PLAN_PRINT_T where SN like" + sql + "union all select * from dbo.P_PLAN_PRINT_T where SN like "+sql;
            DataTable dt=   ClsCommon.dbSql.ExecuteDataTable(sl);
            for (int i=0;i<dt.Rows.Count;i++)
            {
                list.Add(dt.Rows[i]["SN"].ToString());
            }
            return list;
        }

        public static void SetBarcodeIdentification(string sql)
        {
            string sl = "update R_PMS_PLAN_T set CREATE_BARCODE_FLAG='1'  where ID='"+sql+"'";
            ClsCommon.dbSql.ExecuteNonQuery(sl);
        }
        public static DataTable GetPlanObjectByInputConditionToPrint(string sql)
        {
            string sl = "SELECT ID,DT,NAME,R_PMS_PLAN_T.PRODUCTION_ID,C_ASM_PRODUCTION_T.PRODUCTION_VR  , NUMBER,COMPLETE_NUMBER,REMAIND_NUMBER,OK_NUMBER,NG_NUMBER,LINE_ID,PLAN_LEVEL,COMPLETE_FLAG,R_PMS_PLAN_T.OPREATION_USER,CREATE_BARCODE_FLAG  FROM dbo.R_PMS_PLAN_T,dbo.C_ASM_PRODUCTION_T   WHERE COMPLETE_FLAG='1'  and   C_ASM_PRODUCTION_T.PRODUCTION_ID=R_PMS_PLAN_T.PRODUCTION_ID " + sql+" ORDER BY PLAN_LEVEL ASC";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
    }
}
