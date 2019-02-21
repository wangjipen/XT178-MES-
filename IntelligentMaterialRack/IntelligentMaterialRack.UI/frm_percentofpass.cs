using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Globalization;
using System.Runtime;
using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using static ExampleLibrary.DateTimeAxisExamples;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class frm_percentofpass : Form
    {
        public frm_percentofpass()
        {
            InitializeComponent();
        }
        public static List<Item> data = new List<Item>();
        public static List<DataSourceObject> data_Product_Offline = new List<DataSourceObject>();
        public static List<DataSourceObject> data_Referral_Stats = new List<DataSourceObject>();
        private void frm_percentofpass_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            #region  获取当天的产品下线数量
            frm_percentofpass frm = new frm_percentofpass();
            DateTime dTX = frm.dateTimePicker1.Value;
            string time_Today = dTX.ToString("yyyy-MM-dd hh:mm:ss");
            Dictionary<int, int> dic = AsmPTracking_BLL.GetOfflineNumByCondition(time_Today.Substring(0, 10).Trim());
            #endregion
            plotView1.Model = ColumnSeriesWithDates(dic);


            /// 各产品下线分布情况    
            var dt = new DateTime(2017, 1, 1);
            data_Product_Offline = new List<DataSourceObject>();
            Dictionary<int, string> dic_Product_Offline = AsmPTracking_BLL.GetNumOfProduct(time_Today.Substring(0, 10).Trim());
            if (dic_Product_Offline != null)
            {
                for (int i = 0; i < dic_Product_Offline.Count/2; i++)
                    data_Product_Offline.Add(new DataSourceObject { TypeName = dic_Product_Offline[i+ dic_Product_Offline.Count / 2].ToString(), Y = Convert.ToDouble(dic_Product_Offline[i].ToString()) });
            }
            plotView2.Model = Product_Offline();


            /// 产品合格率报表
            data_Referral_Stats = new List<DataSourceObject>();
            double a = AsmPTracking_BLL.GetPercentOfOK(time_Today.Substring(0, 10).Trim());
            if (a > 0)
            {
                data_Referral_Stats.Add(new DataSourceObject { TypeName = "合格", Y = a });
                data_Referral_Stats.Add(new DataSourceObject { TypeName = "不合格", Y = 1 - a });
            }
            plotView3.Model = Referral_Stats();


            Dictionary<string,int> dic_OK_ALL=   AsmPTracking_BLL.GetProduct_OKAndALL(time_Today.Substring(0, 10).Trim());
            lb_offline.Text = dic_OK_ALL["ALL"].ToString();
            lb_OK.Text = dic_OK_ALL["OK"].ToString();
            lb_NG.ForeColor = Color.Red;    
                   
            lb_NG.Text = (dic_OK_ALL["ALL"]- dic_OK_ALL["OK"]).ToString();
           
        }

        /// <summary>
        /// 各小时下线数量统计
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static PlotModel ColumnSeriesWithDates( Dictionary<int,int> dic)
        {
            var plotModel1 = new PlotModel
            {
                Title = "各小时下线数量统计",
                Culture = CultureInfo.InvariantCulture,
            };
            var dt = DateTime.Today;
            var data = new List<Item>();
                for (int i = 0; i < 24; i++)
                    data.Add(new Item { X = dt.AddHours(i), Y = dic[i] });
                plotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Left,Title="产量", TitlePosition = 0.99, Minimum = 0, Maximum = 30 });
                plotModel1.Axes.Add(new CategoryAxis
                {
                    ItemsSource = data,
                    LabelField = "X",
                    StringFormat = "HH:mm",
                    TickStyle = OxyPlot.Axes.TickStyle.None
                });
                plotModel1.Series.Add(new ColumnSeries { ItemsSource = data, ValueField = "Y", Background = OxyColors.AliceBlue, FillColor = OxyColors.CadetBlue, FontSize = 12, Title = "当前时间段下线数",/*LabelPlacement= LabelPlacement.Outside*/LabelFormatString = "{0}" });
                return plotModel1;           
        }

        /// <summary>
        /// 产品合格率报表
        /// </summary>
        /// <returns></returns>
        public static PlotModel Referral_Stats()
        {
            var model = new PlotModel { Title = "产品合格率报表 " };
            var ps = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                Background = OxyColors.AliceBlue,
                TextColor = OxyColors.Blue,
                ItemsSource = data_Referral_Stats,
                LabelField = "TypeName",
                RenderInLegend = true,
                ValueField = "Y",
                InsideLabelFormat = "{1}"
            };

            model.Series.Add(ps);
            return model;
        }
        /// <summary>
        /// 各产品下线分布情况
        /// </summary>
        /// <returns></returns>
        private static PlotModel Product_Offline()
        {
            var model = new PlotModel { Title = "各产品下线分布情况" };
            var ps = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0,
                Background = OxyColors.AliceBlue,
                TextColor = OxyColors.Blue,
                ItemsSource = data_Product_Offline,
                LabelField = "TypeName",
                RenderInLegend = true,
                ValueField = "Y",
                InsideLabelFormat = "{1}"
            };
            model.Series.Add(ps);
            return model;
        }
        private class TimeValue
        {
            public DateTime Time { get; set; }
            public double Value { get; set; }
        }




        public class DataSourceObject
        {
            public string TypeName { get; set; }
            public double Y { get; set; }
        }
        /// <summary>
        /// 控件的值发生改变时触发--查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_search_Click_1(object sender, EventArgs e)
        {
            string time_Today = Convert.ToDateTime(dateTimePicker1.Value.Date).ToString("yyyy-MM-dd");
            #region  获取当天的产品下线数量
            frm_percentofpass frm = new frm_percentofpass();
            Dictionary<int, int> dic = AsmPTracking_BLL.GetOfflineNumByCondition(time_Today.Substring(0, 10).Trim());
            #endregion
            var dt = new DateTime(2017, 1, 1);
            for (int i = 0; i < 24; i++)
                data.Add(new Item { X = dt.AddHours(i), Y = dic[i] });
            plotView1.Model = ColumnSeriesWithDates(dic);


            /// 各产品下线分布情况         
            data_Product_Offline = new List<DataSourceObject>();
            Dictionary<int, string> dic_Product_Offline = AsmPTracking_BLL.GetNumOfProduct(time_Today.Substring(0, 10).Trim());
            if (dic_Product_Offline != null)
            {
                for (int i = 0; i < dic_Product_Offline.Count / 2; i++)
                    data_Product_Offline.Add(new DataSourceObject { TypeName = dic_Product_Offline[i + dic_Product_Offline.Count / 2].ToString(), Y = Convert.ToDouble(dic_Product_Offline[i].ToString()) });
            }
            plotView2.Model = Product_Offline();


            /// 产品合格率报表
            data_Referral_Stats = new List<DataSourceObject>();
            double a = AsmPTracking_BLL.GetPercentOfOK(time_Today.Substring(0, 10).Trim());
            if (a > 0)
            {
                data_Referral_Stats.Add(new DataSourceObject { TypeName = "当前时间段合格量", Y = a });
                data_Referral_Stats.Add(new DataSourceObject { TypeName = "当前时间段不合格量", Y = 1 - a });
            }
            plotView3.Model = Referral_Stats();

            Dictionary<string, int> dic_OK_ALL = AsmPTracking_BLL.GetProduct_OKAndALL(time_Today.Substring(0, 10).Trim());
            lb_offline.Text = dic_OK_ALL["ALL"].ToString();
            lb_OK.Text = dic_OK_ALL["OK"].ToString();
            lb_NG.Text = (dic_OK_ALL["ALL"] - dic_OK_ALL["OK"]).ToString();
            lb_NG.ForeColor = Color.Red;
        }
    }
}
