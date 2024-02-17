using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Entity.Request
{
    public class RLogin
    {
        public EUser User { get; set; }
        public string token { get; set; }
    }
}
