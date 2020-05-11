namespace DataGate.Services.Data.ViewSetups
{
    using System.Linq;

    using DataGate.Services.Data.Common;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;

    public class SubEntitiesVMSetup
    {
        public static void SetPost(EntitiesViewModel model, ISubEntitiesService service)
        {
            var date = DateTimeParser.WebFormat(model.Date);
            bool isInSelectionMode = model.SelectedColumns != null ? true : false;

            //if (isInSelectionMode)
            //{
            //    var dto = AutoMapperConfig.MapperInstance.Map<GetWithSelectionDto>(model);

            //    model.Values = service.GetSubEntitiesSelected(dto).ToList();
            //    model.Headers = service.GetHeaders(model.Id, date).ToList();
            //}
            //else if (!isInSelectionMode)
            //{
            //    model.Values = service.GetSubEntities(model.Id, date).ToList();
            //}

            if (model.SelectTerm != null)
            {
                model.Values = CreateTableView.AddTableToView(model.Values, model.SelectTerm.ToLower());
            }
        }
    }
}
