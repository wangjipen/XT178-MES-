using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmProductionNum_BLL
    {
        /// <summary>
        /// 获取各天产品数量
        /// </summary>
        public static Dictionary<int, int> GetProductionNum(string sql)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < 32; i++)
            {
                dic.Add(i, 0);
            }
            DataTable dt = AsmProductionNum_DAL.GetProductionNum(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime DT = (DateTime)dt.Rows[i]["DT"];
                int time_offline = Convert.ToInt32(DT.ToString("yyyy-MM-dd hh:mm:ss").Substring(8, 2).Trim());
                switch (time_offline)
                {
                    case 0:
                        dic[0]++;
                        break;
                    case 1:
                        dic[1]++;
                        break;
                    case 2:
                        dic[2]++;
                        break;
                    case 3:
                        dic[3]++;
                        break;
                    case 4:
                        dic[4]++;
                        break;
                    case 5:
                        dic[5]++;
                        break;
                    case 6:
                        dic[6]++;
                        break;
                    case 7:
                        dic[7]++;
                        break;
                    case 8:
                        dic[8]++;
                        break;
                    case 9:
                        dic[9]++;
                        break;
                    case 10:
                        dic[10]++;
                        break;
                    case 11:
                        dic[11]++;
                        break;
                    case 12:
                        dic[12]++;
                        break;
                    case 13:
                        dic[13]++;
                        break;
                    case 14:
                        dic[14]++;
                        break;
                    case 15:
                        dic[15]++;
                        break;
                    case 16:
                        dic[16]++;
                        break;
                    case 17:
                        dic[17]++;
                        break;
                    case 18:
                        dic[18]++;
                        break;
                    case 19:
                        dic[19]++;
                        break;
                    case 20:
                        dic[20]++;
                        break;
                    case 21:
                        dic[21]++;
                        break;
                    case 22:
                        dic[22]++;
                        break;
                    case 23:
                        dic[23]++;
                        break;
                    case 24:
                        dic[24]++;
                        break;
                    case 25:
                        dic[25]++;
                        break;
                    case 26:
                        dic[26]++;
                        break;
                    case 27:
                        dic[27]++;
                        break;
                    case 28:
                        dic[28]++;
                        break;
                    case 29:
                        dic[29]++;
                        break;
                    case 30:
                        dic[30]++;
                        break;
                    case 31:
                        dic[31]++;
                        break;
                }
            }
            return dic;
        }
        public static Dictionary<int, int> GetProductionOK(string sql)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < 32; i++)
            {
                dic.Add(i, 0);
            }
            DataTable dt = AsmProductionNum_DAL.GetProductionOK(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime DT = (DateTime)dt.Rows[i]["DT"];
                int time_offline = Convert.ToInt32(DT.ToString("yyyy-MM-dd hh:mm:ss").Substring(8, 2).Trim());
                switch (time_offline)
                {
                    case 0:
                        dic[0]++;
                        break;
                    case 1:
                        dic[1]++;
                        break;
                    case 2:
                        dic[2]++;
                        break;
                    case 3:
                        dic[3]++;
                        break;
                    case 4:
                        dic[4]++;
                        break;
                    case 5:
                        dic[5]++;
                        break;
                    case 6:
                        dic[6]++;
                        break;
                    case 7:
                        dic[7]++;
                        break;
                    case 8:
                        dic[8]++;
                        break;
                    case 9:
                        dic[9]++;
                        break;
                    case 10:
                        dic[10]++;
                        break;
                    case 11:
                        dic[11]++;
                        break;
                    case 12:
                        dic[12]++;
                        break;
                    case 13:
                        dic[13]++;
                        break;
                    case 14:
                        dic[14]++;
                        break;
                    case 15:
                        dic[15]++;
                        break;
                    case 16:
                        dic[16]++;
                        break;
                    case 17:
                        dic[17]++;
                        break;
                    case 18:
                        dic[18]++;
                        break;
                    case 19:
                        dic[19]++;
                        break;
                    case 20:
                        dic[20]++;
                        break;
                    case 21:
                        dic[21]++;
                        break;
                    case 22:
                        dic[22]++;
                        break;
                    case 23:
                        dic[23]++;
                        break;
                    case 24:
                        dic[24]++;
                        break;
                    case 25:
                        dic[25]++;
                        break;
                    case 26:
                        dic[26]++;
                        break;
                    case 27:
                        dic[27]++;
                        break;
                    case 28:
                        dic[28]++;
                        break;
                    case 29:
                        dic[29]++;
                        break;
                    case 30:
                        dic[30]++;
                        break;
                    case 31:
                        dic[31]++;
                        break;
                }
            }
            return dic;
        }
        public static Dictionary<int, int> GetProductionNG(string sql)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < 32; i++)
            {
                dic.Add(i, 0);
            }
            DataTable dt = AsmProductionNum_DAL.GetProductionNG(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime DT = (DateTime)dt.Rows[i]["DT"];
                int time_offline = Convert.ToInt32(DT.ToString("yyyy-MM-dd hh:mm:ss").Substring(8, 2).Trim());
                switch (time_offline)
                {
                    case 0:
                        dic[0]++;
                        break;
                    case 1:
                        dic[1]++;
                        break;
                    case 2:
                        dic[2]++;
                        break;
                    case 3:
                        dic[3]++;
                        break;
                    case 4:
                        dic[4]++;
                        break;
                    case 5:
                        dic[5]++;
                        break;
                    case 6:
                        dic[6]++;
                        break;
                    case 7:
                        dic[7]++;
                        break;
                    case 8:
                        dic[8]++;
                        break;
                    case 9:
                        dic[9]++;
                        break;
                    case 10:
                        dic[10]++;
                        break;
                    case 11:
                        dic[11]++;
                        break;
                    case 12:
                        dic[12]++;
                        break;
                    case 13:
                        dic[13]++;
                        break;
                    case 14:
                        dic[14]++;
                        break;
                    case 15:
                        dic[15]++;
                        break;
                    case 16:
                        dic[16]++;
                        break;
                    case 17:
                        dic[17]++;
                        break;
                    case 18:
                        dic[18]++;
                        break;
                    case 19:
                        dic[19]++;
                        break;
                    case 20:
                        dic[20]++;
                        break;
                    case 21:
                        dic[21]++;
                        break;
                    case 22:
                        dic[22]++;
                        break;
                    case 23:
                        dic[23]++;
                        break;
                    case 24:
                        dic[24]++;
                        break;
                    case 25:
                        dic[25]++;
                        break;
                    case 26:
                        dic[26]++;
                        break;
                    case 27:
                        dic[27]++;
                        break;
                    case 28:
                        dic[28]++;
                        break;
                    case 29:
                        dic[29]++;
                        break;
                    case 30:
                        dic[30]++;
                        break;
                    case 31:
                        dic[31]++;
                        break;
                }
            }
            return dic;
        }
    }
}
