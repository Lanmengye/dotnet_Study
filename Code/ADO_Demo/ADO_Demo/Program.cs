using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Demo
{
    class Program
    {
        //TODO: sql参数化
        static void Main(string[] args)
        {
            DbHelper helper = new DbHelper();

            //test insert
            UserInfo user = new UserInfo
            {
                UserName = "tester2",
                Password = "123456",
                CreateTime = DateTime.Now
            };
            string insertSql = string.Format(@"INSERT INTO UserInfo(UserName,Password,CreateTime) 
                                        VALUES('{0}', '{1}','{2}')",user.UserName,user.Password,user.CreateTime);
            helper.ExecuteDML(insertSql);

            //test update
            user.Password = "666666";
            string updateSql = string.Format(@"Update UserInfo SET Password = '{0}' WHERE Id = '{1}'", user.Password,1);
            helper.ExecuteDML(updateSql);

            //test delete
            string deleteSql = string.Format(@"DELETE UserInfo WHERE UserName = '{0}'", user.UserName);
            helper.ExecuteDML(updateSql);

            //test select
            string selectSql = "SELECT * FROM UserInfo";
            List<UserInfo> users =helper.GetUserInfoByReader(selectSql);
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("======================================");
            List<UserInfo>  users2 = helper.GetUserInfoByAdapter(selectSql);
            foreach (var item in users2)
            {
                Console.WriteLine(item);
            }

        }
    }
}
