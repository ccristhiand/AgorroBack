using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Entity.Request
{
    public class RRolePermits
    {
        public int id { get; set; }
        public int id_sub_module { get; set; }
        public int id_role { get; set; }
        public int id_user { get; set; }
    }
}
