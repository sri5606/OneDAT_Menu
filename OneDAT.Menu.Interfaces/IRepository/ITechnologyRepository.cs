using OneDAT.Helper.IModels;
using OneDAT.Menu.Interfaces.IViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneDAT.Menu.Interfaces.IRepository
{
    /// <summary>
    /// Interface for the Technology Repository
    /// </summary>
    public interface ITechnologyRepository : IBaseRepository<ITechnologyViewModel> 
    {
        Task<string> TestCode();
    }
}
