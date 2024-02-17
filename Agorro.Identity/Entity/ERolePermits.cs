using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Entity
{
    public class ERolePermits
    {
        public int role_permits_id { get; set; }
		public int role_permits_id_role { get; set; }
		public string role_permits_description { get; set; }
		public int role_permits_id_sub_module { get; set; }
		public string sub_module_description { get; set; }
		public string module_description { get; set; }
		public bool role_permits_state { get; set; }
		public int role_permits_user_create { get; set; }
		public DateTime role_permits_date_create { get; set; }
        public int role_permits_user_update { get; set; }
        public DateTime role_permits_date_update { get; set; }
		public bool role_permits_log_delete { get; set; }

    }
}