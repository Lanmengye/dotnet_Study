using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Demo
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateTime { get; set; }

        public override string ToString()
        {
            return this.Id+"\t"+this.UserName + "\t" + this.Password;
        }
    }
}
