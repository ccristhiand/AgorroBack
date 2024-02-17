using Agorro.Identity.Entity.Request;
using Agorro.Identity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Interface
{
    internal interface IRolePermits
    {
        Task<IEnumerable<ERolePermits>> Get();
        Task<int> Add(RRolePermits permits);
        Task<int> Delete(int id);
        Task<int> Update(RRolePermits permits);
        Task<IEnumerable<ERolePermits>> Search(string descripcion);
        Task<IEnumerable<ERolePermits>> GetActives();
        Task<int> UpdateActive(int id);
    }
}
