
namespace Pharus.App.Models.ViewModels.Funds
{
    using System;

    public interface IBaseFundViewModel
    {
        DateTime? ChosenDate { get; set; }

        string Command { get; set; }

        int FundID { get; set; }

        string SearchString { get; set; }
    }
}
