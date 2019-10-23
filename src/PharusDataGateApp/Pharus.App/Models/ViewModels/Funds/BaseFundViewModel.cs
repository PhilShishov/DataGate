namespace Pharus.App.Models.ViewModels.Funds
{
    using System;

    public abstract class BaseFundViewModel : IBaseFundViewModel
    {
        public DateTime? ChosenDate { get; set; }

        public string Command { get; set; }

        public int FundID { get; set; }

        public string SearchString { get; set; }
    }
}
