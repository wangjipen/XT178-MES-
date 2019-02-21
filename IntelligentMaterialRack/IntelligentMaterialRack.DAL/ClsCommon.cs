using MyLog;
using MySql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Timers;
using System.Xml;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class ClsCommon
    {
        static ClsCommon()
        {
            try
            {
                xml.Load(filePath);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            loadXml();
        }
        public static string userName = "默认用户";
        private static string connectionString;
        public static DbUtility dbSql;//数据库对象
        public static XmlNodeList opcRootNode;//opc node
        public static XmlNode InfoRootNode;//站配置node
        public static XmlNode SNRootNode;//SN node
        public static XmlDocument xml = new XmlDocument();//配置文件XmlDocument
        public static XmlNode rootNode;//根node
        public static string filePath = System.Windows.Forms.Application.StartupPath + "\\MyConfig.dll";//配置文件路径
        public static System.Timers.Timer m_ScheduleTimer;
        public static readonly string sqlconnection = "Data Source=.;Initial Catalog=PL9;User Id=sa;Password=xianhui;";
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);  //这里sqlconnection就是数据库连接字符串
            connection.Open();
            return connection;
        }
        public static int selectRecord
        {
            get
            {
                return int.Parse(rootNode.SelectSingleNode("sysConfig/selectRecord").InnerText);
            }
            set
            {
                rootNode.SelectSingleNode("sysConfig/selectRecord").InnerText = value.ToString();
                saveXml();
            }
        }
        #region 日志

        public static LogExpired logKeepPeriod
        {
            get
            {
                return (LogExpired)int.Parse(rootNode.SelectSingleNode("sysConfig/LogKeepPeriod").InnerText);
            }
            set
            {
                rootNode.SelectSingleNode("sysConfig/LogKeepPeriod").InnerText = ((int)value).ToString();
                saveXml();
            }
        }
        #endregion
        #region 方法
        public static void saveXml()
        {
            xml.Save(filePath);
            loadXml();
        }

        private static void loadXml()
        {
            rootNode = xml.DocumentElement;
            opcRootNode = rootNode.SelectNodes("//opcitem");
            InfoRootNode = rootNode.SelectSingleNode("InfoConfig");
            SNRootNode = rootNode.SelectSingleNode("SNConfig");

            string server = rootNode.SelectSingleNode("dbConfig/DataSource").InnerText;
            string database = rootNode.SelectSingleNode("dbConfig/InitialCatalog").InnerText;
            string user = rootNode.SelectSingleNode("dbConfig/UserID").InnerText;
            string password = rootNode.SelectSingleNode("dbConfig/pwd").InnerText;
            if (user == string.Empty && password == string.Empty)
            {
                connectionString = "Data Source=" + server +
                        ";Initial Catalog=" + database +
                        ";integrated security=sspi";
            }
            else
            {
                connectionString = "Data Source=" + server +
                        ";Initial Catalog=" + database +
                        ";User ID=" + user +
                        ";pwd=" + password;
            }
            dbSql = new DbUtility(connectionString, DbProviderType.SqlServer);
        }
        #endregion
        #region 数据库
        public static string DataSource
        {
            get
            {
                return rootNode.SelectSingleNode("dbConfig/DataSource").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("dbConfig/DataSource").InnerText = value;
                saveXml();
            }
        }

        public static string InitialCatalog
        {
            get
            {
                return rootNode.SelectSingleNode("dbConfig/InitialCatalog").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("dbConfig/InitialCatalog").InnerText = value;
                saveXml();
            }
        }

        public static string UserID
        {
            get
            {
                return rootNode.SelectSingleNode("dbConfig/UserID").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("dbConfig/UserID").InnerText = value;
                saveXml();
            }
        }

        public static string pwd
        {
            get
            {
                return rootNode.SelectSingleNode("dbConfig/pwd").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("dbConfig/pwd").InnerText = value;
                saveXml();
            }
        }

        public static string BackupPath
        {
            get
            {
                return rootNode.SelectSingleNode("dbConfig/BackupPath").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("dbConfig/BackupPath").InnerText = value;
                saveXml();
            }
        }

        public static TimeSpan BackupPeriod
        {
            get
            {
                return TimeSpan.Parse(rootNode.SelectSingleNode("dbConfig/BackupPeriod").InnerText);
            }
            set
            {
                rootNode.SelectSingleNode("dbConfig/BackupPeriod").InnerText = value.ToString();
                saveXml();
            }
        }

        public static DateTime BackupTime
        {
            get
            {
                DateTime result;
                if (DateTime.TryParse(rootNode.SelectSingleNode("dbConfig/BackupTime").InnerText, out result))
                {
                    return result;
                }
                BackupTime = DateTime.Now;
                return DateTime.Now;
            }
            set
            {
                rootNode.SelectSingleNode("dbConfig/BackupTime").InnerText = value.ToString();
                saveXml();
            }
        }
        #endregion
        #region 串口

        public static System.IO.Ports.Parity parity
        {
            get
            {
                return (System.IO.Ports.Parity)int.Parse(rootNode.SelectSingleNode("serialPortConfig/Parity").InnerText);
            }
            set
            {
                rootNode.SelectSingleNode("serialPortConfig/Parity").InnerText = ((int)value).ToString();
                saveXml();
            }
        }

        public static string portName
        {
            get
            {
                return rootNode.SelectSingleNode("serialPortConfig/PortName").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("serialPortConfig/PortName").InnerText = value;
                saveXml();
            }
        }

        public static int BaudRate
        {
            get
            {
                return int.Parse(rootNode.SelectSingleNode("serialPortConfig/BaudRate").InnerText);
            }
            set
            {
                rootNode.SelectSingleNode("serialPortConfig/BaudRate").InnerText = value.ToString();
                saveXml();
            }
        }

        public static int DataBits
        {
            get
            {
                return int.Parse(rootNode.SelectSingleNode("serialPortConfig/DataBits").InnerText);
            }
            set
            {
                rootNode.SelectSingleNode("serialPortConfig/DataBits").InnerText = value.ToString();
                saveXml();
            }
        }

        public static System.IO.Ports.StopBits StopBits
        {
            get
            {
                switch (rootNode.SelectSingleNode("serialPortConfig/StopBits").InnerText)
                {
                    case "0":
                        return System.IO.Ports.StopBits.None;
                    case "1":
                        return System.IO.Ports.StopBits.One;
                    case "2":
                        return System.IO.Ports.StopBits.Two;
                    case "3":
                        return System.IO.Ports.StopBits.OnePointFive;
                    default:
                        throw new Exception("错误的停止位数");
                }

            }
            set
            {
                switch (value)
                {
                    case System.IO.Ports.StopBits.None:
                        rootNode.SelectSingleNode("serialPortConfig/StopBits").InnerText = "0";
                        break;
                    case System.IO.Ports.StopBits.One:
                        rootNode.SelectSingleNode("serialPortConfig/StopBits").InnerText = "1";
                        break;
                    case System.IO.Ports.StopBits.Two:
                        rootNode.SelectSingleNode("serialPortConfig/StopBits").InnerText = "2";
                        break;
                    case System.IO.Ports.StopBits.OnePointFive:
                        rootNode.SelectSingleNode("serialPortConfig/StopBits").InnerText = "3";
                        break;
                    default:
                        throw new Exception("错误的停止位数");
                }
                saveXml();
            }
        }
        #endregion
        #region>>>>>启动设置
        public static bool startWithLogin
        {
            get
            {
                string a = rootNode.SelectSingleNode("sysConfig/StartWithLogin").InnerText;
                if (a == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                if (value)
                {
                    rootNode.SelectSingleNode("sysConfig/StartWithLogin").InnerText = "1";
                    saveXml();
                }
                else
                {
                    rootNode.SelectSingleNode("sysConfig/StartWithLogin").InnerText = "0";
                    saveXml();
                }

            }
        }

        public static bool quitWithLogin
        {
            get
            {
                string a = rootNode.SelectSingleNode("sysConfig/QuitWithLogin").InnerText;
                if (a == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                if (value)
                {
                    rootNode.SelectSingleNode("sysConfig/QuitWithLogin").InnerText = "1";
                    saveXml();
                }
                else
                {
                    rootNode.SelectSingleNode("sysConfig/QuitWithLogin").InnerText = "0";
                    saveXml();
                }
            }
        }
        public static bool autoStart
        {
            get
            {
                string a = rootNode.SelectSingleNode("sysConfig/AutoStart").InnerText;
                if (a == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                if (value)
                {
                    rootNode.SelectSingleNode("sysConfig/AutoStart").InnerText = "1";
                    saveXml();
                }
                else
                {
                    rootNode.SelectSingleNode("sysConfig/AutoStart").InnerText = "0";
                    saveXml();
                }
            }
        }
        #endregion
        #region>>>>>打印机设置
        public static string printIp
        {
            get
            {
                return rootNode.SelectSingleNode("printConfig/printIp").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("printConfig/printIp").InnerText = value;
                saveXml();
            }
        }
        public static bool Landscape
        {
            get
            {
                string a = rootNode.SelectSingleNode("printConfig/Landscape").InnerText;
                if (a == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                if (value)
                {
                    rootNode.SelectSingleNode("printConfig/Landscape").InnerText = "1";
                    saveXml();
                }
                else
                {
                    rootNode.SelectSingleNode("printConfig/Landscape").InnerText = "0";
                    saveXml();
                }

            }          
        }
        #endregion
        #region>>>>>标签设置
        public static string ptlIp
        {
            get
            {
                return rootNode.SelectSingleNode("PTLConfig/ptlIp").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("PTLConfig/ptlIp").InnerText = value;
                saveXml();
            }
        }
        public static bool lightModule
        {
            get
            {
                string a = rootNode.SelectSingleNode("PTLConfig/lightModule").InnerText;
                if (a == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                if (value)
                {
                    rootNode.SelectSingleNode("PTLConfig/lightModule").InnerText = "1";
                    saveXml();
                }
                else
                {
                    rootNode.SelectSingleNode("PTLConfig/lightModule").InnerText = "0";
                    saveXml();
                }
            }
        }
        public static string ptlPort
        {
            get
            {
                return rootNode.SelectSingleNode("PTLConfig/ptlPort").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("PTLConfig/ptlPort").InnerText = value;
                saveXml();
            }
        }
        public static string ptlArm
        {
            get
            {
                return rootNode.SelectSingleNode("PTLConfig/ptlArm").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("PTLConfig/ptlArm").InnerText = value;
                saveXml();
            }
        }
        #endregion
        #region>>>>>板卡设置
        public static string adamm_iCom
        {
            get
            {
                return rootNode.SelectSingleNode("AdamConfig/adamm_iCom").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("AdamConfig/adamm_iCom").InnerText = value;
                saveXml();
            }
        }
        public static string adamm_iAddr
        {
            get
            {
                return rootNode.SelectSingleNode("AdamConfig/adamm_iAddr").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("AdamConfig/adamm_iAddr").InnerText = value;
                saveXml();
            }
        }
        public static string adamm_iCount
        {
            get
            {
                return rootNode.SelectSingleNode("AdamConfig/adamm_iCount").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("AdamConfig/adamm_iCount").InnerText = value;
                saveXml();
            }
        }
        public static string AdamType
        {
            get
            {
                return rootNode.SelectSingleNode("AdamConfig/AdamType").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("AdamConfig/AdamType").InnerText = value;
                saveXml();
            }
        }
        public static string adamm_PlloingTime
        {
            get
            {
                return rootNode.SelectSingleNode("AdamConfig/adamm_PlloingTime").InnerText;
            }
            set
            {
                rootNode.SelectSingleNode("AdamConfig/adamm_PlloingTime").InnerText = value;
                saveXml();
            }
        }
        #endregion
    }
}
