using Dapper;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class AsmPPlan_DAL
    {
        public static int AddPPlan(AsmPPlanObject uo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(uo);
                return Convert.ToInt32(result);
            }
        }

    }
}
