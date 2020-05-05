namespace DataGate.Services.Data.ViewSetups
{
    using System;

    using DataGate.Common;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public static class GetOverview
    {
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

        //public static T GetSpecificEntityOverview<T>(int id, DateTime? date = null)
        //{

        //}

        //public T GetSpecificEntityOverview<T>(int id, string chosenDate)
        //{
        //    //this.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

        //    //var date = DateTimeParser.WebFormat(chosenDate);

        //    //var headers = this.GetHeaders();
        //    //var values = this.GetAllActive(null, null, 1);
        //    //var entity = this.GetEntityWithDateById(date, id);

        //    //var entity = new SpecificEntityOverviewGetDto()
        //    //{
        //    //    Id = id,
        //    //    Date = date,
        //    //    Entity = entity,
        //    //    HeadersSelection = headers,
        //    //    Headers = headers,
        //    //    Values = values,
        //    //};

        //    //return AutoMapperConfig.MapperInstance.Map<T>(entity);

        //    //    private const int IndexStartConnectionInSQLTable = 0;
        //    //private const int IndexEndConnectionInSQLTable = 1;


        //    //    model.Entity = service.GetEntityWithDateById(date, entityId).ToList();
        //    //    model.DistinctDocuments = service.GetDistinctDocuments(date, entityId).ToList();
        //    //    model.DistinctAgreements = service.GetDistinctAgreements(date, entityId).ToList();

        //    //    model.Values = service.GetEntity_SubEntities(date, entityId).ToList();
        //    //    model.Headers = service
        //    //                                                    .GetEntity_SubEntities(date, entityId)
        //    //                                                    .Take(1)
        //    //                                                    .FirstOrDefault()
        //    //                                                    .ToList();
        //    //    model.Timeline = service.GetTimeline(entityId).ToList();
        //    //    model.Documents = service.GetAllDocuments(entityId).ToList();
        //    //    model.Agreements = service.GetAllAgreements(date, entityId).ToList();

        //    //    string startConnection = model.Entity.ToList()[1][IndexStartConnectionInSQLTable];
        //    //    model.StartConnection = DateTimeParser.SqlFormat(startConnection);

        //    //    if (model.EndConnection != null)
        //    //    {
        //    //        string endConnection = model.Entity.ToList()[1][IndexEndConnectionInSQLTable];
        //    //        model.EndConnection = DateTimeParser.SqlFormat(endConnection);
        //    //    }

        //    //    //this.ViewData["DocumentFileTypes"] = this.fundsSelectListService.GetAllProspectusFileTypes();
        //    //    //this.ViewData["AgreementsFileTypes"] = this.fundsSelectListService.GetAllAgreementsFileTypes();
        //    //    //this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
        //    //    //this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
        //}
    }
}
