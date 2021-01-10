// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.ViewSetups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Overviews;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.ViewModels.Entities;
    using DataGate.Web.ViewModels.Queries;

    public static class EntitiesVMSetup
    {
        public static async Task<T> SetGet<T>(IEntityService service, string functionActive, IEnumerable<string> userColumns)
        {
            bool isInLayoutMode = userColumns.Count() > 0;

            var today = DateTime.Today;
            var primeHeaders = await service.All(functionActive, null, today).FirstOrDefaultAsync();
            var headers = await service.All(functionActive, null, today).FirstOrDefaultAsync();
            var values = await service.All(functionActive, null, today, 1).ToListAsync();

            if (isInLayoutMode)
            {
                var dtoSelected = new AllSelectedDto
                {
                    Date = today,
                    PreSelectedColumns = headers.Take(GlobalConstants.PreSelectedColumnsCount).ToList(),
                    SelectedColumns = userColumns,                    
                };

                headers = await service.AllSelected(functionActive, dtoSelected).FirstOrDefaultAsync();
                values = await service.AllSelected(functionActive, dtoSelected, 1).ToListAsync();
            }

            var dto = new EntitiesOverviewGetDto()
            {
                IsActive = true,
                Date = DateTimeExtensions.ToWebFormat(today),
                HeadersSelection = primeHeaders,
                Headers = headers,
                Values = values,
                SelectedColumns = userColumns,
            };

            return AutoMapperConfig.MapperInstance.Map<T>(dto);
        }

        public static async Task SetPost(EntitiesViewModel model, IEntityService service, string functionAll, string functionActive)
        {
            var date = DateTimeExtensions.FromWebFormat(model.Date);

            var headers = await service.All(functionActive, null, date).FirstOrDefaultAsync();
            model.Headers = headers.ToList();
            model.HeadersSelection = headers.ToList();

            bool isInSelectionMode = model.SelectedColumns != null;

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
                    headers = await service.AllSelected(functionAll, dtoSelected).FirstOrDefaultAsync();
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
