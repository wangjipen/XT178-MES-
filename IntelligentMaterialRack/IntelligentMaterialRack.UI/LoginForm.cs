using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using System.Net;

namespace IntelligentMaterialRack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // skinEngine1.SkinFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\Skins\DeepCyan.ssk";
            skinEngine1.SkinFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\Skins\mp10.ssk";
        }

        #region 拖动无边框窗体
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            int searchCount = 0;
            //string localHostName = Dns.GetHostName();//本机名
            //System.Net.IPAddress[] addressList = Dns.GetHostAddresses(localHostName);
            //foreach (IPAddress ip in addressList)
            //{
            //    string sql = "SELECT ID FROM dbo.S_REGISTER_T WHERE IP='" + Function_BLL.EncryptDES(ip.ToString(), "SKQ") + "' AND MAC='" + Function_BLL.EncryptDES(Function_BLL.GetMacBySendARP(ip.ToString()), "57858808") + "' AND HOSTNAME='" + Function_BLL.EncryptDES(localHostName, "57858808") + "';";
            //    DataTable dt = new DataTable();
            //    dt = ClsCommon.dbSql.ExecuteDataTable(sql);
            //    if (dt.Rows.Count > 0)
            //    {
            //        searchCount = searchCount + 1;
            //    }
            //}
            //if (searchCount == 0)
            //{
            //    MessageBox.Show("软件没有注册，请注册后重新登录！");
            //    Application.Exit();
            //}
            try
            {
                List<UsersObject> uos = User_BLL.GetAllUser();
                List<UsersObject> uosX = new List<UsersObject>();
                int j = 0;
                for (int i = 0; i < uos.Count; i++)
                {
                    if (!(uos[i].h_Permissions.Equals("超级管理员")))
                    {
                        uosX.Add(uos[i]);
                    }
                    else
                    {
                        break;
                    }
                }
                if (uosX.Count > 0)
                {
                    foreach (UsersObject uo in uosX)
                    {
                        userName.Items.Add(uo.h_UserName);
                    }
                    if (userName.Items.Count - 1 < ClsCommon.selectRecord)
                    {

                    }
                    userName.SelectedIndex = ClsCommon.selectRecord;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查数据库是否正确或网线是否连通," + ex.ToString());
                Application.Exit();
            }
        }
        /// <summary>
        /// 登录信息检查
        /// </summary>
        /// <returns></returns>
        private bool UserInputCheck()
        {
            // 保存登录名称
            string loginName = this.userName.Text.Trim();
            // 保存用户密码
            string userPwd = this.passWord.Text.Trim();

            // 开始验证
            if (string.IsNullOrEmpty(loginName))
            {

                this.toolTip1.ToolTipIcon = ToolTipIcon.Info;
                this.toolTip1.ToolTipTitle = "登录提示";
                Point showLocation = new Point(
                    this.userName.Location.X + this.userName.Width,
                    this.userName.Location.Y);
                this.toolTip1.Show("请您输入登录账户名！", this, showLocation, 5000);
                this.userName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(userPwd))
            {

                this.toolTip1.ToolTipIcon = ToolTipIcon.Info;
                this.toolTip1.ToolTipTitle = "登录提示";
                Point showLocation = new Point(
                    this.passWord.Location.X + this.passWord.Width,
                    this.passWord.Location.Y);
                this.toolTip1.Show("请您输入登陆账户密码！", this, showLocation, 5000);
                this.passWord.Focus();
                return false;
            }
            else if (userPwd.Length < 6)
            {
                this.toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                this.toolTip1.ToolTipTitle = "登录警告";
                Point showLocation = new Point(
                    this.passWord.Location.X + this.passWord.Width,
                    this.passWord.Location.Y);
                this.toolTip1.Show("用户密码长度不能小于六位！", this, showLocation, 5000);
                this.passWord.Focus();
                return false;
            }

            // 如果已通过以上所有验证则返回真
            return true;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Submit_Click(object sender, EventArgs e)
        {
            bool isEmpty = UserInputCheck();
            if (isEmpty == true)
            {
                string loginName = this.userName.Text.Trim();
                string userPwd = this.passWord.Text.Trim();
                if (loginName == "超级管理员" && userPwd == "SKQADMINISTRATOR")
                {
                    ClsCommon.userName = userName.Text;
                    ClsCommon.selectRecord = userName.SelectedIndex;

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    string userPwdX = EncryPtForMy.Class1.EncryptDES(userPwd);
                    DataTable dt = new DataTable();
                    string sql = "select h_UserName,h_yUserPwd,h_Status from Users where h_UserName='"
                        + loginName + "' and h_yUserPwd='" + userPwdX + "'";
                    dt = ClsCommon.dbSql.ExecuteDataTable(sql);

                    if (dt.Rows.Count > 0)
                    {
                        if (int.Parse(dt.Rows[0]["h_Status"].ToString()) > 0)
                        {
                            ClsCommon.userName = userName.Text;
                            ClsCommon.selectRecord = userName.SelectedIndex;
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("此账户已被锁定暂无法登录！", "登陆提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.userName.Text = "";
                            this.passWord.Text = "";
                            this.userName.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("登陆失败：用户名或密码错误,请重新输入!", "登陆提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.userName.Text = "";
                        this.passWord.Text = "";
                        this.userName.Focus();
                    }
                }

            }
        }

        private void BT_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
