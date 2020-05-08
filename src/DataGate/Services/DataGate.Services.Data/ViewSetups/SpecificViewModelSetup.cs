namespace DataGate.Services.Data.ViewSetups
{
    using System;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.Data.Contracts;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;

    public class SpecificViewModelSetup
    {
        private const int IndexStartConnectionInSQLTable = 0;
        private const int IndexEndConnectionInSQLTable = 1;

        public static T SetGet<T>(int id, string chosenDate, ISubEntitiesService service)
        {
            service.ThrowEntityNotFoundExceptionIfIdDoesNotExist(id);

            var date = DateTimeParser.WebFormat(chosenDate);

            //var headers = service.GetHeaders(id, date);
            //var values = service.GetSubEntities(id, date, null, 1);
            var entity = service.GetByIdAndDate(id, date);

            string startConnectionString = entity.ToList()[1][IndexStartConnectionInSQLTable];
            string endConnectionString = entity.ToList()[1][IndexEndConnectionInSQLTable];
            DateTime? endConnection = null;

            if (!string.IsNullOrWhiteSpace(endConnectionString) && endConnectionString != GlobalConstants.EmptyEndConnectionDisplay)
            {
                endConnection = DateTimeParser.SqlFormat(endConnectionString);
            }

            var distinctDocs = service.GetDistinctDocuments<DistinctDocViewModel>(id, date);
            var distinctAgrs = service.GetDistinctAgreements<DistinctDocViewModel>(id, date);
            //var documents = service.GetAllDocuments<AllDocViewModel>(id);
            //var agreements = service.GetAllAgreements<AllAgrViewModel>(id, date);
            //var timelines = service.GetTimeline<TimelineViewModel>(id);

            //public IEnumerable<string> Headers { get; set; }

            //public IEnumerable<string> HeadersSelection { get; set; }

            //public IEnumerable<string[]> Values { get; set; }

            //public IEnumerable<AllDocViewModel> Documents { get; set; }

            //public IEnumerable<AllAgrViewModel> Agreements { get; set; }

            //public IEnumerable<TimelineViewModel> Timelines { get; set; }

            var dto = new SpecificEntityOverviewGetDto()
            {
                Id = id,
                Date = chosenDate,
                Entity = entity,
                StartConnection = DateTimeParser.SqlFormat(startConnectionString),
                EndConnection = endConnection,
                DistinctDocuments = distinctDocs,
                DistinctAgreements = distinctAgrs,
            };

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public static void SetPost(SpecificEntityViewModel model, IEntitySubEntitiesService service)
        {
            var date = DateTimeParser.WebFormat(model.Date);
            bool isInSelectionMode = model.SelectedColumns != null ? true : false;

            if (isInSelectionMode)
            {
                var dto = AutoMapperConfig.MapperInstance.Map<GetWithSelectionDto>(model);

                model.Values = service.GetSubEntitiesSelected(dto).ToList();
                model.Headers = service.GetHeaders(model.Id, date).ToList();
            }
            else if (!isInSelectionMode)
            {
                model.Values = service.GetSubEntities(model.Id, date).ToList();
            }

            if (model.SelectTerm != null)
            {
                model.Values = CreateTableView.AddTableToView(model.Values, model.SelectTerm.ToLower());
            }
        }
    }
}
