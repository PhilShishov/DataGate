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
        public static void SetModel(EntitiesViewModel model, IEntityService<string[]> service)
        {
            // ---------------------------------------------------------
            //
            // Available header column selection
            model.EntitiesHeadersForColumnSelection = service
                                                            .GetAllActive()
                                                            .Take(1)
                                                            .ToList();

            bool isInSelectionMode = false;

            if (model.SelectedColumns != null && model.SelectedColumns.ToList().Count > 0)
            {
                isInSelectionMode = true;
            }

            DateTime? chosenDate = null;

            if (model.ChosenDate != null)
            {
                chosenDate = DateTimeParser.WebFormat(model.ChosenDate);
            }

            if (isInSelectionMode)
            {
                if (model.IsActive)
                {
                    CallActiveEntitiesWithSelectedColumns(model, chosenDate, service);
                }
                else if (!model.IsActive)
                {
                    CallAllEntitiesWithSelectedColumns(model, chosenDate, service);
                }
            }
            else if (!isInSelectionMode)
            {
                if (model.IsActive)
                {
                    model.Entities = service.GetAllActive(chosenDate).ToList();
                }
                else if (!model.IsActive)
                {
                    model.Entities = service.GetAll(chosenDate).ToList();
                }
            }

            if (model.SelectTerm != null)
            {
                model.Entities = CreateTableView.AddTableToView(model.Entities.ToList(), model.SelectTerm.ToLower());
            }
        }

        private static void CallAllEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate, IEntityService<string[]> service)
        {
            model.Entities = service
                .GetAllWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate)
                .ToList();
        }

        private static void CallActiveEntitiesWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate, IEntityService<string[]> service)
        {
            model.Entities = service
                .GetAllActiveWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate)
                .ToList();
        }
    }
}
