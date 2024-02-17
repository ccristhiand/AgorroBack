using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Entity.Request
{
    public class RUser
    {

		public int id_role {  get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string mother_last_name { get; set; }
        public DateTime birt_day { get; set; }
        public string email { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        //public string verification_code { get; set; }
        public string cellphone { get; set; }
        public int id_user { get; set; }
    }
}
