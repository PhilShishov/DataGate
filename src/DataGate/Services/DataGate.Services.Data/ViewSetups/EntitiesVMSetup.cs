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
            var headers = await service.All(functionActive, null, today).FirstOrDefaultAsync();
            var values = await service.All(functionActive, null, today, 1).ToListAsync();

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

            var headers = await service.All(functionActive, null, date).FirstOrDefaultAsync();
            model.Headers = headers.ToList();
            model.HeadersSelection = headers.ToList();

            // ---------------------------------------------------------
            //
            // Algorithm for getting values and headers based on:
            // 1. Date update of table
            // 2. Selected Layout Mode
            // 3. Active entities
            if (isInSelectionMode)
            {
                var dtoSelected = AutoMapperConfig.MapperInstance.Map<AllSelectedDto>(model);

                if (model.IsActive)
                {
                    headers = await service.AllSelected(functionActive, dtoSelected).FirstOrDefaultAsync();
                    model.Headers = headers.ToList();
                    model.Values = await service.AllSelected(functionActive, dtoSelected, 1).ToListAsync();
                }
                else if (!model.IsActive)
                {
                    headers = await service.AllSelected(functionAll, dtoSelected, 1).FirstOrDefaultAsync();
                    model.Headers = headers.ToList();
                    model.Values = await service.AllSelected(functionAll, dtoSelected, 1).ToListAsync();
                }
            }
            else if (!isInSelectionMode)
            {
                if (model.IsActive)
                {
                    model.Values = await service.All(functionActive, null, date, 1).ToListAsync();
                }
                else if (!model.IsActive)
                {
                    model.Values = await service.All(functionAll, null, date, 1).ToListAsync();
                }
            }
        }
    }
}