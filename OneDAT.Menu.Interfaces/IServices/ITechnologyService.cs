using OneDAT.Helper.IModels;
using OneDAT.Menu.Interfaces.IViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneDAT.Menu.Interfaces.IServices
{
    /// <summary>
    /// Intreface for the  Technology Service
    /// </summary>
    public interface ITechnologyService : IBaseService<ITechnologyViewModel>
    {
        Task<string> TestCode();
    }
}
