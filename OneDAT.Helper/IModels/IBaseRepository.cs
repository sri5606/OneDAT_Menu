using OneDAT.Helper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneDAT.Helper.IModels
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="I"></typeparam>
    public interface IBaseRepository<I> where I : IBaseDBModel
    {
        Task<I> Add(I model);
        Task<bool> Delete(string id);
        Task<I> Get(string id);
        Task<ICollection<I>> GetAll();
        Task<ICollection<I>> GetAllById(string id);
        Task<I> Update(I model);
        Task<ICollection<I>> Find(ICollection<FilterCondition> conditions);
    }
}
