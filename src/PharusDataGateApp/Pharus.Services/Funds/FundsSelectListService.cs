namespace Pharus.Services.Funds
{
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Funds.Contracts;

    public class FundsSelectListService : IFundsSelectListService
    {
        private readonly Pharus_vFinaleContext context;

        public FundsSelectListService(
            Pharus_vFinaleContext context)
        {
            this.context = context;
        }

        public List<string> GetAllTbDomCompanyAcronym()
        {
            var companyAcronyms = this.context.TbDomCompanyType
                .Select(tb => tb.CtAcronym)
                .ToList();

            return companyAcronyms;
        }

        public List<string> GetAllTbDomCompanyDesc()
        {
            var companyDesc = this.context.TbDomCompanyType
                .Select(tb => tb.CtDesc)
                .ToList();

            return companyDesc;
        }

        public List<string> GetAllTbDomFStatus()
        {
            var fStatus = this.context.TbDomFStatus
                .Select(tb => tb.StFDesc)
                .ToList();

            return fStatus;
        }

        public List<string> GetAllTbDomLegalForm()
        {
            var legalForms = this.context.TbDomLegalForm
                .Select(tb => tb.LfAcronym)
                .ToList();

            return legalForms;
        }

        public List<string> GetAllTbDomLegalType()
        {
            var legalTypes = this.context.TbDomLegalType
                .Select(tb => tb.LtAcronym)
                .ToList();

            return legalTypes;
        }

        public List<string> GetAllTbDomLegalVehicle()
        {
            var legalVehicles = this.context.TbDomLegalVehicle
                .Select(tb => tb.LvAcronym)
                .ToList();

            return legalVehicles;
        }
    }
}