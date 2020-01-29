namespace OneDAT.Helper.IModels
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBaseDBModel : IBaseModel
    {
        string Id { get; set; }
        void InitAdd();
        void InitUpdate();
    }
}
