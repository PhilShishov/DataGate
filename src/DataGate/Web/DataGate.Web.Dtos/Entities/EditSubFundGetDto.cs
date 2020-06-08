namespace DataGate.Web.Dtos.Entities
{
    using System;

    public class EditSubFundGetDto
    {
        public int Id { get; set; }

        public string SubFundName { get; set; }

        public string DBCode { get; set; }

        public string FirstNavDate { get; set; }

        public string LastNavDate { get; set; }

        public string CSSFAuthDate { get; set; }

        public string ExpiryDate { get; set; }

        public string CesrClass { get; set; }

        public string GeographicalFocus { get; set; }

        public string GlobalExposure { get; set; }

        public string CurrencyCode { get; set; }

        public string NavFrequency { get; set; }

        public string ValuationDate { get; set; }

        public string CalculationDate { get; set; }

        public string Derivatives { get; set; }

        public string DerivMarket { get; set; }

        public string DerivPurpose { get; set; }

        public string PrincipalAssetClass { get; set; }

        public string TypeOfMarket { get; set; }

        public string PrincipalInvestmentStrategy { get; set; }

        public string ClearingCode { get; set; }

        public string SfCatMorningStar { get; set; }

        public string SfCatSix { get; set; }

        public string SfCatBloomberg { get; set; }

        public DateTime InitialDate { get; set; }

        public string CSSFCode { get; set; }

        public string Status { get; set; }

        public string FACode { get; set; }

        public string TACode { get; set; }

        public string LEICode { get; set; }
    }
}
