using DevComponents.DotNetBar;
using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using MyLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class ClosePlanQuery : Form
    {
        public ClosePlanQuery()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        string strCondition;                               //查询条件 (即 where condition......) 不用加where关键字
        DataTable planDt;                                  //工单数据流

        private void ClosePlanQuery_Load(object sender, EventArgs e)
        {
            #region         
            #endregion
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);  //初始化搜索时间
            chkTime.Checked = true;                              //默认开启时间查询
            ReflshDataGridView();
        }
        /// <summary>
        /// 刷新DataGridView组件的数据
        /// </summary>
        public void ReflshDataGridView()
        {
            planDt = null;
            planDt = AsmPlan_BLL.GetClosePlansByCondition(" ORDER BY PPP.DT DESC ");
            DGV_Plan.DataSource = planDt;
            DGV_Plan.ClearSelection();
        }
        /// <summary>
        /// 点击查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Query_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;                                      //SQL搜索语句
                strCondition = getCondition();                   //返回搜索条件语句
                sql = strCondition + " ORDER BY PPP.DT DESC ";  //注意：RPP为运行时表（要更换）、“1”为开始，到时候要换成“4”
                planDt = null;
                planDt = AsmPlan_BLL.GetClosePlansByCondition(sql);
                DGV_Plan.DataSource = planDt;                    //DataGridView数据流
                DGV_Plan.ClearSelection();
            }
            catch (Exception ex)
            {
                Log.InformationLog.Error("查询出错：" + ex.Message);
                MessageBoxEx.Show("查询出错：" + ex.Message);
            }
        }
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        private string getCondition()
        {
            string strCondition = "";
            string beginTime = Convert.ToDateTime(dateTimePicker1.Value.Date).ToString("yyyy-MM-dd ") + dateTimePicker2.Value.ToLongTimeString().ToString();
            string endTime = Convert.ToDateTime(dateTimePicker3.Value.Date).ToString("yyyy-MM-dd ") + dateTimePicker4.Value.ToLongTimeString().ToString();
            if (chkTime.Checked)
            {
                strCondition += " AND PPP.DT between '" + beginTime + "'" + " and '" + endTime + "'";
            }
            if (chkCode.Checked)
            {
                strCondition += " AND PPP.NAME='" + txtCode.Text + "'";
            }
            return strCondition;
        }
        /// <summary>
        /// 更改“操作”字段显示内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_Plan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
                return;
            DataGridView view = (DataGridView)sender;
            object originalValue = e.Value;
            //更改类别显示
            if (view.Columns[e.ColumnIndex].DataPropertyName == "COMPLETE_FLAG")
                switch (Convert.ToInt32(originalValue))
                {
                    case 0:
                        e.Value = "初始化";
                        break;
                    case 1:
                        e.Value = "开始";
                        break;
                    case 2:
                        e.Value = "暂停";
                        break;
                    case 3:
                        e.Value = "强制关闭";
                        break;
                    case 4:
                        e.Value = "关闭";
                        break;
                    default:
                        e.Value = "";
                        break;
                }
        }
        private void chkCode_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }
        private void txtCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void DGV_Plan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
