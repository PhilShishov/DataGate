// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.ViewSetups
{
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Services.Data.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Overviews;
    using DataGate.Web.Dtos.Queries;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;

    public class SubEntitiesVMSetup
    {
        public static async Task<T> SetLoadedGet<T>(IEntityService service, 
                                                    IEntityException exceptionService,
                                                    EntitySubEntitiesGetDto dto, string function)
        {
            var date = DateTimeExtensions.FromWebFormat(dto.Date);
            var entities = await service.All(function, dto.Id, date).ToListAsync();

            dto.Entities = entities;

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public static async Task<T> SetGet<T>(IEntityService service, IEntityException exceptionService,
                                              SubEntitiesGetDto dto, string function)
        {
            var date = DateTimeExtensions.FromWebFormat(dto.Date);
            var values = await service.All(function, dto.Id, date, 1).ToListAsync();
            var headers = await service.All(function, dto.Id, date).FirstOrDefaultAsync();

            dto.Values = values;
            dto.Headers = headers;
            dto.HeadersSelection = headers;

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public static async Task SetPost(SubEntitiesViewModel model, IEntityService service, string function)
        {
            var date = DateTimeExtensions.FromWebFormat(model.Date);
            var headers = await service.All(function, model.Id, date).FirstOrDefaultAsync();
            model.Headers = headers.ToList();
            model.HeadersSelection = headers.ToList();

            bool isInSelectionMode = model.SelectedColumns != null;

            if (isInSelectionMode)
            {
                var dto = AutoMapperConfig.MapperInstance.Map<AllSelectedDto>(model);

                model.Values = await service.AllSelected(function, dto, 1).ToListAsync();
                headers = await service.AllSelected(function, dto).FirstOrDefaultAsync();
                model.Headers = headers.ToList();
            }
            else if (!isInSelectionMode)
            {
                model.Values = await service.All(function, model.Id, date).ToListAsync();
            }
        }
    }
}
