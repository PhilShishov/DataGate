﻿namespace DataGate.Services.Data.ViewSetups
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Data.Common;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;

    public class SubEntitiesVMSetup
    {
        public static async Task<T> SetGet<T>(int id, string chosenDate, ISubEntitiesService service)
        {
            var date = DateTimeParser.WebFormat(chosenDate);
            var headers = await service.GetSubEntities(id, date).FirstOrDefaultAsync();
            var values = await service.GetSubEntities(id, date).ToListAsync();

            SubEntitiesViewModel dto = new SubEntitiesViewModel()
            {
                Id = id,
                Date = chosenDate,
                Headers = headers.ToList(),
                HeadersSelection = headers.ToList(),
                Values = values,
            };

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public static async Task SetPost(SubEntitiesViewModel model, ISubEntitiesService service)
        {
            var date = DateTimeParser.WebFormat(model.Date);
            var headers = await service.GetSubEntities(model.Id, date).FirstOrDefaultAsync();
            model.Headers = headers.ToList();
            model.HeadersSelection = headers.ToList();

            bool isInSelectionMode = model.SelectedColumns != null ? true : false;

            if (isInSelectionMode)
            {
                var dto = AutoMapperConfig.MapperInstance.Map<GetWithSelectionDto>(model);

                model.Values = service.GetSubEntitiesSelected(dto).ToList();
                model.Headers = service.GetSubEntitiesSelected(dto).FirstOrDefault().ToList();
            }
            else if (!isInSelectionMode)
            {
                model.Values = await service.GetSubEntities(model.Id, date).ToListAsync();
            }

            if (model.SelectTerm != null)
            {
                model.Values = await CreateTableView.AddTableToViewAsync(model.Values, model.SelectTerm.ToLower()).ToListAsync();
            }
        }
    }
}
