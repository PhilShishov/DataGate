namespace Pharus.Services.Funds
{
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Contracts;

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
            var companyAcronyms = this.context.TbDomCompanyType.Select(tb => tb.CtAcronym).ToList();

            return companyAcronyms;
        }

        public List<string> GetAllTbDomCompanyDesc()
        {
            var companyAcronyms = this.context.TbDomCompanyType.Select(tb => tb.CtDesc).ToList();

            return companyAcronyms;
        }

        public List<string> GetAllTbDomFStatus()
        {
            var companyAcronyms = this.context.TbDomFStatus.Select(tb => tb.StFDesc).ToList();

            return companyAcronyms;
        }

        public List<string> GetAllTbDomLegalForm()
        {
            var companyAcronyms = this.context.TbDomLegalForm.Select(tb => tb.LfAcronym).ToList();

            return companyAcronyms;
        }

        public List<string> GetAllTbDomLegalType()
        {
            var companyAcronyms = this.context.TbDomLegalType.Select(tb => tb.LtAcronym).ToList();

            return companyAcronyms;
        }

        public List<string> GetAllTbDomLegalVehicle()
        {
            var companyAcronyms = this.context.TbDomLegalVehicle.Select(tb => tb.LvAcronym).ToList();

            return companyAcronyms;
        }
    }
}