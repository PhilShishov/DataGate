namespace DataGate.Services.Data.ViewSetups
{
    using DataGate.Web.ViewModels.Entities;

    public class SpecificViewModelSetup
    {
        public static void PrepareModel(SpecificEntityViewModel model, IEntitySubEntitiesService service)
        {
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
