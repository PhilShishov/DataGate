// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Dtos.Entities
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class EditShareClassGetDto : IDataReaderParser
    {
        public string InitialDate { get; set; }

        public string CSSFCode { get; set; }

        public string Status { get; set; }

        public string FACode { get; set; }

        public string TACode { get; set; }

        public string LEICode { get; set; }

        public int Id { get; set; }

        public string ShareClassName { get; set; }

        public string InvestorType { get; set; }

        public string ShareType { get; set; }

        public string CurrencyCode { get; set; }

        public string CountryIssue { get; set; }

        public string CountryRisk { get; set; }

        public string EmissionDate { get; set; }

        public string InceptionDate { get; set; }

        public string LastNavDate { get; set; }

        public string ExpiryDate { get; set; }

        public string InitialPrice { get; set; }

        public string AccountingCode { get; set; }

        public string Hedged { get; set; }

        public string Listed { get; set; }

        public string BloombergMarket { get; set; }

        public string BloombergCode { get; set; }

        public string BloombergId { get; set; }

        public string ISINCode { get; set; }

        public string ValorCode { get; set; }

        public string WKN { get; set; }

        public string DateBusinessYear { get; set; }

        public string ProspectusCode { get; set; }

        public void Parse(IDataReader reader)
        {
            this.Id = (int)reader["SHARE CLASS ID"];
            this.ISINCode = reader["ISIN CODE"] as string;
            this.InitialDate = reader["VALID FROM"] as string;
            this.ShareClassName = reader["SHARE CLASS NAME"] as string;
            this.Status = reader["STATUS"] as string;
            this.InvestorType = reader["INVESTOR TYPE"] as string;
            this.ShareType = reader["SHARE TYPE"] as string;
            this.CurrencyCode = reader["CCY"] as string;
            this.CountryIssue = reader["COUNTRY ISSUE"] as string;
            this.CountryRisk = reader["ULT PARENT COUNTRY OF RISK"] as string;
            this.EmissionDate = reader["EMISSION DATE"] as string;
            this.InceptionDate = reader["INCEPTION DATE"] as string;
            this.LastNavDate = reader["LAST NAV"] as string;
            this.ExpiryDate = reader["EXPIRY DATE"] as string;
            this.InitialPrice = reader["INITIAL PRICE"] as string;
            this.AccountingCode = reader["ACCOUNTING CODE"] as string;
            this.Hedged = reader["HEDGED"] as string;
            this.Listed = reader["LISTED"] as string;
            this.BloombergMarket = reader["BLOOMBERG MARKET"] as string;
            this.BloombergCode = reader["BLOOMBERG CODE"] as string;
            this.BloombergId = reader["BLOOMBERG ID"] as string;
            this.ValorCode = reader["VALOR CODE"] as string;
            this.FACode = reader["FUND ADMIN. CODE"] as string;
            this.TACode = reader["TRASFER AGENT CODE"] as string;
            this.WKN = reader["WKN CODE"] as string;
            this.DateBusinessYear = reader["BUSINESS YEAR"] as string;
            this.ProspectusCode = reader["PROSPECTUS CODE"] as string;
        }
    }
}
