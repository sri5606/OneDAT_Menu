using OneDAT.Helper.IModels;

namespace OneDAT.Helper.Models
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseModel : IBaseModel
    {
        public virtual string CreatedByUserId { get; set; }
        public virtual string CreatedOnDate { get; set; }
        public virtual string UpdatedByUserId { get; set; }
        public virtual string UpdatedOnDate { get; set; }
    }
}
