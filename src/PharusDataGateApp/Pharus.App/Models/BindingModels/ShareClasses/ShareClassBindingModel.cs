// Model class for binding shareclasses

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels.ShareClasses
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ShareClassBindingModel : BaseEntityBindingModel
    {
        public SelectList InvestorType { get; set; }

        public SelectList CurrencyCode { get; set; }

        public SelectList CountryIssue { get; set; }

        public SelectList CountryRisk { get; set; }

        public SelectList ShareStatus { get; set; }

        public SelectList ShareType { get; set; }
    }
}
