using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pharus.App.Models.BindingModels.ShareClasses
{
    public class ShareClassBindingModel : BaseBindingModel
    {
        public SelectList InvestorType { get; set; }

        public SelectList CurrencyCode { get; set; }

        public SelectList CountryIssue { get; set; }

        public SelectList CountryRisk { get; set; }

        public SelectList ShareStatus { get; set; }

        public SelectList ShareType { get; set; }
    }
}
