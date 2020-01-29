using AutoMapper;
using OneDAT.Menu.Database.MongoDB.Models;
using OneDAT.Menu.Interfaces.IViewModel;

namespace OneDAT.Menu.Database.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelMapper
    {
        public readonly Mapper Mapper;
        /// <summary>
        /// 
        /// </summary>
        public ModelMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ITechnologyViewModel, TechnologyMongo>();
                // add Second mapper like below
                //cfg.CreateMap<ITechnology, TechnologyDynamo>();
            });
            Mapper = new Mapper(config);
        }
        
    }
}
