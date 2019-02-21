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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class OKProductionByDay : Form
    {
        public OKProductionByDay()
        {
            InitializeComponent();
        }
        public static List<Item> data = new List<Item>();

        private void OKProductionByDay_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            dateTimePicker1.Value = DateTime.Now;
            plotView1.Model = ColumnSeriesWithDates();
        }
        /// <summary>
        /// 创建日产量统计图表
        /// </summary>
        /// <param name="dic_NUM"></param>
        /// <returns></returns>
        public  PlotModel ColumnSeriesWithDates()
        {
            var plotModel1 = new PlotModel
            {
                Title = "每日合格产量统计",
                Culture = CultureInfo.InvariantCulture,
            };
            string time_Today = Convert.ToDateTime(dateTimePicker1.Value.Date).ToString("yyyy-MM");//获得当前选择的时间（默认为本月）
            Dictionary<int, int> dic_NUM = AsmProductionNum_BLL.GetProductionOK(time_Today.Substring(0, 7).Trim());
            DateTime datatime = Convert.ToDateTime(dateTimePicker1.Value.Date);
            int day_NUM = DateTime.DaysInMonth(datatime.Year, datatime.Month);//获取某年某月的天
            var data = new List<Item>();
            int a = dic_NUM[0];//用于保存最大值
            for (int i = 1; i <= day_NUM; i++)
            {
                data.Add(new Item { X = i, Y = dic_NUM[i] });
                if (dic_NUM[i] > a)
                    a = dic_NUM[i];
            }
            plotModel1.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "产量", TitlePosition = 0.99, TitleColor = OxyColor.Parse("#8B4500"), TitleFontSize = 16, Minimum = 0 ,Maximum = a*1.1});
            plotModel1.Axes.Add(new CategoryAxis
            {
                ItemsSource = data,
                Title = "日",
                TitlePosition = 0.99,
                TitleColor = OxyColor.Parse("#8B4500"),
                TitleFontSize = 16,
                LabelField = "X",
                TickStyle = OxyPlot.Axes.TickStyle.None
            });

            var ls = new LineSeries { Title = "日合格产品产量", DataFieldX = "X", DataFieldY = "Y", LabelFormatString = "{1}" };
            var ii = new List<Item>();

            for (int i = 0; i < day_NUM; i++)
                ii.Add(new Item { X = i, Y = dic_NUM[i + 1] });
            ls.ItemsSource = ii;
            plotModel1.Series.Add(ls);
            return plotModel1;
        }
        public class Item
        {
            public int X { get; set; }
            public double Y { get; set; }
        }

        private void bt_search_X_Click(object sender, EventArgs e)
        {
            plotView1.Model = ColumnSeriesWithDates();
        }

        private void btn_ExTWO_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = @"Excel|*.xls";
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
            if (path != "")
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
