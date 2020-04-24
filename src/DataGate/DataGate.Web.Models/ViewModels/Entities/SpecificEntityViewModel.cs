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
namespace DataGate.Web.Models.ViewModels.Entities
{
    using System;
    using System.Collections.Generic;

    using DataGate.Web.Models.BindingModels.Files;

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

        public string ContainerEntityName { get; set; }

        public string ContainerEntityId { get; set; }

        public List<string[]> EntityTimeline { get; set; }

        public List<string[]> TSAllPriceValues { get; set; }

        public List<string> TSPriceDates { get; set; }

        public List<string> TSTypeProviders { get; set; }

        public string SelectedFileName { get; set; }

        public List<string[]> EntityDistinctDocuments { get; set; }

        public List<string[]> EntityDistinctAgreements { get; set; }

        public List<string[]> EntityAgreements { get; set; }

        public List<string[]> EntityDocuments { get; set; }

        public int AgreementId { get; set; }

        public UploadEntityFileModel UploadEntityFileModel { get; set; }

        public UploadAgreementFileModel UploadAgreementFileModel { get; set; }

        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public string SelectAdditionalInf { get; set; }

        public string ControllerName { get; set; }
    }
}