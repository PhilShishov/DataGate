// Abstract model class for view entity
// for code reuse

// Created: 11/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.ViewModels
{
    using System;

    using Pharus.App.Models.ViewModels.Contracts;

    public abstract class BaseEntityViewModel : IBaseEntityViewModel
    {
        public DateTime? ChosenDate { get; set; }

        public bool IsActive { get; set; }

        public string Command { get; set; }

        public int EntityId { get; set; }

        public string SearchTerm { get; set; }

        public string HSearchString { get; set; }
    }
}
