using Dapper;
using IntelligentMaterialRack.IntelligentMaterialRack.Moudle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IntelligentMaterialRack.IntelligentMaterialRack.DAL
{
    class User_DAL
    {
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public static List<UsersObject> GetAllUsers()
        {
            IEnumerable<UsersObject> users = null;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {

                users = conn.GetList<UsersObject>();
            }
            return users.ToList();
        }
        public static DataTable GetAllUsersX()
        {
            string sl = "select  * from Users where h_UserName!='超级管理员' ";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }
        public static DataTable GetUserPower(string sql)
        {
            string sl = "select  * from Users where h_UserName='"+sql+"' ";
            DataTable dt = new DataTable();
            dt = ClsCommon.dbSql.ExecuteDataTable(sl);
            return dt;
        }

        public static void Save_Power(string sql_power,string sql_name)
        {
            string sl = "update Users   set Power = '"+ sql_power + "' where h_UserName = '"+ sql_name + "'";
             ClsCommon.dbSql.ExecuteDataTable(sl);
        }

        /// <summary>
        /// 根据条件删除用户
        /// </summary>
        /// <param name="sqlCondition"></param>
        /// <returns></returns>
        public static int DeleteUserByCondition(string sqlCondition)
        {
            var a = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                a = conn.DeleteList<UsersObject>(sqlCondition);
            }
            return Convert.ToInt32(a);
        }

        public static  void Delete_UserByCondition(string sql)
        {
            string sl = "   delete from Users where h_UserName='" + sql + "'";
            ClsCommon.dbSql.ExecuteDataTable(sl);
        }
        /// <summary>
        /// 根据对象删除用户
        /// </summary>
        /// <param name="uo"></param>
        /// <returns></returns>
        public static int DeleteUserByObject(UsersObject uo)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Delete(uo);
            }
            return Convert.ToInt32(result);
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="aak"></param>
        /// <returns></returns>
        public static int AddUser(UsersObject uo)
        {
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                var result = conn.Insert(uo);
                return Convert.ToInt32(result);
            }
        }
        /// <summary>
        /// 更新单个用户
        /// </summary>
        /// <param name="uo"></param>
        /// <returns></returns>
        public static int UpdateUser(UsersObject uo)
        {
            var result = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                result = conn.Update(uo);
            }
            return Convert.ToInt32(result);
        }

        public static void SetUserNormal(string sql)
        {
            string sl = "update Users   set h_Permissions = 'X' where h_UserName = '" + sql + "'";
            ClsCommon.dbSql.ExecuteDataTable(sl);
        }

        /// <summary>
        /// 根据条件查询多个对象
        /// </summary>
        /// <param name="sqlCondition"></param>
        /// <returns></returns>
        public static List<UsersObject> GetUserByCondition(string sqlCondition)
        {
            IEnumerable<UsersObject> user = null;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {

                user = conn.GetList<UsersObject>(sqlCondition);
            }
            return user.ToList();
        }
        /// <summary>
        /// 根据条件查询单个对象必须要ID
        /// </summary>
        /// <param name="sqlCondition"></param>
        /// <returns></returns>
        public static UsersObject GetOneUserByCondition(string sqlCondition)
        {
            UsersObject uo;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                uo = conn.Get<UsersObject>(sqlCondition);
            }
            return uo;
        }
        /// <summary>
        /// 根据条件更新多个用户
        /// </summary>
        /// <param name="sqlCondition"></param>
        /// <returns></returns>
        public static int UpdateUsersByCondition(string sqlCondition)
        {
            var a = 0;
            using (IDbConnection conn = ClsCommon.OpenConnection())  //这里访问的是Sqlite数据文件，这里OpenConnection即上边获取连接数据库对象方法
            {
                a = conn.Update(sqlCondition);
            }
            return Convert.ToInt32(a);
        }
        public static void SetUserPower(string sql)
        {
            string sl = "update Users   set h_Permissions = '1' where h_UserName = '"+sql+"'";
            ClsCommon.dbSql.ExecuteDataTable(sl);
        }
}
}
