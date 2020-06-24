namespace DataGate.Services.Data.ViewSetups
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Data.Entities;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Overviews;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;

    public static class EntitiesVMSetup
    {
        public static async Task<T> SetGet<T>(IEntityService service, string functionActive)
        {
            var today = DateTime.Today;
            var headers = await service.GetAll(functionActive, null, today).FirstOrDefaultAsync();
            var values = await service.GetAll(functionActive, null, today, 1).ToListAsync();

            var dto = new EntitiesOverviewGetDto()
            {
                IsActive = true,
                Date = DateTimeParser.ToWebFormat(today),
                HeadersSelection = headers,
                Headers = headers,
                Values = values,
            };

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public static async Task SetPost(EntitiesViewModel model, IEntityService service, string functionAll, string functionActive)
        {
            var date = DateTimeParser.FromWebFormat(model.Date);
            bool isInSelectionMode = model.SelectedColumns != null ? true : false;

            var headers = await service.GetAll(functionActive, null, date).FirstOrDefaultAsync();
            model.Headers = headers.ToList();
            model.HeadersSelection = headers.ToList();

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
                    headers = await service.GetAllSelected(functionActive, dto).FirstOrDefaultAsync();
                    model.Headers = headers.ToList();
                    model.Values = await service.GetAllSelected(functionActive, dto, 1).ToListAsync();
                }
                else if (!model.IsActive)
                {
                    headers = await service.GetAllSelected(functionAll, dto, 1).FirstOrDefaultAsync();
                    model.Headers = headers.ToList();
                    model.Values = await service.GetAllSelected(functionAll, dto, 1).ToListAsync();
                }
            }
            else if (!isInSelectionMode)
            {
                if (model.IsActive)
                {
                    model.Values = await service.GetAll(functionActive, null, date, 1).ToListAsync();
                }
                else if (!model.IsActive)
                {
                    model.Values = await service.GetAll(functionAll, null, date, 1).ToListAsync();
                }
            }

            if (model.SelectTerm != null)
            {
                model.Values = await CreateTableView.AddTableToViewAsync(model.Values, model.SelectTerm.ToLower()).ToListAsync();
            }
        }
    }
}
