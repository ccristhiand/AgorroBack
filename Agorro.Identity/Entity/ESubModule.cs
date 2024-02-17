using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Entity
{
    public class ESubModule
    {
        public int sub_module_id { get; set; }
        public int module_id { get; set; }
        public string module_description { get; set; }
        public string sub_module_descrioption { get; set; }
        public string module_url { get; set; }
        public string module_icon { get; set; }
        public bool module_state { get; set; }
        public int module_user_create { get; set; }
        public DateTime module_date_create { get; set; }
        public int module_user_update { get; set; }
        public DateTime module_date_update { get; set; }
        public bool module_log_delete { get; set; }
    }
}
