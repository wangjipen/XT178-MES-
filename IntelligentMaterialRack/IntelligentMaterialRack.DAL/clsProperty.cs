using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using Microsoft.Win32;//添加命名空间
using System.Drawing.Design;
using IntelligentMaterialRack.IntelligentMaterialRack.DAL;

namespace SKTraceablity
{
    //[CategoryAttribute("文档设置"),
    //DescriptionAttribute("需要登录才可以启动"),
    //ReadOnlyAttribute(true),
    //DefaultValueAttribute("欢迎使用应用程序！")]
    /// <summary>  

    /// IMSOpenFileInPropertyGrid 的摘要说明。  

    /// </summary>  

    public class PropertyGridFileItem : UITypeEditor
    {

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {

            return UITypeEditorEditStyle.Modal;

        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.

IServiceProvider provider, object value)
        {

            IWindowsFormsEditorService edSvc =

(IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (edSvc != null)
            {

                // 可以打开任何特定的对话框  

                FolderBrowserDialog fd = new FolderBrowserDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    return fd.SelectedPath;
                }

            }

            return value;

        }

    }  


    [DefaultPropertyAttribute("plcAddr")]
    public class AppSettings
    {
//        string _fileName = "jjj";

        [Description("数据库备份路径"), Category("数据库"), Editor(typeof(PropertyGridFileItem),

typeof(System.Drawing.Design.UITypeEditor))]

        public String 数据库备份路径
        {

            get { return ClsCommon.BackupPath; }
            set { ClsCommon.BackupPath = value; }

        }

        [CategoryAttribute("数据库"),
        DescriptionAttribute("数据库备份间隔")]
        public TimeSpan 数据库备份间隔
        {
            get { return ClsCommon.BackupPeriod; }
            set { ClsCommon.BackupPeriod = value; }
        }

        [CategoryAttribute("数据库"),
        DescriptionAttribute("数据库备份间隔")]
        public DateTime 最后备份时间
        {
            get { return ClsCommon.BackupTime; }
            set { ClsCommon.BackupTime = value; }
        }

        [CategoryAttribute("启动设置"),
        DescriptionAttribute("需要登录才可以启动")]
        public bool startWithLogin
        {
            get { return ClsCommon.startWithLogin; }
            set { ClsCommon.startWithLogin = value; }
        }

        [CategoryAttribute("启动设置"),
        DescriptionAttribute("需要登录才可以退出")]
        public bool quitWithLogin
        {
            get { return ClsCommon.quitWithLogin; }
            set { ClsCommon.quitWithLogin = value; }
        }

        [CategoryAttribute("启动设置"),
        DescriptionAttribute("开机自启"),
        ReadOnlyAttribute(true)]
        public bool autoStart
        {
            get { return ClsCommon.autoStart; }
            set 
            {
                SetAutoRun(Application.ExecutablePath, value);
                ClsCommon.autoStart = value; 
            }
        }
        [CategoryAttribute("串口设置"),
        DescriptionAttribute("扫描枪的串口号")]
        public string serialPort
        {
            get { return ClsCommon.portName; }
            set { ClsCommon.portName = value; }
        }

        [CategoryAttribute("串口设置"),
        DescriptionAttribute("波特率")]
        public int BaudRate
        {
            get { return ClsCommon.BaudRate; }
            set { ClsCommon.BaudRate = value; }
        }

        [CategoryAttribute("串口设置"),
        DescriptionAttribute("数据位")]
        public int DataBits
        {
            get { return ClsCommon.DataBits; }
            set { ClsCommon.DataBits = value; }
        }

        [CategoryAttribute("串口设置"),
        DescriptionAttribute("停止位")]
        public System.IO.Ports.StopBits StopBits
        {
            get { return ClsCommon.StopBits; }
            set { ClsCommon.StopBits = value; }
        }

