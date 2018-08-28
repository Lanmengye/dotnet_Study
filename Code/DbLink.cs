using System.Data;
using System.Data.SqlClient;

namespace Management
{
    class DbLink
    {
        //私有的，数据库连接字符串
        private string context = "server=.;initial catalog=WeiLan;uid=sa;pwd=123456";

        //执行DML
        public int execDML(string sql)
        {
            using (SqlConnection con = new SqlConnection(this.context))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd.ExecuteNonQuery();
            }
        }


        //执行DQL
        public DataSet execDQL(string sql)
        {
            using (SqlConnection con = new SqlConnection(this.context))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql,con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
        }
    }
}
