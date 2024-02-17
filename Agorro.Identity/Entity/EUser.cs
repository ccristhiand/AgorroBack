using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Entity
{
    public class EUser
    {
		public int usuario_id { get; set; }
        public int role_id { get; set; }
        public string role_description { get; set; }
        public string usuario_name { get; set; }
        public string usuario_last_name { get; set; }
        public string usuario_mother_last_name { get; set; }
        public DateTime usuario_birt_day { get; set; }
        public string usuario_email { get; set; }
        public int usuario_year { get; set; }
        public string usuario_usuario { get; set; }
        public bool usuario_state { get; set; }
        public int usuario_create { get; set; }
        public DateTime usuario_date_create { get; set; }
        public int usuario_update { get; set; }
        public DateTime usuario_date_update { get; set; }
        public bool usuario_log_delete { get; set; }
        public string result { get; set; }
    }
}
