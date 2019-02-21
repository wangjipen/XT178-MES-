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
    class AsmStation_DAL
    {
        public static int AddStationByObject(AsmStationObject aso)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(aso);
                return Convert.ToInt32(result);
            }
        }
        public static int UpdateStationByObject(AsmStationObject aso)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(aso);
            }
            return Convert.ToInt32(result);
        }
        public static AsmStationObject GetStationByCondition(string sql)
        {
            AsmStationObject aso = null;
            string sl = "SELECT STATION_ID,STATION_INDEX,STATION_NAME,STATION_PROCESSOK,STATION_DATAOK,STATION_TYPE,STATION_RECIPEORNOT,STATION_AGVORNOT,STATION_REQUSTOUTLINE,STATION_LIGHTORNOT,STATION_REQUSTIN,STATION_REVIEWORNOT,STATION_PRINTORNOT,STATION_UPLOADMES,STATION_ENDORNOT,STATION_GUNORNOT,STATION_TIME,STATION_AUTOORNOT FROM dbo.C_ASM_STATION_T WHERE " + sql;
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            if (dt.Rows.Count > 0)
            {
                aso = new AsmStationObject();
                aso.STATION_ID = Convert.ToInt32(dt.Rows[0]["STATION_ID"].ToString());
                aso.STATION_INDEX = dt.Rows[0]["STATION_INDEX"].ToString();
                aso.STATION_NAME = dt.Rows[0]["STATION_NAME"].ToString();
                aso.STATION_PROCESSOK = dt.Rows[0]["STATION_PROCESSOK"].ToString();
                aso.STATION_DATAOK = dt.Rows[0]["STATION_DATAOK"].ToString();
                aso.STATION_TYPE = dt.Rows[0]["STATION_TYPE"].ToString();
                aso.STATION_RECIPEORNOT = dt.Rows[0]["STATION_RECIPEORNOT"].ToString();
                aso.STATION_AGVORNOT = dt.Rows[0]["STATION_AGVORNOT"].ToString();
                aso.STATION_REQUSTOUTLINE = dt.Rows[0]["STATION_REQUSTOUTLINE"].ToString();
                aso.STATION_LIGHTORNOT = dt.Rows[0]["STATION_LIGHTORNOT"].ToString();
                aso.STATION_REQUSTIN = dt.Rows[0]["STATION_REQUSTIN"].ToString();
                aso.STATION_REVIEWORNOT = dt.Rows[0]["STATION_REVIEWORNOT"].ToString();
                aso.STATION_PRINTORNOT = dt.Rows[0]["STATION_PRINTORNOT"].ToString();
                aso.STATION_UPLOADMES = dt.Rows[0]["STATION_UPLOADMES"].ToString();
                aso.STATION_ENDORNOT = dt.Rows[0]["STATION_ENDORNOT"].ToString();
                aso.STATION_GUNORNOT = dt.Rows[0]["STATION_GUNORNOT"].ToString();
                aso.STATION_TIME = Convert.ToInt32(dt.Rows[0]["STATION_TIME"].ToString());
                aso.STATION_AUTOORNOT = dt.Rows[0]["STATION_AUTOORNOT"].ToString();
            }
            return aso;
        }
        public static int DeleteStationByCondition(string sql)
        {
            int a = 0;
            AsmStationObject aso = GetStationByCondition(sql);
            if (aso != null)
            {
                string sl = "DELETE FROM dbo.C_ASM_STATION_T WHERE " + sql;
                a = ClsCommon.dbSql.ExecuteNonQuery(sl);
            }
            return a;
        }
        public static DataTable GetAllStation()
        {
            string sl = "SELECT STATION_ID,STATION_INDEX,STATION_NAME,STATION_PROCESSOK,STATION_DATAOK,STATION_TYPE,STATION_RECIPEORNOT,STATION_AGVORNOT,STATION_REQUSTOUTLINE,STATION_LIGHTORNOT,STATION_REQUSTIN,STATION_REVIEWORNOT,STATION_PRINTORNOT,STATION_UPLOADMES,STATION_ENDORNOT,STATION_GUNORNOT FROM dbo.C_ASM_STATION_T  ";
            //DataTable dt = new DataTable();
            var dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        public static DataTable GetOtherStation()
        {
            string sl = "SELECT STATION_ID,STATION_INDEX,STATION_NAME,STATION_PROCESSOK,STATION_DATAOK,STATION_TYPE,STATION_RECIPEORNOT,STATION_AGVORNOT,STATION_REQUSTOUTLINE,STATION_LIGHTORNOT,STATION_REQUSTIN,STATION_REVIEWORNOT,STATION_PRINTORNOT,STATION_UPLOADMES,STATION_ENDORNOT,STATION_GUNORNOT FROM dbo.C_ASM_STATION_T  where STATION_INDEX !='0'";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        public static DataTable GetFirstStation()
        {
            string sl = "SELECT STATION_ID,STATION_INDEX,STATION_NAME,STATION_PROCESSOK,STATION_DATAOK,STATION_TYPE,STATION_RECIPEORNOT,STATION_AGVORNOT,STATION_REQUSTOUTLINE,STATION_LIGHTORNOT,STATION_REQUSTIN,STATION_REVIEWORNOT,STATION_PRINTORNOT,STATION_UPLOADMES,STATION_ENDORNOT,STATION_GUNORNOT FROM dbo.C_ASM_STATION_T  where STATION_INDEX ='0'";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
    }
}
