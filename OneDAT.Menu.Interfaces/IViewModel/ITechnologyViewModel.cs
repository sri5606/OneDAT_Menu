using OneDAT.Helper.IModels;

namespace OneDAT.Menu.Interfaces.IViewModel
{
    /// <summary>
    /// Interface for the Technology View  Model
    /// </summary>
    public interface ITechnologyViewModel : IBaseDBModel
    {
        string Code { get; set; }
        string ColorCode { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string Status { get; set; }
    }
}
