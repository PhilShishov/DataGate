namespace DataGate.Services.Data.ViewSetups
{
    using System.Linq;

    using DataGate.Services.DateTime;
    using DataGate.Web.ViewModels.Documents;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Timelines;

    public class SpecificViewModelSetup
    {
        private const int IndexStartConnectionInSQLTable = 0;
        private const int IndexEndConnectionInSQLTable = 1;

        public static void PrepareModel(SpecificEntityViewModel model, IEntitySubEntitiesService service)
        {
            service.ThrowEntityNotFoundExceptionIfIdDoesNotExist(model.Id);

            var date = DateTimeParser.WebFormat(model.Date);
            int id = model.Id;

            model.Entity = service.GetByIdAndDate(id, date).ToList();
            model.DistinctDocuments = service.GetDistinctDocuments<DistinctDocViewModel>(id, date);
            model.DistinctAgreements = service.GetDistinctAgreements<DistinctDocViewModel>(id, date);

            var headers = service.GetHeaders(id, date);
            var values = service.GetSubEntities(id, date, null, 1);

            model.Values = service.GetSubEntities(id, date).ToList();
            model.Headers = service
                                                            .GetSubEntities(id, date)
                                                            .Take(1)
                                                            .FirstOrDefault()
                                                            .ToList();
            model.Timelines = service.GetTimeline<TimelineViewModel>(id);
            model.Documents = service.GetAllDocuments<AllDocViewModel>(id);
            model.Agreements = service.GetAllAgreements<AllAgrViewModel>(id, date);

            string startConnection = model.Entity.ToList()[1][IndexStartConnectionInSQLTable];
            model.StartConnection = DateTimeParser.SqlFormat(startConnection);

            if (model.EndConnection != null)
            {
                string endConnection = model.Entity.ToList()[1][IndexEndConnectionInSQLTable];
                model.EndConnection = DateTimeParser.SqlFormat(endConnection);
            }

            //this.ViewData["DocumentFileTypes"] = this.fundsSelectListService.GetAllProspectusFileTypes();
            //this.ViewData["AgreementsFileTypes"] = this.fundsSelectListService.GetAllAgreementsFileTypes();
            //this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
            //this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
        }

        //private void CallEntitySubEntitiesWithSelectedColumns(SpecificEntityViewModel model, DateTime chosenDate)
        //{
        //    model.EntitySubEntities = this.service
        //        .GetFund_SubFundsWithSelectedViewAndDate(
        //                                        model.PreSelectedColumns,
        //                                        model.SelectedColumns,
        //                                        chosenDate,
        //                                        model.EntityId)
        //        .ToList();
        //}
    }
}
