using OneDAT.Helper.Models;
using OneDAT.Menu.Interfaces.IViewModel;
using System.ComponentModel.DataAnnotations;

namespace OneDAT.Menu.Common.ViewModel
{
    /// <summary>
    /// View Model used for all CRUD Operations
    /// </summary>
    public class TechnologyViewModel : BaseViewModel, ITechnologyViewModel
    {
        [Required(ErrorMessage = "Technology code is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Technology ColorCode is required")]
        public string ColorCode { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Technology name is required")]
        public string Name { get; set; }
        public string Status { get; set; }
      
    }
}
