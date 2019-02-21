using Advantech.Adam;
using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using MyLog;
using SKTraceablity.Config;
using SKTraceablity.Setting;
using SKTraceablity.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKTraceablity.Run;
using System.Threading;
using SKTraceablity.Query;
using System.Xml;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using DevComponents.DotNetBar;


namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region>>>>>变量
        AutoSizeFormClass asc = new AutoSizeFormClass();
        bool reStart;
        Adam_BLL ab;
        Print_BLL print;
        SKTraceablity.Run.Alarm alarm = new SKTraceablity.Run.Alarm();
        public string LineName { set; get; }
        public string StationName { set; get; }
        #endregion
        #region>>>>>各种基础配置页面显示
        /// <summary>
        /// 重启系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem11_Click(object sender, EventArgs e)
        {
            bool QuitWithLogin = ClsCommon.quitWithLogin;
            if (QuitWithLogin)
            {
                Form1 fl = new Form1();
                if (fl.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            reStart = true;
            recordMessage("系统重启......", 0);
            Application.Restart();
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem12_Click(object sender, EventArgs e)
        {
            recordMessage("退出系统......", 0);
            this.Close();
            System.Environment.Exit(0);
        }
        /// <summary>
        /// 显示基础配置页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            frmSystemSetting fss = new frmSystemSetting();
            fss.ShowDialog();
            DialogResult result = MessageBox.Show("\n修改系统设置后应重启系统   \n\n\n确认是否重启(Y/N)", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                reStart = true;
                Application.Restart();
            }
        }
        /// <summary>
        /// 显示员工管理页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            frmManagement fm = new frmManagement();
            fm.ShowDialog();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            frmManagement fm = new frmManagement();
            fm.ShowDialog();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            configForSN cfs = new configForSN();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            frmLog fLog = new frmLog();
            fLog.ShowDialog();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            frmLog fLog = new frmLog();
            fLog.ShowDialog();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            ProductionMg pm = new ProductionMg();
            pm.ShowDialog();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            RecipeMg rm = new RecipeMg();
            rm.ShowDialog();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            RecipeDetailMg rdm = new RecipeDetailMg();
            rdm.ShowDialog();
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }
        #endregion
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
               // asc.controllInitializeSize(this);
                #region>>>>>系统初始化
                foreach (XmlNode lineNode in ClsCommon.InfoRootNode.ChildNodes)
                {
                    LineName = lineNode.Attributes["name"].Value;
                    foreach (XmlNode _mNode in lineNode.SelectNodes("station"))
                    {
                        StationName = _mNode.Attributes["name"].Value;
                    }
                }
                #endregion
                #region>>>>>权限管理
                toolStripStatusName.Text = ClsCommon.userName;//显示登录角色
                if (ClsCommon.userName == "超级管理员")
                {
                    buttonItem2.Visible = true;
                    buttonItem22.Visible = true;
                    sideBarPanelItem1.Visible = true;
                    for (int i = 0; i < sideBarPanelItem1.SubItems.Count; i++)
                    {
                        sideBarPanelItem1.SubItems[i].Visible = true;
                    }
                    sideBarPanelItem2.Visible = true;
                    for (int i = 0; i < sideBarPanelItem2.SubItems.Count; i++)
                    {
                        sideBarPanelItem2.SubItems[i].Visible = true;
                    }
                    sideBarPanelItem3.Visible = true;
                    for (int i = 0; i < sideBarPanelItem3.SubItems.Count; i++)
                    {
                        sideBarPanelItem3.SubItems[i].Visible = true;
                    }
                    sideBarPanelItem4.Visible = true;
                    for (int i = 0; i < sideBarPanelItem4.SubItems.Count; i++)
                    {
                        sideBarPanelItem4.SubItems[i].Visible = true;
                    }
                    sideBarPanelItem5.Visible = true;
                    for (int i = 0; i < sideBarPanelItem5.SubItems.Count; i++)
                    {
                        sideBarPanelItem5.SubItems[i].Visible = true;
                    }
                    sideBarPanelItem6.Visible = true;
                    for (int i = 0; i < sideBarPanelItem6.SubItems.Count; i++)
                    {
                        sideBarPanelItem6.SubItems[i].Visible = true;
                    }
                }
                else
                {
                    sideBarPanelItem7.Visible = false;
                    #region>>>初始化用户权限
                    Dictionary<string, List<Dictionary<int, string>>> dic = LoadXmlConfig();
                    DataTable dt_user = User_BLL.GetUserPower(ClsCommon.userName);
                    string user_powerX = dt_user.Rows[0]["Power"].ToString();

                    string   user_power= EncryPtForMy.Class1.DecryptDES(user_powerX);

                    Dictionary<string, List<int>> dic_split_power = Split_Power(user_power);

                   // Lookup<string, string> lookup = ;
                    Dictionary<string, string> dicX = new Dictionary<string, string>();//放置循环结果
                    for (int i=0;i< dic_split_power.Count;i++)
                    {
                        for (int j=0;j<dic.Count;j++)
                        {
                            if (dic_split_power.Keys.ToList()[i]== dic.Keys.ToList()[j])
                            {
                                List<int> listX = dic_split_power[dic_split_power.Keys.ToList()[i]];
                                List<Dictionary<int, string>> listC = dic[dic.Keys.ToList()[j]];
                                Dictionary<int, string> dicCX = new Dictionary<int, string>();
                                for (int m=0;m<listC.Count;m++)
                                {
                                    for (int w=0;w< (listC[m] as Dictionary<int, string>).Keys.Count;w++)
                                    {
                                        dicCX.Add((listC[m] as Dictionary<int, string>).Keys.ToList()[w], (listC[m] as Dictionary<int, string>).Values.ToList()[w]);
                                    }
                                }
                                for (int n=0;n<listX.Count;n++)
                                {
                                    for (int  p=0;p< dicCX.Count;p++)
                                    {
                                        if (listX[n]==dicCX.Keys.ToList()[p])
                                        {
                                            if (dic_split_power.Keys.ToList()[i]== "basis")
                                            {
                                                sideBarPanelItem1.Visible = true;                                                
                                                SideBar sb=this.Controls["sideBar1"] as SideBar;
                                                sb.GetItem("sideBarPanelItem1").SubItems[dicCX.Values.ToList()[p]].Visible = true;
                                                if(dicCX.Values.ToList()[p].ToString().Equals("buttonItem7"))
                                                    buttonItem2.Visible = true;
                                                if (dicCX.Values.ToList()[p].ToString().Equals("buttonItem8"))
                                                    buttonItem22.Visible = true;
                                            }
                                            if (dic_split_power.Keys.ToList()[i] == "plan")
                                            {
                                                sideBarPanelItem4.Visible = true;
                                                SideBar sb = this.Controls["sideBar1"] as SideBar;
                                                sb.GetItem("sideBarPanelItem4").SubItems[dicCX.Values.ToList()[p]].Visible = true;
                                            }
                                            if (dic_split_power.Keys.ToList()[i] == "formula")
                                            {
                                                sideBarPanelItem2.Visible = true;
                                                SideBar sb = this.Controls["sideBar1"] as SideBar;
                                                sb.GetItem("sideBarPanelItem2").SubItems[dicCX.Values.ToList()[p]].Visible = true;
                                            }
                                            if (dic_split_power.Keys.ToList()[i] == "table")
                                            {
                                                sideBarPanelItem5.Visible = true;
                                                SideBar sb = this.Controls["sideBar1"] as SideBar;
                                                sb.GetItem("sideBarPanelItem5").SubItems[dicCX.Values.ToList()[p]].Visible = true;
                                            }
                                            if (dic_split_power.Keys.ToList()[i] == "tool")
                                            {
                                                sideBarPanelItem3.Visible = true;
                                                SideBar sb = this.Controls["sideBar1"] as SideBar;
                                                sb.GetItem("sideBarPanelItem3").SubItems[dicCX.Values.ToList()[p]].Visible = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }

                //if (ClsCommon.userName != "Administrator" && ClsCommon.userName != "超级管理员")
                //{
                //    buttonItem5.Visible = false;
                //    sideBarPanelItem6.Visible = false;
                //}
                //if (ClsCommon.userName != "管理员" && ClsCommon.userName != "Administrator" && ClsCommon.userName != "超级管理员")
                //{
                //    buttonItem6.Visible = false;
                //    buttonItem7.Visible = false;
                //    labelItem1.Visible = false;
                //    buttonItem2.Visible = false;
                //    sideBarPanelItem6.Visible = false;
                //}
                //if (ClsCommon.userName != "Administrator")
                //{
                //    buttonItem5.Visible = false;
                //}
                //if (ClsCommon.userName != "管理员"&& ClsCommon.userName != "Administrator")
                //{
                //    buttonItem6.Visible = false;
                //    buttonItem7.Visible = false;
                //    labelItem1.Visible = false;
                //    buttonItem2.Visible = false;
                //}
                #endregion
                #region>>>>>初始化板卡
                //if (Function_BLL.getStationAttribute(LineName, StationName, "adamOrNot") == "1")
                //{
                //    ab = new Adam_BLL();
                //    ab.LineName = LineName;
                //    ab.StationName = StationName;
                //    ab.recodeAdamMessage += new Adam_BLL.recodeAdamLog(recordMessage);
                //    ab.AdamalarmType += new Adam_BLL.AdamAlarm(AlarmFormBusiness);
                //    ab.Run();
                //}
                #endregion
                #region>>>>>初始化打印
                //if (Function_BLL.getStationAttribute(LineName, StationName, "printOrNot") == "1")
                //{
                //    print = new Print_BLL();
                //    print.recodePrintMessage += new Print_BLL.recodePrintLog(recordMessage);
                //    print.printalarmType += new Print_BLL.printAlarm(AlarmFormBusiness);
                //    Thread printworkThread = new Thread(new ThreadStart(print.Run));
                //    printworkThread.Start();
                //}
                #endregion
                recordMessage("系统初始化成功！！ "+ ClsCommon.userName + "  欢迎你！", 0);
            }
            catch (Exception ex)
            {
                recordMessage("系统初始化失败，请重启......"+ex.Message, 1);
                Application.Restart();
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reStart)
            {
                Log.InformationLog.Info("系统重启");
            }
            else if (!ClsCommon.quitWithLogin)
            {
                DialogResult result = MessageBox.Show("\n欢迎再次使用本系统   \n\n\n确认是否退出(Y/N)", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    //if (ab != null)
                    //{
                    //    ab.CloseAdam();
                    //}
                    recordMessage("系统关闭......", 0);
                    System.Environment.Exit(0);
                    return;
                }
            }
            else
            {

                Form1 fl = new Form1();
                if (fl.ShowDialog() != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.da.Text = "系统时间:" + System.DateTime.Now.ToString("yy/MM/dd HH:mm:ss");
        }
        #region 记录日志的方法
        public void recordMessage(string message, int type)
        {
            recordMessage(string.Empty, message, type);
        }

        public void recordMessage(string name, string message, int type)
        {
            if (type == 1) Log.InformationLog.Error(message);//1表示错误
            else Log.InformationLog.Info(message);
            BeginInvoke((MethodInvoker)delegate ()
            {
                if (RTB_Log.Lines.Count() > 500)
                {
                    RTB_Log.Clear();
                }
            });
            BeginInvoke((MethodInvoker)delegate () { RTB_Log.Text = RTB_Log.Text.Insert(0, DateTime.Now.ToString("yy/MM/dd-HH:mm:ss") + "  ：  " + message + Environment.NewLine); });

        }

        public void recordMessage(string message, Exception ex, int type)
        {
            int i = ex.StackTrace.IndexOf("行号");
            string s = ex.StackTrace.Substring(i + 3);
            i = s.IndexOf(' ');
            if (i != -1)
            {
                s = s.Substring(0, i).Trim();
            }
            if (RTB_Log.Lines.Count() > 500)
            {
                BeginInvoke((MethodInvoker)delegate () { RTB_Log.Clear(); });
            }
            BeginInvoke((MethodInvoker)delegate () { RTB_Log.Text = RTB_Log.Text.Insert(0, DateTime.Now.ToString("yy/MM/dd-HH:mm:ss") + "  ：  " + message + Environment.NewLine); });
            if (type == 0) Log.InformationLog.Info(message + " 行号：" + s);//0表示正常数据
            else if (type == 1) Log.InformationLog.Error(message + " 行号：" + s);//1表示错误
            else if (type == 2) Log.InformationLog.Fatal(message + " 行号：" + s);//2表示产生数据
            else if (type == 3) Log.InformationLog.Debug(message + " 行号：" + s);//3表示系统BUG
        }
        #endregion
        #region>>>>>弹出报警框的方法
        public void AlarmFormBusiness(int type)
        {
            if (type > 0)
            {              
                BeginInvoke((MethodInvoker)delegate () { alarm.alarmRichBox.Text = Function_BLL.getAlarmByType(type.ToString(), LineName, StationName); });                
                BeginInvoke((MethodInvoker)delegate () { alarm.Show(); });
            }
            else
            {
                BeginInvoke((MethodInvoker)delegate () { alarm.Hide(); });
            }
        }

        #endregion

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            ImportRecipe ir = new ImportRecipe();
            ir.ShowDialog();
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            frmBarcode fbc = new frmBarcode();
            fbc.Show();       
        }

      
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            PlanManager pm = new PlanManager();
            pm.ShowDialog();
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            FinishPlanQuery fpq = new FinishPlanQuery();
            fpq.ShowDialog();           
        }



        private void buttonItem18_Click(object sender, EventArgs e)
        {
            ClosePlanQuery cp = new ClosePlanQuery();
            cp.ShowDialog();
        }

        private void btnitem_barcode_Click(object sender, EventArgs e)
        {
            PrintManager prm = new PrintManager();
            prm.ShowDialog();
        }

        private void btnItem_22_Click(object sender, EventArgs e)
        {
            frm_percentofpass fp = new frm_percentofpass();
            fp.ShowDialog();
        }

        private void btnItem_24_Click(object sender, EventArgs e)
        {
            Airtightness air = new Airtightness();
            air.ShowDialog();
        }

        private void btnItem_25_Click(object sender, EventArgs e)
        {
            ProductionByDay pbd = new ProductionByDay();
            pbd.ShowDialog();
        }

        private void btnItem_26_Click(object sender, EventArgs e)
        {
            OKProductionByDay opbd = new OKProductionByDay();
            opbd.ShowDialog();
        }

        private void btnItem_27_Click(object sender, EventArgs e)
        {
            NGProductionByDay npbd = new NGProductionByDay();
            npbd.ShowDialog();
        }

        private void btnItem_28_Click(object sender, EventArgs e)
        {
            frmMonthly_Production fmp = new frmMonthly_Production();
            fmp.ShowDialog();
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            ElectronicRecord er = new ElectronicRecord();
            er.ShowDialog();
        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            User_Power_Manager upm = new User_Power_Manager();
            upm.ShowDialog();
        }

        XmlDocument xml = new XmlDocument();
        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Dictionary<int, string>>> LoadXmlConfig()
        {
            string filePath = System.Windows.Forms.Application.StartupPath + "\\ApplicationName.dll";
            try
            {
                xml.Load(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return HandleXML();
        }

        /// <summary>
        /// 提取各个模块值
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Dictionary<int, string>>> HandleXML()
        {
            XmlNode rootNode;//根节点
            Dictionary<string, List<Dictionary<int, string>>> dic = new Dictionary<string, List<Dictionary<int, string>>>();
            List<Dictionary<int,string>> list_modename;
            Dictionary<int, string> dic_name_detail=null;
            rootNode = xml.DocumentElement;
            //   XmlNode node_mode = rootNode.SelectSingleNode("mode");
            XmlNodeList xnl = rootNode.ChildNodes;
            foreach (XmlNode singleXmlNode in xnl)
            {
                list_modename = new List<Dictionary<int, string>>();
                XmlNodeList xnlX = singleXmlNode.ChildNodes;
                dic_name_detail = new Dictionary<int, string>();
                foreach (XmlNode singleXmlNodeX in xnlX)
                {
                    
                    dic_name_detail.Add(Convert.ToInt32(singleXmlNodeX.Attributes["ID"].Value), singleXmlNodeX.Attributes["name"].Value);
                    
                }
                list_modename.Add(dic_name_detail);
                dic.Add(singleXmlNode.Attributes["name"].Value, list_modename);
            }
            return dic;
        }

        /// <summary>
        /// 拆分字符串
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public Dictionary<string, List<int>> Split_Power(string power)
        {
            Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();
            string[] str = power.Split(';');
            for (int i = 0; i < str.Length; i++)
            {
                List<int> list = new List<int>();
                if (str[i].Split(':')[1] != "")
                {
                    if (str[i].Split(':')[1].ToString().Length == 1)
                    {
                        list.Add(Convert.ToInt32(str[i].Split(':')[1].ToString()));
                    }
                    else
                    {
                        for (int j = 0; j < str[i].Split(':')[1].ToString().Split(',').Length; j++)
                        {
                            list.Add(Convert.ToInt32(str[i].Split(':')[1].ToString().Split(',')[j]));
                        }
                    }
                    dic.Add(str[i].Split(':')[0].ToString(), list);
                }
                else
                {
                    dic.Add(str[i].Split(':')[0].ToString(), list);
                    continue;
                }

            }
            return dic;
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            ReturnLineMg rlm = new ReturnLineMg();
            rlm.ShowDialog();
        }

        private void btn_ROUTING_Click(object sender, EventArgs e)
        {
            try
            {
                frm_routing routing = new frm_routing();
                routing.ShowDialog();
            }
            catch (Exception eXX)
            {

            }
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            WarningManagement1 wmg = new WarningManagement1();
            wmg.ShowDialog();
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            DeviceManagement dmg = new DeviceManagement();
            dmg.ShowDialog();
        }
    }
}
