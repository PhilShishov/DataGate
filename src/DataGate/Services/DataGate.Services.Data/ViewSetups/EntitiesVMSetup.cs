namespace DataGate.Services.Data.ViewSetups
{
    using System;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.Data.Common;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;

    public static class EntitiesVMSetup
    {
        public static T SetGet<T>(IEntityService service)
        {
            var today = DateTime.Today;
            var headers = service.GetHeaders();
            var values = service.GetAllActive(today, null, 1);

            var entity = new EntitiesOverviewGetDto()
            {
                IsActive = true,
                Date = today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
                HeadersSelection = headers,
                Headers = headers,
                Values = values,
            };
            return AutoMapperConfig.MapperInstance.Map<T>(entity);
        }

        public static void SetPost(EntitiesViewModel model, IEntityService service)
        {
            var headers = service.GetHeaders().ToList();
            model.Headers = headers;
            model.HeadersSelection = headers;

            bool isInSelectionMode = model.SelectedColumns != null ? true : false;

            var date = DateTimeParser.WebFormat(model.Date);

            // ---------------------------------------------------------
            //
            // Algorithm for getting values and headers based on:
            // 1. Date update of table
            // 2. Selection mode as columns or not
            // 3. Active entities or not
            // 4. Selected entity or not
            if (isInSelectionMode)
            {
                var dto = AutoMapperConfig.MapperInstance.Map<GetWithSelectionDto>(model);

                if (model.IsActive)
                {
                    model.Headers = service.GetAllActiveSelected(dto, 1).FirstOrDefault().ToList();
                    model.Values = service.GetAllActiveSelected(dto, null, 1).ToList();
                }
                else if (!model.IsActive)
                {
                    model.Headers = service.GetAllSelected(dto, 1).FirstOrDefault().ToList();
                    model.Values = service.GetAllSelected(dto, null, 1).ToList();
                }
            }
            else if (!isInSelectionMode)
            {
                if (model.IsActive)
                {
                    model.Values = service.GetAllActive(date, null, 1).ToList();
                }
                else if (!model.IsActive)
                {
                    model.Values = service.GetAll(date, null, 1).ToList();
                }
            }

            if (model.SelectTerm != null)
            {
                model.Values = CreateTableView.AddTableToView(model.Values, model.SelectTerm.ToLower());
            }
        }
    }
}
