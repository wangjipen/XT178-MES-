using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using System.Data;
using System.Windows.Forms;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmPLeaking_BLL
    {

        /// <summary>
        /// 获取各天合格的数量
        /// </summary>
        public static Dictionary<int,int> GetAirtightnessOK( string sql )
        {
            Dictionary<int, int> dic = AsmPLeaking_DAL.GetAirtightnessOK(sql);
            return dic;          
        }
        /// <summary>
        /// 获取各小时不合格的数量
        /// </summary>
        public static Dictionary<int,int> GetAirtightnessNG(string sql)
        {
            Dictionary<int, int> dic = AsmPLeaking_DAL.GetAirtightnessNG(sql);
            return dic;          
        }
    }
}
