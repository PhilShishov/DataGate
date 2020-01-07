// Model class for viewing
// different entities -
// funds, subfunds, shareclasses

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.ViewModels.Entities
{
    using System.Collections.Generic;

    public class EntitiesViewModel : BaseEntityViewModel
    {
        // ________________________________________________________
        //
        // Property will be filled
        // with table data from DB
        // for all entities of type
        public List<string[]> Entities { get; set; }

        public List<string[]> EntitiesHeadersForColumnSelection { get; set; }
    }
}