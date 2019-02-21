using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using SKTraceablity.SKTraceablity.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class PlanManager : Form
    {
        public PlanManager()
        {
            InitializeComponent();
        }
        private bool edditRemark = true;
        DataTable productionDt;
        DataTable stationDt;
        DataTable planDt;
        DataTable CategoryDt = new DataTable();
        private void PlanManager_Load(object sender, EventArgs e)
        {
            #region>>>>>初始化选择列
            CategoryDt.Columns.Add("NAME");
            CategoryDt.Columns.Add("VALUE");
            DataRow drow2 = CategoryDt.NewRow();
            drow2["NAME"] = "初始化";
            drow2["VALUE"] = "0";
            CategoryDt.Rows.Add(drow2);
            DataRow drow3 = CategoryDt.NewRow();
            drow3["NAME"] = "开始";
            drow3["VALUE"] = "1";
            CategoryDt.Rows.Add(drow3);
            DataRow drow5 = CategoryDt.NewRow();
            drow5["NAME"] = "暂停";
            drow5["VALUE"] = "2";
            CategoryDt.Rows.Add(drow5);
            DataRow drow7 = CategoryDt.NewRow();
            drow7["NAME"] = "强制关闭";
            drow7["VALUE"] = "3";
            CategoryDt.Rows.Add(drow7);
            DataRow drow8 = CategoryDt.NewRow();
            drow8["NAME"] = "完成";
            drow8["VALUE"] = "4";
            CategoryDt.Rows.Add(drow8);
            #endregion
            RefishLineAndProduction();
            ReflshDataGridView();
           // DGV_Plan.ClearSelection();
        }

        private void BT_Edit_Click(object sender, EventArgs e)
        {
            if (edditRemark)
            {
                PL_EDPanel.Visible = true;
                edditRemark = false;
            }
            else
            {
                PL_EDPanel.Visible = false;
                edditRemark = true;
            }
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            DataTable dtX = AsmPlan_BLL.GetPlanByName ( TB_PlanNumber.Text.ToString().Trim());
            if (!(dtX.Rows.Count > 0))
            {
                if (!String.IsNullOrEmpty(CB_Line.SelectedItem.ToString()) && !String.IsNullOrEmpty(TB_PlanNumber.Text) && !String.IsNullOrEmpty(CB_ProductionType.SelectedItem.ToString()) && !String.IsNullOrEmpty(UD_ProductionNumber.Value.ToString()) && !String.IsNullOrEmpty(TB_OperationUser.Text))
                {

                    AsmPlanObject apo = new AsmPlanObject();
                    apo.LINE_ID = Convert.ToInt32(CB_Line.SelectedValue);
                    apo.DT = DateTime.Now;
                    apo.NAME = TB_PlanNumber.Text;
                    apo.PRODUCTION_ID = Convert.ToInt32(CB_ProductionType.SelectedValue);
                    apo.NUMBER = Convert.ToInt32(UD_ProductionNumber.Value);
                    apo.OPREATION_USER = TB_OperationUser.Text;
                    apo.COMPLETE_FLAG = "0";//表示初始化
                    apo.CREATE_BARCODE_FLAG = "0";
                    DataTable dt = AsmPlan_BLL.GetMaxLevelPlanByCondition();
                    if (dt.Rows.Count > 0 && !String.IsNullOrEmpty(dt.Rows[0]["LEVEL"].ToString()))
                    {
                        apo.PLAN_LEVEL = Convert.ToInt32(dt.Rows[0]["LEVEL"].ToString()) + 1;
                    }
                    else
                    {
                        apo.PLAN_LEVEL = 1;
                    }
                    if (AsmPlan_BLL.AddPlan(apo) > 0)
                    {
                        MessageBox.Show("保存成功！");
                        TB_PlanNumber.Text = "";
                        UD_ProductionNumber.Value = 1;
                        TB_OperationUser.Text = "";
                        ReflshDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("保存失败，请检查输入信息是否正确！");
                    }
                }
                else
                {
                    MessageBox.Show("输入信息不全，请检查后保存！");
                }
            }
            else { MessageBox.Show("工单编号有重复！请重新输入"); };
        }
        public void RefishLineAndProduction()
        {
            productionDt = null;
            productionDt = AsmProduction_BLL.GetAllAsmProduction();
            CB_ProductionType.DataSource = productionDt;
            CB_ProductionType.DisplayMember = "PRODUCTION_VR";
            CB_ProductionType.ValueMember = "PRODUCTION_ID";
            CB_ProductionType.SelectedItem = null;
            stationDt = null;
            stationDt = AsmLine_BLL.GetAllLines();
            CB_Line.DataSource = stationDt;
            CB_Line.DisplayMember = "NAME";
            CB_Line.ValueMember = "ID";
            CB_Line.SelectedItem = null;
        }
        public void ReflshDataGridView()
        {
            DataGridViewComboBoxColumn columnCbx = ((DataGridViewComboBoxColumn)DGV_Plan.Columns["operation"]);
            columnCbx.ValueMember = "VALUE";
            columnCbx.DisplayMember = "NAME";
            columnCbx.DataSource = CategoryDt;
            
            planDt = null;
            planDt = AsmPlan_BLL.GetPlansByCondition(" ORDER BY RPP.PLAN_LEVEL ASC ");
            DGV_Plan.DataSource = planDt;
             //   DGV_Plan.ClearSelection();
        }
        /// <summary>
        /// 下移操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Up_Click(object sender, EventArgs e)
        {
            #region 绑定数据源的情况下
            if (this.DGV_Plan.CurrentRow == null)
            {
                MessageBox.Show("请选择要需要操作的步序所在行");
            }
            else
            {
                int row = DGV_Plan.SelectedRows[0].Index;
                if (row >= this.DGV_Plan.Rows.Count - 1)
                {
                    MessageBox.Show("此步序已在底端，不能再下移！");
                }
                else
                {
                    AsmPlanObject apo = AsmPlan_BLL.GetPlanObjectByCondition(" WHERE ID=" + Convert.ToInt32(planDt.Rows[row]["ID"].ToString()));
                    apo.PLAN_LEVEL= apo.PLAN_LEVEL+1;
                    AsmPlanObject apo_1 = AsmPlan_BLL.GetPlanObjectByCondition("WHERE ID=" + Convert.ToInt32(planDt.Rows[row + 1]["ID"].ToString()));                    
                    apo_1.PLAN_LEVEL = apo_1.PLAN_LEVEL - 1;
                    if (AsmPlan_BLL.UpdatePlan(apo) > 0&& AsmPlan_BLL.UpdatePlan(apo_1) >0)
                    {
                        ReflshDataGridView();
                        DGV_Plan.ClearSelection();
                        DGV_Plan.Rows[row +1].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("下移失败！");
                    }
                }
            }
            #endregion
        }
        /// <summary>
        /// 向上移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Down_Click(object sender, EventArgs e)
        {
            if (this.DGV_Plan.CurrentRow == null)
            {
                MessageBox.Show("请选择要需要操作的步序所在行");
            }
            else
            {
                int row = DGV_Plan.SelectedRows[0].Index;
                if (row <= 0)
                {
                    MessageBox.Show("此步序已在顶端，不能再上移！");
                }
                else
                {
                    
                    AsmPlanObject apo = AsmPlan_BLL.GetPlanObjectByCondition(" WHERE ID=" + Convert.ToInt32(planDt.Rows[row]["ID"].ToString()));
                    apo.PLAN_LEVEL = apo.PLAN_LEVEL - 1;
                    AsmPlanObject apo_1 = AsmPlan_BLL.GetPlanObjectByCondition("WHERE ID=" + Convert.ToInt32(planDt.Rows[row - 1]["ID"].ToString()));
                    apo_1.PLAN_LEVEL = apo_1.PLAN_LEVEL + 1;
                    if (AsmPlan_BLL.UpdatePlan(apo) > 0 && AsmPlan_BLL.UpdatePlan(apo_1) > 0)
                    {
                        ReflshDataGridView();
                        DGV_Plan.ClearSelection();
                        DGV_Plan.Rows[row - 1].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("上移失败！");
                    }
                }
            }
        }
        /// <summary>
        /// 放弃编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Clean_Click(object sender, EventArgs e)
        {
            TB_PlanNumber.Text = "";
            UD_ProductionNumber.Value = 1;
            TB_OperationUser.Text = "";
        }
        #region>>>>>下拉菜单事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_Plan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //判断相应的列
            if (dgv.CurrentCell.GetType().Name == "DataGridViewComboBoxCell" && dgv.CurrentCell.RowIndex != -1)
            {
                //给这个DataGridViewComboBoxCell加上下拉事件
                (e.Control as ComboBox).SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);

            }

        }
        /// <summary>
        /// 组合框事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combox = sender as ComboBox;
            //这里比较重要
          //  combox.Leave += new EventHandler(combox_Leave);
            try
            {
                //在这里就可以做值是否改变判断
                if (combox.SelectedItem != null)
                {
                    //  ReflshDataGridView();
                    int row = DGV_Plan.SelectedRows[0].Index;
                    if (combox.SelectedValue.ToString() == "0")
                    {
                        MessageBox.Show("计划已开始或已经是初始化，不能再初始化！");
                        combox.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                        ReflshDataGridView();
                        return;
                    }
                    else if (combox.SelectedValue.ToString() == "4" && Convert.ToInt32(planDt.Rows[row]["NUMBER"].ToString()) - Convert.ToInt32(planDt.Rows[row]["COMPLETE_NUMBER"].ToString()) > 0)
                    {
                        MessageBox.Show("计划没有完成，不能关闭计划！");
                        combox.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                        ReflshDataGridView();
                        return;
                    }
                    else if (combox.SelectedValue.ToString() == "4" && Convert.ToInt32(planDt.Rows[row]["NUMBER"].ToString()) - Convert.ToInt32(planDt.Rows[row]["COMPLETE_NUMBER"].ToString()) == 0)
                    {
                        combox.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);                        
                        #region>>>>>将运行时表中的数据转移到永久性表中
                        AsmPlanObject apo = AsmPlan_BLL.GetPlanObjectByCondition(" WHERE ID=" + Convert.ToInt32(planDt.Rows[row]["ID"].ToString()));
                        AsmPPlanObject appo = new AsmPPlanObject();
                        appo.DT = System.DateTime.Now;
                        appo.COMPLETE_FLAG = "4";
                        appo.COMPLETE_NUMBER = apo.COMPLETE_NUMBER;
                        appo.CREATE_BARCODE_FLAG = apo.CREATE_BARCODE_FLAG;
                        appo.LINE_ID = apo.LINE_ID;
                        appo.NAME = apo.NAME;
                        appo.NG_NUMBER = apo.NG_NUMBER;
                        appo.NUMBER = apo.NUMBER;
                        appo.OK_NUMBER = apo.OK_NUMBER;
                        appo.OPREATION_USER = apo.OPREATION_USER;
                        appo.PLAN_LEVEL = apo.PLAN_LEVEL;
                        appo.PRODUCTION_ID = apo.PRODUCTION_ID;
                        appo.REMAIND_NUMBER = apo.REMAIND_NUMBER;
                        AsmPPlan_BLL.AddPPlan(appo);
                        AsmPlan_BLL.DeleteRPlanByCondition(" ID=" + apo.ID);
                        if (row < this.DGV_Plan.Rows.Count - 1)
                        {                          
                            for (int i=0; i < this.DGV_Plan.Rows.Count-1-row; i++)
                            {
                                AsmPlanObject apoNext = AsmPlan_BLL.GetPlanObjectByCondition(" WHERE ID=" + Convert.ToInt32(planDt.Rows[row+i+1]["ID"].ToString()));
                                apoNext.PLAN_LEVEL = apo.PLAN_LEVEL + i;
                                AsmPlan_BLL.UpdatePlan(apoNext);
                            }
                        }
                        #endregion
                        ReflshDataGridView();
                        return;
                    }
                    else if (combox.SelectedValue.ToString() == "3")
                    {
                        combox.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                        #region>>>>>将运行表中的数据转移到永久性表中
                        AsmPlanObject apo = AsmPlan_BLL.GetPlanObjectByCondition(" WHERE ID=" + Convert.ToInt32(planDt.Rows[row]["ID"].ToString()));
                        AsmPPlanObject appo = new AsmPPlanObject();
                        appo.DT = System.DateTime.Now;
                        appo.COMPLETE_FLAG = "3";
                        appo.COMPLETE_NUMBER = apo.COMPLETE_NUMBER;
                        appo.CREATE_BARCODE_FLAG = apo.CREATE_BARCODE_FLAG;
                        appo.LINE_ID = apo.LINE_ID;
                        appo.NAME = apo.NAME;
                        appo.NG_NUMBER = apo.NG_NUMBER;
                        appo.NUMBER = apo.NUMBER;
                        appo.OK_NUMBER = apo.OK_NUMBER;
                        appo.OPREATION_USER = apo.OPREATION_USER;
                        appo.PLAN_LEVEL = apo.PLAN_LEVEL;
                        appo.PRODUCTION_ID = apo.PRODUCTION_ID;
                        appo.REMAIND_NUMBER = apo.REMAIND_NUMBER;
                        AsmPPlan_BLL.AddPPlan(appo);
                        AsmPlan_BLL.DeleteRPlanByCondition(" ID="+apo.ID);
                        if (row < this.DGV_Plan.Rows.Count - 1)
                        {
                            for (int i = 0; i < this.DGV_Plan.Rows.Count-1 - row; i++)
                            {
                                AsmPlanObject apoNext = AsmPlan_BLL.GetPlanObjectByCondition(" WHERE ID=" + Convert.ToInt32(planDt.Rows[row + i+1]["ID"].ToString()));
                                apoNext.PLAN_LEVEL = apo.PLAN_LEVEL + i;
                                AsmPlan_BLL.UpdatePlan(apoNext);
                            }
                        }
                        #endregion
                        ReflshDataGridView();
                        return;
                    }
                    else
                    {

                        AsmPlanObject apo = AsmPlan_BLL.GetPlanObjectByCondition(" WHERE ID=" + Convert.ToInt32(planDt.Rows[row]["ID"].ToString()));
                        apo.COMPLETE_FLAG = combox.SelectedValue.ToString();
                        AsmPlan_BLL.UpdatePlan(apo);
                        combox.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                        ReflshDataGridView();
                        //  DGV_Plan.ClearSelection();
                        //  DGV_Plan.Rows[row].Selected = true;
                        return;
                    }
                }
                
               // Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 离开combox时，把事件删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void combox_Leave(object sender, EventArgs e)
        {
            ReflshDataGridView();
            ComboBox combox = sender as ComboBox;
            //做完处理，须撤销动态事件
            combox.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
        }
        #endregion

        private void DGV_Plan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
