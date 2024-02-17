using Agorro.Identity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Interface
{
    public interface IMenu
    {
        Task<IEnumerable<EMenu>> Get(int idRole);
    }
}
