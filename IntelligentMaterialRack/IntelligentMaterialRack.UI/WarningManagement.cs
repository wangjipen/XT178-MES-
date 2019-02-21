using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class WarningManagement1 : Form
    {
        int sizePage;           //分页大小
        string showColumn= "DT,ST,CODE,MESSAGE"; //需要得到的字段 (即 column1,column2,......)
        string tabName= "C_ASM_ALARM_MESSAGE_T";                                    //需要查看的表名 (即 from table_name)
        string strCondition;                               //查询条件 (即 where condition......) 不用加where关键字
        string ascColumn = "ID";                                  //排序的字段名 (即 order by column asc/desc)
        int bitOrderType = 1;                                   //排序的类型 (0为升序,1为降序)
        string pkColumn = "ID";                                   //主键名称

        public WarningManagement1()
        {
            InitializeComponent();
        }

        private void WarningManagement_Load(object sender, EventArgs e)
        {
            cmbCount.SelectedIndex = 0;
            buttonX2_Click(null, null);
        }

        private void DGV_CodeInfor_DoubleClick(object sender, EventArgs e   )
        {
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                strCondition = getCondition();
                sizePage = int.Parse(cmbCount.Text);
                gettable();
            }
            catch(Exception ex)
            {
                MessageBox.Show("查询出现错误:" + ex.Message);
            }
        }

        private void gettable()
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@currPage", ParameterDirection.Input, 1));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@showColumn", ParameterDirection.Input, showColumn));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@tabName", ParameterDirection.Input, tabName));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@strCondition", ParameterDirection.Input, strCondition));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@ascColumn", ParameterDirection.Input, ascColumn));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@bitOrderType", ParameterDirection.Input, bitOrderType));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@pkColumn ", ParameterDirection.Input, pkColumn));
            parameters.Add(ClsCommon.dbSql.CreateDbParameter("@pageSize ", ParameterDirection.Input, sizePage));

            DataTable dt = ClsCommon.dbSql.ExecuteDataTable("prcPage", parameters, CommandType.StoredProcedure);
            BindingSource source = new BindingSource();
            source.DataSource = dt;
            DGV_CodeInfor.DataSource = source;
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
                strCondition += " and ST='" + txtCode.Text + "'";
            }
            if (checkBox1.Checked)
            {
                strCondition += " and CODE='" + maskedTextBoxAdv1.Text + "'";
            }
            if (strCondition.Length > 4)
            {
                strCondition = strCondition.Substring(4);
            }

            return strCondition;
        }

        private void cmbCount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
