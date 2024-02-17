using Agorro.Identity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Interface
{
    public interface IRole
    {
        Task<IEnumerable<ERole>> Get();
        Task<IEnumerable<ERole>> GetActives();
        Task<int> Add(string description, int id_user);
        Task<int> Update(string description, int id_user, int id);
        Task<int> UpdateActive(int id);
        Task<int> Delete(int id);
        Task<IEnumerable<ERole>> Search(string description);
    }
}
