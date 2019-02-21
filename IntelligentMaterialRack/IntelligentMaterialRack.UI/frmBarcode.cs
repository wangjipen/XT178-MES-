using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using MySql;
using MyExcel;
using MyLog;
using System.Xml;
using Aresoft.Controls;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using IntelligentMaterialRack.IntelligentMaterialRack.UI;

namespace SKTraceablity.Query
{
    public partial class frmBarcode : Office2007Form
    {
        int reportCount = 0;
        DataGridView dgv;
        int totalPages;
        int page_;
        int sizePage;           //分页大小
        string showColumn; //需要得到的字段 (即 column1,column2,......)
        string tabName;                                    //需要查看的表名 (即 from table_name)
        string strCondition;                               //查询条件 (即 where condition......) 不用加where关键字
        string ascColumn = "id";                                  //排序的字段名 (即 order by column asc/desc)
        int bitOrderType = 1;                                   //排序的类型 (0为升序,1为降序)
        string pkColumn = "id";                                   //主键名称
        int page//当前页页码
        {
            get
            {
                page_ = int.Parse(tstCurrentPage.Text);
                if (page_ == 1)
                {
                    tsbStart.Enabled = false;
                    tsbPreview.Enabled = false;
                    tsbNext.Enabled = true;
                    tsbEnd.Enabled = true;
                }
                else if (page_ == totalPages)
                {
                    tsbNext.Enabled = false;
                    tsbEnd.Enabled = false;
                    tsbStart.Enabled = true;
                    tsbPreview.Enabled = true;
                }
                else
                {
                    tsbStart.Enabled = true;
                    tsbPreview.Enabled = true;
                    tsbNext.Enabled = true;
                    tsbEnd.Enabled = true;
                }
                return page_;
            }
            set
            {
                page_ = value;
                tstCurrentPage.Text = page_.ToString();
            }

        }

        public frmBarcode()
        {
            InitializeComponent();

        }

        private void frmBarcode_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            cmbCount.SelectedIndex = 1;
            chkTime.Checked = true;
          //  cmbType.SelectedIndex = 0;
            databind();
            cmbType.SelectedIndex = 0;
            reportCount = 1;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                page = 1;
                strCondition = getCondition();
                sizePage = int.Parse(cmbCount.Text);
                if (strCondition != string.Empty)
                {
                    sql = "select count(*) from " + tabName + " where " + strCondition;
                }
                else
                {
                    sql = "select count(*) from " + tabName;
                }
                int a = int.Parse(ClsCommon.dbSql.ExecuteScalar(sql).ToString());

