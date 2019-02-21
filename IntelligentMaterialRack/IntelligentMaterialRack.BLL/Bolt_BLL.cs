using SKTraceablity.SKTraceablity.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SKTraceablity.SKTraceablity.BLL
{
    class Bolt_BLL
    {
        public static int AddBoltByObject(BoltObject bo)
        {
            int a = Bolt_DAL.AddBoltByObject(bo);
            return a;
        }
        public static DataTable GetBoltByCondition(string sql)
        {
            DataTable dt = Bolt_DAL.GetBoltByCondition(sql);
            return dt;
        }
    }
}
