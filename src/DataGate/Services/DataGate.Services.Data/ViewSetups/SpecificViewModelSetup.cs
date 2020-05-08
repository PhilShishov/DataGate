namespace DataGate.Services.Data.ViewSetups
{
    using DataGate.Services.DateTime;
    using DataGate.Web.ViewModels.Entities;

    public class SpecificViewModelSetup
    {
        public static void PrepareModel(SpecificEntityViewModel model, IEntitySubEntitiesService service)
        {
            ////var headers = service.GetHeaders().ToList();
            ////model.Headers = headers;
            ////model.HeadersSelection = headers;

            //bool isInSelectionMode = false;

            //if (model.SelectedColumns != null)
            //{
            //    isInSelectionMode = true;
            //}

            //var date = DateTimeParser.WebFormat(model.Date);

            //if (model.SelectTerm == null)
            //{
            //    if (isInSelectionMode)
            //    {
            //        CallEntitySubEntitiesWithSelectedColumns(model, date);
            //    }
            //    else if (!isInSelectionMode)
            //    {
            //        model.EntitySubEntities = this.fundsService.GetFund_SubFunds(chosenDate, model.EntityId).ToList();
            //    }

            //    return this.View(model);
            //}

            //if (isInSelectionMode)
            //{
            //    thisCallEntitySubEntitiesWithSelectedColumns(model, date);
            //}
            //else if (!isInSelectionMode)
            //{
            //    model.EntitySubEntities = this.fundsService
            //        .GetFund_SubFunds(chosenDate, model.Id)
            //        .ToList();
            //}

            //if (model.SelectTerm != null)
            //{
            //    model.Values = CreateTableView.AddTableToView(model.Values, model.SelectTerm.ToLower());
            //}
        }

        //private void CallEntitySubEntitiesWithSelectedColumns(SpecificEntityViewModel model, DateTime date)
        //{
        //    model.EntitySubEntities = this.service
        //        .GetFund_SubFundsWithSelectedViewAndDate(
        //                                        model.PreSelectedColumns,
        //                                        model.SelectedColumns,
        //                                        date,
        //                                        model.EntityId)
        //        .ToList();
        //}
    }
}
