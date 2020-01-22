namespace Pharus.Services.Agreements
{
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Agreements.Contracts;

    public class AgreementsSelectListService : IAgreementsSelectListService
    {
        private readonly Pharus_vFinale_Context context;

        public AgreementsSelectListService(
         Pharus_vFinale_Context context)
        {
            this.context = context;
        }
        public List<string> GetAllTbDomAgreementStatus()
        {
            var aStatus = this.context.TbDomAgreementStatus
                .Select(ast => ast.ASDesc)
                .ToList();

            return aStatus;
        }

        public List<string> GetAllTbCompanies()
        {
            var companies = this.context.TbCompanies               
               .Select(c => c.CName)
               .ToList();

            return companies;
        }
    }
}