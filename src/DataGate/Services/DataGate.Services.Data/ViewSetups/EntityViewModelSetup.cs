// Service class for setting up
// view model properties

// Created: 04/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.ViewSetups
{
    using System;

    using DataGate.Services.DateTime;
    using DataGate.Web.ViewModels.Entities;

    public static class EntityViewModelSetup
    {
        public static void SetModel(EntitiesViewModel model, IEntityService<string[], string> service)
        {
            // ---------------------------------------------------------
            //
            // Available header column selection
            model.Headers = service.GetAllActive(null, 1);

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
                    model.Entities = service.GetAllActive(chosenDate, null, 1);
                }
                else if (!model.IsActive)
                {
                    model.Entities = service.GetAll(chosenDate, null, 1);
                }
            }

            if (model.SelectTerm != null)
            {
                model.Entities = CreateTableView.AddTableToView(model.Entities, model.SelectTerm.ToLower());
            }
        }

        private static void CallAllWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate, IEntityService<string[], string> service)
        {
            model.Entities = service
                .GetAllWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate);
        }

        private static void CallAllActiveWithSelectedColumns(EntitiesViewModel model, DateTime? chosenDate, IEntityService<string[], string> service)
        {
            model.Entities = service
                .GetAllActiveWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate);
        }
    }
}
