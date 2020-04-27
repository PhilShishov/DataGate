// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
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

    using DataGate.Web.InputModels.Files;

    public class SpecificEntityViewModel : BaseEntityViewModel
    {
        // ________________________________________________________
        //
        // Property will be filled
        // with table data from DB
        // for a specific entity
        public IList<string[]> Entity { get; set; }

        // ________________________________________________________
        //
        // Property will be filled
        // with table data from DB
        // for a specific entity sub entities
        public IEnumerable<string[]> EntitySubEntities { get; set; }

        public string ContainerEntityName { get; set; }

        public string ContainerEntityId { get; set; }

        public IEnumerable<string[]> EntityTimeline { get; set; }

        public IEnumerable<string[]> TSAllPriceValues { get; set; }

        public IEnumerable<string> TSPriceDates { get; set; }

        public IEnumerable<string> TSTypeProviders { get; set; }

        public string SelectedFileName { get; set; }

        public IEnumerable<string[]> EntityDistinctDocuments { get; set; }

        public IEnumerable<string[]> EntityDistinctAgreements { get; set; }

        public IEnumerable<string[]> EntityAgreements { get; set; }

        public IEnumerable<string[]> EntityDocuments { get; set; }

        public int AgreementId { get; set; }

        public UploadEntityFileModel UploadEntityFileModel { get; set; }

        public UploadAgreementFileModel UploadAgreementFileModel { get; set; }

        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public string SelectAdditionalInf { get; set; }

        public string ControllerName { get; set; }
    }
}
