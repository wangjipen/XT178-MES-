using IntelligentMaterialRack.IntelligentMaterialRack.DAL;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.BLL
{
    class User_BLL
    {
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public static List<UsersObject> GetAllUser()
        {
            IEnumerable<UsersObject> userObjects = User_DAL.GetAllUsers();
            return userObjects.ToList();
        }
        /// <summary>
        /// 查询所有用户除超级管理员
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllUserX()
        {
            DataTable dt = User_DAL.GetAllUsersX();
            return dt;
        }
        /// <summary>
        /// 根据条件删除用户
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int DeleteUser(string sql)
        {
            int a=  User_DAL.DeleteUserByCondition(sql);
            return a;
        }
        /// <summary>
        /// 删除用户对象
        /// </summary>
        /// <param name="uo"></param>
        /// <returns></returns>
        public static int DeleteUserByObject(UsersObject uo)
        {
            int a = User_DAL.DeleteUserByObject(uo);
            return a;
        }

        /// <summary>
        /// 按指定条件删除用户
        /// </summary>
        /// <param name="sql"></param>
        public static void Delete_UserByCondition(string sql)
        {
            User_DAL.Delete_UserByCondition(sql);
        }
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="uo"></param>
        /// <returns></returns>
        public static int AddUser(UsersObject uo)
        {
            int a = User_DAL.AddUser(uo);
            return a;
        }
        /// <summary>
        /// 更新员工
        /// </summary>
        /// <param name="uo"></param>
        /// <returns></returns>
        public static int UpdateUser(UsersObject uo)
        {
            int a = User_DAL.UpdateUser(uo);
            return a;
        }
        /// <summary>
        /// 根据条件查询多个用户
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<UsersObject> GetUserByCondition(string sql)
        {
            List<UsersObject> uo = User_DAL.GetUserByCondition(sql);
            return uo;
        }
        /// <summary>
        /// 根据条件查询单个用户
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static UsersObject GetOneUserByCondition(string sql)
        {
            UsersObject uo = User_DAL.GetOneUserByCondition(sql);
            return uo;
        }
        /// <summary>
        /// 保存用户的权限
        /// </summary>
        public static void Save_Power(string sql_power, string sql_name)
        {
            User_DAL.Save_Power(sql_name, sql_power);
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="sql"></param>
        public static DataTable GetUserPower(string sql)
        {
            DataTable dt = User_DAL.GetUserPower(sql);
            return dt;
        }

        /// <summary>
        /// 设置用户身份为管理员
        /// </summary>
        /// <param name="sql"></param>
        public static void SetUserAdmin(string sql)
        {
            User_DAL.SetUserPower(sql);
        }
        /// <summary>
        /// 设置用户身份为普通用户
        /// </summary>
        /// <param name="sql"></param>
        public static void SetUserNormal(string sql)
        {
            User_DAL.SetUserNormal(sql);
        }

    }
}
