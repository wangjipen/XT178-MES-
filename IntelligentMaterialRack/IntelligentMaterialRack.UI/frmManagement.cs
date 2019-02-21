using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevComponents.DotNetBar;
using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;

namespace SKTraceablity.Setting
{
    public partial class frmManagement : Office2007Form
    {
        public frmManagement()
        {
            InitializeComponent();
        }

        private void Management_Load(object sender, EventArgs e)
        {
            try
            {
                this.toolStripSave.Enabled = false;
                dgv_User();
                if (ClsCommon.userName != "超级管理员")
                {
                    UD_Permissions.Minimum = 2;
                    DataTable dt = User_BLL.GetUserPower(ClsCommon.userName);
                    if (dt.Rows[0]["h_Permissions"].Equals("1"))
                    {
                        label4.Visible = true;
                        UD_Permissions.Visible = true;
                    }
                    else
                    {
                        label4.Visible = false;
                        UD_Permissions.Visible = false;
                    }
                }
                else
                {
                    UD_Permissions.Minimum = 1;
                    label4.Visible = true;
                    UD_Permissions.Visible = true;
                }
                                           
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("用户管理载入失败！");
                MyLog.Log.InformationLog.Error("用户管理载入失败！" + ex.Message);
            }
        }
        private void dgv_User()
        {
            if (ClsCommon.userName != "超级管理员")
            {
                string sql = "select h_ID,h_UserName,h_yUserPwd,h_Status,h_Permissions,h_Department  from Users where h_Permissions!='1'";
                this.dataGridView_user.AutoGenerateColumns = false;// 关闭自动创建列    
                this.dataGridView_user.DataSource = ClsCommon.dbSql.ExecuteDataTable(sql);
            }
            else
            {
                string sql = "select h_ID,h_UserName,h_yUserPwd,h_Status,h_Permissions,h_Department  from Users ";
                this.dataGridView_user.AutoGenerateColumns = false;// 关闭自动创建列    
                this.dataGridView_user.DataSource = ClsCommon.dbSql.ExecuteDataTable(sql);
            }
                
        }

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            this.toolStripSave.Enabled = true;
            this.toolStripEdit.Enabled = false;

        }
        #region 保存(包括新增用户、修改用户保存)
        /// <summary>
        /// 保存(包括新增用户、修改用户保存)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripSave_Click(object sender, EventArgs e)
        {
            #region       等级为1的用户进行修改
            if (ClsCommon.userName!="超级管理员")
            {
                    //TODO:添加
                    if (this.h_UserName.Text.Trim() == string.Empty || this.h_UserPwd.Text.Trim() == string.Empty)
                    {
                        MessageBoxEx.Show("用户名或密码不能为空!");
                        this.h_UserName.Focus();
                        return;
                    }
                    else if (this.h_UserPwd.Text.Length < 6)
                    {
                        MessageBoxEx.Show("账户密码不能小于6位数字!");
                        this.h_UserPwd.Focus();
                        return;
                    }
                    DataTable dtX = User_BLL.GetUserPower(this.h_UserName.Text.Trim());          
                    if (this.toolStripEdit.Enabled == false)//添加帐户数据判断
                    {
                        if (dtX.Rows.Count > 0)
                        {
                            MessageBox.Show("数据库中已存在相同的用户名！");
                            return;
                        }
                        string str_permisssion = UD_Permissions.Value.ToString();
                        string Power_establish = "";  //放置现创建用户的权限
                
                        DataTable dt= User_BLL.GetUserPower(ClsCommon.userName);
                        if (ClsCommon.userName != "超级管理员")
                        {
                            if (dt.Rows[0]["h_Permissions"].Equals("1"))
                            {
                                string Power_Now_user = EncryPtForMy.Class1.DecryptDES(dt.Rows[0]["Power"].ToString()); //当前登录用户权限
                                string[] Power_Now_user_group = Power_Now_user.Split(';');
                                //2类用户权限分配
                                if (str_permisssion.Equals("2"))
                                {
                                    string PowerX = "basis:;";
                                    for (int i = 1; i < Power_Now_user_group.Length; i++)
                                    {
                                        PowerX += Power_Now_user_group[i] + ";";
                                    }
                                    string power = PowerX.Substring(0, PowerX.Length - 1);
                                    Power_establish = EncryPtForMy.Class1.EncryptDES(power);
                                }

                                //3类用户权限分配
                                if (str_permisssion.Equals("3"))
                                {
                                    string PowerX = "basis:;";
                                    PowerX += "plan:;";
                                    //第三等级人员只能有查看权限不能创建（建立在他的第一等级是否拥有该权限）
                                    string[] Power_Now_user_group_limit = Power_Now_user_group[1].Split(':');
                                    if (Power_Now_user_group_limit[1] != "" && Power_Now_user_group_limit[1] != null)
                                    {
                                        string Power_Now_user_group_limit_again = Power_Now_user_group_limit[1];
                                        if (Power_Now_user_group_limit_again.Length > 1)
                                        {
                                            string[] power_choice = Power_Now_user_group_limit_again.Split(',');
                                            for (int i = 0; i < power_choice.Length; i++)
                                            {
                                                if (power_choice[i] != "0" && power_choice[i] != "3")
                                                {
                                                    PowerX += power_choice[i] + ",";
                                                }                                                                           
                                            }
                                            PowerX = PowerX.Substring(0, PowerX.Length - 1);
                                            PowerX += ";";
                                        }
                                        else
                                            PowerX += ";";
                                    }
                                    PowerX += "formula:;";
                                for (int i = 3; i < 4; i++)
                                {
                                    PowerX += Power_Now_user_group[i] + ";";
                                }
                                PowerX += "tool:";
                                //第三等级人员不能导入配方（建立在他的第一等级是否拥有该权限）
                                string[] Power_Now_user_group_limit_4 = Power_Now_user_group[4].Split(':');
                                if (Power_Now_user_group_limit_4[1] != "" && Power_Now_user_group_limit[1] != null)
                                {
                                    string Power_Now_user_group_limit_again = Power_Now_user_group_limit_4[1];
                                    if (Power_Now_user_group_limit_again.Length > 1)
                                    {
                                        string[] power_choice = Power_Now_user_group_limit_again.Split(',');
                                        for (int i = 0; i < power_choice.Length; i++)
                                        {
                                            if (power_choice[i] != "0")
                                            {
                                                PowerX += power_choice[i] + ",";
                                            }
                                        }
                                        PowerX = PowerX.Substring(0, PowerX.Length - 1);
                                        PowerX += ";";
                                    }
                                    else
                                        PowerX += ";";
                                }
                                string power = PowerX.Substring(0, PowerX.Length - 1);
                                    Power_establish = EncryPtForMy.Class1.EncryptDES(power);
                                }
                            }
                        }
                        else
                        {
                            string PowerX = "";
                            Dictionary<string, List<string>> dic= LoadXmlConfig();
                            for (int i=0;i<dic.Keys.Count;i++)
                            {
                                PowerX += dic.Keys.ToList()[i].ToString() + ":;";
                            }
                            string power = PowerX.Substring(0, PowerX.Length - 1);
                            Power_establish = EncryPtForMy.Class1.EncryptDES(power);

                        }
                        string str_pwd = EncryPtForMy.Class1.EncryptDES(h_UserPwd.Text);

                        string sql = "insert into Users(h_UserName,h_yUserPwd,Power,h_Permissions,h_Status) values('"
                            + h_UserName.Text + "','"
                            + str_pwd + "','"
                            + Power_establish + "','"
                            + str_permisssion + "','"
                            + Convert.ToInt32(h_Status.Checked) + "')";
                        int res = ClsCommon.dbSql.ExecuteNonQuery(sql);
                        if (res > 0)
                        {
                            MessageBoxEx.Show("系统用户添加成功!");
                            dgv_User();
                        }
                    }
                    else if (this.toolStripAdd.Enabled == false)//修改帐户数据判断
                    {
                        string str_permisssion = UD_Permissions.Value.ToString();
                        string Power_establish = "";  //放置现创建用户的权限
                        DataTable dt = User_BLL.GetUserPower(ClsCommon.userName);
                        string Power_Now_user = EncryPtForMy.Class1.DecryptDES(dt.Rows[0]["Power"].ToString()); //当前登录用户权限
                        string[] Power_Now_user_group = Power_Now_user.Split(';');
                        //2类用户权限分配
                        if (str_permisssion.Equals("2"))
                        {
                            string PowerX = "basis:;";
                            for (int i = 1; i < Power_Now_user_group.Length; i++)
                            {
                                PowerX += Power_Now_user_group[i] + ";";
                            }
                            string power = PowerX.Substring(0, PowerX.Length - 1);
                            Power_establish = EncryPtForMy.Class1.EncryptDES(power);
                        }
                        //3类用户权限分配
                        if (str_permisssion.Equals("3"))
                        {
                            string PowerX = "basis:;";
                            PowerX += "plan:;";
                            //第三等级人员只能有查看权限不能创建（建立在他的第一等级是否拥有该权限）
                            string[] Power_Now_user_group_limit = Power_Now_user_group[1].Split(':');
                            if (Power_Now_user_group_limit[1] != "" && Power_Now_user_group_limit[1] != null)
                            {
                                string Power_Now_user_group_limit_again = Power_Now_user_group_limit[1];
                                if (Power_Now_user_group_limit_again.Length > 1)
                                {
                                    string[] power_choice = Power_Now_user_group_limit_again.Split(',');
                                    for (int i = 0; i < power_choice.Length; i++)
                                    {
                                        if (power_choice[i] != "0" && power_choice[i] != "3")
                                        {
                                            PowerX += power_choice[i] + ",";
                                        }
                                    }
                                    PowerX = PowerX.Substring(0, PowerX.Length - 1);
                                    PowerX += ";";
                                }
                                else
                                    PowerX += ";";
                            }
                            PowerX += "formula:;";
                        for (int i = 3; i < 4; i++)
                        {
                            PowerX += Power_Now_user_group[i] + ";";
                        }
                        PowerX += "tool:";
                        //第三等级人员不能导入配方（建立在他的第一等级是否拥有该权限）
                        string[] Power_Now_user_group_limit_4 = Power_Now_user_group[4].Split(':');
                        if (Power_Now_user_group_limit_4[1] != "" && Power_Now_user_group_limit[1] != null)
                        {
                            string Power_Now_user_group_limit_again = Power_Now_user_group_limit_4[1];
                            if (Power_Now_user_group_limit_again.Length > 1)
                            {
                                string[] power_choice = Power_Now_user_group_limit_again.Split(',');
                                for (int i = 0; i < power_choice.Length; i++)
                                {
                                    if (power_choice[i] != "0")
                                    {
                                        PowerX += power_choice[i] + ",";
                                    }
                                }
                                PowerX = PowerX.Substring(0, PowerX.Length - 1);
                                PowerX += ";";
                            }
                            else
                                PowerX += ";";
                        }
                        string power = PowerX.Substring(0, PowerX.Length - 1);
                            Power_establish = EncryPtForMy.Class1.EncryptDES(power);
                        }

                        string str_pwd= EncryPtForMy.Class1.EncryptDES(h_UserPwd.Text);
                        int rowIndex = int.Parse(this.dataGridView_user.SelectedRows[0].Cells[0].Value.ToString());
                        string sql = "update Users set h_UserName='" + h_UserName.Text
                            + "',h_yUserPwd='" + str_pwd
                            + "',h_Status='" + Convert.ToInt32(h_Status.Checked)
                             + "',Power='" + Power_establish
                             + "',h_Permissions='" + str_permisssion
                            + "' where h_ID='" + rowIndex + "'";
                        int res = ClsCommon.dbSql.ExecuteNonQuery(sql);
                        if (res > 0)
                        {
                            MessageBoxEx.Show("用户帐号修改成功！");
                            dgv_User();
                        }
                    }
                    toolStripAdd.Enabled = true;
                    toolStripDel.Enabled = true;
                    toolStripEdit.Enabled = true;
                    toolStripSave.Enabled = false;
            }
            #endregion

            #endregion

            #region   超级用户进行新增、修改
            //TODO:添加
            if (ClsCommon.userName=="超级管理员")
            {         
                        if (this.h_UserName.Text.Trim() == string.Empty || this.h_UserPwd.Text.Trim() == string.Empty)
                        {
                            MessageBoxEx.Show("用户名或密码不能为空!");
                            this.h_UserName.Focus();
                            return;
                        }
                        else if (this.h_UserPwd.Text.Length < 6)
                        {
                            MessageBoxEx.Show("账户密码不能小于6位数字!");
                            this.h_UserPwd.Focus();
                            return;
                        }
                        DataTable dtX_super = User_BLL.GetUserPower(this.h_UserName.Text.Trim());
                        if (this.toolStripEdit.Enabled == false)//添加帐户数据判断
                        {
                            if (dtX_super.Rows.Count > 0)
                            {
                                MessageBox.Show("数据库中已存在相同的用户名！");
                                return;
                            }
                            string str_permisssion = UD_Permissions.Value.ToString();
                            string Power_establish = "";  //放置现创建用户的权限
                            DataTable dt = User_BLL.GetUserPower(ClsCommon.userName);
                              
                                    string power_all = Handle_ID_XML();
                                    string Power_Now_user = power_all; //当前登录用户权限
                                    string[] Power_Now_user_group = Power_Now_user.Split(';');
                    //1类用户分配权限
                    if (str_permisssion.Equals("1"))
                    {
                        
                        string power = Power_Now_user;
                        Power_establish = EncryPtForMy.Class1.EncryptDES(power);
                    }
                            //2类用户权限分配
                            if (str_permisssion.Equals("2"))
                                    {
                                        string PowerX = "basis:;";
                                        for (int i = 1; i < Power_Now_user_group.Length; i++)
                                        {
                                            PowerX += Power_Now_user_group[i] + ";";
                                        }
                                        string power = PowerX.Substring(0, PowerX.Length - 1);
                                        Power_establish = EncryPtForMy.Class1.EncryptDES(power);
                                    }

                                    //3类用户权限分配
                                    if (str_permisssion.Equals("3"))
                                    {
                                        string PowerX = "basis:;";
                                        PowerX += "plan:";
                                        //第三等级人员只能有查看权限不能创建（建立在他的第一等级是否拥有该权限）
                                        string[] Power_Now_user_group_limit = Power_Now_user_group[1].Split(':');
                                        if (Power_Now_user_group_limit[1] != "" && Power_Now_user_group_limit[1] != null)
                                        {
                                            string Power_Now_user_group_limit_again = Power_Now_user_group_limit[1];
                                            if (Power_Now_user_group_limit_again.Length > 1)
                                            {
                                                string[] power_choice = Power_Now_user_group_limit_again.Split(',');
                                                for (int i = 0; i < power_choice.Length; i++)
                                                {
                                                    if (power_choice[i] != "0" && power_choice[i] != "3")
                                                    {
                                                        PowerX += power_choice[i] + ",";
                                                    }
                                                }
                                                PowerX = PowerX.Substring(0, PowerX.Length - 1);
                                                PowerX += ";";
                                            }
                                            else
                                                PowerX += ";";
                                        }
                                        PowerX += "formula:;";
                        for (int i = 3; i < 4; i++)
                        {
                            PowerX += Power_Now_user_group[i] + ";";
                        }
                        PowerX += "tool:";
                        //第三等级人员不能导入配方（建立在他的第一等级是否拥有该权限）
                        string[] Power_Now_user_group_limit_4 = Power_Now_user_group[4].Split(':');
                        if (Power_Now_user_group_limit_4[1] != "" && Power_Now_user_group_limit[1] != null)
                        {
                            string Power_Now_user_group_limit_again = Power_Now_user_group_limit_4[1];
                            if (Power_Now_user_group_limit_again.Length > 1)
                            {
                                string[] power_choice = Power_Now_user_group_limit_again.Split(',');
                                for (int i = 0; i < power_choice.Length; i++)
                                {
                                    if (power_choice[i] != "0")
                                    {
                                        PowerX += power_choice[i] + ",";
                                    }
                                }
                                PowerX = PowerX.Substring(0, PowerX.Length - 1);
                                PowerX += ";";
                            }
                            else
                                PowerX += ";";
                        }
                        string power = PowerX.Substring(0, PowerX.Length - 1);
                                        Power_establish = EncryPtForMy.Class1.EncryptDES(power);
                                    }
                                
             
                            string str_pwd = EncryPtForMy.Class1.EncryptDES(h_UserPwd.Text);

                            string sql = "insert into Users(h_UserName,h_yUserPwd,Power,h_Permissions,h_Status) values('"
                                + h_UserName.Text + "','"
                                + str_pwd + "','"
                                + Power_establish + "','"
                                + str_permisssion + "','"
                                + Convert.ToInt32(h_Status.Checked) + "')";
                            int res = ClsCommon.dbSql.ExecuteNonQuery(sql);
                            if (res > 0)
                            {
                                MessageBoxEx.Show("系统用户添加成功!");
                                dgv_User();
                            }
                        }
                        else if (this.toolStripAdd.Enabled == false)//修改帐户数据判断
                        {
                            string str_permisssion = UD_Permissions.Value.ToString();
                            string Power_establish = "";  //放置现创建用户的权限
                            DataTable dt = User_BLL.GetUserPower(ClsCommon.userName);
                            string Power_Now_user =  Handle_ID_XML(); ; //当前登录用户权限
                            string[] Power_Now_user_group = Power_Now_user.Split(';');

                    //1类用户分配权限
                    if (str_permisssion.Equals("1"))
                    {

                        string power = Power_Now_user;
                        Power_establish = EncryPtForMy.Class1.EncryptDES(power);
                    }

                    //2类用户权限分配
                    if (str_permisssion.Equals("2"))
                            {
                                string PowerX = "basis:;";
                                for (int i = 1; i < Power_Now_user_group.Length; i++)
                                {
                                    PowerX += Power_Now_user_group[i] + ";";
                                }
                                string power = PowerX.Substring(0, PowerX.Length - 1);
                                Power_establish = EncryPtForMy.Class1.EncryptDES(power);
                            }
                            //3类用户权限分配
                            if (str_permisssion.Equals("3"))
                            {
                                string PowerX = "basis:;";
                                PowerX += "plan:";
                                //第三等级人员只能有查看权限不能创建（建立在他的第一等级是否拥有该权限）
                                string[] Power_Now_user_group_limit = Power_Now_user_group[1].Split(':');
                                if (Power_Now_user_group_limit[1] != "" && Power_Now_user_group_limit[1] != null)
                                {
                                    string Power_Now_user_group_limit_again = Power_Now_user_group_limit[1];
                                    if (Power_Now_user_group_limit_again.Length > 1)
                                    {
                                        string[] power_choice = Power_Now_user_group_limit_again.Split(',');
                                        for (int i = 0; i < power_choice.Length; i++)
                                        {
                                            if (power_choice[i] != "0" && power_choice[i] != "3")
                                            {
                                                PowerX += power_choice[i] + ",";
                                            }
                                        }
                                        PowerX = PowerX.Substring(0, PowerX.Length - 1);
                                        PowerX += ";";
                                    }
                                    else
                                        PowerX += ";";
                                }
                                PowerX += "formula:;";
                                for (int i = 3; i < 4; i++)
                                {
                                    PowerX += Power_Now_user_group[i] + ";";
                                }
                        PowerX += "tool:";
                        //第三等级人员不能导入配方（建立在他的第一等级是否拥有该权限）
                        string[] Power_Now_user_group_limit_4 = Power_Now_user_group[4].Split(':');
                        if (Power_Now_user_group_limit_4[1] != "" && Power_Now_user_group_limit[1] != null)
                        {
                            string Power_Now_user_group_limit_again = Power_Now_user_group_limit_4[1];
                            if (Power_Now_user_group_limit_again.Length > 1)
                            {
                                string[] power_choice = Power_Now_user_group_limit_again.Split(',');
                                for (int i = 0; i < power_choice.Length; i++)
                                {
                                    if (power_choice[i] != "0")
                                    {
                                        PowerX += power_choice[i] + ",";
                                    }
                                }
                                PowerX = PowerX.Substring(0, PowerX.Length - 1);
                                PowerX += ";";
                            }
                            else
                                PowerX += ";";
                        }
                        string power = PowerX.Substring(0, PowerX.Length - 1);
                                Power_establish = EncryPtForMy.Class1.EncryptDES(power);
                            }

                            string str_pwd = EncryPtForMy.Class1.EncryptDES(h_UserPwd.Text);
                            int rowIndex = int.Parse(this.dataGridView_user.SelectedRows[0].Cells[0].Value.ToString());
                            string sql = "update Users set h_UserName='" + h_UserName.Text
                                + "',h_yUserPwd='" + str_pwd
                                + "',h_Status='" + Convert.ToInt32(h_Status.Checked)
                                 + "',Power='" + Power_establish
                                 + "',h_Permissions='" + str_permisssion
                                + "' where h_ID='" + rowIndex + "'";
                            int res = ClsCommon.dbSql.ExecuteNonQuery(sql);
                            if (res > 0)
                            {
                                MessageBoxEx.Show("用户帐号修改成功！");
                                dgv_User();
                            }
                        }
                        toolStripAdd.Enabled = true;
                        toolStripDel.Enabled = true;
                        toolStripEdit.Enabled = true;
                        toolStripSave.Enabled = false;
            }
            #endregion
        }





