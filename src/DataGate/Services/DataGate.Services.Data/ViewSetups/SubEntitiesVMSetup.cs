namespace DataGate.Services.Data.ViewSetups
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Data.Common;
    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;

    public class SubEntitiesVMSetup
    {
        public static async Task<T> SetLoadedGet<T>(int id, string chosenDate, string container, ISubEntitiesService service)
        {
            var date = DateTimeParser.WebFormat(chosenDate);
            var entities = await service.GetSubEntities(id, date).ToListAsync();

            var dto = new EntitySubEntitiesGetDto()
            {
                Id = id,
                Date = chosenDate,
                Container = container,
                Entities = entities,
            };

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public static async Task<T> SetGet<T>(int id, string chosenDate, string container, ISubEntitiesService service)
        {
            var date = DateTimeParser.WebFormat(chosenDate);
            var values = await service.GetSubEntities(id, date, null, 1).ToListAsync();
            var headers = await service.GetSubEntities(id, date).FirstOrDefaultAsync();

            var dto = new SubEntitiesGetDto()
            {
                Id = id,
                Date = chosenDate,
                Container = container,
                Values = values,
                Headers = headers,
                HeadersSelection = headers,
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

                model.Values = await service.GetSubEntitiesSelected(dto, null, 1).ToListAsync();
                headers = await service.GetSubEntitiesSelected(dto).FirstOrDefaultAsync();
                model.Headers = headers.ToList();
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
