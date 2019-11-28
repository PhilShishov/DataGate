// Interface model for view entity

// Created: 11/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.ViewModels.Contracts
{
    using System;

    public interface IBaseEntityViewModel
    {
        string ChosenDate { get; set; }

        string Command { get; set; }

        int EntityId { get; set; }

        string SearchTerm { get; set; }
    }
}
