namespace Pharus.Services.ShareClasses
{
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.Contracts;

    public class ShareClassesSelectListService : IShareClassesSelectListService
    {
        private readonly Pharus_vFinaleContext _context;

        public ShareClassesSelectListService(
            Pharus_vFinaleContext context)
        {
            this._context = context;
        }
        public List<string> GetAllTbDomCurrencyCode()
        {
            var currencyCode = this._context.TbDomIsoCurrency.Select(tb => tb.IsoCcyCode).ToList();

            return currencyCode;
        }

        public List<string> GetAllTbDomInvestorType()
        {
            var investorType = this._context.TbDomInvestorType.Select(tb => tb.ItDesc).ToList();

            return investorType;
        }

        public List<string> GetAllTbDomShareStatus()
        {
            var shareStatus = this._context.TbDomShareStatus.Select(tb => tb.ScSDesc).ToList();

            return shareStatus;
        }

        public List<string> GetAllTbDomShareType()
        {
            var shareType = this._context.TbDomShareType.Select(tb => tb.StDesc).ToList();

            return shareType;
        }
    }
}