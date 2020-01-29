using Amazon.DynamoDBv2.DataModel;
using OneDAT.Menu.Interfaces.IDBModels;

namespace OneDAT.Menu.Database.DynamoDB.Models
{
    /// <summary>
    /// Dynamo DB Cloumns
    /// </summary>
    [DynamoDBTable("Technology")]
    public class TechnologyDynamo : BaseDynamoDBModel, ITechnologyTable
    {
        public string Code { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
