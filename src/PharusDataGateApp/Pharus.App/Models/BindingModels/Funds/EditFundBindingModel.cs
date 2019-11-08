namespace Pharus.App.Models.BindingModels.Funds
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class EditFundBindingModel : BaseBindingModel
    {
        public SelectList FStatus { get; set; }
        public SelectList LegalForm { get; set; }

        public SelectList LegalVehicle { get; set; }

        public SelectList LegalType { get; set; }

        public SelectList CompanyTypeDesc { get; set; }

        public SelectList CompanyAcronym { get; set; }
    }
}
