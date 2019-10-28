namespace Pharus.App.Models.BindingModels.Funds
{
    using System.Collections.Generic;

    using Pharus.Domain.Enums;

    public class EditFundBindingModel
    {
        //TODO data annotation checks
        public List<string[]> FundProperties { get; set; }

        public TbDomFStatus FStatus { get; set; }
        public TbDomLegalForm LegalForm { get; set; }

        public TbDomLegalVehicle LegalVehicle { get; set; }

        public TbDomCompanyTypeDesc CompanyTypeDesc { get; set; }

        public TbDomCompanyAcronym CompanyAcronym { get; set; }
    }
}
