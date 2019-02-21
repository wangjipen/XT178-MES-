using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Globalization;
using System.Runtime;
using static ExampleLibrary.DateTimeAxisExamples;
using static ExampleLibrary.TimeSpanAxisExamples;
using System.IO;
using OxyPlot.WindowsForms;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class Airtightness : Form
    {
        public Airtightness()
        {
            InitializeComponent();
        }

        public static List<Item> data = new List<Item>();
        public Dictionary<int, string> dic_year = new Dictionary<int, string>();
        public Dictionary<int, string> dic_month = new Dictionary<int, string>();
        private void Airtightness_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            dateTimePicker1.Value = DateTime.Now;
            dic_month = SetMonthRule();
            dic_year = SetYearRule();
            #region  获取当天的气密合格与否的数量
            DateTime dTX = dateTimePicker1.Value;
            string time_Today = dTX.ToString("yyyy-MM-dd hh:mm:ss");
            //int year=Convert.ToInt32( dTX.ToString("yyyy"));
            //int month = Convert.ToInt32(dTX.ToString("MM"));
            //string str_year = "";
            //string str_month = "";
            //for (int i = 2017; i < 2051; i++)
            //{
            //    if (i == year)
            //    {
            //        str_year = dic_year[i];
            //    }
            //}
            //for (int i = 1; i < 32; i++)
            //{
            //    if (month == i)
            //    {
            //        str_month = dic_month[i];
            //    }
            //}
            Dictionary<int, int> dic_OK = AsmPLeaking_BLL.GetAirtightnessOK(time_Today.Substring(0, 7).Trim());
            Dictionary<int, int> dic_NG = AsmPLeaking_BLL.GetAirtightnessNG(time_Today.Substring(0, 7).Trim());
            #endregion
            DateTime datetime = DateTime.Now;
            plotView1.Model = ColumnSeriesWithDates(dic_OK, dic_NG, datetime);
        }

        /// <summary>
        /// 气密性测试统计图表的创建
        /// </summary>
        /// <param name="dic_OK"></param>
        /// <param name="dic_NG"></param>
        /// <returns></returns>
        public static PlotModel ColumnSeriesWithDates(Dictionary<int, int> dic_OK, Dictionary<int, int> dic_NG,DateTime datetime)
        {
            var plotModel1 = new PlotModel
            {
                Title = "气密性测试统计",
                Culture = CultureInfo.InvariantCulture,
            };
             int day_NUM = DateTime.DaysInMonth(datetime.Year, datetime.Month);          
            var data = new List<Item>();
            for (int i = 1; i < day_NUM+1; i++)
                data.Add(new Item { X = i, Y = dic_OK[i], YY=dic_NG[i]});
            plotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Left,Title="产量", TitlePosition = 0.99, Minimum = 0, Maximum = 280 });
          //  plotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom,Title="日期",TitlePosition = 0.99, Minimum = 0 });
            plotModel1.Axes.Add(new CategoryAxis
            {
                ItemsSource = data,
                LabelField = "X",
                IsZoomEnabled = false,
                IsPanEnabled = false,
                TickStyle = OxyPlot.Axes.TickStyle.None
            });
            plotModel1.Series.Add(new ColumnSeries { ItemsSource = data, ValueField = "Y", Background = OxyColors.Gainsboro, FillColor = OxyColors.CadetBlue, FontSize = 12, Title = "指定日期合格量",/*LabelPlacement= LabelPlacement.Outside*/LabelFormatString = "{0}" });
            plotModel1.Series.Add(new ColumnSeries { ItemsSource = data, ValueField = "YY", Background = OxyColors.Gainsboro, FillColor = OxyColors.Indigo, FontSize = 12, Title = "指定日期不合格量",/*LabelPlacement= LabelPlacement.Outside*/LabelFormatString = "{0}" });
            return plotModel1;
        }
        public class Item
        {
            public int X { get; set; }
            public double Y { get; set; }
            public double YY { get; set; }
        }

   
  
   

       
        private void bt_Export_Click(object sender, EventArgs e)
        {
           //不要删
        }


        /// <summary>
        /// 设置条码年的规则
        /// </summary>
        public Dictionary<int, string> SetYearRule()
        {
            Dictionary<int, string> dic_year = new Dictionary<int, string>();
            dic_year.Add(2017, "7");
            dic_year.Add(2018, "8");
            dic_year.Add(2019, "9");
            dic_year.Add(2020, "A");
            dic_year.Add(2021, "B");
            dic_year.Add(2022, "C");
            dic_year.Add(2023, "D");
            dic_year.Add(2024, "E");
            dic_year.Add(2025, "F");
            dic_year.Add(2026, "G");
            dic_year.Add(2027, "H");
            dic_year.Add(2028, "J");
            dic_year.Add(2029, "K");
            dic_year.Add(2030, "L");
            dic_year.Add(2031, "M");
            dic_year.Add(2032, "N");
            dic_year.Add(2033, "P");
            dic_year.Add(2034, "R");
            dic_year.Add(2035, "S");
            dic_year.Add(2036, "T");
            dic_year.Add(2037, "V");
            dic_year.Add(2038, "W");
            dic_year.Add(2039, "X");
            dic_year.Add(2040, "Y");
            dic_year.Add(2041, "1");
            dic_year.Add(2042, "2");
            dic_year.Add(2043, "3");
            dic_year.Add(2044, "4");
            dic_year.Add(2045, "5");
            dic_year.Add(2046, "6");
            dic_year.Add(2047, "7");
            dic_year.Add(2048, "8");
            dic_year.Add(2049, "9");
            dic_year.Add(2050, "A");
            return dic_year;
        }


        /// <summary>
        /// 设置月的规则
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> SetMonthRule()
        {
            Dictionary<int, string> dic_month = new Dictionary<int, string>();
            dic_month.Add(1, "1");
            dic_month.Add(2, "2");
            dic_month.Add(3, "3");
            dic_month.Add(4, "4");
            dic_month.Add(5, "5");
            dic_month.Add(6, "6");
            dic_month.Add(7, "7");
            dic_month.Add(8, "8");
            dic_month.Add(9, "9");
            dic_month.Add(10, "A");
            dic_month.Add(11, "B");
            dic_month.Add(12, "C");
            dic_month.Add(13, "D");
            dic_month.Add(14, "E");
            dic_month.Add(15, "F");
            dic_month.Add(16, "G");
            dic_month.Add(17, "H");
            dic_month.Add(18, "J");
            dic_month.Add(19, "K");
            dic_month.Add(20, "L");
            dic_month.Add(21, "M");
            dic_month.Add(22, "N");
            dic_month.Add(23, "P");
            dic_month.Add(24, "R");
            dic_month.Add(25, "S");
            dic_month.Add(26, "T");
            dic_month.Add(27, "V");
            dic_month.Add(28, "W");
            dic_month.Add(29, "X");
            dic_month.Add(30, "Y");
            dic_month.Add(31, "0");
            return dic_month;
        }
        /// <summary>
        /// 查询按钮监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_search_X_Click(object sender, EventArgs e)
        {
            string time_Today = Convert.ToDateTime(dateTimePicker1.Value.Date).ToString("yyyy-MM-dd");
            Dictionary<int, int> dic_OK = AsmPLeaking_BLL.GetAirtightnessOK(time_Today.Substring(0, 7).Trim());
            Dictionary<int, int> dic_NG = AsmPLeaking_BLL.GetAirtightnessNG(time_Today.Substring(0, 7).Trim());
            DateTime datatime = Convert.ToDateTime(dateTimePicker1.Value.Date);
            int day_NUM = DateTime.DaysInMonth(datatime.Year, datatime.Month);
            //for (int i = 0; i < day_NUM; i++)
            //{
            //    data.Add(new Item { X = i+1, Y = dic_OK[i], YY = dic_NG[i] });
            //}
            plotView1.Model = ColumnSeriesWithDates(dic_OK, dic_NG, datatime);
        }


        /// <summary>
        /// 导出图表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExTWO_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //   sfd.Filter = @"Excel|*.xlsx";
            sfd.Filter = "xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            sfd.ShowDialog();
            string path = sfd.FileName;
            PlotModel pm = plotView1.Model;
            var pngExporter = new PngExporter { Width = 1000, Height = 400, Background = OxyColors.White };
            Bitmap bitmap = pngExporter.ExportToBitmap(pm);
            Image image = bitmap;
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            byte[] bytes = ms.ToArray();
            IWorkbook workbook = new HSSFWorkbook();
            workbook.CreateSheet("sheet1");


            if (path != null && path != "")
            {
                using (FileStream fs = File.Create(path))
                {
                    ISheet sheet = workbook.GetSheetAt(0);
                    HSSFClientAnchor anchor = new HSSFClientAnchor(0, 0, 0, 0, 0, 5, 6, 10);
                    int pic = workbook.AddPicture(bytes, PictureType.PNG);
                    IDrawing patriarch = sheet.CreateDrawingPatriarch();
                    IPicture ipic = patriarch.CreatePicture(anchor, pic);
                    ipic.Resize();
                    workbook.Write(fs);
                }
                MessageBox.Show("保存成功！");
            }


        }
    }
}
