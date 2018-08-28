using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Demo
{
    /// <summary>
    /// 数据库访问类
    /// 使用ADO.net五大对象访问数据库
    /// </summary>
    public class DbHelper
    {
        private static readonly string connectionString = "server = .;initial catalog = Test; uid = sa; pwd = 123456";

        //数据库连接对象
        private readonly SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// 执行DML语句（增删改）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteDML(string sql)
        {
            connection.Open();

            //数据库语句执行对象
            SqlCommand command = new SqlCommand(sql,connection);

            //受影响行数
            int rows = command.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine("执行完毕，受影响{0}行", rows);

            return rows;
        }

        /// <summary>
        /// 使用SqlDataReader执行DQL语句（查）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<UserInfo> GetUserInfoByReader(string sql)
        {
            List<UserInfo> users = new List<UserInfo>();
            connection.Open();
            SqlCommand cmd = new SqlCommand(sql,connection);

            //数据库指针对象
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //TODO: 可通过反射建立Map关系，简化对象赋值操作
                UserInfo user = new UserInfo
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    CreateTime = Convert.ToDateTime(reader["CreateTime"])
                };
                users.Add(user);
            }
            connection.Close();
            return users;
        }

        /// <summary>
        /// 使用SqlDataAdapter执行DQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<UserInfo> GetUserInfoByAdapter(string sql)
        {
            //数据集
            DataSet dataSet = new DataSet();

            //数据适配器（自动打开数据库连接）
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            //填充数据
            adapter.Fill(dataSet);

            connection.Close();
            List<UserInfo> users = new List<UserInfo>();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    UserInfo user =new UserInfo {
                        Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]),
                        UserName = dataSet.Tables[0].Rows[i]["UserName"].ToString(),
                        Password =dataSet.Tables[0].Rows[i]["Password"].ToString(),
                        CreateTime = Convert.ToDateTime(dataSet.Tables[0].Rows[i]["CreateTime"])
                    };
                    users.Add(user);
                }
            }
            return users;
        }
    }
}
