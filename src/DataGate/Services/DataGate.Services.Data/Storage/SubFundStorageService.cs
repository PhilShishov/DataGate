namespace DataGate.Services.Data.Storage
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common.Exceptions;
    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Services.SqlClient.Contracts;
    using DataGate.Web.Dtos.Entities;
    using DataGate.Web.InputModels.SubFunds;
    using Microsoft.EntityFrameworkCore;

    public class SubFundStorageService : ISubFundStorageService
    {
        private const int SkipHeaders = 1;
        private const int IndexName = 3;
        private const int IndexStatus = 4;
        private const int IndexCSSFCode = 5;
        private const int IndexFACode = 6;
        private const int IndexDEPCode = 7;
        private const int IndexTACode = 8;
        private const int IndexFirstNavDate = 9;
        private const int IndexLastNavDate = 10;
        private const int IndexAuthDate = 11;
        private const int IndexExpiryDate = 12;
        private const int IndexLEICode = 13;
        private const int IndexCesrClass = 14;
        private const int IndexGeoFocus = 15;
        private const int IndexGlobalExposure = 16;
        private const int IndexCurrency = 17;
        private const int IndexFrequency = 18;
        private const int IndexValuation = 19;
        private const int IndexCalculation = 20;
        private const int IndexDerivs = 21;
        private const int IndexDerivMarket = 22;
        private const int IndexAssetClass = 23;
        private const int IndexMarketType = 24;
        private const int IndexInvestStrategy = 25;
        private const int IndexClearingCode = 26;
        private const int IndexMorningStar = 27;
        private const int IndexSix = 28;
        private const int IndexBloomberg = 29;

        private readonly string sqlFunctionId = "[fn_subfund_id]";

        private readonly ISqlQueryManager sqlManager;
        private readonly IRepository<TbHistorySubFund> repository;
        private readonly ISubFundSelectListService service;

        public SubFundStorageService(
                        ISqlQueryManager sqlQueryManager,
                        IRepository<TbHistorySubFund> repository,
                        ISubFundSelectListService service)
        {
            this.sqlManager = sqlQueryManager;
            this.repository = repository;
            this.service = service;
        }

        public T GetByIdAndDate<T>(int id, string date)
        {
            this.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var dateParsed = DateTimeParser.FromWebFormat(date);

            var dto = this.sqlManager
                .ExecuteQueryMapping<EditSubFundGetDto>(this.sqlFunctionId, id, dateParsed)
                .FirstOrDefault();

            return AutoMapperConfig.MapperInstance.Map<T>(dto);

            //var query = await this.sqlManager
            //    .ExecuteQueryAsync(this.sqlFunctionId, dateParsed, id)
            //    .Skip(SkipHeaders)
            //    .FirstOrDefaultAsync();

            //var dto = new EditSubFundGetDto
            //{
            //    InitialDate = dateParsed,
            //    Id = id,
            //    SubFundName = query[IndexName],
            //    CSSFCode = query[IndexCSSFCode],
            //    Status = query[IndexStatus],
            //    FACode = query[IndexFACode],
            //    TACode = query[IndexTACode],
            //    LEICode = query[IndexLEICode],
            //    DBCode = query[IndexLEICode],
            //    FirstNavDate = query[IndexFirstNavDate],
            //    LastNavDate = query[IndexLastNavDate],
            //    CSSFAuthDate = query[IndexAuthDate],
            //    ExpiryDate = query[IndexExpiryDate],
            //    CesrClass = query[IndexCesrClass],
            //    GeographicalFocus = query[IndexGeoFocus],
            //    GlobalExposure = query[IndexGlobalExposure],
            //    CurrencyCode = query[IndexCurrency],
            //    NavFrequency = query[IndexFrequency],
            //    ValuationDate = query[IndexValuation],
            //    CalculationDate = query[IndexCalculation],
            //    Derivatives = query[IndexDerivs],
            //    DerivMarket = query[IndexDerivMarket],
            //    PrincipalAssetClass = query[IndexAssetClass],
            //    TypeOfMarket = query[IndexMarketType],
            //    PrincipalInvestmentStrategy = query[IndexInvestStrategy],
            //    ClearingCode = query[IndexClearingCode],
            //    SfCatMorningStar = query[IndexMorningStar],
            //    SfCatSix = query[IndexSix],
            //    SfCatBloomberg = query[IndexBloomberg],
            //};
        }

        public Task<int> Edit(EditSubFundInputModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(CreateSubFundInputModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DoesExist(string name)
        {
            return await this.repository.All().AnyAsync(sf => sf.SfOfficialSubFundName == name);
        }

        private void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
        {
            if (!this.Exists(id))
            {
                throw new EntityNotFoundException(nameof(TbHistorySubFund));
            }
        }

        private bool Exists(int id) => this.repository.All().Any(x => x.SfId == id);
    }
}
