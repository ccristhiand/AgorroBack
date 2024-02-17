using Agorro.Identity.Entity.Request;
using Agorro.Identity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Interface
{
    public interface IUser
    {
        Task<IEnumerable<EUser>> Get();
        Task <string> Add(RUser rUser);
        Task<int> Delete(int id);
        Task<int> Update();
        Task<IEnumerable<EUser>> Search(string descripcion);
        Task<IEnumerable<EUser>> GetActives();
        Task<int> UpdateActive(int id);
        Task<EUser> Login(string user, string password);
    }
}
