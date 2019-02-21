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
    class Bolt_DAL
    {
        public static int AddBoltByObject(BoltObject bo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(bo);
                return Convert.ToInt32(result);
            }
        }
        public static DataTable GetBoltByCondition(string sql)
        {
            string sl = "SELECT  DT AS '日期',Keypart_Name AS '名称',A AS '角度值°',T AS '扭矩值N/M',R AS '结果',WID AS '员工号',ST AS '工位' FROM dbo.AutoASS_Bolt WHERE" + sql;
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
    }
}
