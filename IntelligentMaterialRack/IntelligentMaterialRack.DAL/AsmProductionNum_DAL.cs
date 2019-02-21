using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class AsmProductionNum_DAL
    {
        public static DataTable GetProductionNum(string sql)
        {
            string sl = "select distinct (SN), DT  from P_ASM_TRACKING_T where Convert(varchar,DT,120) between   '" + sql +"-28' and  '" + sql + "-31' and STATUS IN ('OK','NG','RJ','RF')";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            #region  清除重复的
            DataTable dt_clear = AsmProductionNum_DAL.GetProductionOK(sql);
            for (int i = 0; i < dt_clear.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if ((dt_clear.Rows[i]["SN"].ToString().Equals(dt.Rows[j]["SN"].ToString())))
                    {
                        dt.Rows[j].Delete();
                    }
                }
                dt.AcceptChanges();
            }
            for(int j=0 ; j < dt_clear.Rows.Count ; j++)
            {
                dt.Rows.Add(dt_clear.Rows[j].ItemArray);
            }
            dt.AcceptChanges();
            #endregion
            return dt;
        }
        public static DataTable GetProductionOK(string sql)
        {
            string sl = "select distinct (SN), DT  from P_ASM_TRACKING_T where Convert(varchar,DT,120) between   '" + sql + "-01' and  '" + sql + "-31' and STATUS IN ('OK','RF')";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        public static DataTable GetProductionNG(string sql)
        {
            string sl = "select distinct (SN), DT  from P_ASM_TRACKING_T where Convert(varchar,DT,120) between   '" + sql + "-01' and  '" + sql + "-31' and STATUS IN ('NG','RJ')";
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            #region  清除重复的
            string slX = "select distinct (SN),DT  from P_ASM_TRACKING_T where Convert(varchar,DT,120) between   '" + sql + "-01' and  '" + sql + "-31' and STATUS IN ('OK','RF') ";
            DataTable dt_OK = ClsCommon.dbSql.ExecuteDataTable(slX);
            for (int i = 0; i < dt_OK.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if ((dt_OK.Rows[i]["SN"].ToString().Equals(dt.Rows[j]["SN"].ToString())))
                    {
                        dt.Rows[j].Delete();
                    }
                }
                dt.AcceptChanges();
            }
            #endregion
            return dt;
        }
    }
}
