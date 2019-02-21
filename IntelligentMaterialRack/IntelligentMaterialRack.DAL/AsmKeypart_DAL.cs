using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class AsmKeypart_DAL
    {
        public static DataTable GetKeypartByCondition(string sql)
        {
            string sl = "SELECT  DT AS '日期',Keypart_Name AS '名称',Keypart_NUM AS '批次号',WID AS '员工号',ST AS '工位' FROM dbo.AutoASS_Keypart WHERE"+sql;
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
    }
}
