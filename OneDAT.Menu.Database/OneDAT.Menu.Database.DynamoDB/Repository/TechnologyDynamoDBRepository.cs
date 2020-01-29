using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Logging;
using OneDAT.Menu.Common.ViewModel;
using OneDAT.Menu.Database.DynamoDB.Models;
using OneDAT.Menu.Interfaces.IRepository;
using OneDAT.Menu.Interfaces.IViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneDAT.Menu.Database.DynamoDB.Repository
{
    /// <summary>
    /// Technology DynamoDB Repository
    /// </summary>
    public class TechnologyDynamoDBRepository : BaseRepository<TechnologyDynamoDBRepository, TechnologyDynamo, TechnologyViewModel, ITechnologyViewModel>, ITechnologyRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dbContext"></param>
        /// <param name="modelMapper"></param>
        public TechnologyDynamoDBRepository(ILogger<TechnologyDynamoDBRepository> logger, DBContext dbContext, ModelMapper modelMapper) : base(logger, dbContext, modelMapper)
        {

        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> TestCode()
        {
            return "Test Dynamo Code";
        }
    }
}
