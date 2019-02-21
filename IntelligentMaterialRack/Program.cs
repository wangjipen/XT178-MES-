using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using IntelligentMaterialRack.IntelligentMaterialRack.UI;
using MyLog;
using MyLog.Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace IntelligentMaterialRack
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            bool StartWithLogin;

            using (var mutex = new Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
#if !DEBUG
                    Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
#endif
                    Log.LogKeepPeriod = ClsCommon.logKeepPeriod;
                    LogEnviromentOperation.Instance.InitializeSetting();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    StartWithLogin = ClsCommon.startWithLogin;

                        if (!StartWithLogin)
                        {
                            Application.Run(new MainForm());
                        }
                        else
                        {
                            Form1 fl = new Form1();
                            if (fl.ShowDialog() == DialogResult.OK)
                            {
                                Application.Run(new  MainForm());
                            }
                        }
                }
                else
                {
                    MessageBox.Show("应用程序已经在运行中!");
                    System.Threading.Thread.Sleep(1000);
                    System.Environment.Exit(1);
                }
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.InformationLog.Error(e.Exception.Message);
            MessageBox.Show(e.Exception.Message);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.InformationLog.Error(e.ExceptionObject.ToString());
            MessageBox.Show(e.ExceptionObject.ToString());
        }
    }
}
