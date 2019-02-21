using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmKeypart_BLL
    {
        public static DataTable GetKeypartByCondition(string sql)
        {
            DataTable dt = AsmKeypart_DAL.GetKeypartByCondition(sql);
            return dt;
        }
    }
}
