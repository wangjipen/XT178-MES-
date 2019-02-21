using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using System.Globalization;
using System.Threading;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class PrintManager : Form
    {

        public int addbtn_times = 0;
        public Dictionary<int, string> dic_year = new Dictionary<int, string>();
        public Dictionary<int, string> dic_month = new Dictionary<int, string>();
        public PrintManager()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintManager_Load(object sender, EventArgs e)
        {
            DataTable dt= AsmPlan_BLL.GetPlanObjectByConditionToPrint();
            LoadSource(dt);
            dic_year  = SetYearRule();
            dic_month = SetMonthRule();

            lb_LINE_ID.DataSource = AsmLine_BLL.GetAllLines();
            lb_LINE_ID.DisplayMember = "NAME";
            lb_LINE_ID.ValueMember = "ID";
            lb_LINE_ID.SelectedIndex=-1;
        }
        /// <summary>
        /// 加载数据源
        /// </summary>
        /// <param name="dt"></param>
        public void LoadSource(DataTable dt)
        {
            DataGridViewButtonColumn columnbtn = new DataGridViewButtonColumn();
            
            
                    columnbtn.Text = "生成条码";
                    columnbtn.UseColumnTextForButtonValue = true;
                    columnbtn.Name = "操作";            
                    columnbtn.FlatStyle = FlatStyle.Popup;
            //dGV_Print.allowUserToAddRow = false;
            ///将生成条码的放置前列
            DataTable dtX = dt.Clone();
            dtX.Clear();
            int x_OK = 0,x_NO=0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["CREATE_BARCODE_FLAG"].ToString().Equals("0"))
                {
                    dtX.Rows.Add(dt.Rows[i].ItemArray);
                    x_NO++;
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["CREATE_BARCODE_FLAG"].ToString().Equals("1"))
                {
                    dtX.Rows.Add(dt.Rows[i].ItemArray);//通过一个数组来设置此行的所有值
                    x_OK++;
                }
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = dtX;
            
            dGV_Print.AutoGenerateColumns = false;
            dGV_Print.DataSource = bs;
            addbtn_times++;
            if (addbtn_times==1)
            {
                dGV_Print.Columns.Add(columnbtn);
               
            }

            for (int i=0;i<dtX.Rows.Count;i++)
            {
                if (dtX.Rows[i]["CREATE_BARCODE_FLAG"].ToString().Equals("1"))
                {
                  string a= dtX.Rows[i]["PRODUCTION_VR"].ToString();
                  dGV_Print.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
           
                }
            }

            if (dGV_Print.Rows.Count>0)
            {
                dGV_Print.Rows[0].Selected = false;
            }

        }
        /// <summary>
        /// button按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dGV_Print_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                string buttonText = this.dGV_Print.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (buttonText.Equals("生成条码") && (this.dGV_Print.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.Yellow))
                {
                    rTB_Barcode.Text = "";//清空richtextbox
                    AsmPlanObject apo = new AsmPlanObject();
                    string plan_productionvr = dGV_Print.Rows[e.RowIndex].Cells["PRODUCTION_VR"].Value.ToString();
                    string plan_data = dGV_Print.Rows[e.RowIndex].Cells["DT"].Value.ToString();
                    string plan_lineid = dGV_Print.Rows[e.RowIndex].Cells["LINE_ID"].Value.ToString();
                    string plan_number = dGV_Print.Rows[e.RowIndex].Cells["NUMBER"].Value.ToString();
                    string plan_productionid = dGV_Print.Rows[e.RowIndex].Cells["PRODUCTION_ID"].Value.ToString();
                    string plan_id = dGV_Print.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    apo.ID = Convert.ToInt32(plan_id);
                    apo.NAME = plan_productionvr;
                    apo.PRODUCTION_ID = Convert.ToInt32(plan_productionid);
                    apo.NUMBER = Convert.ToInt32(plan_number);
                    apo.LINE_ID = Convert.ToInt32(plan_lineid);

                    DateTime dt = Convert.ToDateTime(plan_data);
                    //int numofdate =Convert.ToInt32(dt.ToString("MM-dd"));
                    List<string> list = GetDayOfWeek(dt, plan_productionid);
                    CreateBarcodeBysomething(list, dt , apo);
                    ///设置R_PMS_PLAN_T打印标识
                    AsmPlan_BLL.SetBarcodeIdentification(plan_id);
                    MessageBox.Show("条码生成成功！");
                    Thread.Sleep(1000);
                    //dGV_Print.Rows[e.RowIndex]
                    dGV_Print.DataSource = null;
                    DataTable dtUpdate = AsmPlan_BLL.GetPlanObjectByConditionToPrint();
                    LoadSource(dtUpdate);
                }
                
                if (buttonText.Equals("展示条码") && (this.dGV_Print.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Yellow))
                {
                    rTB_Barcode.Text = "";
                    DataTable dt = AsmPlanPrint_BLL.GetBarcodeByCondition(this.dGV_Print.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        rTB_Barcode.AppendText(dt.Rows[i]["SN"].ToString() + "\r");
                    }
                }
            }
           
        }

        /// <summary>
        /// 根据datetime返回当前日期是今年第几周
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static int GetWeekOfYear(DateTime dt)
        {        
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }

        // <summary>
        // 获取当前日期包含指定计划名且在指定日期范围内的SN
        // </summary>
        // <returns></returns>
        public  List<string> GetDayOfWeek(DateTime dt,string id)
        {
            //DateTime startWeek1 = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
            //DateTime endWeek1 = startWeek1.AddDays(6);  //本周周日  
            //int week = (int)dt.DayOfWeek;
            //if (week == 0) week = 7; //周日
            //DateTime startWeek = dt.AddDays(-(week - 1));
            //DateTime endWeek = startWeek.AddDays(6);
            #region
            int str_month = Convert.ToInt32(dt.ToString("MM"));
            int str_day = Convert.ToInt32(dt.ToString("dd"));
            string month = ""; string day = "";
            int year = Convert.ToInt32( dt.ToString("yyyy"));
            for (int i = 1; i < 32; i++)
            {
                if (str_month == i)
                {
                    month = dic_month[i];
                }
                if (str_day == i)
                {
                    day = dic_month[i];
                }
            }
            string str_year = "";
            for (int i = 2017; i < 2051; i++)
            {
                if (i == year)
                {
                    str_year = dic_year[i];
                }
            }
            #endregion



            List<string> list=   AsmPlan_BLL.GetSnByTime("'%" + str_year+month+day + "_______' " + " and  PRODUCTION_ID=' " + id+"'");
            return list;
        }

       


        /// <summary>
        /// 构建SN并存储
        /// </summary>
        /// <param name="list_SN"></param>
        /// <param name="weekofyear"></param>
        /// <param name="lineid"></param>
        /// <param name="product_name"></param>
        /// <returns></returns>
        public  bool CreateBarcodeBysomething(List<string> list_SN,DateTime numofdate,AsmPlanObject apo)
        {
            try
            {
                string month_day = "";
                int str_month =Convert.ToInt32( numofdate.ToString("MM"));
                int str_day   =Convert.ToInt32(numofdate.ToString("dd"));
                string month =""; string day = "";
                for (int i=1;i<32;i++)
                {
                    if (str_month==i)
                    {
                        month = dic_month[i];
                    }
                    if (str_day == i)
                    {
                        day = dic_month[i];
                    }
                }


                bool x = true;
                PrintManager pm = new PrintManager();
                if (list_SN.Count != 0)
                {

                    List<string> list_barcode = new List<string>();
                    List<int> list_lastnumoffive = new List<int>();
                    ///截取后五位
                    for (int i = 0; i < list_SN.Count; i++)
                    {
                        // list_lastnumoffive.Add(list_SN[i].ToString().IndexOf(list_SN[i].ToString(), 18, list_SN[i].ToString().Length));
                        int a = list_SN[i].ToString().Length;
                        list_lastnumoffive.Add(Convert.ToInt32( list_SN[i].ToString().Substring(a-7,7)));
                    }
                    ///比较得出最大值
                    int max = list_lastnumoffive[0];
                    int max_keep = 0;
                    for (int i = 0; i < list_lastnumoffive.Count; i++)
                    {
                        if (list_lastnumoffive[i] > max)
                        {
                            max = list_lastnumoffive[i];
                            max_keep = list_lastnumoffive[i];
                        }
                    }

                    DateTime dt = DateTime.Now;
                    int year = Convert.ToInt32( dt.ToString("yyyy"));
                    string str_year = "";
                    for (int i=2017;i<2051;i++)
                    {
                        if (i==year)
                        {
                            str_year = dic_year[i];
                        }
                    }
                    //int a = (dt.Year % 100) - 20;
                    for (int i=0;i<apo.NUMBER;i++)
                    {
                        max += 1;
                        list_barcode.Add("0"+apo.LINE_ID+apo.NAME+str_year+month+day+max.ToString("D7"));
                    }
                    
                    ///存储
                    ///
                    for (int i = 0; i < list_barcode.Count; i++)
                    {
                        AsmPlanPrintObject appo = new AsmPlanPrintObject();
                        appo.DT = DateTime.Now;
                        appo.SN = list_barcode[i].ToString();                    
                        rTB_Barcode.AppendText(appo.SN+"\r");
                        appo.PLAN_ID = apo.ID;
                        appo.LINE_ID = Convert.ToInt32(apo.LINE_ID);
                        appo.PRODUCTION_ID = Convert.ToInt32(apo.PRODUCTION_ID);
                        appo.SERIAL_NO = max_keep+i;
                        appo.PRINT_FLAG = "0";
                        AsmPlanPrint_BLL.AddPlanPrint(appo);
                    }

                }
                else
                {
                    List<string> list_barcode = new List<string>();
                    int numOfSN = Convert.ToInt32(apo.NUMBER);

                    DateTime dtt = DateTime.Now;
                    int year = Convert.ToInt32(dtt.ToString("yyyy"));
                    string str_year = "";
                    for (int i = 2017; i < 2051; i++)
                    {
                        if (i == year)
                        {
                            str_year = dic_year[i];
                        }
                    }
                    for (int i = 1; i < numOfSN + 1; i++)
                    {                     
                            DateTime dt = DateTime.Now;
                            string item = "0" + apo.LINE_ID+apo.NAME + str_year + month+day + i.ToString("D7");
                            list_barcode.Add(item);                           
                            rTB_Barcode.AppendText(item.Trim() + "\r");                      
                    }
                    ///存储
                    ///
                    for (int i = 0; i < list_barcode.Count; i++)
                    {
                        AsmPlanPrintObject appo = new AsmPlanPrintObject();
                        appo.DT = DateTime.Now;
                        appo.SN = list_barcode[i].ToString();
                        appo.PLAN_ID = apo.ID;
                        appo.LINE_ID = Convert.ToInt32(apo.LINE_ID);
                        appo.PRODUCTION_ID = Convert.ToInt32(apo.PRODUCTION_ID);
                        appo.SERIAL_NO = i+1;
                        appo.PRINT_FLAG = "0";
                        AsmPlanPrint_BLL.AddPlanPrint(appo);
                    }
                }
                return x;
            }
            catch (Exception  e)
            {
                MessageBox.Show(e.Message);
                return false;
            }                  
        }

        /// <summary>
        /// 按条件查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_select_Click(object sender, EventArgs e)
        {
            string str_name = tB_name.Text.Trim();
            string str_lineid = "";
            if (lb_LINE_ID.SelectedValue != null)
            {
                 str_lineid = lb_LINE_ID.SelectedValue.ToString();
            }
            else
            {
                str_lineid = "";
            }
            
            string str_operationuser = tb_operationuser.Text.Trim();
            string sql = "";
            if (str_name != null  && str_name != "")
            {
                sql = "and C_ASM_PRODUCTION_T.PRODUCTION_VR='" + str_name + "'";
            }
            if (str_lineid != null && str_lineid != "")
            {
                if(sql!=null)
                    sql +=" and "+" LINE_ID='" + str_lineid + "'";
                else
                    sql +=  "and LINE_ID='" + str_lineid + "'";
            }
            if (str_operationuser != null && str_operationuser != "")
            {
                if(sql!="")
                    sql += " and " +"OPREATION_USER='" + str_operationuser + "'";
                else
                    sql +=  "and OPREATION_USER='" + str_operationuser + "'";
            }
            if (sql == "")
            {
                    DataTable dt = AsmPlan_BLL.GetPlanObjectByInputConditionToPrint(sql);             
                    dGV_Print.DataSource = null;
                    LoadSource(dt);  
            }
            else
            {
                DataTable dt = AsmPlan_BLL.GetPlanObjectByInputConditionToPrint(sql);
                if (dt != null)
                {
                    dGV_Print.DataSource = null;
                    LoadSource(dt);
                }
                else
                    MessageBox.Show("输入查询条件有误！");
            }
        }

        /// <summary>
        /// 修改按钮生成条码为展示条码
        /// CellFormating  重绘制单元格属性时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dGV_Print_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e!= null)
            {
                if (dGV_Print.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1   )
                {
                    if ( dGV_Print.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Yellow)
                    {                     
                        DataGridViewButtonCell dgvc = dGV_Print.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;                 
                        dgvc.UseColumnTextForButtonValue = false;
                        dgvc.Value = "展示条码";
                    }
                }
            }
        }

        private void dGV_Print_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgb = (DataGridView)sender;
            dgb.Rows[dgb.Rows.Count-1].Cells[dgb.ColumnCount-1].Value = "zhanshi";
        }

        /// <summary>
        /// 设置条码年的规则
        /// </summary>
        public Dictionary<int, string> SetYearRule()
        {
          Dictionary<int,string>  dic_year = new Dictionary<int, string>();
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

      
    }
}
