using Dapper;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class AsmPTracking_DAL
    {
        public static Dictionary<int, int> GetOfflineNumByCondition(string sql)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < 24; i++)
            {
                dic.Add(i, 0);
            }
            string sl = "select SN,DT  from(    select SN, DT, STATUS, P_TRACKING_T, row_number() over(partition by[SN] order by[SN]) as group_idx    from P_ASM_TRACKING_T    where CONVERT(varchar, DT, 120) like'"+sql+"%') s where s.group_idx = 1  ";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime DT = (DateTime)dt.Rows[i]["DT"];
                int time_offline = Convert.ToInt32(DT.ToString("yyyy-MM-dd HH:mm:ss").Substring(11, 2).Trim());
                switch (time_offline)
                {
                    case 0:
                        dic[0]++;
                        break;
                    case 1:
                        dic[1]++;
                        break;
                    case 2:
                        dic[2]++;
                        break;
                    case 3:
                        dic[3]++;
                        break;
                    case 4:
                        dic[4]++;
                        break;
                    case 5:
                        dic[5]++;
                        break;
                    case 6:
                        dic[6]++;
                        break;
                    case 7:
                        dic[7]++;
                        break;
                    case 8:
                        dic[8]++;
                        break;
                    case 9:
                        dic[9]++;
                        break;
                    case 10:
                        dic[10]++;
                        break;
                    case 11:
                        dic[11]++;
                        break;
                    case 12:
                        dic[12]++;
                        break;
                    case 13:
                        dic[13]++;
                        break;
                    case 14:
                        dic[14]++;
                        break;
                    case 15:
                        dic[15]++;
                        break;
                    case 16:
                        dic[16]++;
                        break;
                    case 17:
                        dic[17]++;
                        break;
                    case 18:
                        dic[18]++;
                        break;
                    case 19:
                        dic[19]++;
                        break;
                    case 20:
                        dic[20]++;
                        break;
                    case 21:
                        dic[21]++;
                        break;
                    case 22:
                        dic[22]++;
                        break;
                    case 23:
                        dic[23]++;
                        break;
                }
            }
            return dic;
        }


        public static Dictionary<string, int> GetPercentOfOK(string sql)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string sl = "select COUNT(s.SN)  as NUM from(    select SN, DT, STATUS, P_TRACKING_T, row_number() over(partition by[SN] order by[SN]) as group_idx    from P_ASM_TRACKING_T    where CONVERT(varchar, DT, 120) like'"+sql+"%'  and STATUS = 'OK') s where s.group_idx = 1  ";
            DataTable dt_OK_NUM = ClsCommon.dbSql.ExecuteDataTable(sl);
            string sl2 = "select COUNT(s.SN)  as NUM from(    select SN, DT, STATUS, P_TRACKING_T, row_number() over(partition by[SN] order by[SN]) as group_idx    from P_ASM_TRACKING_T    where CONVERT(varchar, DT, 120) like'"+sql+"%'  ) s where s.group_idx = 1  ";
            DataTable dt_ALL_NUM = ClsCommon.dbSql.ExecuteDataTable(sl2);
            dic.Add("OK", Convert.ToInt32(dt_OK_NUM.Rows[0]["NUM"].ToString()));
            dic.Add("ALL", Convert.ToInt32(dt_ALL_NUM.Rows[0]["NUM"].ToString()));
            return dic;
        }

        public static Dictionary<int, string> GetNumOfProduct(string sql)
        {
            string sl = "select count(SN) as NUM,TypeName,PRODUCTION_NAME from P_ASM_TRACKING_T ,C_ASM_PRODUCTION_T  where Convert(varchar, DT,120) like '" + sql + "%' and TypeName = PRODUCTION_VR group by TypeName,PRODUCTION_NAME";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            Dictionary<int, string> dic = new Dictionary<int, string>();
            Dictionary<int, string> dicX = new Dictionary<int, string>();
            int a = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dic.Add(i, dt.Rows[i]["NUM"].ToString());

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dic.Add(i + dt.Rows.Count, dt.Rows[i]["PRODUCTION_NAME"].ToString());
            }
            return dic;
        }



        public static Dictionary<int, int> GetMonthTurnoutByYear(string sql)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 1; i < 13; i++)
            {
                dic[i] = 0;
            }
            string sl = "select s.*  from(select SN, DT, STATUS, P_TRACKING_T, row_number() over(partition by[SN] order by[SN]) as group_idx    from P_ASM_TRACKING_T    where CONVERT(varchar, DT, 120) like'"+sql+"%'  ) s where s.group_idx = 1  ";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime de = Convert.ToDateTime(dt.Rows[i]["DT"]);
                string date = de.ToString("MM");
                int Month = Convert.ToInt32(date);
                switch (Month)
                {
                    case 1:
                        dic[1]++;
                        break;
                    case 2:
                        dic[2]++;
                        break;
                    case 3:
                        dic[3]++;
                        break;
                    case 4:
                        dic[4]++;
                        break;
                    case 5:
                        dic[5]++;
                        break;
                    case 6:
                        dic[6]++;
                        break;
                    case 7:
                        dic[7]++;
                        break;
                    case 8:
                        dic[8]++;
                        break;
                    case 9:
                        dic[9]++;
                        break;
                    case 10:
                        dic[10]++;
                        break;
                    case 11:
                        dic[11]++;
                        break;
                    case 12:
                        dic[12]++;
                        break;
                }
            }
            return dic;
        }
        public static AsmPTrackingObject GetPTrackingObjectByCondition(string sql)
        {
            AsmPTrackingObject arto = null;
            string sl = "SELECT P_TRACKING_T,DT,ST,BST,SN,EngineSN,GearboxSN,TypeName,TrayNum,ProductNum,STATUS,PLAN_ID,OFFLINE_DT,REWORK_FLAG FROM dbo.P_ASM_TRACKING_T WHERE  " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                arto = new AsmPTrackingObject();
                arto.P_TRACKING_T = Convert.ToInt32(dt.Rows[0]["P_TRACKING_T"].ToString());
                arto.DT = Convert.ToDateTime(dt.Rows[0]["DT"].ToString());
                arto.ST = dt.Rows[0]["ST"].ToString();
                arto.BST = dt.Rows[0]["BST"].ToString();
                arto.SN = dt.Rows[0]["SN"].ToString();
                arto.EngineSN = dt.Rows[0]["EngineSN"].ToString();
                arto.GearboxSN = dt.Rows[0]["GearboxSN"].ToString();
                arto.TypeName = dt.Rows[0]["TypeName"].ToString();
                arto.TrayNum = dt.Rows[0]["TrayNum"].ToString();
                arto.ProductNum = dt.Rows[0]["ProductNum"].ToString();
                arto.STATUS = dt.Rows[0]["STATUS"].ToString();
                arto.PLAN_ID = Convert.ToInt32(dt.Rows[0]["PLAN_ID"].ToString());
                arto.OFFLINE_DT = Convert.ToDateTime(dt.Rows[0]["OFFLINE_DT"].ToString());
                arto.REWORK_FLAG = dt.Rows[0]["REWORK_FLAG"].ToString();
            }
            return arto;
        }
        public static AsmPTrackingObject GetOfflineSnForNg(string sql)
        {
            AsmPTrackingObject arto = null;
            string sl = "SELECT MAX(P_TRACKING_T) AS P_TRACKING_T ,DT,ST,BST,SN,EngineSN,GearboxSN,TypeName,TrayNum,ProductNum,STATUS,PLAN_ID,OFFLINE_DT,REWORK_FLAG FROM dbo.P_ASM_TRACKING_T WHERE  " + sql+ " GROUP BY DT,ST,BST,SN,EngineSN,GearboxSN,TypeName,TrayNum,ProductNum,STATUS,PLAN_ID,OFFLINE_DT,REWORK_FLAG";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                arto = new AsmPTrackingObject();
                arto.P_TRACKING_T = Convert.ToInt32(dt.Rows[0]["P_TRACKING_T"].ToString());
                arto.DT = Convert.ToDateTime(dt.Rows[0]["DT"].ToString());
                arto.ST = dt.Rows[0]["ST"].ToString();
                arto.BST = dt.Rows[0]["BST"].ToString();
                arto.SN = dt.Rows[0]["SN"].ToString();
                arto.EngineSN = dt.Rows[0]["EngineSN"].ToString();
                arto.GearboxSN = dt.Rows[0]["GearboxSN"].ToString();
                arto.TypeName = dt.Rows[0]["TypeName"].ToString();
                arto.TrayNum = dt.Rows[0]["TrayNum"].ToString();
                arto.ProductNum = dt.Rows[0]["ProductNum"].ToString();
                arto.STATUS = dt.Rows[0]["STATUS"].ToString();
                arto.PLAN_ID = Convert.ToInt32(dt.Rows[0]["PLAN_ID"].ToString());
                arto.OFFLINE_DT = Convert.ToDateTime(dt.Rows[0]["OFFLINE_DT"].ToString());
                arto.REWORK_FLAG = dt.Rows[0]["REWORK_FLAG"].ToString();
            }
            return arto;
        }
        public static int AddPTrackingObject(AsmPTrackingObject uo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(uo);
                return Convert.ToInt32(result);
            }
        }
    }
}
