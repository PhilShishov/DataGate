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
    using AutoMapper;
    using DataGate.Web.InputModels.Files;

    public class SpecificEntityViewModel : BaseEntityViewModel
    {
        // ________________________________________________________
        //
        // Property will be filled
        // with table headers and values
        // data from DB for a specific entity
        public IEnumerable<string[]> Entity { get; set; }

        public string Container { get; set; }

        public string ContainerId { get; set; }

        public List<string[]> Timeline { get; set; }

        //public IEnumerable<string[]> TSAllPriceValues { get; set; }

        //public IEnumerable<string> TSPriceDates { get; set; }

        //public IEnumerable<string> TSTypeProviders { get; set; }

        public string SelectedFileName { get; set; }

        public IEnumerable<DistinctDocViewModel> DistinctDocuments { get; set; }

        public IEnumerable<DistinctDocViewModel> DistinctAgreements { get; set; }

        public List<string[]> Agreements { get; set; }

        public List<string[]> Documents { get; set; }

        public UploadEntityFileModel UploadEntityFileModel { get; set; }

        public UploadAgreementFileModel UploadAgreementFileModel { get; set; }

        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public string SelectAdditionalInf { get; set; }

        public string ControllerName { get; set; }
    }
}
