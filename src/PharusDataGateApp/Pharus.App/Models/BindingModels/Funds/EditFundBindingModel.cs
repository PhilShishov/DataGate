namespace Pharus.App.Models.BindingModels.Funds
{
    using Pharus.Domain.Enums.Funds;

    public class EditFundBindingModel : BaseBindingModel
    {
        public TbDomFStatus FStatus { get; set; }
        public TbDomLegalForm LegalForm { get; set; }

        public TbDomLegalVehicle LegalVehicle { get; set; }

        public TbDomCompanyTypeDesc CompanyTypeDesc { get; set; }

        public TbDomCompanyAcronym CompanyAcronym { get; set; }
    }
}
