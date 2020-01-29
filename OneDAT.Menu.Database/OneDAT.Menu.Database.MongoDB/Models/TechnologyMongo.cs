using OneDAT.Menu.Interfaces.IDBModels;

namespace OneDAT.Menu.Database.MongoDB.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TechnologyMongo : BaseMongoDBModel, ITechnologyTable
    {
        public string Code { get; set; }
        public string ColorCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
