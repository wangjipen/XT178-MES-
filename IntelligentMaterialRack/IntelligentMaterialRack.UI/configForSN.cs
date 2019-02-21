using System;
using System.ComponentModel;
using System.Xml;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using IntelligentMaterialRack.IntelligentMaterialRack.BLL;

namespace SKTraceablity.Config
{
    class configForSN
    {
        frmConfig configForm;
        private string name = "产线配置";
        string nodeItemName = "line";
        string inputNodeName;
        public static AsmLineObject alo;
        #region 构造函数
        public configForSN()
        {
            configForm = new frmConfig();
            configForm.Text = name;
            configForm.btnAdd.Click += new EventHandler(btnAdd_Click);
            configForm.btnRemove.Click += new EventHandler(btnRemove_Click);
            configForm.btnPrevious.Click += new EventHandler(btnPrevious_Click);
            configForm.btnNext.Click += new EventHandler(btnNext_Click);
            configForm.btnOK.Click += new EventHandler(btnOK_Click);
            configForm.btnCancel.Click += new EventHandler(btnCancel_Click);

            configForm.listBox.SelectedIndexChanged += new EventHandler(listBox_SelectedIndexChanged);
            if (ClsCommon.InfoRootNode.ChildNodes.Count>0)
            {
                foreach (XmlNode node in ClsCommon.InfoRootNode.ChildNodes)
                {
                    configForm.listBox.Items.Add(node.Attributes["name"].Value);
                }
                if (configForm.listBox.Items.Count > 0)
                {
                    configForm.listBox.SelectedIndex = 0;
                }
            }
            else
            {
                configForm.btnRemove.Enabled = false;
                configForm.btnPrevious.Enabled = false;
                configForm.btnNext.Enabled = false;
            }

            configForm.ShowDialog();
        }
        #endregion

        #region 控件事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            XmlNode rootNode = ClsCommon.InfoRootNode.SelectSingleNode(nodeItemName + "[@name='" + configForm.listBox.Text + "']");
            XmlNode parentNode = ClsCommon.InfoRootNode;
            XmlElement element;
            int index = 0;
            string stName;
            XmlNodeList stationNodes = parentNode.SelectNodes(nodeItemName);///////DELETE
            foreach (XmlNode node in stationNodes)
            {
                if (int.Parse(node.Attributes["index"].Value) > index)
                {
                    index = int.Parse(node.Attributes["index"].Value);
                }
            }
            index++;
            stName = nodeItemName + index.ToString();

