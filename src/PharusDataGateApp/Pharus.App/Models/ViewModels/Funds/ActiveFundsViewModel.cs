
namespace Pharus.App.Models.ViewModels.Funds
{
    using System;
    using System.Collections.Generic;

    public class ActiveFundsViewModel
    {
        public List<string[]> ActiveFunds { get; set; }

        public int FundID { get; set; }

        public DateTime? ChosenDate { get; set; }

        public string Command { get; set; }

        public string SearchString { get; set; }
    }
}
