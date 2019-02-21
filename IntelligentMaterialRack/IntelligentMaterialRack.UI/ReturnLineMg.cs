using IntelligentMaterialRack.IntelligentMaterialRack.BLL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using SKTraceablity.SKTraceablity.BLL;
using SKTraceablity.SKTraceablity.Moudle;
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
    public partial class ReturnLineMg : Form
    {
        public ReturnLineMg()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        DataTable lststationDt;
        DataTable newstationDt;
        AsmPTrackingObject aro;
        private void BT_Search_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TB_Sn.Text.Trim()))
            {
                aro = new AsmPTrackingObject();
                try
                {
                    aro = AsmPTracking_BLL.GetOfflineSnForNg(" SN='" + TB_Sn.Text.Trim() + "' and STATUS='NG'");
                    if (aro != null && aro.REWORK_FLAG=="0")
                    {
                        label_ST.Text = aro.ST;
                        label_ST.Refresh();
                        label_Status.Text = aro.STATUS;
                        label_Status.Refresh();
                        label_Type.Text = aro.TypeName;
                        label_Type.Refresh();
                        BT_Save.Enabled = true;
                        #region  如已经存在返修路线则进行显示
                        DataTable dt = AsmReworkWay_BLL.SelectWayByCondition("SN='" + TB_Sn.Text.Trim() + "'");
                        if (dt.Rows.Count>0)
                        {
                            
                            RB_Return.Checked = true;
                            for (int m=0;m< newstationDt.Rows.Count;m++)
                            {
                                lststationDt.ImportRow(newstationDt.Select("STATION_NAME='" + newstationDt.Rows[m]["STATION_NAME"].ToString() + "'")[0]);
                            }
                            newstationDt.Rows.Clear();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                
                                newstationDt.ImportRow(lststationDt.Select("STATION_NAME='" + dt.Rows[i]["STATION_NAME"].ToString() + "'")[0]);
                                lststationDt.Rows.Remove(lststationDt.Select("STATION_NAME='" + dt.Rows[i]["STATION_NAME"].ToString() + "'")[0]);
                            }

                            #endregion
                        }
                        ///返修原因显示
                        DataTable dt_reason = AsmReworkReson_BLL.GetReasonByCondition("SN='"+ TB_Sn.Text.Trim() + "'");
                        if (dt_reason.Rows.Count>0)
                        {
                           
                            for (int i=0;i<CB_Reson.Items.Count;i++)
                            {
                                if (CB_Reson.Items[i].Equals(dt_reason.Rows[0]["RESON"].ToString().Split(';')[0]))
                                {
                                    CB_Reson.SelectedIndex = i;
                                    if (dt_reason.Rows[0]["RESON"].ToString().Split(';').Length==2)
                                    {
                                        TB_Reson.Text = dt_reason.Rows[0]["RESON"].ToString().Split(';')[1];
                                    }
                                }
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("不存在该返修总成！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请输入总成号！");
            }
        }

        private void RB_Offline_CheckedChanged(object sender, EventArgs e)
        {
            Panel_Return.Visible = false;
        }

        private void RB_Return_CheckedChanged(object sender, EventArgs e)
        {
            Panel_Return.Visible = true;
            lststationDt = null;
            newstationDt = null;
            lststationDt = AsmStation_BLL.GetOtherStation();
            newstationDt = AsmStation_BLL.GetFirstStation();
            lstStation.DataSource = lststationDt;
            lstStation.DisplayMember = "STATION_NAME";
            lstStation.ValueMember = "STATION_ID";
            newStation.DataSource = newstationDt;
            newStation.DisplayMember = "STATION_NAME";
            newStation.ValueMember = "STATION_ID";
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Panel_Return.Visible = false;
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            if (aro == null)//未指定总成
            {
                MessageBox.Show("保存失败。请点击查询确认总成！");
            }
            else
            {
                #region>>>>>维护下线
                if (RB_Offline.Checked == true)
                {
                    AsmReworkResonObject arro = new AsmReworkResonObject();
                    arro.SN = aro.SN;
                    arro.DT = DateTime.Now;
                    arro.Type = aro.TypeName;
                    arro.Reson = CB_Reson.Text + ";" + TB_Reson.Text;
                    if (AsmReworkReson_BLL.AddReworkReson(arro) > 0)
                    {
                        #region>>>>>将运行表中的数据转移到永久性表中
                        try
                        {
                            string sql = "sn='" + aro.SN + "'";
                            AsmRTrackingObject arto = AsmRTracking_BLL.GetAsmRTrackingObjectBySn(sql);
                            AsmPTrackingObject apto = new AsmPTrackingObject();
                            apto.DT = arto.DT;
                            apto.ST = arto.ST;
                            apto.BST = arto.BST;
                            apto.SN = arto.SN;
                            apto.EngineSN = arto.EngineSN;
                            apto.GearboxSN = arto.GearboxSN;
                            apto.TypeName = arto.TypeName;
                            apto.TrayNum = arto.TrayNum;
                            apto.ProductNum = arto.ProductNum;
                            apto.STATUS = "RF";
                            apto.PLAN_ID = arto.PLAN_ID;
                            apto.REWORK_FLAG = arto.REWORK_FLAG;
                            apto.OFFLINE_DT = DateTime.Now;
                            AsmPTracking_BLL.AddPTrackingObject(apto);
                            AsmRTracking_BLL.DeleteRTrackingByCondition("R_TRACKING_ID=" + arto.R_TRACKING_ID);
                            MessageBox.Show("保存成功！");
                            BT_Save.Enabled = false;
                            TB_Sn.Text = "";
                            label_ST.Text = "";
                            label_Status.Text = "";
                            label_Type.Text = "";
                            aro = null;
                            lststationDt = null;
                            newstationDt = null;
                            lststationDt = AsmStation_BLL.GetOtherStation();
                            newstationDt = AsmStation_BLL.GetFirstStation();
                            lstStation.DataSource = lststationDt;
                            lstStation.DisplayMember = "STATION_NAME";
                            lstStation.ValueMember = "STATION_ID";
                            newStation.DataSource = newstationDt;
                            newStation.DisplayMember = "STATION_NAME";
                            newStation.ValueMember = "STATION_ID";
                            CB_Reson.SelectedIndex = -1;
                            TB_Reson.Text = "";

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("保存失败，请检查输入信息是否正确！");
                    }
                }
                #endregion
                #region>>>>>返工
                else if (RB_Return.Checked == true)
                {
                    DataTable dt_way=   AsmReworkWay_BLL.SelectWayByCondition("SN='" + TB_Sn.Text.Trim() + "'");
                    DataTable dt_reason = AsmReworkReson_BLL.GetReasonByCondition("SN='" + TB_Sn.Text.Trim() + "'");
                    if (dt_way.Rows.Count > 0 || dt_reason.Rows.Count > 0)
                    {
                        AsmReworkWay_BLL.DeleteWayBycondition("SN='" + TB_Sn.Text.Trim() + "'");
                        AsmReworkReson_BLL.DeleteReasonByCondition("SN='" + TB_Sn.Text.Trim() + "'");
                        #region
                        //存储到ReworkWay表
                        AsmReworkWayObject arwo;
                        for (int i = 0; i < newstationDt.Rows.Count; i++)
                        {
                            arwo = new AsmReworkWayObject();
                            arwo.DT = DateTime.Now;
                            arwo.SN = aro.SN;
                            arwo.ST_NAME = newstationDt.Rows[i][2].ToString();
                            arwo.ST_ID = int.Parse(newstationDt.Rows[i][0].ToString());
                            arwo.SERIAL_NO = i;
                            AsmReworkWay_BLL.AddReworkWay(arwo);
                        }
                        //存储到ReworkReson表
                        AsmReworkResonObject arro = new AsmReworkResonObject();
                        arro.SN = aro.SN;
                        arro.DT = DateTime.Now;
                        arro.Type = aro.TypeName;
                        arro.Reson = CB_Reson.Text + ";" + TB_Reson.Text;
                        if (AsmReworkReson_BLL.AddReworkReson(arro) > 0)
                        {
                            #region>>>>>将运行表中的数据转移到永久性表中
                            try
                            {
                                //string sql = "sn='" + aro.SN + "'";
                                //AsmRTrackingObject arto = AsmRTracking_BLL.GetAsmRTrackingObjectBySn(sql);
                                //AsmPTrackingObject apto = new AsmPTrackingObject();
                                //apto.DT = System.DateTime.Now;
                                //apto.ST = arto.ST;
                                //apto.BST = arto.BST;
                                //apto.SN = arto.SN;
                                //apto.EngineSN = arto.EngineSN;
                                //apto.GearboxSN = arto.GearboxSN;
                                //apto.TypeName = arto.TypeName;
                                //apto.TrayNum = arto.TrayNum;
                                //apto.ProductNum = arto.ProductNum;
                                //apto.STATUS = "NG";
                                //AsmPTracking_BLL.AddPTrackingObject(apto);
                                //AsmRTracking_BLL.DeleteRTrackingByCondition("R_TRACKING_ID=" + arto.R_TRACKING_ID);
                                MessageBox.Show("保存成功！");
                                BT_Save.Enabled = false;
                                TB_Sn.Text = "";
                                label_ST.Text = "";
                                label_Status.Text = "";
                                label_Type.Text = "";
                                aro = null;
                                lststationDt = null;
                                newstationDt = null;
                                lststationDt = AsmStation_BLL.GetOtherStation();
                                newstationDt = AsmStation_BLL.GetFirstStation();
                                lstStation.DataSource = lststationDt;
                                lstStation.DisplayMember = "STATION_NAME";
                                lstStation.ValueMember = "STATION_ID";
                                newStation.DataSource = newstationDt;
                                newStation.DisplayMember = "STATION_NAME";
                                newStation.ValueMember = "STATION_ID";
                                CB_Reson.SelectedIndex = -1;
                                TB_Reson.Text = "";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            #endregion
                        }
                        else
                        {
                            MessageBox.Show("保存失败，请检查输入信息是否正确！");
                        }
                        #endregion
                    }

                    else
                    {
                        #region
                        //存储到ReworkWay表
                        AsmReworkWayObject arwo;
                        for (int i = 0; i < newstationDt.Rows.Count; i++)
                        {
                            arwo = new AsmReworkWayObject();
                            arwo.DT = DateTime.Now;
                            arwo.SN = aro.SN;
                            arwo.ST_NAME = newstationDt.Rows[i][2].ToString();
                            arwo.ST_ID = int.Parse(newstationDt.Rows[i][0].ToString());
                            arwo.SERIAL_NO = i;
                            AsmReworkWay_BLL.AddReworkWay(arwo);
                        }
                        //存储到ReworkReson表
                        AsmReworkResonObject arro = new AsmReworkResonObject();
                        arro.SN = aro.SN;
                        arro.DT = DateTime.Now;
                        arro.Type = aro.TypeName;
                        arro.Reson = CB_Reson.Text + ";" + TB_Reson.Text;
                        if (AsmReworkReson_BLL.AddReworkReson(arro) > 0)
                        {
                            #region>>>>>将运行表中的数据转移到永久性表中
                            try
                            {
                                //string sql = "sn='" + aro.SN + "'";
                                //AsmRTrackingObject arto = AsmRTracking_BLL.GetAsmRTrackingObjectBySn(sql);
                                //AsmPTrackingObject apto = new AsmPTrackingObject();
                                //apto.DT = System.DateTime.Now;
                                //apto.ST = arto.ST;
                                //apto.BST = arto.BST;
                                //apto.SN = arto.SN;
                                //apto.EngineSN = arto.EngineSN;
                                //apto.GearboxSN = arto.GearboxSN;
                                //apto.TypeName = arto.TypeName;
                                //apto.TrayNum = arto.TrayNum;
                                //apto.ProductNum = arto.ProductNum;
                                //apto.STATUS = "NG";
                                //AsmPTracking_BLL.AddPTrackingObject(apto);
                                //AsmRTracking_BLL.DeleteRTrackingByCondition("R_TRACKING_ID=" + arto.R_TRACKING_ID);
                                MessageBox.Show("保存成功！");
                                BT_Save.Enabled = false;
                                TB_Sn.Text = "";
                                label_ST.Text = "";
                                label_Status.Text = "";
                                label_Type.Text = "";
                                aro = null;
                                lststationDt = null;
                                newstationDt = null;
                                lststationDt = AsmStation_BLL.GetOtherStation();
                                newstationDt = AsmStation_BLL.GetFirstStation();
                                lstStation.DataSource = lststationDt;
                                lstStation.DisplayMember = "STATION_NAME";
                                lstStation.ValueMember = "STATION_ID";
                                newStation.DataSource = newstationDt;
                                newStation.DisplayMember = "STATION_NAME";
                                newStation.ValueMember = "STATION_ID";
                                CB_Reson.SelectedIndex = -1;
                                TB_Reson.Text = "";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            #endregion
                        }
                        else
                        {
                            MessageBox.Show("保存失败，请检查输入信息是否正确！");
                        }
                        #endregion
                    }
                }
                #endregion
                #region>>>>>报废
                else if (RB_Scrap.Checked == true)
                {
                    AsmReworkResonObject arro = new AsmReworkResonObject();
                    arro.SN = aro.SN;
                    arro.DT = DateTime.Now;
                    arro.Type = aro.TypeName;
                    arro.Reson = CB_Reson.Text + ";" + TB_Reson.Text;
                    if (AsmReworkReson_BLL.AddReworkReson(arro) > 0)
                    {
                        #region>>>>>将运行表中的数据转移到永久性表中
                        try
                        {
                            string sql = "sn='" + aro.SN + "'";
                            AsmRTrackingObject arto = AsmRTracking_BLL.GetAsmRTrackingObjectBySn(sql);
                            AsmPTrackingObject apto = new AsmPTrackingObject();
                            apto.DT = System.DateTime.Now;
                            apto.ST = arto.ST;
                            apto.BST = arto.BST;
                            apto.SN = arto.SN;
                            apto.EngineSN = arto.EngineSN;
                            apto.GearboxSN = arto.GearboxSN;
                            apto.TypeName = arto.TypeName;
                            apto.TrayNum = arto.TrayNum;
                            apto.ProductNum = arto.ProductNum;
                            apto.STATUS = "RJ";
                            apto.PLAN_ID = arto.PLAN_ID;
                            apto.REWORK_FLAG = arto.REWORK_FLAG;
                            apto.OFFLINE_DT = DateTime.Now;
                            AsmPTracking_BLL.AddPTrackingObject(apto);
                            AsmRTracking_BLL.DeleteRTrackingByCondition("R_TRACKING_ID=" + arto.R_TRACKING_ID);
                            MessageBox.Show("保存成功！");
                            BT_Save.Enabled = false;
                            TB_Sn.Text = "";
                            label_ST.Text = "";
                            label_Status.Text = "";
                            label_Type.Text = "";
                            aro = null;
                            lststationDt = null;
                            newstationDt = null;
                            lststationDt = AsmStation_BLL.GetOtherStation();
                            newstationDt = AsmStation_BLL.GetFirstStation();
                            lstStation.DataSource = lststationDt;
                            lstStation.DisplayMember = "STATION_NAME";
                            lstStation.ValueMember = "STATION_ID";
                            newStation.DataSource = newstationDt;
                            newStation.DisplayMember = "STATION_NAME";
                            newStation.ValueMember = "STATION_ID";
                            CB_Reson.SelectedIndex = -1;
                            TB_Reson.Text = "";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("保存失败，请检查输入信息是否正确！");
                    }
                }
                #endregion
            }

        }

        private void BT_Right_Click(object sender, EventArgs e)
        {
            //记录所选数据项
            DataRow[] removex = lststationDt.Select("STATION_NAME='" + lstStation.Text + "'");
            if (removex.Length > 0)
            {
                foreach (DataRow drVal in removex)
                {
                    //移位
                    newstationDt.ImportRow(drVal);
                    lststationDt.Rows.Remove(drVal);
                    newStation.SelectedIndex = newstationDt.Rows.Count - 1;
                }
            }
        }
        private void BT_Left_Click(object sender, EventArgs e)
        {
            if (newStation.SelectedIndex == 0)
            {
                MessageBox.Show("注意：" + newstationDt.Rows[0][2] + "工位为上线工位！");
                return;
            }
            else
            {
                DataRow[] removex = newstationDt.Select("STATION_NAME='" + newStation.Text + "'");
                if (removex.Length > 0)
                {
                    foreach (DataRow drVal in removex)
                    {
                        //移位
                        lststationDt.ImportRow(drVal);
                        newstationDt.Rows.Remove(drVal);
                        //排序
                        DataView dv = lststationDt.DefaultView;
                        dv.Sort = "STATION_ID";
                    }
                }
                return;
            }
        }

        private void BT_Up_Click(object sender, EventArgs e)
        {
            int indexR = newStation.SelectedIndex;
            if (indexR == 0)
            {
                MessageBox.Show("注意："+newstationDt.Rows[0][2]+"工位已是返修首工位！");
            }
            else if (indexR == 1)
            {
                MessageBox.Show("注意：" + newstationDt.Rows[0][2] + "工位为上线工位，不可调换顺序！");
            }
            else
            {
                DataRow dr = newstationDt.NewRow();
                dr.ItemArray = newstationDt.Rows[indexR].ItemArray;
                newstationDt.Rows[indexR].ItemArray = newstationDt.Rows[indexR - 1].ItemArray;
                newstationDt.Rows[indexR - 1].ItemArray = dr.ItemArray;
                newStation.SelectedIndex = indexR - 1;
            }
            return;
        }

        private void BT_Down_Click(object sender, EventArgs e)
        {
            int indexR = newStation.SelectedIndex;
            if (indexR == 0)
            {
                MessageBox.Show("注意：" + newstationDt.Rows[0][2] + "工位为上线工位，不可调换顺序！");
            }
            else if (indexR < newstationDt.Rows.Count - 1)
            {
                DataRow dr = newstationDt.NewRow();
                dr.ItemArray = newstationDt.Rows[indexR].ItemArray;
                newstationDt.Rows[indexR].ItemArray = newstationDt.Rows[indexR + 1].ItemArray;
                newstationDt.Rows[indexR + 1].ItemArray = dr.ItemArray;
                newStation.SelectedIndex = indexR + 1;
            }
            else
            {
                MessageBox.Show("注意：该工位已为末工位，请勿重复设置！");
            }
        }

        private void BT_Clear_Click(object sender, EventArgs e)
        {
            TB_Sn.Text = "";
            label_ST.Text = "";
            label_Status.Text = "";
            label_Type.Text = "";
            aro = null;
            lststationDt = null;
            newstationDt = null;
            lststationDt = AsmStation_BLL.GetOtherStation();
            newstationDt = AsmStation_BLL.GetFirstStation();
            lstStation.DataSource = lststationDt;
            lstStation.DisplayMember = "STATION_NAME";
            lstStation.ValueMember = "STATION_ID";
            newStation.DataSource = newstationDt;
            newStation.DisplayMember = "STATION_NAME";
            newStation.ValueMember = "STATION_ID";
            CB_Reson.SelectedIndex = -1;
            TB_Reson.Text = "";
            BT_Save.Enabled = false;
        }
    }
}
