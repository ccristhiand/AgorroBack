using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Entity.Request
{
    public class Rmodule
    {
        public int? id { get; set; }
        public string? description { get; set; }
        public int? id_user { get; set; }
        public string? url { get; set; }
        public string? icon { get; set; }
    }
}
