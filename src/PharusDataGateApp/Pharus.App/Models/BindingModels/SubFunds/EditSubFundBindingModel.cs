using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pharus.App.Models.BindingModels.SubFunds
{
    public class EditSubFundBindingModel : BaseBindingModel
    {
        public SelectList CalculationDate { get; set; }

        public SelectList CesrClass { get; set; }

        public SelectList CurrencyCode { get; set; }

        public SelectList Derivatives { get; set; }

        public SelectList DerivMarket { get; set; }

        public SelectList DerivPurpose { get; set; }

        public SelectList Frequency { get; set; }

        public SelectList GeographicalFocus { get; set; }

        public SelectList GlobalExposure { get; set; }

        public SelectList PrincipalAssetClass { get; set; }

        public SelectList PrincipalInvestmentStrategy { get; set; }

        public SelectList SfCatBloomberg { get; set; }

        public SelectList SfCatMorningStar { get; set; }

        public SelectList SfCatSix { get; set; }

        public SelectList SfStatus { get; set; }

        public SelectList TypeOfMarket { get; set; }

        public SelectList ValuationDate { get; set; }
    }
}
