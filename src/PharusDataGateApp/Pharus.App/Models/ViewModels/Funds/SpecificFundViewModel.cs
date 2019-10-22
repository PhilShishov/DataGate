namespace Pharus.App.Models.ViewModels.Funds
{
    using System;
    using System.Collections.Generic;

    public class SpecificFundViewModel
    {
        public List<string[]> ActiveFund { get; set; }

        public List<string[]> AFSubFunds { get; set; }

        public int FundId { get; set; }

        public DateTime? ChosenDate { get; set; }

        public string Command { get; set; }
    }
}
