﻿namespace DataGate.Services.Data.ViewSetups
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.ViewModels.Queries;

    public class SpecificVMSetup
    {
        private const int IndexStartConnectionInSQLTable = 1;
        private const int IndexEndConnectionInSQLTable = 2;

        public static async Task<T> SetGet<T>(int id, string date, IEntityDetailsService service, IEntityException exceptionService, QueriesToPassDto queryDto)
        {
            exceptionService.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var dateParsed = DateTimeParser.WebFormat(date);
            var entity = await service.GetByIdAndDate(queryDto.SqlFunctionById, id, dateParsed).ToListAsync();
            string startConnectionString = entity.ToList()[1][IndexStartConnectionInSQLTable];
            string endConnectionString = entity.ToList()[1][IndexEndConnectionInSQLTable];
            DateTime? endConnection = null;

            if (!string.IsNullOrWhiteSpace(endConnectionString) && endConnectionString != GlobalConstants.EmptyEndConnectionDisplay)
            {
                endConnection = DateTimeParser.SqlFormat(endConnectionString);
            }

            var distinctDocs = service.GetDistinctDocuments(queryDto.SqlFunctionDistinctDocuments, id, dateParsed);
            var distinctAgrs = service.GetDistinctAgreements(queryDto.SqlFunctionDistinctAgreements, id, dateParsed);

            var dto = new SpecificEntityOverviewGetDto()
            {
                Id = id,
                Date = date,
                Entity = entity,
                StartConnection = DateTimeParser.SqlFormat(startConnectionString),
                EndConnection = endConnection,
                DistinctDocuments = distinctDocs,
                DistinctAgreements = distinctAgrs,
            };

            if (queryDto.SqlFunctionContainer != null)
            {
                dto.Container = service.GetContainer(queryDto.SqlFunctionContainer, id, dateParsed);
            }

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }
    }
}
