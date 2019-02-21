using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using SKTraceablity.SKTraceablity.BLL;
using SKTraceablity.SKTraceablity.Moudle;
using SKTrackClient.SKTrackClient.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class ElectronicRecord : Form
    {
        public ElectronicRecord()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        public static string BasePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        public DataTable discriptDt;//描述总成
        public DataTable materialDt;//物料
        public DataTable boltDt;//螺栓
        public DataTable leakageDt;//气密性
        Dictionary<string, object> data = new Dictionary<string, object>();
        private void ElectronicRecord_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Search_Click(object sender, EventArgs e)
        {
            data = new Dictionary<string, object>();
            if (!String.IsNullOrEmpty(TB_Sn.Text))
            {
                AsmRTrackingObject aro = AsmRTracking_BLL.GetAsmRTrackingObjectBySn(" SN='"+TB_Sn.Text.Trim() + "'");
                if (aro != null)
                {
                    label6.Text = TB_Sn.Text.Trim();
                    label6.Refresh();
                    label8.Text = aro.TypeName;
                    label8.Refresh();
                    label10.Text = aro.DT.ToString("yyyy-MM-dd HH:mm:ss");
                    label10.Refresh();
                    label12.Text = "           ";
                    label12.Refresh();
                    //data = new Dictionary<string, object>();
                    data.Add("sn", TB_Sn.Text.Trim());
                    data.Add("productionType", aro.TypeName);
                    data.Add("onlineDate", aro.DT.ToString());
                    data.Add("offlineDate", "");
                    DataTable dt = Bolt_BLL.GetBoltByCondition(" SN='" + TB_Sn.Text.Trim() + "'");
                    if (dt.Rows.Count != 0)
                    {
                        DGV_Bolt.DataSource = dt;//DGV_Bolt接收数据
                        DGV_Bolt.Visible = true;
                        label3.Visible = true;
                        DGV_Bolt.ClearSelection();
                    }
                    else
                    {
                        label3.Visible = false;
                        DGV_Bolt.Visible = false;
                    }
                    data.Add("bolt", dt);
                    DataTable materialdt = AsmKeypart_BLL.GetKeypartByCondition(" SN='" + TB_Sn.Text.Trim() + "'");
                    if (materialdt.Rows.Count != 0)
                    {
                        DGV_Material.DataSource = materialdt;//DGV_Material接收数据
                        DGV_Material.Visible = true;
                        label2.Visible = true;
                        DGV_Material.ClearSelection();
                    }
                    else
                    {
                        label2.Visible = false;
                        DGV_Material.Visible = false;
                    }
                    data.Add("material", materialdt);
                    DataTable leakagedt = AsmLeakage_BLL.GetLeakageBySn(" SN='" + TB_Sn.Text.Trim() + "'");   
                    if (leakagedt.Rows.Count != 0)
                    {
                        DGV_Leakage.DataSource = leakagedt;//DGV_Leakage接收数据
                        DGV_Leakage.Visible = true;
                        label5.Visible = true;
                        DGV_Leakage.ClearSelection();
                    }
                    else
                    {
                        label5.Visible = false;
                        DGV_Leakage.Visible = false;
                    }
                    data.Add("leakage", leakagedt);
                    return;
                }
                else
                {
                    AsmPTrackingObject apo = AsmPTracking_BLL.GetPTrackingObjectByCondition(" SN='" + TB_Sn.Text.Trim() + "'");
                    if (apo != null)
                    {
                        label6.Text = TB_Sn.Text.Trim();
                        label6.Refresh();
                        label8.Text = apo.TypeName;
                        label8.Refresh();
                        label10.Text = apo.DT.ToString("yyyy-MM-dd HH:mm:ss");
                        label10.Refresh();
                        label12.Text= apo.OFFLINE_DT.ToString("yyyy-MM-dd HH:mm:ss");
                        label12.Refresh();
                        //data = new Dictionary<string, object>();
                        data.Add("sn", TB_Sn.Text.Trim());
                        data.Add("productionType", apo.TypeName);
                        data.Add("onlineDate",apo.DT.ToString());
                        data.Add("offlineDate", apo.OFFLINE_DT.ToString());
                        DataTable dt = Bolt_BLL.GetBoltByCondition(" SN='" + TB_Sn.Text.Trim() + "'");
                        if (dt.Rows.Count != 0)
                        {
                            DGV_Bolt.DataSource = dt;//DGV_Bolt接收数据
                            DGV_Bolt.Visible = true;
                            label3.Visible = true;
                            DGV_Bolt.ClearSelection();
                        }
                        else
                        {
                            label3.Visible = false;
                            DGV_Bolt.Visible = false;
                        }
                        data.Add("bolt", dt);
                        DataTable materialdt = AsmKeypart_BLL.GetKeypartByCondition(" SN='" + TB_Sn.Text.Trim() + "'");
                        if (materialdt.Rows.Count != 0)
                        {
                            DGV_Material.DataSource = materialdt;//DGV_Material接收数据
                            DGV_Material.Visible = true;
                            label2.Visible = true;
                            DGV_Material.ClearSelection();
                        }
                        else
                        {
                            label2.Visible = false;
                            DGV_Material.Visible = false;
                        }
                        data.Add("material", materialdt);
                        DataTable leakagedt = AsmLeakage_BLL.GetLeakageBySn(" SN='" + TB_Sn.Text.Trim() + "'");
                        if (leakagedt.Rows.Count != 0)
                        {
                            DGV_Leakage.DataSource = leakagedt;//DGV_Leakage接收数据
                            DGV_Leakage.Visible = true;
                            label5.Visible = true;
                            DGV_Leakage.ClearSelection();
                        }
                        else
                        {
                            label5.Visible = false;
                            DGV_Leakage.Visible = false;
                        }
                        data.Add("leakage", leakagedt);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("不存在此总成号，请重新输入");
                        TB_Sn.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入总成号！");
            }
        }
        public void FillDataToWord(Dictionary<string,object> dic)
        {
            try
            {
                object oMissing = System.Reflection.Missing.Value;
                //创建一个Word应用程序实例
                Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application();
                //设置为不可见
                oWord.Visible = false;
                //模板文件地址
                object oTemplate = BasePath + "\\module\\recordModule.docx";
                //以模板为基础生成文档
                Microsoft.Office.Interop.Word._Document oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);
                //声明书签数组
                object[] oBookMark = new object[dic.Count];
                //赋值书签名
                //List<string> keyString = new List<string>(dic.Keys);
                //for (int i = 0; i < keyString.Count; i++)
                //{
                //    oBookMark[i] = keyString[i];
                //}
                oBookMark[0] = "sn";
                oBookMark[1] = "productionType";
                oBookMark[2] = "onlineDate";
                oBookMark[3] = "offlineDate";
                oBookMark[4] = "materialData";
                oBookMark[5] = "boltData";
                oBookMark[6] = "leakageData";
                System.Data.DataTable materialtable = (System.Data.DataTable)dic["material"];
                System.Data.DataTable bolttable = (System.Data.DataTable)dic["bolt"];
                System.Data.DataTable leakagetable = (System.Data.DataTable)dic["leakage"];
                //赋值任意数据到书签的位置
                oDoc.Bookmarks.get_Item(ref oBookMark[0]).Range.Text = dic["sn"].ToString();
                oDoc.Bookmarks.get_Item(ref oBookMark[1]).Range.Text = dic["productionType"].ToString();
                if(dic["onlineDate"]!=null)
                {
                    oDoc.Bookmarks.get_Item(ref oBookMark[2]).Range.Text = dic["onlineDate"].ToString();
                }
                if (dic["offlineDate"] != null)
                    oDoc.Bookmarks.get_Item(ref oBookMark[3]).Range.Text = dic["offlineDate"].ToString();
                if (materialtable.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Word.Table newTable = oDoc.Tables.Add(oDoc.Bookmarks.get_Item(ref oBookMark[4]).Range, materialtable.Rows.Count+1, materialtable.Columns.Count);
                    newTable.set_Style("网格型");
                    //设置首行标题
                    newTable.Rows[1].Cells[1].Range.Text = "日期";
                    newTable.Rows[1].Cells[2].Range.Text = "名称";
                    newTable.Rows[1].Cells[3].Range.Text = "批次号";
                    newTable.Rows[1].Cells[4].Range.Text = "员工号";
                    newTable.Rows[1].Cells[5].Range.Text = "工位";
                    for (int i = 1; i <= materialtable.Rows.Count; i++)
                    {
                        for (int j = 0; j < materialtable.Columns.Count; j++)
                        {
                            newTable.Rows[i + 1].Cells[j + 1].Range.Text = materialtable.Rows[i-1][j].ToString();
                        }
                    }
                }
                if (bolttable.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Word.Table boltDataTable = oDoc.Tables.Add(oDoc.Bookmarks.get_Item(ref oBookMark[5]).Range, bolttable.Rows.Count+1, bolttable.Columns.Count);
                    boltDataTable.set_Style("网格型");
                    //设置首行标题
                    boltDataTable.Rows[1].Cells[1].Range.Text = "日期";
                    boltDataTable.Rows[1].Cells[2].Range.Text = "名称";
                    boltDataTable.Rows[1].Cells[3].Range.Text = "角度值°";
                    boltDataTable.Rows[1].Cells[4].Range.Text = "扭矩值N/M";
                    boltDataTable.Rows[1].Cells[5].Range.Text = "结果";
                    boltDataTable.Rows[1].Cells[6].Range.Text = "员工号";
                    boltDataTable.Rows[1].Cells[7].Range.Text = "工位";
                    for (int i = 1; i <= bolttable.Rows.Count; i++)
                    {
                        for (int j = 0; j < bolttable.Columns.Count; j++)
                        {
                            boltDataTable.Rows[i + 1].Cells[j + 1].Range.Text = bolttable.Rows[i-1][j].ToString();
                            boltDataTable.Rows[i].Cells[1].Width = 80;
                            boltDataTable.Rows[i].Cells[2].Width = 95;
                            boltDataTable.Rows[i].Cells[3].Width = 50;
                            boltDataTable.Rows[i].Cells[4].Width = 50;
                            boltDataTable.Rows[i].Cells[5].Width = 30;
                            boltDataTable.Rows[i].Cells[6].Width = 90;
                            boltDataTable.Rows[i].Cells[7].Width = 30;
                        }
                    }
                    //设置末行宽度
                    boltDataTable.Rows[boltDataTable.Rows.Count].Cells[1].Width = 80;
                    boltDataTable.Rows[boltDataTable.Rows.Count].Cells[2].Width = 95;
                    boltDataTable.Rows[boltDataTable.Rows.Count].Cells[3].Width = 50;
                    boltDataTable.Rows[boltDataTable.Rows.Count].Cells[4].Width = 50;
                    boltDataTable.Rows[boltDataTable.Rows.Count].Cells[5].Width = 30;
                    boltDataTable.Rows[boltDataTable.Rows.Count].Cells[6].Width = 90;
                    boltDataTable.Rows[boltDataTable.Rows.Count].Cells[7].Width = 30;
                }
                if (leakagetable.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Word.Table leakageDataTable = oDoc.Tables.Add(oDoc.Bookmarks.get_Item(ref oBookMark[6]).Range, leakagetable.Rows.Count+1, leakagetable.Columns.Count);
                    leakageDataTable.set_Style("网格型");
                    //设置首行标题
                    leakageDataTable.Rows[1].Cells[1].Range.Text = "日期";
                    leakageDataTable.Rows[1].Cells[2].Range.Text = "气压值";
                    leakageDataTable.Rows[1].Cells[3].Range.Text = "泄漏值";
                    leakageDataTable.Rows[1].Cells[4].Range.Text = "结果";
                    leakageDataTable.Rows[1].Cells[5].Range.Text = "员工号";
                    leakageDataTable.Rows[1].Cells[6].Range.Text = "工位";
                    for (int i = 1; i <= leakagetable.Rows.Count; i++)
                    {
                        for (int j = 0; j < leakagetable.Columns.Count; j++)
                        {
                            leakageDataTable.Rows[i + 1].Cells[j + 1].Range.Text = leakagetable.Rows[i-1][j].ToString();
                            leakageDataTable.Rows[i].Cells[1].Width = 80;
                            leakageDataTable.Rows[i].Cells[2].Width = 40;
                            leakageDataTable.Rows[i].Cells[3].Width = 40;
                            leakageDataTable.Rows[i].Cells[4].Width = 30;
                            leakageDataTable.Rows[i].Cells[5].Width = 100;
                            leakageDataTable.Rows[i].Cells[6].Width = 30;
                            //newTable.Rows[i].Cells[7].Width = 30;
                        }
                    }
                    //设置末行宽度
                    leakageDataTable.Rows[leakageDataTable.Rows.Count].Cells[1].Width = 80;
                    leakageDataTable.Rows[leakageDataTable.Rows.Count].Cells[2].Width = 40;
                    leakageDataTable.Rows[leakageDataTable.Rows.Count].Cells[3].Width = 40;
                    leakageDataTable.Rows[leakageDataTable.Rows.Count].Cells[4].Width = 30;
                    leakageDataTable.Rows[leakageDataTable.Rows.Count].Cells[5].Width = 100;
                    leakageDataTable.Rows[leakageDataTable.Rows.Count].Cells[6].Width = 30;
                }

                //弹出保存文件对话框，保存生成的Word
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Word Document(*.doc)|*.doc";
                // sfd.DefaultExt = "Word Document(*.doc)|*.doc";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    object filename = sfd.FileName;
                    //object filename = BasePath + "\\module\\recordModule2017.docx";
                    oDoc.SaveAs(ref filename, ref oMissing, ref oMissing, ref oMissing,
                       ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                       ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                       ref oMissing, ref oMissing);
                    MessageBox.Show("保存成功！");
                    oDoc.Close(ref oMissing, ref oMissing, ref oMissing);
                    //关闭word
                    oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
                    Thread.Sleep(1000);
                    //  DSO_Record.Open(filename.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BT_Export_Click(object sender, EventArgs e)
        {
            if (DGV_Material.Visible!=false || DGV_Bolt.Visible!=false  ||  DGV_Leakage.Visible!=false)
            {
                FillDataToWord(data);
            } 
            else
            {
                MessageBox.Show("该总成暂无物料、螺栓、气密性数据。");
            }
        }
    }
}