        [CategoryAttribute("串口设置"),
        DescriptionAttribute("奇偶校验")]
        public System.IO.Ports.Parity Parity
        {
            get { return ClsCommon.parity; }
            set { ClsCommon.parity = value; }
        }
        [CategoryAttribute("日志"),
        DescriptionAttribute("日志保存时间")]
        public MyLog.LogExpired logKeepPeriod
        {
            get { return ClsCommon.logKeepPeriod; }
            set { ClsCommon.logKeepPeriod = value; }
        }
        [CategoryAttribute("打印机设置"),
       DescriptionAttribute("打印机IP地址")]
        public string 打印机IP
        {
            get { return ClsCommon.printIp; }
            set { ClsCommon.printIp = value; }
        }
        [CategoryAttribute("打印机设置"),
      DescriptionAttribute("纸张横向或者竖向")]
        public bool 纸张横向
        {
            get { return ClsCommon.Landscape; }
            set { ClsCommon.Landscape = value; }
        }
        [CategoryAttribute("标签设置"),
      DescriptionAttribute("标签控制器IP地址")]
        public string 控制器地址
        {
            get { return ClsCommon.ptlIp; }
            set { ClsCommon.ptlIp = value; }
        }
        [CategoryAttribute("标签设置"),
     DescriptionAttribute("标签控制器端口号")]
        public string 控制器端口号
        {
            get { return ClsCommon.ptlPort; }
            set { ClsCommon.ptlPort = value; }
        }
        [CategoryAttribute("标签设置"),
    DescriptionAttribute("料架区域编号")]
        public string 料架区域编号
        {
            get { return ClsCommon.ptlArm; }
            set { ClsCommon.ptlArm = value; }
        }
        [CategoryAttribute("标签设置"),
   DescriptionAttribute("亮灯模式，TRUE 表示一起点亮，FALSE 表示单个点亮")]
        public bool 亮灯模式
        {
            get { return ClsCommon.lightModule; }
            set { ClsCommon.lightModule = value; }
        }
        [CategoryAttribute("板卡设置"),
   DescriptionAttribute("板卡端口号")]
        public string 端口号
        {
            get { return ClsCommon.adamm_iCom; }
            set { ClsCommon.adamm_iCom = value; }
        }
        [CategoryAttribute("板卡设置"),
   DescriptionAttribute("板卡地址")]
        public string 板卡地址
        {
            get { return ClsCommon.adamm_iAddr; }
            set { ClsCommon.adamm_iAddr = value; }
        }
        [CategoryAttribute("板卡设置"),
  DescriptionAttribute("开始地址")]
        public string 开始地址
        {
            get { return ClsCommon.adamm_iCount; }
            set { ClsCommon.adamm_iCount = value; }
        }
        [CategoryAttribute("板卡设置"),
 DescriptionAttribute("板卡类型")]
        public string 板卡类型
        {
            get { return ClsCommon.AdamType; }
            set { ClsCommon.AdamType = value; }
        }
        [CategoryAttribute("板卡设置"),
DescriptionAttribute("轮循时间（MS）")]
        public string 轮循时间
        {
            get { return ClsCommon.adamm_PlloingTime; }
            set { ClsCommon.adamm_PlloingTime = value; }
        }
        /// <summary>
        /// 设置应用程序开机自动运行
        /// </summary>
        /// <param name="fileName">应用程序的文件名</param>
        /// <param name="isAutoRun">是否自动运行，为false时，取消自动运行</param>
        /// <exception cref="System.Exception">设置不成功时抛出异常</exception>
        public static void SetAutoRun(string fileName, bool isAutoRun)
        {
            RegistryKey reg = null;
            try
            {
                if (!System.IO.File.Exists(fileName))
                    throw new Exception("该文件不存在!");
                String name = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (reg == null)
                    reg = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (isAutoRun)
                    reg.SetValue(name, fileName);
                else
                    reg.SetValue(name, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                if (reg != null)
                    reg.Close();
            }

        }
    }
}
