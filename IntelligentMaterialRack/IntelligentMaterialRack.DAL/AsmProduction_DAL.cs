using Dapper;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.DAL
{
    class AsmProduction_DAL
    {
        /// <summary>
        /// 获取所有的产品
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllAsmProduction()
        {
            string sql = "SELECT PRODUCTION_ID,PRODUCTION_NAME,PRODUCTION_TYPE,PRODUCTION_TRADEMARK,PRODUCTION_SERIES,PRODUCTION_VR,PRODUCTION_DISCRIPTION,PRODUCTION_ET,PRODUCTION_GT,PRODUCTION_STE FROM dbo.C_ASM_PRODUCTION_T";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            return dt;
        }
        public static DataTable GetAsmProduction()
        {
            string sql = "SELECT PRODUCTION_NAME FROM dbo.C_ASM_PRODUCTION_T";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            return dt;
        }
        public static int AddAsmProductionByObject(AsmProductionObject apo)
        {
            int a=0;
            try
            {
                string sql = "INSERT INTO dbo.C_ASM_PRODUCTION_T(PRODUCTION_NAME,PRODUCTION_TYPE,PRODUCTION_TRADEMARK,PRODUCTION_SERIES,PRODUCTION_VR,PRODUCTION_DISCRIPTION,PRODUCTION_ET,PRODUCTION_GT,PRODUCTION_STE)VALUES('" + apo.PRODUCTION_NAME + "','" + apo.PRODUCTION_TYPE + "','" + apo.PRODUCTION_TRADEMARK + "','" + apo.PRODUCTION_SERIES + "','" + apo.PRODUCTION_VR + "','" + apo.PRODUCTION_DISCRIPTION+"','"+apo.PRODUCTION_ET+"','"+apo.PRODUCTION_GT + "','" + apo.PRODUCTION_STE + "');";
                a= ClsCommon.dbSql.ExecuteNonQuery(sql);
                return a;
            }
            catch (Exception ex)
            {
                return a;
            }
        }
        public static int AddAsmProductionByObjectReturnId(AsmProductionObject apo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(apo);
                return Convert.ToInt32(result);
            }
        }
        public static int UpdateAsmProductionById(AsmProductionObject apo)
        {
            int a = 0;
            try
            {
                string sql = "UPDATE dbo.C_ASM_PRODUCTION_T SET PRODUCTION_NAME='"+apo.PRODUCTION_NAME+"',PRODUCTION_TYPE='"+apo.PRODUCTION_TYPE+"',PRODUCTION_TRADEMARK='"+apo.PRODUCTION_TRADEMARK+"',PRODUCTION_SERIES='"+apo.PRODUCTION_SERIES+"',PRODUCTION_VR='"+apo.PRODUCTION_VR+"',PRODUCTION_DISCRIPTION='"+apo.PRODUCTION_DISCRIPTION+"',PRODUCTION_ET='"+apo.PRODUCTION_ET+"',PRODUCTION_GT='"+apo.PRODUCTION_GT + "',PRODUCTION_STE='" + apo.PRODUCTION_STE + "' WHERE PRODUCTION_ID="+apo.PRODUCTION_ID;
                a = ClsCommon.dbSql.ExecuteNonQuery(sql);
                return a;
            }
            catch (Exception ex)
            {
                return a;
            }
        }
        public static int DeleteAamProductionByObject(AsmProductionObject apo)
        {
            int a = 0;
            try
            {
                string sql = "DELETE FROM dbo.C_ASM_PRODUCTION_T WHERE PRODUCTION_ID=" + apo.PRODUCTION_ID;
                a = ClsCommon.dbSql.ExecuteNonQuery(sql);
                return a;
            }
            catch (Exception ex)
            {
                return a;
            }
        }
        public static int DeleteAamProductionByID(int id)
        {
            int a = 0;
            try
            {
                string sql = "DELETE FROM dbo.C_ASM_PRODUCTION_T WHERE PRODUCTION_ID=" + id;
                a = ClsCommon.dbSql.ExecuteNonQuery(sql);
                return a;
            }
            catch (Exception ex)
            {
                return a;
            }
        }
        public static AsmProductionObject GetAsmProductionByCondition(string sql)
        {
            AsmProductionObject apo = null;
            try
            {
                string sl = "SELECT PRODUCTION_ID,PRODUCTION_NAME,PRODUCTION_TYPE,PRODUCTION_TRADEMARK,PRODUCTION_SERIES,PRODUCTION_VR,PRODUCTION_DISCRIPTION,PRODUCTION_GT,PRODUCTION_ET,PRODUCTION_STE FROM dbo.C_ASM_PRODUCTION_T WHERE " + sql;
                DataTable dt = new DataTable();
                dt = ClsCommon.dbSql.ExecuteDataTable(sl);
                if (dt.Rows.Count > 0)
                {
                    apo = new AsmProductionObject();
                    apo.PRODUCTION_ID =Convert.ToInt32(dt.Rows[0]["PRODUCTION_ID"].ToString());
                    apo.PRODUCTION_NAME = dt.Rows[0]["PRODUCTION_NAME"].ToString();
                    apo.PRODUCTION_TYPE = dt.Rows[0]["PRODUCTION_TYPE"].ToString();
                    apo.PRODUCTION_TRADEMARK = dt.Rows[0]["PRODUCTION_TRADEMARK"].ToString();
                    apo.PRODUCTION_SERIES = dt.Rows[0]["PRODUCTION_SERIES"].ToString();
                    apo.PRODUCTION_VR = dt.Rows[0]["PRODUCTION_VR"].ToString();
                    apo.PRODUCTION_DISCRIPTION = dt.Rows[0]["PRODUCTION_DISCRIPTION"].ToString(); 
                    apo.PRODUCTION_ET= dt.Rows[0]["PRODUCTION_ET"].ToString();
                    apo.PRODUCTION_GT = dt.Rows[0]["PRODUCTION_GT"].ToString();
                    apo.PRODUCTION_STE = dt.Rows[0]["PRODUCTION_STE"].ToString();
                }
                return apo;
            }
            catch (Exception ex)
            {
                return apo;
            }
        }
    }
}
