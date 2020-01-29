// Service class for managing shareclasses selects

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.Services.ShareClasses
{
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Data;
    using Pharus.Services.ShareClasses.Contracts;

    public class ShareClassesSelectListService : IShareClassesSelectListService
    {
        private readonly Pharus_vFinale_Context context;
        private const int shareClassFileType = 3;

        public ShareClassesSelectListService(
            Pharus_vFinale_Context context)
        {
            this.context = context;
        }

        public List<string> GetAllTbDomCountry()
        {
            var country = this.context.TbDomIsoCountry
                .Select(tb => tb.IsoCountryIso2 + " - " + tb.IsoCountryDesc)
                .ToList();

            return country;
        }

        public List<string> GetAllTbDomCurrencyCode()
        {
            var currencyCode = this.context.TbDomIsoCurrency
                .Select(tb => tb.IsoCcyCode)
                .ToList();

            return currencyCode;
        }

        public List<string> GetAllTbDomInvestorType()
        {
            var investorType = this.context.TbDomInvestorType
                .Select(tb => tb.ItDesc)
                .ToList();

            return investorType;
        }

        public List<string> GetAllTbDomShareStatus()
        {
            var shareStatus = this.context.TbDomShareStatus
                .Select(tb => tb.ScSDesc)
                .ToList();

            return shareStatus;
        }

        public List<string> GetAllTbDomShareType()
        {
            var shareType = this.context.TbDomShareType
                .Select(tb => tb.StDesc)
                .ToList();

            return shareType;
        }

        public List<string> GetAllShareClassFileTypes()
        {
            var fileTypes = this.context.TbDomFileType
                .Where(ft => ft.FiletypeEntity == shareClassFileType)
                .Select(ft => ft.FiletypeDesc)
                .ToList();

            return fileTypes;
        }

        public List<string> GetAllAgreementsFileTypes()
        {
            var agrFileTypes = this.context.TbDomActivityType
                .Where(at => at.AtEntity == shareClassFileType)
                .Select(at => at.AtDesc)
                .ToList();

            return agrFileTypes;
        }
    }
}