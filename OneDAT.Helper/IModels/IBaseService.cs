using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneDAT.Helper.IModels
{
    public interface IBaseService<V>
    {
        Task<V> Add(V model);
        Task<bool> Delete(string id);
        Task<V> Get(string id);
        Task<ICollection<V>> GetAll();
        Task<ICollection<V>> GetAllById(string id);
        Task<V> Update(V model);
        Task<ICollection<V>> Find(V model);
    }
}
