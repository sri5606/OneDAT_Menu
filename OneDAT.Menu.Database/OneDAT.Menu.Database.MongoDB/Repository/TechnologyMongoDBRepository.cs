using Microsoft.Extensions.Logging;
using OneDAT.Menu.Common.ViewModel;
using OneDAT.Menu.Database.MongoDB.Models;
using OneDAT.Menu.Interfaces.IRepository;
using OneDAT.Menu.Interfaces.IViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneDAT.Menu.Database.MongoDB.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class TechnologyMangoDBRepository : BaseRepository<TechnologyMangoDBRepository, TechnologyMongo, TechnologyViewModel, ITechnologyViewModel>, ITechnologyRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dbContext"></param>
        /// <param name="modelMapper"></param>
        public TechnologyMangoDBRepository(ILogger<TechnologyMangoDBRepository> logger, DBContext dbContext, ModelMapper modelMapper) : base(logger, dbContext, modelMapper)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> TestCode()
        {
            return "Test Mongo Code";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public async Task<ICollection<ITechnologyViewModel>> GetAllById(string id)
        //{
        //    var data= await 
        //}
        //public async Task<bool> Delete(string id)
        //{
        //    return true;
        //}
       
    }

}
