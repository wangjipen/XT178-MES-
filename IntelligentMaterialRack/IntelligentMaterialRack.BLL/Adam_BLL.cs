using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using MyAdam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
   public class Adam_BLL
    {
        public static MyAdamBusiness myAdam;
        public delegate void recodeAdamLog(string a, int b);
        public event recodeAdamLog recodeAdamMessage;
        public delegate void AdamAlarm(int type);
        public event AdamAlarm AdamalarmType;
        public delegate void AdamChangeDI(int channel, bool value);//申明DI状态改变的代理
        public event AdamChangeDI AdamDIRevice;
        bool AlarmMark;
        private static object locker = new object();
        public string LineName { set; get; }
        public string StationName { set; get; }
        public static string LineNameS;
        public static string StationNameS;
        public void Run()
        {
            try
            {
                LineNameS = LineName;
                StationNameS = LineName;
                myAdam = new MyAdamBusiness();
                myAdam.m_iCom = Convert.ToInt32(ClsCommon.adamm_iCom);
                myAdam.m_iAddr = Convert.ToInt32(ClsCommon.adamm_iAddr);
                myAdam.m_iCount = Convert.ToInt32(ClsCommon.adamm_iCount);
                myAdam.AdamType = ClsCommon.AdamType;
                myAdam.m_PlloingTime = Convert.ToInt32(ClsCommon.adamm_PlloingTime);
                myAdam.recodeMessage += new MyAdamBusiness.recodeLog(RecordInfoMessage);
                myAdam.alarmType += new MyAdamBusiness.Alarm(ReturnAdamType);
                myAdam.DIRevice += new MyAdamBusiness.ChangeDI(AdamBusiness);
                Thread workThread = new Thread(new ThreadStart(myAdam.Run));
                workThread.Start();
                AlarmMark = true;
                #region>>>>初始化灯
                Thread.Sleep(100);
                Write(Convert.ToInt32(Function_BLL.getAdamAddressByStation(LineName, StationName, "AlarmGreen")), true);//绿灯亮起
                #endregion
            }
            catch (Exception ex)
            {
                recodeAdamMessage("初始化板卡失败，请检查连接" + ex.Message, 1);
            }

        }
        #region 日志输出
        public void RecordInfoMessage(string a, int b)
        {
            recodeAdamMessage(a, b);
        }
        #endregion
        #region >>>>>报警代码输出
        public void ReturnAdamType(int type)
        {
            if(AlarmMark)
            AdamalarmType(type);
        }
        #endregion
        #region>>>>>板卡输入业务处理
        public void AdamBusiness(int channel, bool value)
        {
            try
            {
                #region>>>>>报警复位
                if (!String.IsNullOrEmpty(Function_BLL.getAdamAddressByStation(LineName, StationName, "AlarmReset")) && Convert.ToInt32(Function_BLL.getAdamAddressByStation("1", "0", "AlarmReset")) == channel && value == false)
                {
                    if (!String.IsNullOrEmpty(Function_BLL.getAdamAddressByStation(LineName, StationName, "AlarmRed")))
                    {
                        Write(Convert.ToInt32(Function_BLL.getAdamAddressByStation(LineName, StationName, "AlarmRed")), false);//红灯熄灭
                        Write(Convert.ToInt32(Function_BLL.getAdamAddressByStation(LineName, StationName, "AlarmVoice")), false);//声音熄灭
                        Write(Convert.ToInt32(Function_BLL.getAdamAddressByStation(LineName, StationName, "AlarmGreen")), true);//绿灯亮起
                        ReturnAdamType(0);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                ReturnAdamType(30);//监控ADAM控制字错误
                recodeAdamMessage("监控ADAM控制字错误" + ex.Message, 1);
            }
        }
        #endregion
        #region>>>>>关闭端口
        public  void CloseAdam()
        {
            #region>>>>初始化灯
            Write(Convert.ToInt32(Function_BLL.getAdamAddressByStation(LineName, StationName, "AlarmRed")), false);//红灯熄灭
            Write(Convert.ToInt32(Function_BLL.getAdamAddressByStation(LineName, StationName, "AlarmVoice")), false);//声音熄灭
            Write(Convert.ToInt32(Function_BLL.getAdamAddressByStation(LineName, StationName, "AlarmGreen")), false);//绿灯亮起
            #endregion
            myAdam.CloseAdam();
        }
        #endregion
        #region>>>>>写入板卡值和报警类型
        public static void Write(int channel, bool value)
        {
            try
            {
                lock (locker)
                {
                    myAdam.WriteDo(channel, value);
                }
            }
            catch (Exception ex)
            {
                new Adam_BLL().ReturnAdamType(31);//ADAM写值错误
                Alarm();
                new Adam_BLL().recodeAdamMessage("ADAM写入值错误：" + ex.Message, 1);
            }
        }
        public static void WriteAlarmType(int type)
        {
            new Adam_BLL().AdamalarmType(type);
        }
        public static void Alarm()
        {
            try
            {
                Write(Convert.ToInt32(Function_BLL.getAdamAddressByStation(LineNameS, StationNameS, "AlarmRed")), true);//报警灯亮
                Write(Convert.ToInt32(Function_BLL.getAdamAddressByStation(LineNameS, StationNameS, "AlarmVoice")), true);//声音
                Write(Convert.ToInt32(Function_BLL.getAdamAddressByStation(LineNameS, StationNameS, "AlarmGreen")), false);//绿灯熄灭
            }
            catch (Exception ex)
            {
                new Adam_BLL().ReturnAdamType(32);//ADAM写值错误
                new Adam_BLL().recodeAdamMessage("调用报警方法出差：" + ex.Message, 1);
            }
        }
        #endregion
    }
}
