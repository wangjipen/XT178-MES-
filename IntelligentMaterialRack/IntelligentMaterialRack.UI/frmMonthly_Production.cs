using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class frmMonthly_Production : Form
    {
        public frmMonthly_Production()
        {
            InitializeComponent();
        }
        private void frmMonthly_Production_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            this.MaximizeBox = false;
            DateTime dt =  DateTime.Now;
            string time_Year = dt.ToString("yyyy");
            Dictionary<int,int> dic= AsmPTracking_BLL.GetMonthTurnoutByYear(time_Year);
            plotView1.Model=     LineChartSeriesWithDates(dic,time_Year);
        }
        /// <summary>
        /// 每月每天的产量统计
        /// </summary>
        /// <param name="dic_OK"></param>
        /// <returns></returns>
        public static PlotModel LineChartSeriesWithDates(Dictionary<int, int> dicX , string time_Year)
        {
            var plotmodel = new PlotModel();
            var lineSerial = new LineSeries() {
                Title = "月产量直线图",
                Background = OxyColors.AliceBlue,
                TextColor = OxyColors.Blue,
                LabelFormatString="{1}",                
            };
            int max = dicX[1];
            for (int i=1;i<dicX.Count;i++)
            {
                if (dicX[i + 1] > max) max = dicX[i + 1];
            }
            plotmodel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = max*1.1,
                Title = "产量",//显示标题内容
                TitlePosition = 0.99,//显示标题位置
                TitleColor = OxyColor.Parse("#8B4500"),//显示标题颜色
                IsZoomEnabled = false,//坐标轴缩放关闭
                IsPanEnabled = false,//图表缩放功能关闭
                MajorGridlineStyle = OxyPlot.LineStyle.Solid,
            });
            plotmodel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = 0.8,
                Maximum = 12.2,
                Title = "月份",//显示标题内容
                TitlePosition = 0.99,//显示标题位置
                TitleColor = OxyColor.Parse("#8B4500"),//显示标题颜色
                IsZoomEnabled = false,//坐标轴缩放关闭
                IsPanEnabled = false,//图表缩放功能关闭
                MajorGridlineStyle = OxyPlot.LineStyle.Solid,
                
            });
            frmMonthly_Production frm = new frmMonthly_Production();
            List<Point> list = new List<Point>();
            for (int i = 0; i < dicX.Count; i++)
            {
                lineSerial.Points.Add(new DataPoint(i+1, dicX[i + 1]));
            }
            plotmodel.Series.Add(lineSerial);        
            //----------------
            //var rd = new Random();
            //Task.Factory.StartNew(() =>
            //{
            //    while (true)
            //    {
            //        var x = rd.NextDouble() * 10 % 1;
            //        var y = rd.NextDouble() * 5 % 1;
            //        lineSerial.Points.Add(new DataPoint(x, y));
            //        //刷新视图
            //        plotmodel.InvalidatePlot(true);
            //        Thread.Sleep(500);
            //    }
            //});
            //----------------
            return plotmodel;
        }

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
        }

        /// <summary>
        /// 查询的监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_search_Click(object sender, EventArgs e)
        {
            string time_Year = comboBox1.SelectedItem.ToString();
            Dictionary<int, int> dic = AsmPTracking_BLL.GetMonthTurnoutByYear(time_Year);
            plotView1.Model = LineChartSeriesWithDates(dic, time_Year);
        }

        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
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
            else
            {
            }
        }
    }
}