            element = ClsCommon.xml.CreateElement(nodeItemName);
            element.SetAttribute("index", index.ToString());
            element.SetAttribute("name", stName);
            element.SetAttribute("plcIP", "");
            element.SetAttribute("threaCount", "0");
            element.SetAttribute("updateRate", "0");
            element.SetAttribute("heartBeatAddr", "");
           // element.SetAttribute("packOrNot", "1");
           // element.SetAttribute("plcAgvIP", "");
           // element.SetAttribute("agvBeatAddr", "");
           // element.SetAttribute("sparePlcIp", "");
           // element.SetAttribute("sparePlcBeatAddr", "");
            parentNode.AppendChild(element);
            ClsCommon.saveXml();
            AsmLineObject ao = new AsmLineObject();
            ao.DT = DateTime.Now;
            ao.NAME = stName;
            AsmLine_BLL.AddLineByObject(ao);
            configForm.listBox.Items.Add(stName);
            configForm.listBox.SelectedIndex = configForm.listBox.Items.Count - 1;
            if (configForm.listBox.Items.Count > 0)
            {
                configForm.btnRemove.Enabled = true;
                configForm.btnPrevious.Enabled = true;
                configForm.btnNext.Enabled = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            XmlNode parentNode = ClsCommon.InfoRootNode;
            DialogResult result = MessageBox.Show("确定删除" + configForm.listBox.Text + "站？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result != DialogResult.OK)
            {
                return;
            }
            XmlNode stationNode;
            int selectIndex = configForm.listBox.SelectedIndex;
            stationNode = parentNode.SelectSingleNode(nodeItemName + "[@name='" + configForm.listBox.Text + "']");
            parentNode.RemoveChild(stationNode);
            ClsCommon.saveXml();
            AsmLine_BLL.DeleteLineByCondition(" NAME='" + configForm.listBox.Text + "'");
            configForm.listBox.Items.Remove(configForm.listBox.Text);
            if (parentNode.ChildNodes.Count > 0)
            {
                if (selectIndex > 0)
                {
                    configForm.listBox.SelectedIndex = selectIndex - 1;
                }
                else
                {
                    configForm.listBox.SelectedIndex = 0;
                }
            }
            else
            {
                configForm.propertyGrid.SelectedObject = null;
                configForm.btnRemove.Enabled = false;
                configForm.btnPrevious.Enabled = false;
                configForm.btnNext.Enabled = false;
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            XmlNode parentNode = ClsCommon.InfoRootNode;
            int selectIndex = configForm.listBox.SelectedIndex;
            if (selectIndex > 0)
            {
                XmlNode stationNode = parentNode.SelectSingleNode(nodeItemName + "[@name='" + configForm.listBox.Items[selectIndex] + "']");
                XmlNode preNode = parentNode.SelectSingleNode(nodeItemName + "[@name='" + configForm.listBox.Items[selectIndex - 1] + "']");
                parentNode.InsertBefore(stationNode, preNode);
                ClsCommon.saveXml();
                string str = configForm.listBox.Items[selectIndex - 1].ToString();
                configForm.listBox.Items[selectIndex - 1] = configForm.listBox.Items[selectIndex];
                configForm.listBox.Items[selectIndex] = str;
                configForm.listBox.SelectedIndex = selectIndex - 1;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            XmlNode parentNode = ClsCommon.InfoRootNode;
            int selectIndex = configForm.listBox.SelectedIndex;
            if (selectIndex != configForm.listBox.Items.Count - 1)
            {
                XmlNode stationNode = parentNode.SelectSingleNode(nodeItemName + "[@name='" + configForm.listBox.Items[selectIndex] + "']");
                XmlNode nextNode = parentNode.SelectSingleNode(nodeItemName + "[@name='" + configForm.listBox.Items[selectIndex + 1] + "']");
                parentNode.InsertAfter(stationNode, nextNode);
                ClsCommon.saveXml();
                string str = configForm.listBox.Items[selectIndex + 1].ToString();
                configForm.listBox.Items[selectIndex + 1] = configForm.listBox.Items[selectIndex];
                configForm.listBox.Items[selectIndex] = str;
                configForm.listBox.SelectedIndex = selectIndex + 1;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            configForm.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            configForm.Close();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlNode rootNode = ClsCommon.InfoRootNode.SelectSingleNode(nodeItemName + "[@name='" + configForm.listBox.Text + "']");
            if (configForm.listBox.SelectedIndex < 0)
            {
                return;
            }
            
            ConfigProperty cp = new ConfigProperty(rootNode, configForm, configForm.listBox.Text);
            configForm.propertyGrid.SelectedObject = cp;
           
        }
        #endregion

        #region 属性类
        [DefaultPropertyAttribute("站名")]
        public class ConfigProperty
        {
            XmlNode node;
            frmConfig fm;
            string LineName;
            AsmLineObject allo;
            public ConfigProperty(XmlNode selectNode,frmConfig form,string lineName)
            {
                node = selectNode;
                fm = form;
                LineName = lineName;
                reflsh();
            }
            public void reflsh()
            {
                allo = AsmLine_BLL.GetLineByCondition(" NAME='" + LineName + "'");
            }
            private string Get(string attribute)
            {
                return node.Attributes[attribute].Value;
            }

            private void Set(string attribute, string value)
            {
                node.Attributes[attribute].Value = value;
                ClsCommon.saveXml();
            }

            #region 属性
            [CategoryAttribute("属性"),
            DescriptionAttribute("索引")]
            public int 索引
            {
                get { return int.Parse(Get("index")); }
                set { Set("index", value.ToString()); }
            }

            [CategoryAttribute("属性"),
            DescriptionAttribute("名称")]
            public string 名称
            {
                get { return Get("name"); 
                }
                set { 
                    Set("name", value);
                    allo.NAME = value;
                    AsmLine_BLL.UpdateLineByObject(allo);
                    reflsh();
                    fm.listBox.Items[fm.listBox.SelectedIndex] = value;
                   
                }
            }

            [CategoryAttribute("属性"),
            DescriptionAttribute("PLC地址")]
            public string PLC地址
            {
                get { return Get("plcIP"); }
                set { Set("plcIP", value); }
            }
            //[CategoryAttribute("属性"),
            //DescriptionAttribute("AGVPLC地址")]
            //public string AGVPLC地址
            //{
            //    get { return Get("plcAgvIP"); }
            //    set { Set("plcAgvIP", value); }
            //}
            //[CategoryAttribute("属性"),
            //DescriptionAttribute("AGV心跳地址")]
            //public string AGV心跳地址
            //{
            //    get { return Get("agvBeatAddr"); }
            //    set { Set("agvBeatAddr", value); }
            //}
            //[CategoryAttribute("属性"),
            //DescriptionAttribute("备用PLC地址")]
            //public string 备用PLC地址
            //{
            //    get { return Get("sparePlcIp"); }
            //    set { Set("sparePlcIp", value); }
            //}
            //[CategoryAttribute("属性"),
            //DescriptionAttribute("备用PLC心跳地址")]
            //public string 备用PLC心跳地址
            //{
            //    get { return Get("sparePlcBeatAddr"); }
            //    set { Set("sparePlcBeatAddr", value); }
            //}
            [CategoryAttribute("属性"),
            DescriptionAttribute("线程数")]
            public int 线程数
            {
                get { return int.Parse(Get("threaCount")); }
                set { Set("threaCount", value.ToString()); }
            }

            [CategoryAttribute("属性"),
            DescriptionAttribute("刷新频率")]
            public int 刷新频率
            {
                get { return int.Parse(Get("updateRate")); }
                set { Set("updateRate", value.ToString()); }
            }

            [CategoryAttribute("属性"),
            DescriptionAttribute("心跳位")]
            public string 心跳位
            {
                get { return Get("heartBeatAddr"); }
                set { Set("heartBeatAddr", value); }
            }
           // [CategoryAttribute("属性"),
           //DescriptionAttribute("是否PACK线")]
           // public bool 是否PACK线
           // {
           //     get { return Get("packOrNot")=="1" ? true:false; }
           //     set { Set("packOrNot", value ? "1" : "0"); }
           // }
            //[CategoryAttribute("属性"),
            //DescriptionAttribute("批次号地址")]
            //public string 批次号地址
            //{
            //    get { return Get("bnAddr"); }
            //    set
            //    {
            //        Set("bnAddr", value);

            //    }
            //}

            //[CategoryAttribute("属性"),
            //DescriptionAttribute("产品号码地址")]
            //public string 产品号码地址
            //{
            //    get { return Get("pnAddr"); }
            //    set
            //    {
            //        Set("pnAddr", value);

            //    }
            //}

            #endregion

            #region 打开对话框类
            [Description("站配置"),
            Category("配置"),
            Editor(typeof(PropertyGridFileItemSN), typeof(System.Drawing.Design.UITypeEditor))]
            public string 站配置
            {
                get { return node.Attributes["name"].Value; }

            }
            public class PropertyGridFileItemSN : UITypeEditor
            {
                public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
                {
                    return UITypeEditorEditStyle.Modal;
                }

                public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
                {
                    IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                    if (edSvc != null)
                    {
                        frmSysConfig fsc = new frmSysConfig();
                        fsc.lineName = value.ToString();
                        fsc.ShowDialog();
                    }
                    return value;
                }

            }
            #endregion
        }
        #endregion
    }
}
