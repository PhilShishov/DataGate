﻿// Model class for viewing
// different independent entities -
// funds, subfunds, shareclasses

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.ViewModels.Entities
{
    using System.Collections.Generic;

    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Overviews;

    public class EntitiesViewModel : BaseEntityViewModel, IMapFrom<EntitiesOverviewGetDto>
    {
        // ________________________________________________________
        //
        // Property will be filled
        // with table data from DB
        // for all entities of type
        public List<string[]> Values { get; set; }

        public List<string> Headers { get; set; }

        public List<string> HeadersSelection { get; set; }

        public bool IsActive { get; set; }

        public IReadOnlyCollection<string> PreSelectedColumns { get; set; }

        public IEnumerable<string> SelectedColumns { get; set; }

        public string SelectTerm { get; set; }
    }
}
