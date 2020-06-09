namespace DataGate.Web.Dtos.Entities
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class EditFundGetDto : IDataReaderParser
    {
        public string InitialDate { get; set; }

        public int Id { get; set; }

        public string FundName { get; set; }

        public string CSSFCode { get; set; }

        public string Status { get; set; }

        public string LegalForm { get; set; }

        public string LegalVehicle { get; set; }

        public string LegalType { get; set; }

        public string FACode { get; set; }

        public string DEPCode { get; set; }

        public string TACode { get; set; }

        public string CompanyTypeDesc { get; set; }

        public string TinNumber { get; set; }

        public string LEICode { get; set; }

        public string RegNumber { get; set; }

        public void Parse(IDataReader reader)
        {
            this.InitialDate = reader["VALID FROM"] as string;
            this.Id = (int)reader["FUND ID"];
            this.FundName = reader["FUND NAME"] as string;
            this.Status = reader["STATUS"] as string;
            this.CSSFCode = reader["CSSF CODE"] as string;
            this.LegalForm = reader["LEGAL FORM"] as string;
            this.LegalVehicle = reader["LEGAL VEHICLE"] as string;
            this.LegalType = reader["LEGAL TYPE"] as string;
            this.FACode = reader["FUND ADMIN CODE"] as string;
            this.DEPCode = reader["DEP. CODE"] as string;
            this.TACode = reader["TRANSFER AGENT CODE"] as string;
            this.CompanyTypeDesc = reader["COMPANY DESCRIPTION"] as string;
            this.TinNumber = reader["TIN NUMBER"] as string;
            this.LEICode = reader["LEI CODE"] as string;
            this.RegNumber = reader["REG. NUMBER"] as string;
        }
    }
}
