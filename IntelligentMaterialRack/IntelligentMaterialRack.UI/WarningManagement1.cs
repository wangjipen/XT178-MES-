using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class WarningManagement : Form
    {
        public WarningManagement()
        {
            InitializeComponent();
        }
        private bool edditRemark = true;
        DataTable warningDt;
        //标志位，判断是新增，还是修改;true 新增；false 修改；
        private bool flag = true;


        private void WarningManagement_Load(object sender, EventArgs e)
        {
            ReflshDataGridView();
        }

        private void ReflshDataGridView()
        {
            warningDt = null;
            warningDt = AsmAlarmCode_BLL.GetAlarmCodes();
            DGV_CodeInfor.DataSource = warningDt;
        }

        private void BT_Edit_Click(object sender, EventArgs e)
        {
            if (edditRemark)
            {
                flag = true;
                BT_Save.Text = "保存";
                TB_Code.Enabled = true;
                PL_Edit.Visible = true;
                edditRemark = false;
            }
            else
            {
                PL_Edit.Visible = false;
                ClearPL_Edit();
                edditRemark = true;
            }
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(TB_Code.Text)&& !String.IsNullOrEmpty(TB_ChineseInfor.Text) && !String.IsNullOrEmpty(TB_EnglishInfor.Text))
            {
                //新增
                if (flag)
                {
                    if (AsmAlarmCode_BLL.IsExistCode("ALARM_CODE='" + TB_Code.Text + "'"))
                    {
                        MessageBox.Show("该报警代码已存在！");
                    }
                    else
                    {
                        AsmAlarmCodeObject aaco = new AsmAlarmCodeObject();
                        aaco.DT = DateTime.Now;
                        aaco.ALARM_CODE = int.Parse(TB_Code.Text);
                        aaco.ALARM_TEXT = TB_ChineseInfor.Text;
                        aaco.ALARM_ENGLISH = TB_EnglishInfor.Text;
                        if (AsmAlarmCode_BLL.AddAlarmCode(aaco) > 0)
                        {
                            MessageBox.Show("保存成功！");
                            ClearPL_Edit();
                            ReflshDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("保存失败！");
                            ReflshDataGridView();
                        }
                    }
                }
                //修改
                else
                {
                    if (AsmAlarmCode_BLL.IsExistCode("ALARM_CODE='" + TB_Code.Text + "'"))
                    {
                        AsmAlarmCodeObject aaco = AsmAlarmCode_BLL.GetAlarmCodeObjectByCondition("where ALARM_CODE='" + TB_Code.Text + "'");
                        aaco.DT = DateTime.Now;
                        aaco.ALARM_CODE = int.Parse(TB_Code.Text);
                        aaco.ALARM_TEXT = TB_ChineseInfor.Text;
                        aaco.ALARM_ENGLISH = TB_EnglishInfor.Text;
                        if (AsmAlarmCode_BLL.UpdateAlarmCode(aaco) > 0)
                        {
                            MessageBox.Show("修改成功！");
                            ClearPL_Edit();
                            ReflshDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("修改失败！");
                            ReflshDataGridView();
                        }
                    }
                    else
                    {
                        MessageBox.Show("该报警信息不存在！");
                    }
                }
            }
            else
            {
                MessageBox.Show("请完整输入信息");
            }
        }

        private void BT_Query_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(TB_CodeQuery.Text))
            {
                warningDt = null;
                warningDt = AsmAlarmCode_BLL.GetAlarmCodesByCondition("ALARM_CODE='"+ TB_CodeQuery.Text+"'");
                if(warningDt.Rows.Count>0)
                {
                    DGV_CodeInfor.DataSource = warningDt;
                    //TB_Code.Text = warningDt.Rows[0]["ALARM_CODE"].ToString();
                    TB_Code.Enabled = true;
                    //TB_ChineseInfor.Text= warningDt.Rows[0]["ALARM_TEXT"].ToString();
                    //TB_EnglishInfor.Text= warningDt.Rows[0]["ALARM_ENGLISH"].ToString();
                }
                else
                {
                    MessageBox.Show("该报警代码不存在，请重新审查！");
                    ReflshDataGridView();
                }
            }
            else
            {
                MessageBox.Show("请填写完报警代码后进行查询！");
            }
        }

        private void DGV_CodeInfor_DoubleClick(object sender, EventArgs e)
        {
            PL_Edit.Visible = true;
            edditRemark = false;
            int row = DGV_CodeInfor.SelectedRows[0].Index;
            TB_Code.Text = warningDt.Rows[row]["ALARM_CODE"].ToString();
            TB_ChineseInfor.Text= warningDt.Rows[row]["ALARM_TEXT"].ToString();
            TB_EnglishInfor.Text= warningDt.Rows[row]["ALARM_ENGLISH"].ToString();
            BT_Save.Text = "修改";
            flag = false;
            TB_Code.Enabled = false;
            BT_Delete.Visible = true;
        }

        private void BT_Clear_Click(object sender, EventArgs e)
        {
            ClearPL_Edit();
        }
        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BT_Reflesh_Click(object sender, EventArgs e)
        {
            TB_CodeQuery.Text = "";
            ClearPL_Edit();
            ReflshDataGridView();
            MessageBox.Show("刷新成功！");
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Delete_Click(object sender, EventArgs e)
        {
            if (AsmAlarmCode_BLL.DeleteAlarmCodeByCondition("ALARM_CODE='" + TB_Code.Text + "'") > 0)
            {
                MessageBox.Show("删除成功！");
                ClearPL_Edit();
                ReflshDataGridView();
            }
            else
            {
                MessageBox.Show("删除失败！");
                ReflshDataGridView();
            }
        }
        /// <summary>
        /// 刷新编辑框
        /// </summary>
        private void ClearPL_Edit()
        {
            TB_Code.Text = "";
            TB_Code.Enabled = true;
            TB_ChineseInfor.Text = "";
            TB_EnglishInfor.Text = "";
            BT_Save.Text = "保存";
            BT_Delete.Visible = false;
            flag = true;
        }
    }
}
