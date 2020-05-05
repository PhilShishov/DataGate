// Service class for setting up
// view model properties

// Created: 04/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.ViewSetups
{
    using System;
    using System.Linq;

    using DataGate.Services.DateTime;
    using DataGate.Services.Mapping;
    using DataGate.Web.ViewModels.Entities;

    public static class EntityViewModelSetup
    {
        public static void SetModel(EntitiesOverviewViewModel model, IEntityService service)
        {
            // ---------------------------------------------------------
            //
            // Available header column selection
            var headers = service.GetAllActive(null, 1);
            model.Headers = headers.ToList();
            model.HeadersSelection = headers;

            bool isInSelectionMode = false;

            if (model.SelectedColumns != null)
            {
                isInSelectionMode = true;
            }

            DateTime? chosenDate = null;

            if (model.Date != null)
            {
                chosenDate = DateTimeParser.WebFormat(model.Date);
            }

            if (isInSelectionMode)
            {
                var dto = AutoMapperConfig.MapperInstance.Map<GetWithSelectionDto>(model);

                if (model.IsActive)
                {
                    CallAllActiveWithSelectedColumns(model, dto, service);
                }
                else if (!model.IsActive)
                {
                    CallAllWithSelectedColumns(model, dto, service);
                }
            }
            else if (!isInSelectionMode)
            {
                if (model.IsActive)
                {
                    model.Values = service.GetAllActive(chosenDate, null, 1).ToList();
                }
                else if (!model.IsActive)
                {
                    model.Values = service.GetAll(chosenDate, null, 1).ToList();
                }
            }

            if (model.SelectTerm != null)
            {
                model.Values = CreateTableView.AddTableToView(model.Values, model.SelectTerm.ToLower());
            }
        }

        private static void CallAllWithSelectedColumns(EntitiesOverviewViewModel model, GetWithSelectionDto dto, IEntityService service)
        {
            model.Values = service
                .GetAllWithSelectedViewAndDate(
                            dto,
                            null,
                            1)
                .ToList();

            model.Headers = service
                .GetAllWithSelectedViewAndDate(
                            dto,
                            1)
                .ToList();
        }

        private static void CallAllActiveWithSelectedColumns(EntitiesOverviewViewModel model, GetWithSelectionDto dto, IEntityService service)
        {
            model.Values = service
                .GetAllActiveWithSelectedViewAndDate(
                            dto,
                            null,
                            1)
                .ToList();

            model.Headers = service
               .GetAllActiveWithSelectedViewAndDate(
                          dto,
                           1)
               .ToList();
        }
    }
}
