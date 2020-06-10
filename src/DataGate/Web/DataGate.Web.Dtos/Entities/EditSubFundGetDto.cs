namespace DataGate.Web.Dtos.Entities
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class EditSubFundGetDto : IDataReaderParser
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

        public string InitialDate { get; set; }

        public string CSSFCode { get; set; }

        public string Status { get; set; }

        public string FACode { get; set; }

        public string TACode { get; set; }

        public string LEICode { get; set; }

        public void Parse(IDataReader reader)
        {
            this.InitialDate = reader["VALID FROM"] as string;
            this.Id = (int)reader["SUB FUND ID"];
            this.SubFundName = reader["SUB FUND NAME"] as string;
            this.Status = reader["STATUS"] as string;
            this.CSSFCode = reader["CSSF CODE"] as string;
            this.FACode = reader["ADMIN CODE"] as string;
            this.DBCode = reader["DEPOSITARY BANK CODE"] as string;
            this.TACode = reader["TRANSFER AGENT CODE"] as string;
            this.FirstNavDate = reader["FIRST NAV DATE"] as string;
            this.LastNavDate = reader["LAST NAV DATE"] as string;
            this.CSSFAuthDate = reader["CSSF AUTH. DATE"] as string;
            this.ExpiryDate = reader["EXPIRY DATE"] as string;
            this.LEICode = reader["LEI CODE"] as string;
            this.CesrClass = reader["CESR CLASS"] as string;
            this.GeographicalFocus = reader["GEO FOCUS"] as string;
            this.GlobalExposure = reader["GLOBAL EXPOSURE"] as string;
            this.CurrencyCode = reader["CURRENCY"] as string;
            this.NavFrequency = reader["FREQUENCY"] as string;
            this.ValuationDate = reader["VALUATION DATE"] as string;
            this.CalculationDate = reader["CALCULATION DATE"] as string;
            this.Derivatives = reader["DERIVATIVES"] as string;
            this.DerivMarket = reader["DERIV. MARKET"] as string;
            this.DerivPurpose = reader["DERIV. PURPOSE"] as string;
            this.PrincipalAssetClass = reader["PRINCIPAL ASSET CLASS"] as string;
            this.ClearingCode = reader["CLEARING CODE"] as string;
            this.SfCatMorningStar = reader["MORNINGSTAR CATEGORY"] as string;
            this.SfCatSix = reader["SIX CATEGORY"] as string;
            this.SfCatBloomberg = reader["BLOOMBERG CATEGORY"] as string;
        }
    }
}
