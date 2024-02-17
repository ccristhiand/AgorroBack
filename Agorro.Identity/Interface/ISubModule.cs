using Agorro.Identity.Entity;
using Agorro.Identity.Entity.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Interface
{
    internal interface ISubModule
    {
        Task<IEnumerable<ESubModule>> Get();
        Task<int> Add(RSubModule subModule);
        Task<int> Delete(int id);
        Task<int> Update(RSubModule subModule);
        Task<IEnumerable<ESubModule>> Search(string descripcion);
        Task<IEnumerable<ESubModule>> GetActives();
        Task<int> UpdateActive(int id);
    }
}