                if (a % sizePage != 0)
                {
                    totalPages = a / sizePage + 1;
                }
                else
                {
                    totalPages = a / sizePage;
                }
                tslTotalPages.Text = "/" + totalPages.ToString();
                gettable();
            }
            catch (Exception ex)
            {
                Log.InformationLog.Error("查询出错：" + ex.Message);
                MessageBoxEx.Show("查询出错：" + ex.Message);
            }
        }

        private void gettable()
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@currPage", ParameterDirection.Input, page));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@showColumn", ParameterDirection.Input, showColumn));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@tabName", ParameterDirection.Input, tabName));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@strCondition", ParameterDirection.Input, strCondition));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@ascColumn", ParameterDirection.Input, ascColumn));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@bitOrderType", ParameterDirection.Input, bitOrderType));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@pkColumn ", ParameterDirection.Input, pkColumn));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@pageSize ", ParameterDirection.Input, sizePage));
            DataTable dt = ClsCommon.dbSql.ExecuteDataTable("prcPage", parameters, CommandType.StoredProcedure);
            if (cmbType.SelectedValue.ToString()== "C_GEELY_TESTDATA_T")
            {
                new FrmBarcodeTest().Show();
            }
            BindingSource source = new BindingSource
            {
                DataSource = dt
            };
            dgv.DataSource = source;
        }

        private string getCondition()
        {
            string strCondition = "";
            string beginTime = Convert.ToDateTime(dateTimePicker1.Value.Date).ToString("yyyy-MM-dd ") + dateTimePicker2.Value.ToLongTimeString().ToString();
            string endTime = Convert.ToDateTime(dateTimePicker3.Value.Date).ToString("yyyy-MM-dd ") + dateTimePicker4.Value.ToLongTimeString().ToString();
            if (chkTime.Checked)
            {
                strCondition += " and dt between '" + beginTime + "'" + " and '" + endTime + "'";
            }
            if (chkCode.Checked)
            {
                strCondition += " and SN='" + txtCode.Text + "'";
            }
            if (strCondition.Length > 4)
            {
                strCondition = strCondition.Substring(4);
            }

            return strCondition;
        }
       
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog frm = new SaveFileDialog();
                frm.FileName = DateTime.Now.ToString("yyyyMMddHHmm");
                frm.Filter = "excel文件(*.xls)|*.xlsx|所有文件(*.*)|*.*";
                if (DialogResult.OK == frm.ShowDialog())
                {
                    string strFileName = frm.FileName;
                    ExcelHelper execl = new ExcelHelper(strFileName);
                    if (execl.DataGridViewToExcel(dgv, "data", true) > 0)
                    {
                        MessageBox.Show("Excel导出成功。");
                    }
                    else
                    {
                        MessageBox.Show("Excel导出失败。");
                    }
                    execl.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("Excel导出失败。");
                MyLog.Log.InformationLog.Error("Excel导出失败。", ex);
            }
        }

        private void tsbStart_Click(object sender, EventArgs e)
        {
            page = 1;
            gettable();
        }

        private void tsbEnd_Click(object sender, EventArgs e)
        {
            page = totalPages;
            gettable();
        }

        private void tsbPreview_Click(object sender, EventArgs e)
        {
            if (page != 1)
            {
                page--;
                gettable();
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (page != totalPages)
            {
                page++;
                gettable();
            }
        }

        private void tstCurrentPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                gettable();
            }
        }
        /// <summary>
        /// 数据库表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbType.Text == "部件")
            //{
            //    dataGridView1.Visible = true;
            //    dataGridView2.Visible = false;
            //    dataGridView3.Visible = false;
            //    dataGridView4.Visible = false;
            //    dataGridView5.Visible = false;
            //    tabName = "AutoASS_Keypart";
            //    showColumn = "id,dt,Transfer,Mode,ST,SN,WID,TID,CSC,Keypart_ID,Keypart_Name,Keypart_PN,Keypart_NUM,Module";
            //    dgv = dataGridView1;
            //}
            //else if (cmbType.Text == "扭矩")
            //{
            //    dataGridView1.Visible = false;
            //    dataGridView3.Visible = false;
            //    dataGridView4.Visible = false;
            //    dataGridView2.Visible = true;
            //    dataGridView5.Visible = false;
            //    tabName = "AutoASS_Bolt";
            //    showColumn = "id,dt,Transfer,Mode,SN,ST,T,A,P,C,R,WID,TID,Keypart_ID,Keypart_Name,Keypart_PN";
            //    dgv = dataGridView2;
            //}
            //else if (cmbType.Text == "气密性")
            //{
            //    dataGridView1.Visible = false;
            //    dataGridView2.Visible = false;
            //    dataGridView4.Visible = false;
            //    dataGridView3.Visible = true;
            //    dataGridView5.Visible = false;
            //    tabName = "AutoASS_Leakage";
            //    showColumn = "id,dt,Transfer,Mode,ST,SN,V1,V2,R,WID,TID,P,Keypart_ID";
            //    dgv = dataGridView3;
            //}
            //else if (cmbType.Text == "二级总成(扭矩)")
            //{
            //    dataGridView1.Visible = false;
            //    dataGridView2.Visible = false;
            //    dataGridView3.Visible = false;
            //    dataGridView5.Visible = false;
            //    dataGridView4.Visible = true;
            //    tabName = "AutoASS_Bolt_CSC";
            //    showColumn = "id,dt,Transfer,Mode,SN,ST,T,A,P,C,R,WID,TID,Keypart_ID,Keypart_Name,Keypart_PN";
            //    dgv = dataGridView4;
            //}
            //else if (cmbType.Text == "二级总成(部件)")
            //{
            //    dataGridView1.Visible = false;
            //    dataGridView2.Visible = false;
            //    dataGridView3.Visible = false;
            //    dataGridView4.Visible = false;
            //    dataGridView5.Visible = true;
            //    tabName = "AutoASS_Keypart_CSC";
            //    showColumn = "id,dt,Transfer,Mode,ST,SN,WID,TID,CSC,Keypart_ID,Keypart_Name,Keypart_PN,Keypart_NUM,CSC_Slot";
            //    dgv = dataGridView5;
            //}
            if (reportCount == 1)
            {
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns.Clear();
                }
                showColumn = "";
                dataGridView1.Visible = true;
                tabName = cmbType.SelectedValue.ToString();
                XmlNode roportNode = ClsCommon.rootNode.SelectSingleNode("reportConfig");
                XmlNodeList tableNodes = roportNode.SelectNodes("Table");
                foreach (XmlNode nodetable in tableNodes)
                {
                    if (nodetable.Attributes["name"].Value == cmbType.SelectedValue.ToString())
                    {
                        XmlNodeList tableColumn = nodetable.SelectNodes("item");
                        for (int i = 0; i < tableColumn.Count; i++)
                        {
                            XmlNode columnNode = tableColumn[i];
                            if (i == tableColumn.Count-1)
                            {
                                showColumn = showColumn + columnNode.Attributes["columnName"].Value;
                            }
                            else
                            {
                                showColumn = showColumn + columnNode.Attributes["columnName"].Value + ",";
                            }
                            if (columnNode.Attributes["showName"].Value == "编号")
                            {
                                ascColumn = columnNode.Attributes["columnName"].Value;
                                pkColumn= columnNode.Attributes["columnName"].Value;
                            }
                            if (columnNode.Attributes["columnName"].Value == "ST")
                            {
                                dataGridView1.Columns.Add(new DataGridViewAutoFilterTextBoxColumn());
                            }
                            else if (columnNode.Attributes["columnName"].Value == "SN")
                            {
                                dataGridView1.Columns.Add(new DataGridViewAutoFilterTextBoxColumn());
                            }
                            else if (columnNode.Attributes["columnName"].Value == "WID")
                            {
                                dataGridView1.Columns.Add(new DataGridViewAutoFilterTextBoxColumn());
                            }
                            else
                            {
                                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                            }
                            dataGridView1.Columns[i].HeaderText = columnNode.Attributes["showName"].Value;  
                            if (columnNode.Attributes["columnName"].Value == "[X-Y]")
                            {
                                dataGridView1.Columns[i].DataPropertyName = "X-Y";
                            }
                            else
                            {
                                dataGridView1.Columns[i].DataPropertyName = columnNode.Attributes["columnName"].Value;
                            }
                           
                        }
                    }
                }
                dgv = dataGridView1;
                buttonX2_Click(null, null);
            }
           
        }
        /// <summary>
        /// 根据表名查数据库数据
        /// </summary>
        /// <param name="tableName"></param>
        public void findData(string tableName)
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns.Clear();
            }
            showColumn = "";
            dataGridView1.Visible = true;
            tabName = cmbType.SelectedValue.ToString();
            XmlNode roportNode = ClsCommon.rootNode.SelectSingleNode("reportConfig");
            XmlNodeList tableNodes = roportNode.SelectNodes("Table");
            foreach (XmlNode nodetable in tableNodes)
            {
                if (nodetable.Attributes["name"].Value == tableName)
                {
                    XmlNodeList tableColumn = nodetable.SelectNodes("item");
                    for (int i = 0; i < tableColumn.Count; i++)
                    {
                        XmlNode columnNode = tableColumn[i];
                        if (i == tableColumn.Count - 1)
                        {
                            showColumn = showColumn + columnNode.Attributes["columnName"].Value;
                        }
                        else
                        {
                            showColumn = showColumn + columnNode.Attributes["columnName"].Value + ",";
                        }
                        if (columnNode.Attributes["columnName"].Value == "ST")
                        {
                            dataGridView1.Columns.Add(new DataGridViewAutoFilterTextBoxColumn());
                        }
                        else if (columnNode.Attributes["columnName"].Value == "SN")
                        {
                            dataGridView1.Columns.Add(new DataGridViewAutoFilterTextBoxColumn());
                        }
                        else if (columnNode.Attributes["columnName"].Value == "WID")
                        {
                            dataGridView1.Columns.Add(new DataGridViewAutoFilterTextBoxColumn());
                        }
                        else
                        {
                            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                        }
                        dataGridView1.Columns[i].HeaderText = columnNode.Attributes["showName"].Value;
                        dataGridView1.Columns[i].DataPropertyName = columnNode.Attributes["columnName"].Value;
                    }
                }
            }
            dgv = dataGridView1;
            buttonX2_Click(null, null);
        }
        /// <summary>
        /// 窗体加载完成后，重新根据表名查数据库数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBarcode_Shown(object sender, EventArgs e)
        {
            findData(cmbType.SelectedValue.ToString());
        }
        /// <summary>
        /// 绑定表名下拉菜单
        /// </summary>
        public void databind()
        {
            XmlNode roportNode = ClsCommon.rootNode.SelectSingleNode("reportConfig");
            XmlNodeList tableNodes = roportNode.SelectNodes("Table");
            List<Table> tableName = new List<Table>();
            foreach (XmlNode nodetable in tableNodes)
            {
                Table table = new Table();
                table.TabelName = nodetable.Attributes["showName"].Value;
                table.TableValue = nodetable.Attributes["name"].Value;
                //  cmbType.Items.Add(nodetable.Attributes["showName"].Value);
                tableName.Add(table);
            }
            cmbType.DataSource = tableName;
            cmbType.DisplayMember = "TabelName";
            cmbType.ValueMember = "TableValue";

        }
    }
}
