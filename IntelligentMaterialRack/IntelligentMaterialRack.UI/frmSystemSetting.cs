using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Microsoft.Win32;//添加命名空间
using MyExcel;
using System.Xml;
using MyLog;
using System.Data.SqlClient;
using System.IO;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;

namespace SKTraceablity.Setting
{
    public partial class frmSystemSetting : Office2007Form
    {
        public frmSystemSetting()
        {
            InitializeComponent();
        }

        private void frmSystemSetting_Load(object sender, EventArgs e)
        {
            try
            {
                AppSettings a = new AppSettings();
                propertyGrid1.SelectedObject = a;

                txtDbName.Text = ClsCommon.InitialCatalog;
                txtDbServer.Text = ClsCommon.DataSource;
                txtDbUser.Text = ClsCommon.UserID;
                txtDbPwd.Text = ClsCommon.pwd;
            }
            catch
            {
                MessageBoxEx.Show("载入配置失败！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = txtDbServer.Text;
            string uid = txtDbUser.Text;
            string pwd = txtDbPwd.Text;
            string dbname = txtDbName.Text;
            string strSql;
            if (uid == string.Empty && pwd == string.Empty)
            {
                strSql = "Data Source=" + server + ";Initial Catalog=" + dbname + ";integrated security=sspi";
            }
            else
            {
                strSql = "Server=" + server + ";User Id=" + uid + ";Password=" + pwd + ";Database=" + dbname + ";";
            }
            SqlConnection myConn = new SqlConnection(strSql);
            try
            {
                myConn.Open();
                MessageBoxEx.Show("数据库连接成功！");
            }
            catch
            {
                MessageBoxEx.Show("数据库连接失败！");
            }
            finally
            {
                myConn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommon.InitialCatalog = txtDbName.Text;
                ClsCommon.DataSource = txtDbServer.Text;
                ClsCommon.UserID = txtDbUser.Text;
                ClsCommon.pwd = txtDbPwd.Text;
                MessageBox.Show("修改成功");
            }
            catch
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}
