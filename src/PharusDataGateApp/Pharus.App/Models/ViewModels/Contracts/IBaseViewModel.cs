namespace Pharus.App.Models.ViewModels.Contracts
{
    using System;

    public interface IBaseViewModel
    {
        DateTime? ChosenDate { get; set; }

        string Command { get; set; }

        int EntityId { get; set; }

        string SearchString { get; set; }

        string HSearchString { get; set; }
    }
}
