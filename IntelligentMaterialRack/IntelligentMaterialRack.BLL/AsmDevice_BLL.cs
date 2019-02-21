using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System.Data;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class AsmDevice_BLL
    {
        public static bool IsExistCode(String sql)
        {
            bool a = AsmDevice_DAL.IsExistCode(sql);
            return a;
        }

        public static int AddDeviceObject(AsmDeviceObject uo)
        {
            int a = AsmDevice_DAL.AddDeviceObject(uo);
            return a;
        }
        public static AsmDeviceObject GetDeviceObjectByCondition(string sql)
        {
            AsmDeviceObject ado  = AsmDevice_DAL.GetDeviceObjectByCondition(sql);
            return ado;
        }
        public static int UpdateDeviceObject(AsmDeviceObject uo)
        {
            int a = AsmDevice_DAL.UpdateDeviceObject(uo);
            return a;
        }
        public static DataTable GetDevices()
        {
            DataTable dt = AsmDevice_DAL.GetDevices();
            return dt;
        }
        public static int DeleteDeviceByCondition(String sql)
        {
            int a = AsmDevice_DAL.DeleteDeviceByCondition(sql);
            return a;
        }
        public static DataTable GetDevicesByCondition(string sql)
        {
            DataTable dt = AsmDevice_DAL.GetDevicesByCondition(sql);
            return dt;
        }
    }
}
