namespace Pharus.App.Models.ViewModels
{
    using System;

    using Pharus.App.Models.ViewModels.Contracts;

    public abstract class BaseViewModel : IBaseViewModel
    {
        public DateTime? ChosenDate { get; set; }

        public string Command { get; set; }

        public int EntityId { get; set; }

        public string SearchString { get; set; }
    }
}
