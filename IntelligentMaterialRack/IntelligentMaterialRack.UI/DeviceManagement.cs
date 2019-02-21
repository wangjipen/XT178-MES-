using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using SKTraceablity.SKTraceablity.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentMaterialRack.IntelligentMaterialRack.UI
{
    public partial class DeviceManagement : Form
    {
        public DeviceManagement()
        {
            InitializeComponent();
        }
        DataTable stationDt1;
        DataTable stationDt2;
        DataTable deviceDT;
        String oldIP;
        //标志位，判断是新增，还是修改;true 新增；false 修改；
        bool flag = true;
        private bool edditRemark = true;
        private void DeviceManagement_Load(object sender, EventArgs e)
        {
            StationRefish();
            ReflshDataGridView();
        }

        private void ReflshDataGridView()
        {
            deviceDT = null;
            deviceDT = AsmDevice_BLL.GetDevices();
            DGV_DeviceInfor.DataSource = deviceDT;
        }

        public void StationRefish()
        {
            stationDt1 = null;
            stationDt1 = AsmStation_BLL.GetAllStation();
            CB_ST1.DataSource = stationDt1;
            //CB_ST1.DisplayMember = "STATION_NAME";
            CB_ST1.ValueMember = "STATION_NAME";
            CB_ST1.SelectedIndex = 0;
            stationDt2 = null;
            stationDt2 = AsmStation_BLL.GetAllStation();
            CB_ST2.DataSource = stationDt2;
           // CB_ST2.DisplayMember = "STATION_NAME";
            CB_ST2.ValueMember = "STATION_NAME";
            CB_ST2.SelectedIndex = 0;
        }

        private void CB_Type2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Type2.SelectedItem == null)
            {
                return;
            }
            else if (CB_Type2.SelectedItem.ToString().Trim() == "打印机")
            {
                PL_Print.Visible = true;
                PL_PLC.Visible = false;
                TB_Control.Text = "";
                TB_CID.Text = "";
            }
            else if (CB_Type2.SelectedItem.ToString().Trim() == "PLC")
            {
                PL_Print.Visible = false;
                PL_PLC.Visible = true;
                TB_Print.Text = "";
            }
            else
            {
                PL_Print.Visible = false;
                PL_PLC.Visible = false;
                TB_Control.Text = "";
                TB_CID.Text = "";
                TB_Print.Text = "";
            }
        }

        private void BT_Print_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                object filename = fileDialog.FileName;
                TB_Print.Text = filename.ToString();
            }
        }

        private void BT_Edit_Click(object sender, EventArgs e)
        {
            if (edditRemark)
            {
                BT_Save.Text = "保存";
                flag = true;
                PL_Text1.Visible = true;
                PL_Text2.Visible = true;
                PL_BT.Visible = true;
                edditRemark = false;
            }
            else
            {
                PL_Text1.Visible = false;
                PL_Text2.Visible = false;
                PL_Print.Visible = false;
                PL_PLC.Visible = false;
                PL_BT.Visible = false;
                ClearEdit();
                edditRemark = true;
            }
        }

        private void BT_Clear_Click(object sender, EventArgs e)
        {
            ClearEdit();
        }

        private void ClearEdit()
        {
            TB_Name.Text = "";
            TB_Print.Text = "";
            TB_IP.Text = "";
            TB_CID.Text = "";
            TB_Control.Text = "";
            CB_ST1.SelectedIndex = 0;
            CB_ST2.SelectedIndex = 0;
            CB_Type1.SelectedIndex = -1;
            CB_Type2.SelectedIndex = -1;
            CB_Pro.SelectedIndex = -1;
            PL_Print.Visible = false;
            PL_PLC.Visible = false;
            BT_Save.Text = "保存";
            BT_Delete.Visible = false;
            flag = true;
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            if(check()==true)
            {
                //新增
                if(flag)
                {
                    //判断设备名是否存在
                    if (AsmDevice_BLL.IsExistCode("DEVICE_IP='" + TB_IP.Text + "'"))
                    {
                        MessageBox.Show("IP地址存在冲突，请检查！");
                    }
                    else
                    { 
                        AsmDeviceObject ado = new AsmDeviceObject();
                        ado.DEVICE_NAME = TB_Name.Text;
                        ado.DEVICE_STATION = CB_ST2.Text;
                        ado.DEVICE_TYPE = CB_Type2.SelectedItem.ToString();
                        ado.DEVICE_IP = TB_IP.Text;
                        ado.DEVICE_CID = TB_CID.Text;
                        ado.DEVICE_PROTOCOL = CB_Pro.SelectedItem.ToString();
                        ado.DEVICE_PRINTADD = TB_Print.Text;
                        ado.DEVICE_CONTROLADD = TB_Control.Text;
                        if (AsmDevice_BLL.AddDeviceObject(ado) > 0)
                        {
                            MessageBox.Show("新增成功！");
                            ClearEdit();
                            ReflshDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("新增失败！");
                            ReflshDataGridView();
                        }
                    }
                }
                //修改
                else
                {
                    if (AsmDevice_BLL.IsExistCode("DEVICE_IP='" + oldIP + "'"))
                    {
                        AsmDeviceObject ado = AsmDevice_BLL.GetDeviceObjectByCondition("where DEVICE_IP='" + oldIP + "'");
                        ado.DEVICE_NAME = TB_Name.Text;
                        ado.DEVICE_STATION = CB_ST2.Text;
                        ado.DEVICE_TYPE = CB_Type2.SelectedItem.ToString();
                        ado.DEVICE_IP = TB_IP.Text;
                        ado.DEVICE_CID = TB_CID.Text;
                        ado.DEVICE_PROTOCOL = CB_Pro.SelectedItem.ToString();
                        ado.DEVICE_PRINTADD = TB_Print.Text;
                        ado.DEVICE_CONTROLADD = TB_Control.Text;
                        if (AsmDevice_BLL.UpdateDeviceObject(ado) > 0)
                        {
                            MessageBox.Show("修改成功！");
                            ClearEdit();
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
                        MessageBox.Show("该设备不存在！");
                    }
                }
            }
        }
        /// <summary>
        /// 保存前检查数据是否输入完整
        /// </summary>
        /// <returns></returns>
        private bool check()
        {
            if (TB_Name.Text.Trim() == "")
            {
                MessageBox.Show("设备名称不能为空！");
                return false;
            }

            if (TB_IP.Text.Trim() == "")
            {
                MessageBox.Show("设备IP不能为空！");
                return false;
            }
            else
            {
                string ipStr = TB_IP.Text;
                if(!isIP(ipStr))
                {
                    MessageBox.Show("IP不合法，请重新输入！");
                    return false;
                }
            }

            if (CB_Type2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择设备类型！");
                return false;
            }
            if (CB_Pro.SelectedIndex == -1)
            {
                MessageBox.Show("请选择设备通讯协议！");
                return false;
            }
            if(TB_Control.Text.Trim()!="")
            {
                string ipStr = TB_Control.Text;
                if (!isIP(ipStr))
                {
                    MessageBox.Show("IP不合法，请重新输入！");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 判断IP地址是否合法
        /// </summary>
        /// <param name="IpStr"></param>
        /// <returns></returns>
        private bool isIP(String IpStr)
        {
            bool blnTest = false;
            bool Result = true;

            Regex regex = new Regex("((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)");
            blnTest = regex.IsMatch(IpStr);
            if (blnTest == true)
            {
                string[] strTemp = IpStr.Split(new char[] { '.' }); // textBox1.Text.Split(new char[] { '.' });
                for (int i = 0; i < strTemp.Length; i++)
                {
                    if (Convert.ToInt32(strTemp[i]) > 255)
                    { //大于255则提示，不符合IP格式 
                        Result = false;
                    }
                }
            }
            else
            {
                //输入非数字则提示，不符合IP格式 
                Result = false;
            }
            return Result;
        }

        private void BT_Query_Click(object sender, EventArgs e)
        {
            if(CB_Type1.SelectedIndex != -1)
            {
                deviceDT = null;
                deviceDT = AsmDevice_BLL.GetDevicesByCondition("DEVICE_TYPE='" + CB_Type1.Text + "' and DEVICE_STATION='" + CB_ST1.Text + "'");
                DGV_DeviceInfor.DataSource = deviceDT;
            }
            else
            {
                deviceDT = null;
                deviceDT = AsmDevice_BLL.GetDevicesByCondition("DEVICE_STATION='" + CB_ST1.Text + "'");
                DGV_DeviceInfor.DataSource = deviceDT;           
            }
        }

        private void DGV_DeviceInfor_DoubleClick(object sender, EventArgs e)
        {
            PL_Text1.Visible = true;
            PL_Text2.Visible = true;
            PL_BT.Visible = true;
            edditRemark = false;
            int row = DGV_DeviceInfor.SelectedRows[0].Index;
            TB_Name.Text = deviceDT.Rows[row]["DEVICE_NAME"].ToString();
            TB_IP.Text = deviceDT.Rows[row]["DEVICE_IP"].ToString();
            oldIP = deviceDT.Rows[row]["DEVICE_IP"].ToString();
            TB_Print.Text = deviceDT.Rows[row]["DEVICE_PRINTADD"].ToString();
            TB_CID.Text = deviceDT.Rows[row]["DEVICE_CID"].ToString();
            TB_Control.Text= deviceDT.Rows[row]["DEVICE_CONTROLADD"].ToString();
            CB_ST2.SelectedValue = deviceDT.Rows[row]["DEVICE_STATION"].ToString();
            CB_Type2.SelectedItem = deviceDT.Rows[row]["DEVICE_TYPE"].ToString();
            CB_Pro.SelectedItem= deviceDT.Rows[row]["DEVICE_PROTOCOL"].ToString();
            BT_Save.Text = "修改";
            flag = false;
            BT_Delete.Visible = true;
        }

        private void BT_Delete_Click(object sender, EventArgs e)
        {
            if (TB_IP.Text != "")
            {
                if (AsmDevice_BLL.DeleteDeviceByCondition("DEVICE_IP='" + TB_IP.Text + "'") > 0)
                {
                    MessageBox.Show("删除成功！");
                    BT_Delete.Visible = false;
                    ClearEdit();
                    ReflshDataGridView();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                    ReflshDataGridView();
                }
            }
        }
    }
}
