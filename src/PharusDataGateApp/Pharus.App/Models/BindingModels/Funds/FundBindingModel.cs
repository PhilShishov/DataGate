namespace Pharus.App.Models.BindingModels.Funds
{
    using System;

    public class FundBindingModel : BaseBindingModel
    {
        public DateTime ChosenDate { get; set; }

        public int FId { get; set; }

        public string FStatus { get; set; }

        public string LegalForm { get; set; }

        public string LegalVehicle { get; set; }

        public string LegalType { get; set; }

        public string CompanyTypeDesc { get; set; }

        public string CompanyAcronym { get; set; }
    }
}
