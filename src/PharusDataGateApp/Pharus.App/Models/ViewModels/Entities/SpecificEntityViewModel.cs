namespace Pharus.App.Models.ViewModels.Funds
{
    using System.Collections.Generic;

    public class SpecificEntityViewModel : BaseViewModel
    {
        public List<string[]> ActiveEntity { get; set; }

        public List<string[]> AESubEntities { get; set; }
    }
}
