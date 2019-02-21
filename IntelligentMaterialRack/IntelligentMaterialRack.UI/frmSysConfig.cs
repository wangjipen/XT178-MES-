using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Xml;
using SKTraceablity.SKTraceablity.Moudle;
using SKTraceablity.SKTraceablity.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;

namespace SKTraceablity.Config
{
    public partial class frmSysConfig : Office2007Form
    {
        #region 站属性类
        //[CategoryAttribute("文档设置"),
        //DescriptionAttribute("需要登录才可以启动"),
        //ReadOnlyAttribute(true),
        //DefaultValueAttribute("欢迎使用应用程序！")]
       
        [DefaultPropertyAttribute("站名")]
        public class ConfigProperty
        {
            private frmSysConfig form;
            XmlNode thisNode;
            XmlNode node;
            public string StationName;
            AsmStationObject aso;

            public ConfigProperty(XmlNode station, frmSysConfig fm,string stationName)
            {
                form = fm;
                thisNode = station;
                StationName = stationName;
                Refish();
            }         
            #region 站属性
            [CategoryAttribute("站属性"),
            DescriptionAttribute("索引（*索引一定要从0开始，依次叠加）")]
            public int 索引
            {
                get { return int.Parse(thisNode.Attributes["index"].Value); }
                set
                {
                    thisNode.Attributes["index"].Value = value.ToString();
                    aso.STATION_INDEX= value.ToString();
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }

            [CategoryAttribute("站属性"),
            DescriptionAttribute("站名")]
            public string 站名
            {
                get { return thisNode.Attributes["name"].Value; }
                set
                {
                    thisNode.Attributes["name"].Value = value.ToString();
                    ClsCommon.saveXml();
                    aso.STATION_NAME= value.ToString();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                    form.lstStation.Items[form.lstStation.SelectedIndex] = value;
                }
               
            }

            //[CategoryAttribute("站属性"),
            //DescriptionAttribute("流水号")]
            //public string 流水号
            //{
            //    get { return thisNode.Attributes["snAddr"].Value; }
            //    set
            //    {
            //        thisNode.Attributes["snAddr"].Value = value.ToString();
            //        ClsCommon.saveXml();
            //    }
            //}
            [CategoryAttribute("站属性"),
            DescriptionAttribute("是否线外站")]
            public bool 是否线外站
            {
                get { return thisNode.Attributes["type"].Value == "1" ? true : false; ; }
                set
                {
                    if (value)
                    {
                        thisNode.Attributes["type"].Value = "1";
                        aso.STATION_TYPE = "1";
                    }
                    else
                    {
                        thisNode.Attributes["type"].Value = "0"; ;
                        aso.STATION_TYPE = "0";
                    }
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            [CategoryAttribute("站属性"),
           DescriptionAttribute("是否需要配方")]
            public bool 是否需要配方
            {
                get { return thisNode.Attributes["recipeOrNot"].Value == "1" ? true : false; ; }
                set
                {
                    if (value)
                    {
                        thisNode.Attributes["recipeOrNot"].Value = "1";
                        aso.STATION_RECIPEORNOT = "1";
                    }
                    else
                    {
                        thisNode.Attributes["recipeOrNot"].Value = "0"; ;
                        aso.STATION_RECIPEORNOT = "0";
                    }
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            [CategoryAttribute("站属性"),
          DescriptionAttribute("是否有AGV小车")]
            public bool 是否有AGV小车
            {
                get { return thisNode.Attributes["agvOrNot"].Value == "1" ? true : false; ; }
                set
                {
                    if (value)
                    {
                        thisNode.Attributes["agvOrNot"].Value = "1";
                        aso.STATION_AGVORNOT = "1";
                    }
                    else
                    {
                        thisNode.Attributes["agvOrNot"].Value = "0"; ;
                        aso.STATION_AGVORNOT = "0";
                    }
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            [CategoryAttribute("站属性"),
         DescriptionAttribute("是否请求MES出站")]
            public bool 是否请求MES出站
            {
                get { return thisNode.Attributes["requentMESoutLineOrNot"].Value == "1" ? true : false; ; }
                set
                {
                    if (value)
                    {
                        thisNode.Attributes["requentMESoutLineOrNot"].Value = "1";
                        aso.STATION_REQUSTOUTLINE = "1";
                    }
                    else
                    {
                        thisNode.Attributes["requentMESoutLineOrNot"].Value = "0"; ;
                        aso.STATION_REQUSTOUTLINE = "0";
                    }
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            [CategoryAttribute("站属性"),
      DescriptionAttribute("是否请求MES进站")]
            public bool 是否请求MES进站
            {
                get { return thisNode.Attributes["requentMESInLineOrNot"].Value == "1" ? true : false; ; }
                set
                {
                    if (value)
                    {
                        thisNode.Attributes["requentMESInLineOrNot"].Value = "1";
                        aso.STATION_REQUSTIN = "1";
                    }
                    else
                    {
                        thisNode.Attributes["requentMESInLineOrNot"].Value = "0"; ;
                        aso.STATION_REQUSTIN = "0";
                    }
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            [CategoryAttribute("站属性"),
       DescriptionAttribute("是否点亮放行灯")]
            public bool 是否点亮放行灯
            {
                get { return thisNode.Attributes["lightLighOrNot"].Value == "1" ? true : false; ; }
                set
                {
                    if (value)
                    {
                        thisNode.Attributes["lightLighOrNot"].Value = "1";
                        aso.STATION_LIGHTORNOT = "1";
                    }
                    else
                    {
                        thisNode.Attributes["lightLighOrNot"].Value = "0"; ;
                        aso.STATION_LIGHTORNOT = "0";
                    }
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            [CategoryAttribute("站属性"),
      DescriptionAttribute("工位节拍")]
            public string 工位节拍
            {              
                get { return thisNode.Attributes["stationTime"].Value; }
                set
                {
                    thisNode.Attributes["stationTime"].Value = value.ToString();
                    ClsCommon.saveXml();
                    aso.STATION_TIME =Convert.ToInt32(value.ToString());
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            [CategoryAttribute("站属性"),
     DescriptionAttribute("是否触发打印")]
            public bool 是否触发打印
            {
                get { return thisNode.Attributes["printOrNot"].Value == "1" ? true : false; ; }
                set
                {
                    if (value)
                    {
                        thisNode.Attributes["printOrNot"].Value = "1";
                        aso.STATION_PRINTORNOT = "1";
                    }
                    else
                    {
                        thisNode.Attributes["printOrNot"].Value = "0"; ;
                        aso.STATION_PRINTORNOT = "0";
                    }
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            [CategoryAttribute("站属性"),
    DescriptionAttribute("数据是否上传MES")]
            public bool 数据是否上传MES
            {
                get { return thisNode.Attributes["dataUploadMESOrNot"].Value == "1" ? true : false; ; }
                set
                {
                    if (value)
                    {
                        thisNode.Attributes["dataUploadMESOrNot"].Value = "1";
                        aso.STATION_UPLOADMES = "1";
                    }
                    else
                    {
                        thisNode.Attributes["dataUploadMESOrNot"].Value = "0"; ;
                        aso.STATION_UPLOADMES = "0";
                    }
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
             [CategoryAttribute("站属性"),
    DescriptionAttribute("是否末站")]
            public bool 是否末站
            {
                  get { return thisNode.Attributes["endSTorNot"].Value == "1" ? true : false; ; }
                set
                {
                    if (value)
                    {
                        thisNode.Attributes["endSTorNot"].Value = "1";
                        aso.STATION_ENDORNOT = "1";
                    }
                    else
                    {
                        thisNode.Attributes["endSTorNot"].Value = "0"; ;
                        aso.STATION_ENDORNOT = "0";
                    }
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            [CategoryAttribute("站属性"),
   DescriptionAttribute("是否有拧紧枪")]
            public bool 是否有拧紧枪
            {
                get { return thisNode.Attributes["gunOrNot"].Value == "1" ? true : false; ; }
                set
                {
                    if (value)
                    {
                        thisNode.Attributes["gunOrNot"].Value = "1";
                        aso.STATION_GUNORNOT = "1";
                    }
                    else
                    {
                        thisNode.Attributes["gunOrNot"].Value = "0"; ;
                        aso.STATION_GUNORNOT = "0";
                    }
                    ClsCommon.saveXml();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            [CategoryAttribute("站属性"),
  DescriptionAttribute("0表示手动站，1表示自动站，2表示测试站")]
            public string 站类型
            {
                get { return thisNode.Attributes["autoOrNot"].Value; }
                set
                {
                    thisNode.Attributes["autoOrNot"].Value = value.ToString();
                    ClsCommon.saveXml();
                    aso.STATION_AUTOORNOT = value.ToString();
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            #endregion

            #region 放行条件

            [CategoryAttribute("放行条件"),
            DescriptionAttribute("流程判断")]
            public bool 流程判断
            {
                get { return thisNode.Attributes["processOK"].Value == "1" ? true : false; }
                set
                {
                    thisNode.Attributes["processOK"].Value = value ? "1" : "0";
                    ClsCommon.saveXml();
                    aso.STATION_PROCESSOK= value ? "1" : "0";
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }

            [CategoryAttribute("放行条件"),
            DescriptionAttribute("数据判断")]
            public bool 数据判断
            {
                get { return thisNode.Attributes["dataOK"].Value == "1" ? true : false; }
                set
                {
                    thisNode.Attributes["dataOK"].Value = value ? "1" : "0";
                    ClsCommon.saveXml();
                    aso.STATION_DATAOK= value ? "1" : "0";
                    AsmStation_BLL.UpdateStationByObject(aso);
                    Refish();
                }
            }
            #endregion
            public  void Refish()
            {
                aso = AsmStation_BLL.GetStationByCondition(" STATION_NAME='" + StationName + "';");
            }

        }
        #endregion

        public string lineName;

        public frmSysConfig()
        {
            InitializeComponent();
        }
       
        private void frmSysConfig_Load(object sender, EventArgs e)
        {
            lstStation.Items.Clear();
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + lineName + "']");
            XmlNodeList stationNodes = lineNode.SelectNodes("station");///////DELETE
            if (stationNodes.Count > 0)
            {
                foreach (XmlNode node_ in stationNodes)
                {
                    lstStation.Items.Add(node_.Attributes["name"].Value);
                }
                if (lstStation.Items.Count > 0) lstStation.SelectedIndex = 0;
            }
            else
            {
                btnRemove.Enabled = false;
                btnMovedown.Enabled = false;
                btnMoveup.Enabled = false;
            }
        }

        private void lstStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStation.Text == string.Empty)
            {
                return;
            }
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + lineName + "']");
            XmlNode stNode = lineNode.SelectSingleNode("station[@name='" + lstStation.Text + "']");
            ConfigProperty cp = new ConfigProperty(stNode, this, lstStation.Text);
            
            propertyGrid1.SelectedObject = cp;
            tcStation.SelectedIndex = 0;
            loadItems(dgvControl, "opcitem");
            loadItems(dgvData, "dataitem");
            //loadItems(agvControlConfig, "agvitem");
            //loadItems(agvTagConfig, "agvdataitem");
            XmlElement xe = (XmlElement)stNode;
            if (xe.Attributes["autoOrNot"].Value == "1")
            {
                loadItems(MaterialConfigP, "boltName");
                tpMaterialTag.Parent = tcStation;
            }
            else
            {
                tpMaterialTag.Parent = null;
            }
            if (xe.Attributes["type"].Value == "1")
            {
                loadItems(dgv_Outline, "ptvitem");
                tpOutlineConfig.Parent = tcStation;
            }
            else
            {
                tpOutlineConfig.Parent = null;
            }
            //loadItems(passLightDGV, "lightitem");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int index = 0;
            string stName;
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + lineName + "']");
            XmlNodeList stationNodes = lineNode.SelectNodes("station");///////DELETE
            foreach (XmlNode node in stationNodes)
            {
                if (int.Parse(node.Attributes["index"].Value) > index)
                {
                    index = int.Parse(node.Attributes["index"].Value);
                }
            }
            if (lstStation.Items.Count > 0) index++;
            stName = "Station" + index.ToString();
            XmlElement element = ClsCommon.xml.CreateElement("station");
            element.SetAttribute("index", index.ToString());
            element.SetAttribute("name", stName);
            element.SetAttribute("processOK", "0");
            element.SetAttribute("dataOK", "0");
            //element.SetAttribute("index", index.ToString());
            //element.SetAttribute("name", stName);
            //element.SetAttribute("scanValue", "");
            //element.SetAttribute("automaticStation", "0");
            element.SetAttribute("type", "0");
            element.SetAttribute("recipeOrNot", "1");
            element.SetAttribute("agvOrNot", "1");
            element.SetAttribute("requentMESoutLineOrNot", "0");
            element.SetAttribute("lightLighOrNot", "0");
            element.SetAttribute("requentMESInLineOrNot", "0");
            element.SetAttribute("reviewOrNot", "1");
            element.SetAttribute("printOrNot", "0");
            element.SetAttribute("dataUploadMESOrNot", "0");
            element.SetAttribute("endSTorNot", "0");
            element.SetAttribute("gunOrNot", "1");
            element.SetAttribute("autoOrNot", "0");
            element.SetAttribute("stationTime", "10000");
            //element.SetAttribute("keypartOK", "0");
            //element.SetAttribute("statusOK", "0");
            //element.SetAttribute("processOK", "0");
            // element.SetAttribute("dataOK", "0");
            //element.SetAttribute("snAddr", "");
            //element.SetAttribute("snTagAddr", "");
            //element.SetAttribute("okAddr", "");
            //element.SetAttribute("programAddr", "");
            //element.SetAttribute("enableAddr", "");
            //element.SetAttribute("enableTagAddr", "");

            lineNode.AppendChild(element);
            ClsCommon.saveXml();
            #region>>>>>同步新增站
            AsmStationObject aso=new AsmStationObject();
            aso.STATION_INDEX = index.ToString();
            aso.STATION_NAME = stName;
            aso.STATION_PROCESSOK = "0";
            aso.STATION_DATAOK = "0";
            aso.STATION_TYPE = "0";
            aso.STATION_RECIPEORNOT = "1";
            aso.STATION_AGVORNOT = "1";
            aso.STATION_REQUSTOUTLINE = "1";
            aso.STATION_LIGHTORNOT = "1";
            aso.STATION_REQUSTIN = "1";
            aso.STATION_REVIEWORNOT = "1";
            aso.STATION_PRINTORNOT = "1";
            aso.STATION_UPLOADMES = "1";
            aso.STATION_ENDORNOT = "0";
            aso.STATION_GUNORNOT = "1";
            aso.STATION_AUTOORNOT = "0";
            aso.STATION_TIME = 10000;
            AsmStation_BLL.AddStationByObject(aso);
            #endregion
            lstStation.Items.Add(stName);
            lstStation.SelectedIndex = lstStation.Items.Count - 1;

            if (lstStation.Items.Count > 0)
            {
                btnRemove.Enabled = true;
                btnMovedown.Enabled = true;
                btnMoveup.Enabled = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            XmlNode stationNode;
            if (lstStation.SelectedIndex < 0)
            {
                MessageBoxEx.Show("没有选择站");
                return;
            }
            DialogResult result = MessageBoxEx.Show("确定删除" + lstStation.Text + "站？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result != DialogResult.OK)
            {
                return;
            }
            int selectIndex = lstStation.SelectedIndex;
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + lineName + "']");
            stationNode = lineNode.SelectSingleNode("station[@name='" + lstStation.Text + "']");
            lineNode.RemoveChild(stationNode);
            ClsCommon.saveXml();
            AsmStation_BLL.DeleteStationByCondition(" STATION_NAME='"+ lstStation.Text+"';");
            lstStation.Items.Remove(lstStation.Text);
            if (selectIndex > 0)
            {
                lstStation.SelectedIndex = selectIndex - 1;
            }
            if (lstStation.Items.Count > 0)
            {
                if (selectIndex > 0)
                {
                    lstStation.SelectedIndex = selectIndex - 1;
                }
                else
                {
                    lstStation.SelectedIndex = 0;
                }
            }
            else
            {
                propertyGrid1.SelectedObject = null;
                btnRemove.Enabled = false;
                btnMovedown.Enabled = false;
                btnMoveup.Enabled = false;
            }
        }

        private void btnMoveup_Click(object sender, EventArgs e)
        {
            if (lstStation.SelectedIndex < 0)
            {
                MessageBoxEx.Show("没有选择站");
                return;
            }
            int selectIndex = lstStation.SelectedIndex;
            if (selectIndex > 0)
            {
                XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + lineName + "']");
                XmlNode stationNode = lineNode.SelectSingleNode("station[@name='" + lstStation.Items[selectIndex] + "']");
                XmlNode preNode = lineNode.SelectSingleNode("station[@name='" + lstStation.Items[selectIndex - 1] + "']");
                lineNode.InsertBefore(stationNode, preNode);
                ClsCommon.saveXml();
                string str = lstStation.Items[selectIndex - 1].ToString();
                lstStation.Items[selectIndex - 1] = lstStation.Items[selectIndex];
                lstStation.Items[selectIndex] = str;
                lstStation.SelectedIndex = selectIndex - 1;
            }
        }

        private void btnMovedown_Click(object sender, EventArgs e)
        {
            if (lstStation.SelectedIndex < 0)
            {
                MessageBoxEx.Show("没有选择站");
                return;
            }
            int selectIndex = lstStation.SelectedIndex;
            if (selectIndex != lstStation.Items.Count - 1)
            {
                XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + lineName + "']");
                XmlNode stationNode = lineNode.SelectSingleNode("station[@name='" + lstStation.Items[selectIndex] + "']");
                XmlNode nextNode = lineNode.SelectSingleNode("station[@name='" + lstStation.Items[selectIndex + 1] + "']");
                lineNode.InsertAfter(stationNode, nextNode);
                ClsCommon.saveXml();
                string str = lstStation.Items[selectIndex + 1].ToString();
                lstStation.Items[selectIndex + 1] = lstStation.Items[selectIndex];
                lstStation.Items[selectIndex] = str;
                lstStation.SelectedIndex = selectIndex + 1;
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            saveToXml(dgvData, "dataitem");
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            saveToXml(dgvControl, "opcitem");
        }

        private void loadItems(DataGridView dg, string str)
        {
            DataTable myTable = new DataTable();
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + lineName + "']");
            XmlNode node = lineNode.SelectSingleNode("station[@name='" + lstStation.Text + "']");
            XmlNodeList nodes = node.SelectNodes(str);
            if (nodes.Count == 0 || nodes == null)
            {
                for (int i = 0; i < dg.ColumnCount; i++)
                {
                    myTable.Columns.Add(dg.Columns[i].DataPropertyName);
                }
            }
            else
            {
                for (int i = 0; i < dg.ColumnCount; i++)
                {
                    myTable.Columns.Add(dg.Columns[i].DataPropertyName);
                }
                foreach (XmlNode node_ in nodes)
                {
                    DataRow newRow;
                    newRow = myTable.NewRow();
                    for (int i = 0; i < node_.Attributes.Count; i++)
                    {
                        newRow[node_.Attributes[i].Name] = node_.Attributes[i].Value;
                    }
                    myTable.Rows.Add(newRow);
                }
            }
            BindingSource source = new BindingSource();
            source.DataSource = myTable;
            dg.DataSource = source;
        }

        private void saveToXml(DataGridView dg, string nodeName)
        {
            try
            {
                XmlNode stationNode;
                if (lstStation.SelectedIndex < 0)
                {
                    MessageBoxEx.Show("没有选择站");
                    return;
                }
                XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + lineName + "']");
                stationNode = lineNode.SelectSingleNode("station[@name='" + lstStation.Text + "']");
                foreach (XmlNode delNode in stationNode.SelectNodes(nodeName))
                {
                    stationNode.RemoveChild(delNode);
                }

                for (int i = 0; i < dg.RowCount - 1; i++)
                {
                    XmlElement element = ClsCommon.xml.CreateElement(nodeName);
                    for (int j = 0; j < dg.ColumnCount; j++)
                    {
                        string elementName = dg.Columns[j].DataPropertyName;
                        string elementValue = dg[j, i].Value == null ? string.Empty : dg[j, i].Value.ToString();
                        element.SetAttribute(elementName, elementValue);
                    }
                    stationNode.AppendChild(element);
                }
                ClsCommon.saveXml();
                MessageBoxEx.Show("修改成功");
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("修改失败");
                MyLog.Log.InformationLog.Error(nodeName + "修改失败" + ex.Message);
            }
        }
        /// <summary>
        /// 保存小车控制字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void editButton_Click(object sender, EventArgs e)
        //{
        //    saveToXml(agvControlConfig, "agvitem");
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    saveToXml(agvTagConfig, "agvdataitem");
        //}

        private void TB_MATERIAL_Click(object sender, EventArgs e)
        {
            saveToXml(MaterialConfigP, "boltName");
        }

        private void BT_outLine_Click(object sender, EventArgs e)
        {
            saveToXml(dgv_Outline, "ptvitem");
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    saveToXml(passLightDGV, "lightitem");
        //}
    }
}