        #region 删除用户操作
        /// <summary>
        /// 删除用户操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripDel_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("确认删除此账户", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if(this.dataGridView_user.Rows.Count>0)
                {
                    string rowIndex = this.dataGridView_user.SelectedRows[0].Cells[0].Value.ToString();
                    string sql = "delete from Users where h_ID='" + rowIndex + "'";
                    int res = ClsCommon.dbSql.ExecuteNonQuery(sql);
                    if (res > 0)
                    {
                        MessageBoxEx.Show("删除成功!");
                        dgv_User();
                    }
                }
                else
                {
                    MessageBox.Show("请确定删除对象！");
                }
            }
        }
        #endregion
        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            try
            {
                this.toolStripAdd.Enabled = false;
                this.toolStripDel.Enabled = false;
                if(this.dataGridView_user.Rows.Count>0)
                {
                    string rowIndex = this.dataGridView_user.SelectedRows[0].Cells[0].Value.ToString();//获取当前所选行索引值
                    if (rowIndex != string.Empty)
                    {
                        this.toolStripSave.Enabled = true;
                        string sql = "select h_UserName,h_yUserPwd,h_Permissions,h_Status from Users where h_ID='" + rowIndex + "'";
                        DataTable dt = new DataTable();
                        dt = ClsCommon.dbSql.ExecuteDataTable(sql);
                        this.h_UserName.Text = dt.Rows[0][0].ToString();
                        string str_pwd = EncryPtForMy.Class1.DecryptDES(dt.Rows[0][1].ToString());
                        this.h_UserPwd.Text = str_pwd;
                        this.UD_Permissions.Value = Convert.ToInt32(dt.Rows[0]["h_Permissions"].ToString());
                        int st = int.Parse(dt.Rows[0][2].ToString());
                        if (st > 0)
                        {
                            this.h_Status.Checked = true;
                        }
                    }
                }  
                else
                {
                    MessageBox.Show("请选择修改对象！");
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show( EX.Message);
            }
        }

        private void dataGridView_user_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.h_UserName.Text = this.dataGridView_user[1, this.dataGridView_user.CurrentCell.RowIndex].Value.ToString();
            this.h_UserPwd.Text = this.dataGridView_user[2, this.dataGridView_user.CurrentCell.RowIndex].Value.ToString();
                this.UD_Permissions.Value = Convert.ToInt32(this.dataGridView_user[4, this.dataGridView_user.CurrentCell.RowIndex].Value.ToString());
            
            if (int.Parse(this.dataGridView_user[3, this.dataGridView_user.CurrentCell.RowIndex].Value.ToString()) == 1)
            {
                this.h_Status.Checked = true;
            }
            if (int.Parse(this.dataGridView_user[3, this.dataGridView_user.CurrentCell.RowIndex].Value.ToString()) == 0)
            {
                this.h_Status.Checked = false;
            }
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
            return HandleXML();
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

        /// <summary>
        /// 提取所有的权限
        /// </summary>
        /// <returns></returns>
        public string Handle_ID_XML()
        {
            XmlDocument xml_all = new XmlDocument();
            string filePath = System.Windows.Forms.Application.StartupPath + "\\ApplicationName.dll";
            try
            {
                xml_all.Load(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            XmlNode rootNode;//根节点
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            List<string> list_modename;
            rootNode = xml_all.DocumentElement;
            //   XmlNode node_mode = rootNode.SelectSingleNode("mode");
            XmlNodeList xnl = rootNode.ChildNodes;
            foreach (XmlNode singleXmlNode in xnl)
            {
                list_modename = new List<string>();
                XmlNodeList xnlX = singleXmlNode.ChildNodes;
                foreach (XmlNode singleXmlNodeX in xnlX)
                {
                    list_modename.Add(singleXmlNodeX.Attributes["ID"].Value);
                }
                dic.Add(singleXmlNode.Attributes["name"].Value, list_modename);
            }

            string str_power = "";
            for (int i=0;i<dic.Count;i++)
            {
                str_power += dic.Keys.ToList()[i].ToString()+":";
                List<string> list = dic[dic.Keys.ToList()[i].ToString()];
                for (int j=0;j<list.Count;j++)
                {
                    if (j != list.Count - 1)
                    {
                        str_power += list[j] + ",";
                    }
                    else
                    {
                        str_power += list[j] + ";";
                    }
                   
                }
            }
            return str_power.Substring(0,str_power.Length-1);
        }
    }
}
