using OneDAT.Helper.IModels;

namespace OneDAT.Menu.Interfaces.IDBModels
{
    /// <summary>
    /// Interface for the Technology Table
    /// </summary>
    public interface ITechnologyTable : IBaseDBModel
    {
        string Code { get; set; }
        string ColorCode { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string Status { get; set; }
    }
}
