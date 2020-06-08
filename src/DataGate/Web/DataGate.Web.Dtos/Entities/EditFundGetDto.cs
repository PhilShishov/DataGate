namespace DataGate.Web.Dtos.Entities
{
    using System;

    public class EditFundGetDto
    {
        public DateTime InitialDate { get; set; }

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
    }
}
