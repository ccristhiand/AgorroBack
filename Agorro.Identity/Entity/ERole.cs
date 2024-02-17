using Agorro.Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Entity
{
    public class ERole
    {
        public int id { get; set; }
        public string description { get; set; }
        public bool state { get; set; }
        public int user_create { get; set; }
        public DateTime date_create { get; set; }
        public int user_update { get; set; }
        public DateTime date_update { get; set; }
        public bool log_delete { get; set; }

    }
}
