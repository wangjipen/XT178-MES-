using Lassalle.Flow;
using SKTraceablity.SKTraceablity.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using SKTraceablity.SKTraceablity.Moudle;
using IntelligentMaterialRack.IntelligentMaterialRack.BLL;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class frm_routing : Form
    {
        public frm_routing()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.CreateDiagram(this.addFlow);
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Delete)
                {
                    if (addFlow.SelectedItems.Count > 0)
                    {
                        if (addFlow.SelectedItems[0].Text != null)
                        {
                            List<Node> list = DrawStation(this.addFlow);
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i].Text.Equals(addFlow.SelectedItems[0].Text))
                                {
                                    Image img = new Bitmap(System.Environment.CurrentDirectory.Substring(0, System.Environment.CurrentDirectory.Length - 10) + "\\Resources\\station.png");
                                    list[i].Image = img;
                                    addFlow.AddNode(list[i]);
                                }
                            }
                        }
                    }
                    addFlow.IsSelectionChangeEventFired = false;
                    addFlow.DeleteSel();
                    addFlow.IsSelectionChangeEventFired = true;
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception  e)
            {
                return false;
            }
            
        }
     

        /// <summary>
        /// 窗体加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_routing_Load(object sender, EventArgs e)
        {
            LoadSource_combobox();
        }
        public Form Form { get; set; }

      
        /// <summary>
        /// 创建图
        /// </summary>
        /// <param name="addflow"></param>
        public    void CreateDiagram(AddFlow addflow)
        {
           
            try
            {
                AssemblyCopyrightAttribute aca = new AssemblyCopyrightAttribute("");
                addflow.Dock = DockStyle.Fill;
                addflow.BorderStyle = BorderStyle.FixedSingle;
                addflow.BackColor = Color.AliceBlue;
                addflow.CanStretchLink = false;
                addFlow.CanDrawNode = false;


                addflow.NodeModel.ShapeFamily = ShapeFamily.Rectangle;
                addflow.NodeModel.FillColor = Color.Transparent;
                addflow.NodeModel.GradientColor = Color.Transparent;
                addflow.NodeModel.DrawColor = Color.Transparent;
                addflow.NodeModel.TextPosition = TextPosition.CenterBottom;
                addflow.NodeModel.TextColor = Color.Black;
                addflow.NodeModel.ImagePosition = ImagePosition.CenterTop;
                addflow.NodeModel.IsEditable = false;
                addflow.NodeModel.IsXSizeable = false;
                addflow.NodeModel.IsYSizeable = false;

                addflow.LinkModel.FillColor = Color.Black;
                addflow.LinkModel.Thickness = 3;
                addflow.LinkModel.IsAdjustOrg = true;
                addflow.LinkModel.IsAdjustDst = true;

                List<Node> list_station = DrawStation(addflow);
                for (int i = 0; i < list_station.Count; i++)
                {
                    Image img = new Bitmap(System.Environment.CurrentDirectory.Substring(0, System.Environment.CurrentDirectory.Length - 10) + "\\Resources\\station.png");
                    list_station[i].Image = img;
                    addflow.AddNode(list_station[i]);
                }
                var nodes = addflow.Items.OfType<Node>().ToArray();
            }
            catch (Exception e1)
            {
            }

            
        }

        Link AddLink(AddFlow addflow, Node org, Node dst)
        {
            Link link = new Link(org, dst, null, addflow);
            addflow.AddLink(link);
            return link;
        }


        /// <summary>
        /// 绘制各个工位
        /// </summary>
        /// <param name="addflow"></param>
        public List<Node> DrawStation(AddFlow addflow)
        {
        
       
                List<Node> list = new List<Node>();
                Node node = null;
                DataTable dt = AsmStation_BLL.GetAllStation();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    node = new Node(10 + (60 * i), 580, 50, 85, dt.Rows[i]["STATION_NAME"].ToString(), addflow);
                    node.Text = dt.Rows[i]["STATION_NAME"].ToString();
                    node.FillColor = Color.White;
                    list.Add(node);
                }
                return list;
     
           
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e)
        {
            try
            {
                this.addFlow.Clear(); this.CreateDiagram(this.addFlow);
                bt_save.Enabled = true;
                addFlow.Enabled = true;
                Node[] nodes = addFlow.Items.OfType<Node>().ToArray();
                DataTable dt = AsmproductionWayRecord_BLL.GetAllByCondition("PRODUCTION_NAME = '" + cB_product_name.SelectedItem.ToString() + "'");
                int K_left = 0, K_right = 0;
                if (!(dt.Rows.Count > 0)) { MessageBox.Show("该产品未配置工艺路线"); this.addFlow.Clear(); this.CreateDiagram(this.addFlow); return; }
                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    for (int i = 0; i < nodes.Count(); i++)
                    {
                        if (nodes[i].Text.Equals(dt.Rows[j]["ST_NAME"]))
                        {
                            K_left = i;
                            break;
                        }
                    }
                    j++;
                    for (int i = 0; i < nodes.Count(); i++)
                    {
                        if (nodes[i].Text.Equals(dt.Rows[j]["ST_NAME"]))
                        {
                            K_right = i;
                            break;
                        }
                    }
                    //nodes[K_right].Location = new PointF(59 * (K_right + 2), 62 * (K_right + 2));
                    List<PointF> list = SetPointF();

                    nodes[K_left].Location = list[K_left];
                    nodes[K_right].Location = list[K_right];
                    Link link = new Link(nodes[K_left], nodes[K_right], "", addFlow);
                    this.addFlow.AddLink(link);
                }
            }
            catch (Exception eee)
            {

            }
           
        }


        /// <summary>
        /// 设置显示的坐标
        /// </summary>
        public List<PointF> SetPointF()
        {
            List<PointF> list = new List<PointF>();
            DataTable dt = AsmStation_BLL.GetAllStation();
            PointF pf;
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i < 5)
                { pf = new PointF(130 * i, 80);    list.Add(pf);}
                if (i >= 5 && i < 10)
                { pf = new PointF(130 *( i), 180);   list.Add(pf); }
                else
                {  pf = new PointF(130 * (i), 280); list.Add(pf); }
            }
            return list;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadSource_combobox()
        {
            try
            {
                DataTable dt = AsmProduction_BLL.GetAsmProduction();
                List<string> list = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["PRODUCTION_NAME"].ToString());
                }
                this.cB_product_name.DataSource = list;
            }
            catch (Exception e2)
            {
            }
           
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_save_Click(object sender, EventArgs e)
        {
           string str_product_name= cB_product_name.SelectedItem.ToString();
           DataTable dt=    AsmproductionWayRecord_BLL.GetAllByCondition("PRODUCTION_NAME='"+str_product_name+"'");
            if (dt.Rows.Count > 0)
            {
                AsmproductionWayRecord_BLL.DeleteAllByCondition("PRODUCTION_NAME='" + str_product_name + "'");
                StoreData();
            }
            else
            {
                StoreData();
            }
            MessageBox.Show("保存成功！");
        }

        /// <summary>
        /// 存储数据
        /// </summary>
        public void StoreData()
        {
            try
            {
                List<Item> list_item = addFlow.Items;
                DataTable dt = AsmStation_BLL.GetAllStation();
                AsmProductionWayRecordObject apwo = null;
                AsmProductionWayRecordObject apwo_right = null;
                List<string> list = new List<string>();
                bool judge = false;
                bool judge_right = false;
                int j = 1;

                List<Item> list_link = new List<Item>();
                for (int i = 0; i < list_item.Count; i++)
                {
                    if (list_item[i].GetType().ToString().Contains("Link"))
                        list_link.Add(list_item[i]);
                }

                for (int i = 0; i < list_link.Count; i++)
                {
                    string str_left = (list_link[i] as Link).Org.Text;
                    string str_right = (list_link[i] as Link).Dst.Text;


                    if (list.Count > 0)
                    {
                        for (int m = 0; m < list.Count; m++)
                        {
                            if (str_left.Equals(list[m]))
                            {
                                judge = false;
                            }
                            else
                                judge = true;
                        }
                    }
                    else
                    {
                        judge = true;
                    }

                    if (judge)
                    {
                        apwo = new AsmProductionWayRecordObject();
                        apwo.ST_NAME = str_left;
                        AsmProductionObject apo = AsmProduction_BLL.GetAsmProductionByCondition("PRODUCTION_NAME='" + cB_product_name.SelectedItem.ToString() + "'");
                        if (apo != null)
                        {
                            apwo.PRODUCTION_NAME = apo.PRODUCTION_NAME;
                            apwo.PRODUCTION_ID = apo.PRODUCTION_ID;
                        }
                        AsmStationObject aso = AsmStation_BLL.GetStationByCondition("STATION_NAME='" + apwo.ST_NAME + "'");
                        if (aso != null)
                        {
                            apwo.ST_ID = aso.STATION_ID;
                        }
                        apwo.DT = System.DateTime.Now;
                        apwo.SERIAL_NO = j++;
                        AsmproductionWayRecord_BLL.AddRecord(apwo);
                    }

                    if (list.Count > 0)
                    {
                        for (int m = 0; m < list.Count; m++)
                        {
                            if (str_right.Equals(list[m]))
                            {
                                judge_right = false;
                            }
                            else
                                judge_right = true;
                        }
                    }
                    else
                    {
                        judge_right = true;
                    }
                    if (judge_right)
                    {
                        apwo_right = new AsmProductionWayRecordObject();
                        apwo_right.ST_NAME = str_right;
                        AsmProductionObject apoX = AsmProduction_BLL.GetAsmProductionByCondition("PRODUCTION_NAME='" + cB_product_name.SelectedItem.ToString() + "'");
                        apwo_right.PRODUCTION_NAME = apoX.PRODUCTION_NAME;
                        apwo_right.PRODUCTION_ID = apoX.PRODUCTION_ID;
                        AsmStationObject asoX = AsmStation_BLL.GetStationByCondition("STATION_NAME='" + apwo_right.ST_NAME + "'");
                        apwo_right.ST_ID = asoX.STATION_ID;
                        apwo_right.DT = System.DateTime.Now;
                        apwo_right.SERIAL_NO = j++;
                        AsmproductionWayRecord_BLL.AddRecord(apwo_right);
                    }
                }

                DataTable dt_way = AsmProductionWay_BLL.GetWayByCondition("PRODUCTION_NAME= '" + cB_product_name.SelectedItem.ToString().Trim() + "'");
                if (!(dt_way.Rows.Count > 0))
                {
                    DataTable dt_record = AsmproductionWayRecord_BLL.GetAllRecordByCondition(cB_product_name.SelectedItem.ToString().Trim());
                    AsmProductionWayObject apwro = null;
                    for (int i = 0; i < dt_record.Rows.Count; i++)
                    {
                        apwro = new AsmProductionWayObject();
                        apwro.ST_NAME = dt_record.Rows[i]["ST_NAME"].ToString();
                        apwro.DT = Convert.ToDateTime(dt_record.Rows[i]["DT"].ToString());
                        apwro.PRODUCTION_NAME = dt_record.Rows[i]["PRODUCTION_NAME"].ToString();
                        apwro.PRODUCTION_ID = Convert.ToInt32(dt_record.Rows[i]["PRODUCTION_ID"].ToString());
                        apwro.ST_NAME = dt_record.Rows[i]["ST_NAME"].ToString();
                        apwro.ST_ID = Convert.ToInt32(dt_record.Rows[i]["ST_ID"].ToString());
                        apwro.SERIAL_NO = i + 1;
                        AsmProductionWay_BLL.AddRoutingRecord(apwro);
                    }
                }
                else
                {
                    AsmProductionWay_BLL.DeleteAllByCondition("PRODUCTION_NAME= '" + cB_product_name.SelectedItem.ToString().Trim() + "'");
                    DataTable dt_record = AsmproductionWayRecord_BLL.GetAllRecordByCondition(cB_product_name.SelectedItem.ToString().Trim());
                    AsmProductionWayObject apwro = null;
                    for (int i = 0; i < dt_record.Rows.Count; i++)
                    {
                        apwro = new AsmProductionWayObject();
                        apwro.DT = Convert.ToDateTime(dt_record.Rows[i]["DT"]);
                        apwro.PRODUCTION_NAME = dt_record.Rows[i]["PRODUCTION_NAME"].ToString();
                        apwro.PRODUCTION_ID = Convert.ToInt32(dt_record.Rows[i]["PRODUCTION_ID"].ToString());
                        apwro.ST_NAME = dt_record.Rows[i]["ST_NAME"].ToString();
                        apwro.ST_ID = Convert.ToInt32(dt_record.Rows[i]["ST_ID"].ToString());
                        apwro.SERIAL_NO = i + 1;
                        AsmProductionWay_BLL.AddRoutingRecord(apwro);
                    }
                }


            }
            catch (Exception)
            {

            }
           
         
        }

        private void addFlow_AfterAddLink(object sender, AfterAddLinkEventArgs e)
        {
            Link line = e.Link;string str_left = line.Org.Text;
            string str_right = line.Dst.Text;
            line.Text = str_left+ "->"+ str_right;
        }


        /// <summary>
        /// 工位属性配置
        /// </summary>
        /// <param name="sql"></param>
        public void StationConfigure(string sql)
        {
            try
            {
                string str_station = "";
                AsmStationObject aso = AsmStation_BLL.GetStationByCondition(sql);
                if (aso != null)
                {
                    str_station += "站名：          " + aso.STATION_NAME + "\n\n";
                    str_station += "站类型：        " + aso.STATION_TYPE + "\n\n";
                    str_station += "是否需要配方：  " + ((aso.STATION_RECIPEORNOT == "1") ? true : false) + "\n\n";
                    str_station += "是否配备AGV：   " + ((aso.STATION_AGVORNOT == "1") ? true : false) + "\n\n";
                    str_station += "是否点亮放行灯：" + ((aso.STATION_LIGHTORNOT == "1") ? true : false) + "\n\n";
                    str_station += "是否配置打印机：" + ((aso.STATION_PRINTORNOT == "1") ? true : false) + "\n\n";
                    str_station += "是否末站：      " + ((aso.STATION_ENDORNOT == "1") ? true : false) + "\n\n";
                    str_station += "是否配备拧紧枪：" + ((aso.STATION_GUNORNOT == "1") ? true : false) + "\n\n";
                    str_station += "工位节拍：      " + aso.STATION_TIME + "\n\n";
                }
                rTB_stationproperty.AppendText(str_station);
            }
            catch (Exception e)
            {
            }
           
        }

        /// <summary>
        /// 点击工位时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addFlow_SelectionChange(object sender, SelectionChangeArgs e)
        {
            try
            {
                rTB_stationproperty.Clear();
                Node node = e.Item as Node;
                if (node != null)
                {
                    if (node.Text != null && node.Text != "")
                    {
                        string str_node_station = node.Text;
                        StationConfigure("STATION_NAME='" + str_node_station + "'");
                    }
                }
            }
            catch (Exception ec)
            {

            }
        }
    }
}
