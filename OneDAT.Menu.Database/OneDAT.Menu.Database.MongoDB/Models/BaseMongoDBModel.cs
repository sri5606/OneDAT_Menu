using OneDAT.Helper.IModels;
using OneDAT.Helper.Models;
using System;

namespace OneDAT.Menu.Database.MongoDB.Models
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseMongoDBModel : BaseModel, IBaseDBModel
    {
        public virtual string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
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
