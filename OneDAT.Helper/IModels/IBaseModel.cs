namespace OneDAT.Helper.IModels
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBaseModel
    {
        string CreatedByUserId { get; set; }
        string CreatedOnDate { get; set; }
        string UpdatedByUserId { get; set; }
        string UpdatedOnDate { get; set; }
    }
}
