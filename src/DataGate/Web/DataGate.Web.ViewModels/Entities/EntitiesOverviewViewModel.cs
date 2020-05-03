// Model class for viewing
// different independent entities -
// funds, subfunds, shareclasses

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.ViewModels.Entities
{
    public class EntitiesOverviewViewModel : BaseEntityViewModel
    {
        // ________________________________________________________
        //
        // Property will be filled
        // with table data from DB
        // for all entities of type
        public string SearchTerm { get; set; }

        public bool IsActive { get; set; }
    }
}
