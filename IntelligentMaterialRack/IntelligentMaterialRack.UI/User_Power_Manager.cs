using IntelligentMaterialRack.IntelligentMaterialRack.FUNCTION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System.Xml;
using static System.Resources.ResXFileRef;
using PresentationControls;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class User_Power_Manager : Form
    {
        public User_Power_Manager()
        {
            InitializeComponent();
        }
        private void User_Power_Manager_Load(object sender, EventArgs e)
        {
            LoadSource();
        }
        /// <summary>
        /// 填充页面
        /// </summary>
        public void LoadSource()
        {

            panel2.VerticalScroll.Visible = true;//主面板

            DataTable dt = User_BLL.GetAllUserX();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string user_name = dt.Rows[i]["h_UserName"].ToString();
                Panel p_row = new Panel();//分面板
                p_row.Name = "panel_" + user_name;
                p_row.Size = new Size(1331, 34);
                p_row.BackColor = Color.CornflowerBlue;
                #region  label
                Label l_name = new Label();
                l_name.Name = "lb_" + user_name;
                l_name.Text = user_name;
                l_name.Font = new Font(l_name.Font.FontFamily, 15, l_name.Font.Style);
                l_name.Location = new System.Drawing.Point(2, 5);
                p_row.Controls.Add(l_name);
                #endregion

                #region CheckBoxComboBox
                CheckBoxComboBox cbcb;
                Size s = new Size();
                s.Width = 181;
                Dictionary<int, ListSelectionWrapper<Status>> dicX = SaveMessage();
                for (int j = 0; j < dicX.Count; j++)
                {
           
                   
                    string str_power = EncryPtForMy.Class1.DecryptDES(dt.Rows[i]["Power"].ToString());
                    Dictionary<int, List<int>> dic_POWER = Split_Power(str_power);
                    cbcb = new CheckBoxComboBox();
                    cbcb.Name = "cbcb" + j;
                    cbcb.DataSource = dicX[j];
                    cbcb.DisplayMemberSingleItem = "Name";
                    cbcb.DisplayMember = "NameConcatenated";
                    cbcb.ValueMember = "Selected";
                    if (dic_POWER.Count>0)    //为了判断
                    {
                        if (dic_POWER[j].ToList()!=null)
                        {
                            List<int> list = dic_POWER[j].ToList();
                            for (int K = 0; K < list.Count; K++)
                            {
                                dicX[j][list[K]].Selected = true;
                            }
                        }                       
                    }                
                    //dicX[j].FindObjectWithItem(sDD).Selected = true;
                    cbcb.Size = s;
                    cbcb.Font = new Font(cbcb.Font.FontFamily, 13, cbcb.Font.Style);
                    cbcb.BackColor = Color.Azure;
                    cbcb.Enabled = false;
                    cbcb.Location = new System.Drawing.Point(142 + j * 195, 5);
                    p_row.Controls.Add(cbcb);
                }
                #endregion
                #region button
                Button bt_alter = new Button();
                bt_alter.Text = "修改";
                bt_alter.Name = user_name;
                bt_alter.Click += new EventHandler(Alter_Power);
                bt_alter.FlatStyle = FlatStyle.Popup;
                bt_alter.Size = new Size(50, 30);
                bt_alter.Tag = 9999;
                bt_alter.Location = new System.Drawing.Point(142 + 5 * 195, 2);

                Button btX_save = new Button();
                btX_save.Text = "保存";
                btX_save.Name = user_name;
                btX_save.Click += new EventHandler(Save_Power);
                btX_save.FlatStyle = FlatStyle.Popup;
                btX_save.Tag = 9999;
                btX_save.Size = new Size(50, 30);
                btX_save.Location = new System.Drawing.Point(141 + 5 * 195 + 55, 2);

                Button bt_see = new Button();
                bt_see.Text = "查看";
                bt_see.Name = user_name;
                bt_see.Click += new EventHandler(Check_Power);
                bt_see.FlatStyle = FlatStyle.Popup;
                bt_see.Tag = 9999;
                bt_see.Size = new Size(50, 30);
                bt_see.Location = new System.Drawing.Point(143 + 5 * 195 + 106, 2);

                Button bt_delete = new Button();
                bt_delete.Text = "删除";
                bt_delete.Name = user_name;
                bt_delete.Click += new EventHandler(Delete_User);
                bt_delete.FlatStyle = FlatStyle.Popup;
                bt_delete.Tag = 9999;
                bt_delete.Size = new Size(50, 30);
                bt_delete.Location = new System.Drawing.Point(142 + 5 * 195 + 163, 2);

                p_row.Controls.Add(bt_alter);
                p_row.Controls.Add(btX_save);
                p_row.Controls.Add(bt_see);
                p_row.Controls.Add(bt_delete);
                #endregion
                p_row.Location = new System.Drawing.Point(5, 45 * (i + 1) + 10 * i);
                panel2.Controls.Add(p_row);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public void Delete_User(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            CheckBoxComboBox cbcb = panel2.Controls["panel_" + button.Name].Controls["cbcb0"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb1 = panel2.Controls["panel_" + button.Name].Controls["cbcb1"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb2 = panel2.Controls["panel_" + button.Name].Controls["cbcb2"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb3 = panel2.Controls["panel_" + button.Name].Controls["cbcb3"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb4 = panel2.Controls["panel_" + button.Name].Controls["cbcb4"] as CheckBoxComboBox;
            Panel p_delete = panel2.Controls["panel_" + button.Name] as Panel;
            Point pp = p_delete.Location;
            this.Controls.Remove(p_delete);
            p_delete.Dispose();
            User_BLL.Delete_UserByCondition(button.Name);
            //LoadSource();
        }

        /// <summary>
        /// 查看权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Check_Power(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            CheckBoxComboBox cbcb = panel2.Controls["panel_" + button.Name].Controls["cbcb0"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb1 = panel2.Controls["panel_" + button.Name].Controls["cbcb1"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb2 = panel2.Controls["panel_" + button.Name].Controls["cbcb2"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb3 = panel2.Controls["panel_" + button.Name].Controls["cbcb3"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb4 = panel2.Controls["panel_" + button.Name].Controls["cbcb4"] as CheckBoxComboBox;

            string str0 = cbcb.Text.Trim();
            string str1 = cbcb1.Text.Trim();
            string str2 = cbcb2.Text.Trim();
            string str3 = cbcb3.Text.Trim();
            string str4 = cbcb4.Text.Trim();

            string str_power ="拥有权限:(1)基础配置：" + str0 +";"+ "(2)计划管理：" + str1 + ";" + "(3)配方管理权限包含：" + str2 + ";" + "(4)报表管理权限包含：" + str3 + ";" + "(5)工具权限包含" + str4;
            rtb_power.Text = "";
            rtb_power.AppendText("用户");
            rtb_power.SelectionColor = Color.Gold;
            rtb_power.AppendText(button.Name);
            rtb_power.SelectionColor = Color.Black;
            rtb_power.AppendText("拥有权限:(1)");
            rtb_power.SelectionColor = Color.Orchid;
            rtb_power.AppendText("基础配置");
            rtb_power.SelectionColor = Color.Black;
            rtb_power.AppendText(":"+str0 + ";(2)");
            rtb_power.SelectionColor = Color.Orchid;
            rtb_power.AppendText("计划管理");
            rtb_power.SelectionColor = Color.Black;
            rtb_power.AppendText(":" + str1 + ";(3)");
            rtb_power.SelectionColor = Color.Orchid;
            rtb_power.AppendText("配方管理");
            rtb_power.SelectionColor = Color.Black;
            rtb_power.AppendText(":" + str2 + ";(4)");
            rtb_power.SelectionColor = Color.Orchid;
            rtb_power.AppendText("报表管理");
            rtb_power.SelectionColor = Color.Black;
            rtb_power.AppendText(":" + str3 + ";(5)");
            rtb_power.SelectionColor = Color.Orchid;
            rtb_power.AppendText("工具");
            rtb_power.SelectionColor = Color.Black;
            rtb_power.AppendText(":" + str4 );
        }

        /// <summary>
        /// 保存按钮监听
        /// </summary>
        public void Save_Power(object sender, EventArgs e)
        {
            bool set_admin = false;   //标识当前保存用户是否为管理员
            string ListText = "";
            Button button = (Button)sender;
            CheckBoxComboBox cbcb= panel2.Controls["panel_" + button.Name].Controls["cbcb0"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb1 = panel2.Controls["panel_" + button.Name].Controls["cbcb1"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb2 = panel2.Controls["panel_" + button.Name].Controls["cbcb2"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb3 = panel2.Controls["panel_" + button.Name].Controls["cbcb3"] as CheckBoxComboBox;
            CheckBoxComboBox cbcb4 = panel2.Controls["panel_" + button.Name].Controls["cbcb4"] as CheckBoxComboBox;
            #region   保存
            string str0= cbcb.Text.Trim();  
            string[] strX0 = str0.Split('&');
            List<int> a0=  Split_string_Save(strX0, "basis");
            string str_power0 = "basis:";
            for (int i=0;i<a0.Count;i++)
            {
                if (a0.Count - 1 == i)
                    str_power0 += a0[i];
                else
                {
                    str_power0 += a0[i] + ",";
                    //if (a0[i] == 0)//设置为管理员  并在数据库赋值标识
                    //{
                    //    User_BLL.SetUserAdmin(button.Name);
                    //    set_admin = true;
                    //}
                }
            }
           //if (set_admin == false)
           //     User_BLL.SetUserNormal(button.Name);
                    
            str_power0= str_power0 + ";";
           
            string str1 = cbcb1.Text.Trim(); 
            string[] strX1 = str1.Split('&');
            List<int> a1 = Split_string_Save(strX1, "plan");
            string str_power1 = "plan:";
            for (int i = 0; i < a1.Count; i++)
            {
                if (a1.Count-1==i)               
                    str_power1 += a1[i];             
                else
                    str_power1 += a1[i] + ",";
            }
            str_power1 = str_power1 + ";";
            
            string str2 = cbcb2.Text.Trim(); 
            string[] strX2 = str2.Split('&');
            List<int> a2 = Split_string_Save(strX2, "formula");
            string str_power2 = "formula:";
            for (int i = 0; i < a2.Count; i++)
            {
                if (a2.Count - 1 == i)
                    str_power2 += a2[i];
                else
                    str_power2 += a2[i] + ",";
            }
            str_power2 = str_power2 + ";";
          
            string str3 = cbcb3.Text.Trim(); 
            string[] strX3 = str3.Split('&');
            List<int> a3 = Split_string_Save(strX3, "table");
            string str_power3 = "table:";
            for (int i = 0; i < a3.Count; i++)
            {
                if (a3.Count - 1 == i)
                    str_power3 += a3[i];
                else
                    str_power3 += a3[i] + ",";
            }
            str_power3 = str_power3 + ";";
           
            string str4 = cbcb4.Text.Trim(); 
            string[] strX4 = str4.Split('&');
            List<int> a4 = Split_string_Save(strX4, "tool");
            string str_power4 = "tool:";
            for (int i = 0; i < a4.Count; i++)
            {
                if (a4.Count - 1 == i)
                    str_power4 += a4[i];
                else
                    str_power4 += a4[i] + ",";
            }
            str_power4 = str_power4 + ";";
            string str_power = str_power0 + str_power1 + str_power2 + str_power3 + str_power4;
            string Power = EncryPtForMy.Class1.EncryptDES(str_power.Substring(0, str_power.Length - 1));
           User_BLL.Save_Power(button.Name, Power);

            #endregion

            cbcb.Enabled = false;
            cbcb1.Enabled = false;
            cbcb2.Enabled = false;
            cbcb3.Enabled = false;
            cbcb4.Enabled = false;
        }

        /// <summary>
        /// 特级拆分字符串  返回功能代表数字数组
        /// </summary>
        public List<int> Split_string_Save(string[] str,string  mode_name)
        {
            List<int> a=new List<int>();

            List<string> list = new List<string>();
            for (int i=0;i<str.Length;i++)
            {
                //list.Add(str[i].Substring(1,str[i].Length-2));
                list.Add(str[i].Replace('\"',' ').Trim());
            }
            Dictionary<string, List<string>> dicX = new Dictionary<string, List<string>>();
            dicX = LoadXmlConfig();
            List<string> li=dicX[mode_name].ToList();
            for (int m = 0; m < list.Count; m++)
            {
                for (int k = 0; k < li.Count; k++)
                {
                    if (list[m].Equals(li[k]))
                    {
                        a.Add(k);
                    }
                }
            }
            return a;
        }

        /// <summary>
        /// 拆分权限字符串
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public Dictionary<int, List<int>> Split_Power(string power)
        {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            string[] str= power.Split(';');
            for (int i=0;i<str.Length;i++)
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
                    dic.Add(i, list);
                }
                else
                {
                    dic.Add(i, list);
                    continue;
                }
                  
            }
            return dic;
        }
        
        /// <summary>
        /// 修改按钮监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Alter_Power(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            panel2.Controls["panel_"+button.Name].Controls["cbcb0"].Enabled = true;
            panel2.Controls["panel_" + button.Name].Controls["cbcb1"].Enabled = true;
            panel2.Controls["panel_" + button.Name].Controls["cbcb2"].Enabled = true;
            panel2.Controls["panel_" + button.Name].Controls["cbcb3"].Enabled = true;
            panel2.Controls["panel_" + button.Name].Controls["cbcb4"].Enabled = true;         
        }

        /// <summary>
        /// 帐户信息保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string name = tb_name.Text.Trim();
        //    string pwd = tb_pwd.Text.Trim();
        //    int check = 0;
        //    if (cb_Check.CheckState == CheckState.Checked)
        //        check = 1;
        //    UsersObject uo = new UsersObject();
        //    uo.h_UserName = name;
        //    uo.h_yUserPwd = pwd;
        //    uo.h_Status = 1;
        //    Dictionary<string, List<string>> dic = LoadXmlConfig();
        //    List<string> li = dic.Keys.ToList();
        //    for (int i=0;i<li.Count;i++)
        //    {
        //        uo.Power += li[i] + ":;";
        //    }
        //    uo.Power = uo.Power.Substring(0,uo.Power.Length-1);
        //    User_BLL.AddUser(uo);
        //    LoadSource();
        //    tb_name.Text = "";
        //    tb_pwd.Text = "";
        //}
    
        /// <summary>
        /// 列表信息保存
        /// </summary>
        public Dictionary<int, ListSelectionWrapper<Status>> SaveMessage()
        {
            Dictionary<int, ListSelectionWrapper<Status>> dic = new Dictionary<int, ListSelectionWrapper<Status>>();

            Dictionary<string, List<string>> dicX = new Dictionary<string, List<string>>();
            dicX = LoadXmlConfig();
            ListSelectionWrapper<Status> StatusSelections;
            StatusList _StatusList = new StatusList();
            List<string> list_basis =  dicX["basis"].ToList();
            for (int i=0; i<list_basis.Count;i++ )
            {
                Status sDD = new Status(i, list_basis[i].ToString());
                _StatusList.Add(sDD);
            }
            StatusSelections = new ListSelectionWrapper<Status>(_StatusList, "Name");
            dic.Add(0, StatusSelections);

            ListSelectionWrapper<Status> StatusSelections1;
            StatusList _StatusList1 = new StatusList();
            List<string> list_plan = dicX["plan"].ToList();
            for (int i = 0; i < list_plan.Count; i++)
            {
                Status sDD = new Status(i, list_plan[i].ToString());
                _StatusList1.Add(sDD);
            }
            StatusSelections1 = new ListSelectionWrapper<Status>(_StatusList1, "Name");
            dic.Add(1, StatusSelections1);

            ListSelectionWrapper<Status> StatusSelections2;
            StatusList _StatusList2 = new StatusList();
            List<string> list_formula = dicX["formula"].ToList();
            for (int i = 0; i < list_formula.Count; i++)
            {
                Status sDD = new Status(i, list_formula[i].ToString());
                _StatusList2.Add(sDD);
            }
            StatusSelections2 = new ListSelectionWrapper<Status>(_StatusList2, "Name");
            dic.Add(2, StatusSelections2);

            ListSelectionWrapper<Status> StatusSelections3;
            StatusList _StatusList3 = new StatusList();
            List<string> list_table = dicX["table"].ToList();
            for (int i = 0; i < list_table.Count; i++)
            {
                Status sDD = new Status(i, list_table[i].ToString());
                _StatusList3.Add(sDD);
            }
            StatusSelections3 = new ListSelectionWrapper<Status>(_StatusList3, "Name");
            dic.Add(3, StatusSelections3);

            ListSelectionWrapper<Status> StatusSelections4;
            StatusList _StatusList4 = new StatusList();
            List<string> list_tool = dicX["tool"].ToList();
            for (int i = 0; i < list_tool.Count; i++)
            {
                Status sDD = new Status(i, list_tool[i].ToString());
                _StatusList4.Add(sDD);
            }
            StatusSelections4 = new ListSelectionWrapper<Status>(_StatusList4, "Name");
            dic.Add(4, StatusSelections4);

            return dic;
        }

        XmlDocument xml = new XmlDocument();
        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<string>> LoadXmlConfig()
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
            return  HandleXML();
        }

        /// <summary>
        /// 提取各个模块值
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<string>> HandleXML()
        {
            XmlNode rootNode;//根节点
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            List<string> list_modename;
            rootNode = xml.DocumentElement;
            //   XmlNode node_mode = rootNode.SelectSingleNode("mode");
            XmlNodeList xnl = rootNode.ChildNodes;
            foreach (XmlNode singleXmlNode in xnl)
            {
                    list_modename = new List<string>();
                    XmlNodeList xnlX = singleXmlNode.ChildNodes;
                    foreach (XmlNode singleXmlNodeX in xnlX)
                    {
                        list_modename.Add(singleXmlNodeX.Attributes["detail"].Value);
                    }
                    dic.Add(singleXmlNode.Attributes["name"].Value, list_modename);
            }
            return dic;
        }
    }
}
