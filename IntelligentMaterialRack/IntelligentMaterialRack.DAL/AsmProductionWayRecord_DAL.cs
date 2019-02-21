using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class AsmProductionWayRecord_DAL
    {

        public static void AddRecord(AsmProductionWayRecordObject apwo)
        {
            string sl = "insert  into  dbo.C_ASM_PRODUCTION_WAY_T_Record (DT,PRODUCTION_NAME,PRODUCTION_ID,ST_NAME,ST_ID,SERIAL_NO) values('" + apwo.DT+"','"+apwo.PRODUCTION_NAME+"',"+apwo.PRODUCTION_ID+",'"+apwo.ST_NAME+"',"+apwo.ST_ID+","+apwo.SERIAL_NO+")";
            ClsCommon.dbSql.ExecuteDataTable(sl);
        }

        public static DataTable GetAllByCondition(string sql)
        {
            string sl = "select * from C_ASM_PRODUCTION_WAY_T_Record where " + sql;
            DataTable  dt= ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }

        public static void DeleteAllByCondition(string sql)
        {
            string sl = "delete  from  C_ASM_PRODUCTION_WAY_T_Record where " + sql;
            ClsCommon.dbSql.ExecuteDataTable(sl);

        }


        public static DataTable GetAllRecordByCondition(string sql )
        {
            string sl = "select distinct ST_NAME  ,ST_ID,PRODUCTION_NAME,PRODUCTION_ID,DT from C_ASM_PRODUCTION_WAY_T_Record     where PRODUCTION_NAME = '"+sql+"'  order by ST_ID";
            DataTable dt= ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }

    }
}
