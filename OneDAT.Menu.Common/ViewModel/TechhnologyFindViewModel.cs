using OneDAT.Helper.Models;
using OneDAT.Menu.Interfaces.IViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneDAT.Menu.Common.ViewModel
{
    /// <summary>
    /// View Model Used for the Find operation
    /// </summary>
    public class TechhnologyFindViewModel : BaseViewModel, ITechnologyViewModel
    {
        public string Code { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
       
    }
}
