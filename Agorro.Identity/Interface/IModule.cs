using Agorro.Identity.Entity;
using Agorro.Identity.Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Interface
{
    public interface IModule
    {
        Task<IEnumerable<EModule>> Get();
        Task<int> Add(Rmodule rmodule);
        Task<int> Update(Rmodule rmodule);
        Task<int> Delete(int id);
        Task<IEnumerable<EModule>> Search(string description);
    }
}
