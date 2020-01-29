using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace OneDAT.Menu.Database.DynamoDB
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DBContext
    {
        private readonly AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        internal readonly DynamoDBContext Instance;

        /// <summary>
        /// 
        /// </summary>
        public DBContext()
        {
            Instance = new DynamoDBContext(client);
        }
    }
}
