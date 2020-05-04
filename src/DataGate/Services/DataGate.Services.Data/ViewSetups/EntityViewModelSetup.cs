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
    using DataGate.Web.ViewModels.Entities;

    public static class EntityViewModelSetup
    {
        public static void SetModel(EntitiesOverviewViewModel model, IEntityService service)
        {
            // ---------------------------------------------------------
            //
            // Available header column selection
            model.Headers = service.GetAllActive(null, 1).ToList();
            model.HeadersSelection = service.GetAllActive(null, 1);

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
                if (model.IsActive)
                {
                    CallAllActiveWithSelectedColumns(model, chosenDate, service);
                }
                else if (!model.IsActive)
                {
                    CallAllWithSelectedColumns(model, chosenDate, service);
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

        private static void CallAllWithSelectedColumns(EntitiesOverviewViewModel model, DateTime? chosenDate, IEntityService service)
        {
            model.Values = service
                .GetAllWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate,
                            null,
                            1)
                .ToList();

            model.Headers = service
                .GetAllWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate,
                            1)
                .ToList();
        }

        private static void CallAllActiveWithSelectedColumns(EntitiesOverviewViewModel model, DateTime? chosenDate, IEntityService service)
        {
            model.Values = service
                .GetAllActiveWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate,
                            null,
                            1)
                .ToList();

            model.Headers = service
               .GetAllActiveWithSelectedViewAndDate(
                           model.PreSelectedColumns,
                           model.SelectedColumns,
                           chosenDate,
                           1)
               .ToList();
        }
    }
}
