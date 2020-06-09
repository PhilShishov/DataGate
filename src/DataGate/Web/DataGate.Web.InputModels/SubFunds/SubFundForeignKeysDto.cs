namespace DataGate.Web.InputModels.SubFunds
{
    using DataGate.Services.Mapping;

    public class SubFundForeignKeysDto : IMapFrom<EditSubFundInputModel>, IMapFrom<CreateSubFundInputModel>
    {
        public string Status { get; set; }

        public string CesrClass { get; set; }

        public string GeographicalFocus { get; set; }

        public string GlobalExposure { get; set; }

        public string NavFrequency { get; set; }

        public string ValuationDate { get; set; }

        public string CalculationDate { get; set; }

        public string DerivMarket { get; set; }

        public string DerivPurpose { get; set; }

        public string PrincipalAssetClass { get; set; }

        public string TypeOfMarket { get; set; }

        public string PrincipalInvestmentStrategy { get; set; }

        public string SfCatMorningStar { get; set; }

        public string SfCatSix { get; set; }

        public string SfCatBloomberg { get; set; }
    }
}
