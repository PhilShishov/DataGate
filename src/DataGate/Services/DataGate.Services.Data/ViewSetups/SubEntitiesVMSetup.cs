﻿namespace DataGate.Services.Data.ViewSetups
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Data.Entities;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Overviews;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;

    public class SubEntitiesVMSetup
    {
        public static async Task<T> SetLoadedGet<T>(IEntityService service, IEntityException exceptionService,
                                                    EntitySubEntitiesGetDto dto, string function)
        {
            exceptionService.ThrowEntityNotFoundExceptionIfIdDoesNotExist(dto.Id);
            var date = DateTimeParser.FromWebFormat(dto.Date);
            var entities = await service.GetAll(function, dto.Id, date).ToListAsync();

            dto.Entities = entities;

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public static async Task<T> SetGet<T>(IEntityService service, IEntityException exceptionService,
                                              SubEntitiesGetDto dto, string function)
        {
            exceptionService.ThrowEntityNotFoundExceptionIfIdDoesNotExist(dto.Id);
            var date = DateTimeParser.FromWebFormat(dto.Date);
            var values = await service.GetAll(function, dto.Id, date, 1).ToListAsync();
            var headers = await service.GetAll(function, dto.Id, date).FirstOrDefaultAsync();

            dto.Values = values;
            dto.Headers = headers;
            dto.HeadersSelection = headers;

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public static async Task SetPost(SubEntitiesViewModel model, IEntityService service, string function)
        {
            var date = DateTimeParser.FromWebFormat(model.Date);
            var headers = await service.GetAll(function, model.Id, date).FirstOrDefaultAsync();
            model.Headers = headers.ToList();
            model.HeadersSelection = headers.ToList();

            bool isInSelectionMode = model.SelectedColumns != null ? true : false;

            if (isInSelectionMode)
            {
                var dto = AutoMapperConfig.MapperInstance.Map<GetWithSelectionDto>(model);

                model.Values = await service.GetAllSelected(function, dto, 1).ToListAsync();
                headers = await service.GetAllSelected(function, dto).FirstOrDefaultAsync();
                model.Headers = headers.ToList();
            }
            else if (!isInSelectionMode)
            {
                model.Values = await service.GetAll(function, model.Id, date).ToListAsync();
            }

            if (model.SelectTerm != null)
            {
                model.Values = await CreateTableView.AddTableToViewAsync(model.Values, model.SelectTerm.ToLower()).ToListAsync();
            }
        }
    }
}
