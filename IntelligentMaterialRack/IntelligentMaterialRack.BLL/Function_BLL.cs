using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using MyPLCDataview;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class Function_BLL
    {
        /// <summary>
        /// 获取PLC变量地址
        /// </summary>
        /// <param name="line"></param>
        /// <param name="station"></param>
        /// <param name="addressname"></param>
        /// <returns></returns>
        public static string getAddressByStation(string line, string station, string addressname)
        {
            string addressresult = null;
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + line + "']");
            XmlNode stationNodes = lineNode.SelectSingleNode("station[@name='" + station + "']");
            if (stationNodes != null)
            {
                XmlNodeList addressNodeList = stationNodes.SelectNodes("dataitem");
                if (addressNodeList.Count > 0)
                {
                    foreach (XmlNode address in addressNodeList)
                    {
                        XmlElement xe = (XmlElement)address;
                        if (xe.Attributes["name"].Value == addressname)
                        {
                            addressresult = xe.Attributes["addr"].Value;
                        }
                    }
                }
            }
            return addressresult;
        }
        /// <summary>
        /// 获取ADAM变量地址
        /// </summary>
        /// <param name="line"></param>
        /// <param name="station"></param>
        /// <param name="addressname"></param>
        /// <returns></returns>
        public static string getAdamAddressByStation(string line, string station, string addressname)
        {
            string addressresult = null;
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + line + "']");
            XmlNode stationNodes = lineNode.SelectSingleNode("station[@name='" + station + "']");
            if (stationNodes != null)
            {
                XmlNodeList addressNodeList = stationNodes.SelectNodes("adamDataItem");
                if (addressNodeList.Count > 0)
                {
                    foreach (XmlNode address in addressNodeList)
                    {
                        XmlElement xe = (XmlElement)address;
                        if (xe.Attributes["name"].Value == addressname)
                        {
                            addressresult = xe.Attributes["addr"].Value;
                        }
                    }
                }
            }
            return addressresult;
        }
        /// <summary>
        /// 获取PLC控制字地址
        /// </summary>
        /// <param name="line"></param>
        /// <param name="station"></param>
        /// <param name="addressname"></param>
        /// <returns></returns>
        public static string getControlAddressByStation(string line, string station, string addressname)
        {
            string addressresult = null;
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + line + "']");
            XmlNode stationNodes = lineNode.SelectSingleNode("station[@name='" + station + "']");
            if (stationNodes != null)
            {
                XmlNodeList addressNodeList = stationNodes.SelectNodes("opcitem");
                if (addressNodeList.Count > 0)
                {
                    foreach (XmlNode address in addressNodeList)
                    {
                        XmlElement xe = (XmlElement)address;
                        if (xe.Attributes["name"].Value == addressname)
                        {
                            addressresult = xe.Attributes["addr"].Value;
                        }
                    }
                }
            }
            return addressresult;
        }       
        /// <summary>
        /// 根据产线获取PLC的IP地址
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string getPlcIpAddress(string line, string item)
        {
            string addressresult = null;
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + line + "']");
            XmlElement xe = (XmlElement)lineNode;
            if (xe.Attributes["name"].Value == line)
            {
                addressresult = xe.Attributes[item].Value;
            }
            return addressresult;
        }
        /// <summary>
        /// 查询工位属性
        /// </summary>
        /// <param name="line"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string getStationAttribute(string line, string station, string item)
        {
            string addressresult = null;
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + line + "']");
            XmlNode stationNodes = lineNode.SelectSingleNode("station[@name='" + station + "']");
            XmlElement xe = (XmlElement)stationNodes;
            //if (xe.Attributes["name"].Value == item)
            //{
            addressresult = xe.Attributes[item].Value;
            //}
            return addressresult;
        }
        /// <summary>
        /// 根据报警类型获取报警的详细信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string getAlarmByType(string type, string line, string station)
        {
            string detail = null;
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + line + "']");
            XmlNode stationNodes = lineNode.SelectSingleNode("station[@name='" + station + "']");
            XmlNode empNodeList = stationNodes.SelectSingleNode("alarm");
            if (stationNodes != null)
            {
                XmlNodeList empList = empNodeList.SelectNodes("item");
                if (empList.Count > 0)
                {
                    foreach (XmlNode empSingle in empList)
                    {
                        XmlElement xe = (XmlElement)empSingle;
                        if (xe.Attributes["type"].Value == type)
                        {
                            detail = xe.Attributes["detail"].Value;
                        }
                    }
                }

            }
            return detail;
        }
        #region 获取MAC地址
        ///<summary>
        /// 通过SendARP获取网卡Mac
        /// 网络被禁用或未接入网络（如没插网线）时此方法失灵
        ///</summary>
        ///<param name="remoteIP"></param>
        ///<returns></returns>
        public static string GetMacBySendARP(string remoteIP)
        {
            StringBuilder macAddress = new StringBuilder();

            try
            {
                Int32 remote = inet_addr(remoteIP);

                Int64 macInfo = new Int64();
                Int32 length = 6;
                SendARP(remote, 0, ref macInfo, ref length);

                string temp = Convert.ToString(macInfo, 16).PadLeft(12, '0').ToUpper();

                int x = 12;
                for (int i = 0; i < 6; i++)
                {
                    if (i == 5)
                    {
                        macAddress.Append(temp.Substring(x - 2, 2));
                    }
                    else
                    {
                        macAddress.Append(temp.Substring(x - 2, 2) + "-");
                    }
                    x -= 2;
                }

                return macAddress.ToString();
            }
            catch
            {
                return macAddress.ToString();
            }
        }

        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]

        private static extern Int32 inet_addr(string ip);
        #endregion 
        #region 加密解密
        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
        #endregion
        public static List<monitorAddress> GetMtAddressList(string line, string attributeName)
        {
            XmlNode lineNode = ClsCommon.InfoRootNode.SelectSingleNode("line[@name='" + line + "']");
            XmlNodeList controlNodeList = lineNode.SelectNodes("station");
            List<monitorAddress> maList = new List<monitorAddress>();
            foreach (XmlNode item in controlNodeList)
            {
                XmlNodeList contol = item.SelectNodes(attributeName);
                foreach (XmlNode itemO in contol)
                {
                    XmlElement xe = (XmlElement)itemO;
                    Dictionary<string, string> para = new Dictionary<string, string>();
                    para.Add("type", xe.Attributes["type"].Value);
                    para.Add("address", xe.Attributes["addr"].Value);
                    para.Add("stationName", item.Attributes["name"].Value);
                    para.Add("lineName", item.ParentNode.Attributes["name"].Value);
                    monitorAddress ma = new monitorAddress(xe.Attributes["addr"].Value, para);
                    maList.Add(ma);
                }
            }
            return maList;
        }
    }
}
