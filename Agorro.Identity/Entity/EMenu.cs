using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Entity
{
    public class EMenu
    {
        public string label { get; set; }
        public string icon { get; set; }
        public List<ESubMenu> items { get; set; }

    }

    public class ESubMenu
    {
        public string label { get; set; }
        public string icon { get; set; }
        public string routerLink { get; set; }
    }

    public class EMenuData
    {
        internal IEnumerable<object> items;

        public string module_description { get; set; }
        public string module_icon { get; set; }
        public string sub_module_description { get; set; }
        public string sub_module_icon { get;}
        public string sub_module_url { get;}
    }
}
