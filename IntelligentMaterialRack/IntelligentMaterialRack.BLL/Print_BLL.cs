using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using MyPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class Print_BLL
    {
        private static ToPrint tp;
        public delegate void recodePrintLog(string a, int b);
        public event recodePrintLog recodePrintMessage;
        public delegate void printAlarm(int type);
        public event printAlarm printalarmType;
        public void Run()
        {
            try
            {
                tp = new ToPrint(new Font("宋体", 8, FontStyle.Regular), new Font("幼圆", 20, FontStyle.Bold));
                tp.Landscape = Convert.ToBoolean(ClsCommon.Landscape);//纸张横向
                recodePrintMessage("初始化打印成功......", 0);
            }
            catch (Exception ex)
            {
                printalarmType(72);
                recodePrintMessage("初始化打印失败......"+ex.Message, 1);
            }
        }
        public void PrintContext(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                bool a = tp.Print(dt, "测试");
                if (a)
                {
                    recodePrintMessage("打印成功....",0);
                }
                else
                {
                    recodePrintMessage("打印失败....",1);
                }
            }
        }
        public static void PrintDt(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                bool a = tp.Print(dt, "物料清单");
            }
        }
    }
}
