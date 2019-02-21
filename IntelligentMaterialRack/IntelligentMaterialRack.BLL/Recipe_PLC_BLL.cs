using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using SKTraceablity.SKTraceablity.Moudle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SKTraceablity.SKTraceablity.BLL
{
    class Recipe_PLC_BLL
    {
        private static Dictionary<string, Dictionary<string, string>> StationsDic=new Dictionary<string, Dictionary<string, string>>();
        private static Dictionary<string, Dictionary<int, Dictionary<string, string>>> RecipesDic = new Dictionary<string, Dictionary<int, Dictionary<string, string>>>();
        public void Run()
        {
            foreach (XmlNode lineNode in ClsCommon.InfoRootNode.ChildNodes)
            {
                XmlNodeList stationList = lineNode.SelectNodes("station");
                foreach (XmlNode stationName in stationList)
                {
                    #region>>>>>初始化工位缓存信息
                    Dictionary<string, string> station = new Dictionary<string, string>();
                    station.Add("Emp", "");
                    station.Add("Sn", "");
                    station.Add("EngineSN", "");
                    station.Add("GearboxSN", "");
                    station.Add("TypeName", "");
                    station.Add("TrayNum", "");
                    station.Add("ProductNum", "");
                    station.Add("StepNum", "");
                    station.Add("ToalStep", "");
                    station.Add("LOT1", "");
                    station.Add("LOT2", "");
                    station.Add("LOT3", "");
                    station.Add("LOT4", "");
                    station.Add("LOT5", "");
                    station.Add("LOT6", "");
                    station.Add("LOT7", "");
                    station.Add("LOT8", "");
                    station.Add("LOT9", "");
                    station.Add("LOT0", "");
                    StationsDic.Add(stationName.Attributes["name"].Value, station);
                    #endregion
                }
            }
        }
        /// <summary>
        /// 加载对应工位下对应产品的配方
        /// </summary>
        /// <param name="productionVr"></param>
        /// <param name="stationName"></param>
        public static bool LoadRecipes(string productionVr,string stationName)
        {
            try
            {
                List<AsmRecipeDetailObject> recipeList = AsmProductionRecipe_BLL.GetRecipesByProductionAndStation(productionVr, stationName);
                if (recipeList.Count > 0)
                {
                    Dictionary<int, Dictionary<string, string>> rp = new Dictionary<int, Dictionary<string, string>>();
                    foreach (AsmRecipeDetailObject ardo in recipeList)
                    {
                        Dictionary<string, string> recipe = new Dictionary<string, string>();
                        recipe.Add("StepNo", ardo.StepNo);
                        recipe.Add("Step_Category", ardo.Step_Category);
                        recipe.Add("Material_Name", ardo.Material_Name);
                        recipe.Add("Number", ardo.Number);
                        recipe.Add("Gun_No", ardo.Gun_No);
                        recipe.Add("Program_No", ardo.Program_No);
                        recipe.Add("Photo_No", ardo.Photo_No);
                        recipe.Add("Sleeve_No", ardo.Sleeve_No);
                        recipe.Add("ReworkTimes", ardo.ReworkTimes);
                        recipe.Add("Feacode", ardo.Feacode);
                        recipe.Add("CheckOrNo", ardo.CheckOrNo);
                        recipe.Add("ReviewOrNo", ardo.ReviewOrNo);
                        recipe.Add("ExactOrNo", ardo.ExactOrNo);
                        recipe.Add("MaterialPn", ardo.MaterialPn);
                        recipe.Add("BoltEQS", ardo.BoltEQS);
                        recipe.Add("A_Limit", ardo.A_Limit);
                        recipe.Add("T_Limit", ardo.T_Limit);
                        rp.Add(Convert.ToInt32(ardo.StepNo), recipe);
                    }
                    RecipesDic.Add(stationName, rp);
                    WriteCacheStationInfo(stationName, "ToalStep", recipeList.Count.ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// 
        /// 获取单步配方信息
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="stepNo"></param>
        /// <returns></returns>
        public static AsmRecipeDetailObject GetSingleRecipe(string stationName, int stepNo)
        {
            AsmRecipeDetailObject ardo = null;
            Dictionary<int, Dictionary<string, string>> stationRecipes = RecipesDic[stationName];
            Dictionary<string, string> recipe = stationRecipes[stepNo];
            if (recipe.Count > 0)
            {
                ardo = new AsmRecipeDetailObject();
                ardo.StepNo = recipe["StepNo"].ToString();
                ardo.Step_Category = recipe["Step_Category"];
                ardo.Material_Name = recipe["Material_Name"];
                ardo.Number = recipe["Number"];
                ardo.Gun_No = recipe["Gun_No"];
                ardo.Program_No = recipe["Program_No"];
                ardo.Photo_No = recipe["Photo_No"];
                ardo.Sleeve_No = recipe["Sleeve_No"];
                ardo.ReworkTimes = recipe["ReworkTimes"];
                ardo.Feacode = recipe["Feacode"];
                ardo.CheckOrNo = recipe["CheckOrNo"];
                ardo.ReviewOrNo = recipe["ReviewOrNo"];
                ardo.ExactOrNo = recipe["ExactOrNo"];
                ardo.MaterialPn = recipe["MaterialPn"];
                ardo.BoltEQS = recipe["BoltEQS"];
                ardo.A_Limit = recipe["A_Limit"];
                ardo.T_Limit = recipe["T_Limit"];
            }
            return ardo;
        }
        /// <summary>
        /// 写入工位缓存信息
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="item"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void WriteCacheStationInfo(string stationName, string item, string value)
        {
            StationsDic[stationName][item] = value;
        }
        /// <summary>
        /// 读取工位缓存信息
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetCacheStationInfo(string stationName, string item)
        {
            return StationsDic[stationName][item];
        }
        /// <summary>
        /// 清空工位缓存的信息
        /// </summary>
        /// <param name="stationName"></param>
        public static void ResetCacheStationInfo(string stationName)
        {
            StationsDic[stationName]["Emp"] = "";
            StationsDic[stationName]["Sn"] = "";
            StationsDic[stationName]["EngineSN"] = "";
            StationsDic[stationName]["GearboxSN"] = "";
            StationsDic[stationName]["TypeName"] = "";
            StationsDic[stationName]["TrayNum"] = "";
            StationsDic[stationName]["ProductNum"] = "";
            StationsDic[stationName]["StepNum"] = "";
            StationsDic[stationName]["ToalStep"] = "";
            StationsDic[stationName]["LOT0"] = "";
            StationsDic[stationName]["LOT1"] = "";
            StationsDic[stationName]["LOT2"] = "";
            StationsDic[stationName]["LOT3"] = "";
            StationsDic[stationName]["LOT4"] = "";
            StationsDic[stationName]["LOT5"] = "";
            StationsDic[stationName]["LOT6"] = "";
            StationsDic[stationName]["LOT7"] = "";
            StationsDic[stationName]["LOT8"] = "";
            StationsDic[stationName]["LOT9"] = "";
        }
        /// <summary>
        /// 清空工位配方
        /// </summary>
        public static void ResetCacheStationRecipeInfo(string stationName)
        {
            RecipesDic.Remove(stationName);
        }
    }
}
