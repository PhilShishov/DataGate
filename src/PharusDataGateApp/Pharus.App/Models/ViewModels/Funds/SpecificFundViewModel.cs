namespace Pharus.App.Models.ViewModels.Funds
{
    using System.Collections.Generic;

    public class SpecificFundViewModel : BaseFundViewModel
    {
        public List<string[]> ActiveFund { get; set; }

        public List<string[]> AFSubFunds { get; set; }
    }
}
