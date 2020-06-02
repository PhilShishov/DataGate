﻿// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Model class for viewing
// a specific entity -
// fund, subfund, shareclass
// and their subentities -
// for fund - its subfunds,
// and for subfund - its shareclasses

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.ViewModels.Entities
{
    using System;
    using System.Collections.Generic;

    using DataGate.Services.Mapping;
    using DataGate.Web.ViewModels.Documents;
    using DataGate.Web.ViewModels.Queries;

    public class SpecificEntityViewModel : BaseEntityViewModel, IMapFrom<SpecificEntityOverviewGetDto>
    {
        // ________________________________________________________
        //
        // Property will be filled
        // with table headers and values
        // data from DB for a specific entity
        public IEnumerable<string[]> Entity { get; set; }

        public string Container { get; set; }

        public string ContainerId { get; set; }

        // public IEnumerable<string[]> TSAllPriceValues { get; set; }
        // public IEnumerable<string> TSPriceDates { get; set; }
        // public IEnumerable<string> TSTypeProviders { get; set; }
        public IEnumerable<DistinctDocViewModel> DistinctDocuments { get; set; }

        public IEnumerable<DistinctAgrViewModel> DistinctAgreements { get; set; }

        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public string SelectAdditionalInf { get; set; }
    }
}
