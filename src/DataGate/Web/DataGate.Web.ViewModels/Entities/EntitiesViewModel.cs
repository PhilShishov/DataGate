// Model class for viewing
// different independent entities -
// funds, subfunds, shareclasses

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.ViewModels.Entities
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

        public string SearchTerm { get; set; }

        public bool IsActive { get; set; }
    }
}
