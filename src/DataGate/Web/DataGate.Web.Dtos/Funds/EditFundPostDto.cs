using System;

namespace DataGate.Web.Dtos.Funds
{
    public class EditFundPostDto
    {
        public DateTime InitialDate { get; set; }

        public int FundId { get; set; }

        public string FundName { get; set; }

        public string CSSFCode { get; set; }

        public int Status { get; set; }

        public int LegalForm { get; set; }

        public int LegalVehicle { get; set; }

        public int LegalType { get; set; }

        public string FACode { get; set; }

        public string DEPCode { get; set; }

        public string TACode { get; set; }

        public int CompanyTypeDesc { get; set; }

        public string TinNumber { get; set; }

        public string LEICode { get; set; }

        public string RegNumber { get; set; }
    }
}