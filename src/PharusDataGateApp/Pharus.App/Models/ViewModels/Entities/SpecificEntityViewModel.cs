// Model class for viewing
// a specific entity -
// fund, subfund, shareclass
// and their subentities -
// for fund - its subfunds,
// and for subfund -its shareclasses

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.ViewModels.Entities
{
    using System.Collections.Generic;

    public class SpecificEntityViewModel : BaseEntityViewModel
    {
        // ________________________________________________________
        //
        // Property will be filled
        // with table data from DB
        // for a specific entity
        public List<string[]> Entity { get; set; }

        // ________________________________________________________
        //
        // Property will be filled
        // with table data from DB
        // for a specific entity sub entities
        public List<string[]> EntitySubEntities { get; set; }
    }
}
