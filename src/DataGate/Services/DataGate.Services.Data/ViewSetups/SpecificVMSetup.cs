namespace DataGate.Services.Data.ViewSetups
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Queries;

    public class SpecificVMSetup
    {
        private const int IndexStartConnectionInSQLTable = 1;
        private const int IndexEndConnectionInSQLTable = 2;

        public static async Task<T> SetGet<T>(int id, string date, IEntityDetailsService service, IEntityException exceptionService, QueriesToPassDto queryDto)
        {
            exceptionService.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var dateParsed = DateTimeParser.FromWebFormat(date);
            var entity = await service.ByIdAndDate(queryDto.SqlFunctionById, id, dateParsed).ToListAsync();
            string startConnectionString = entity.ToList()[1][IndexStartConnectionInSQLTable];
            string endConnectionString = entity.ToList()[1][IndexEndConnectionInSQLTable];
            DateTime? endConnection = null;

            if (!string.IsNullOrWhiteSpace(endConnectionString) && endConnectionString != GlobalConstants.EmptyEndConnectionDisplay)
            {
                endConnection = DateTimeParser.FromSqlFormat(endConnectionString);
            }

            var dto = new DetailsDto()
            {
                Id = id,
                Date = date,
                Entity = entity,
                StartConnection = DateTimeParser.FromSqlFormat(startConnectionString),
                EndConnection = endConnection,
            };

            if (queryDto.SqlFunctionContainer != null)
            {
                dto.Container = service.GetContainer(queryDto.SqlFunctionContainer, id, dateParsed);
            }

            if (queryDto.SqlFunctionActiveSE != null)
            {
                var subEntities = await service.GetSubEntities(queryDto.SqlFunctionActiveSE, id, dateParsed, 1).ToListAsync();
                dto.SubEntityCount = subEntities.Count;
            }

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }
    }
}
