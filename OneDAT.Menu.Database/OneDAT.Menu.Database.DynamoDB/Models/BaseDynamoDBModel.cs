using Amazon.DynamoDBv2.DataModel;
using OneDAT.Helper.IModels;
using OneDAT.Helper.Models;
using System;

namespace OneDAT.Menu.Database.DynamoDB.Models
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseDynamoDBModel : BaseModel, IBaseDBModel
    {
        [DynamoDBHashKey]
        public virtual string Id { get; set; }
        public void InitAdd()
        {
            throw new NotImplementedException();
        }

        public void InitUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
