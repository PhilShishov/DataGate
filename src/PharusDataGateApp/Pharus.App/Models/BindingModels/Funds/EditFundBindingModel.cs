namespace Pharus.App.Models.BindingModels.Funds
{
    using System.Collections.Generic;

    public class EditFundBindingModel : BaseBindingModel
    {
        public List<string> FStatus { get; set; }
        public List<string> LegalForm { get; set; }

        public List<string> LegalVehicle { get; set; }

        public List<string> LegalType { get; set; }

        public List<string> CompanyTypeDesc { get; set; }

        public List<string> CompanyAcronym { get; set; }
    }
}
