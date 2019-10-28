namespace Pharus.App.Models.ViewModels.Funds
{
    using System.Collections.Generic;

    public class ActiveFundsViewModel : BaseFundViewModel
    {
        public List<string[]> ActiveFunds { get; set; }
    }
}
