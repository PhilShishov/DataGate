namespace DataGate.Services.Data.ViewSetups
{
    using System;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;

    public static class GetOverview
    {
        private const int IndexStartConnectionInSQLTable = 0;
        private const int IndexEndConnectionInSQLTable = 1;

        public static T Entities<T>(IEntityService service)
        {
            var headers = service.GetHeaders();
            var values = service.GetAllActive(null, null, 1);

            var entity = new EntitiesOverviewGetDto()
            {
                IsActive = true,
                Date = DateTime.Today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
                HeadersSelection = headers,
                Headers = headers,
                Values = values,
            };

            return AutoMapperConfig.MapperInstance.Map<T>(entity);
        }

        public static T SpecificEntity<T>(int id, string chosenDate, IEntitySubEntitiesService service)
        {
            service.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var date = DateTimeParser.WebFormat(chosenDate);

            var headers = service.GetHeaders(id, date);
            var values = service.GetSubEntities(id, date, null, 1);
            var entity = service.GetByIdAndDate(id, date);

            string startConnection = entity.ToList()[1][IndexStartConnectionInSQLTable];
            string endConnection = entity.ToList()[1][IndexEndConnectionInSQLTable];

            var distinctDocs = service.GetDistinctDocuments<DistinctDocViewModel>(id, date);
            var distinctAgrs = service.GetDistinctAgreements<DistinctDocViewModel>(id, date);
            //var documents = service.GetAllDocuments<AllDocViewModel>(id);

            var dto = new SpecificEntityOverviewGetDto()
            {
                Id = id,
                Date = date,
                Entity = entity,
                Headers = headers,
                HeadersSelection = headers,
                Values = values,
                StartConnection = DateTimeParser.SqlFormat(startConnection),
                EndConnection = DateTimeParser.SqlFormat(endConnection),
                DistinctDocuments = distinctDocs,
                DistinctAgreements = distinctAgrs,
                //Documents = 

            };

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
            //    model.DistinctAgreements = service.GetDistinctAgreements(date, entityId).ToList();

            //    model.Timeline = service.GetTimeline(entityId).ToList();
            //    model.Documents = service.GetAllDocuments(entityId).ToList();
            //    model.Agreements = service.GetAllAgreements(date, entityId).ToList();
        }
    }
}
