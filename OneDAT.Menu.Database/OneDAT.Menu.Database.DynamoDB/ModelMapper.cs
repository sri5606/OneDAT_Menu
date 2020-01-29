using AutoMapper;
using OneDAT.Helper.Enumerations;
using OneDAT.Menu.Common.ViewModel;
using OneDAT.Menu.Database.DynamoDB.Models;
using OneDAT.Menu.Interfaces.IViewModel;
using System.Collections.Generic;

namespace OneDAT.Menu.Database.DynamoDB
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelMapper
    {
        internal readonly Mapper Mapper;
        public ModelMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ITechnologyViewModel, TechnologyDynamo>();
                //add Second mapper like below
                cfg.CreateMap<TechnologyDynamo, TechnologyViewModel>();
                // cfg.CreateMap<ITechnology, TechnologyDynamo>();
            });
            Mapper = new Mapper(config);
        }

    }
}
