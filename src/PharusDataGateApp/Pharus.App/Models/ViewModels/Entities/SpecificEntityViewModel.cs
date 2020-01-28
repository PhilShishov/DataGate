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
namespace Pharus.App.Models.ViewModels.Entities
{
    using System.Collections.Generic;

    using Pharus.App.Models.BindingModels.Files;

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

        public string BaseEntityName { get; set; }

        public string BaseEntityId { get; set; }

        public List<string[]> EntityTimeline { get; set; }

        public List<string[]> EntityDocuments { get; set; }

        public List<string[]> TSAllPriceValues { get; set; }

        public List<string> TSPriceDates { get; set; }

        public List<string> TSTypeProviders { get; set; }

        public string ProspectusNameToDisplay { get; set; }

        public List<string[]> DistinctDocumentsNamesToDisplay { get; set; }

        public List<string[]> DistinctAgreementsNamesToDisplay { get; set; }

        public List<string[]> AllAgreementsNamesToDisplay { get; set; }

        public int AgreementId { get; set; }

        public UploadEntityFileModel UploadEntityFileModel { get; set; }

        public UploadAgreementFileModel UploadAgreementFileModel { get; set; }

        public string StartConnection { get; set; }

        public string EndConnection { get; set; }

        public string SelectAdditionalInf { get; set; }

        public string ControllerName { get; set; }
    }
}