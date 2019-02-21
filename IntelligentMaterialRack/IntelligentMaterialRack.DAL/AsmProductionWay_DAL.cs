using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class AsmProductionWay_DAL
    {

        public static void AddRoutingRecord(AsmProductionWayObject apwo)
        {
            string sl = "insert  into  dbo.C_ASM_PRODUCTION_WAY_T (DT,PRODUCTION_NAME,PRODUCTION_ID,ST_NAME,ST_ID,SERIAL_NO) values('" + apwo.DT + "','" + apwo.PRODUCTION_NAME + "'," + apwo.PRODUCTION_ID + ",'" + apwo.ST_NAME + "'," + apwo.ST_ID + "," + apwo.SERIAL_NO + ")";
            ClsCommon.dbSql.ExecuteDataTable(sl);
        }

        public static DataTable GetWayByCondition(string sql)
        {
            DataTable dt = new DataTable();
            string sl = "select * from C_ASM_PRODUCTION_WAY_T where "+sql;
            dt= ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }

        public static void DeleteAllByCondition(string sql)
        {
            string sl = "delete  from  C_ASM_PRODUCTION_WAY_T where " + sql;
            ClsCommon.dbSql.ExecuteDataTable(sl);

        }
    }
}
