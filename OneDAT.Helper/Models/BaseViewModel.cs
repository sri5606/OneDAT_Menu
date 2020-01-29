using OneDAT.Helper.IModels;
using System;

namespace OneDAT.Helper.Models
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseViewModel : BaseModel, IBaseDBModel
    {
        public virtual string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public void InitAdd()
        {
            string now = DateTime.Now.ToString();
            Id = Guid.NewGuid().ToString();
            CreatedOnDate = now;
            UpdatedOnDate = now;
        }

        public void InitUpdate()
        {
            string now = DateTime.Now.ToString();
            UpdatedOnDate = now;
        }
    }
}
