﻿// Service class for setting up
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
        public static void SetModel(EntitiesOverviewViewModel model, IEntityService<string[], string> service)
        {
            // ---------------------------------------------------------
            //
            // Available header column selection
            model.THeaders = service.GetAllActive(null, 1);
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
                    model.TValues = service.GetAllActive(chosenDate, null, 1);
                }
                else if (!model.IsActive)
                {
                    model.TValues = service.GetAll(chosenDate, null, 1);
                }
            }

            if (model.SelectTerm != null)
            {
                model.TValues = CreateTableView.AddTableToView(model.TValues, model.SelectTerm.ToLower());
            }
        }

        private static void CallAllWithSelectedColumns(EntitiesOverviewViewModel model, DateTime? chosenDate, IEntityService<string[], string> service)
        {
            model.TValues = service
                .GetAllWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate,
                            null,
                            1);

            model.THeaders = service
                .GetAllWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate,
                            1);
        }

        private static void CallAllActiveWithSelectedColumns(EntitiesOverviewViewModel model, DateTime? chosenDate, IEntityService<string[], string> service)
        {
            model.TValues = service
                .GetAllActiveWithSelectedViewAndDate(
                            model.PreSelectedColumns,
                            model.SelectedColumns,
                            chosenDate,
                            null,
                            1);

            model.THeaders = service
               .GetAllActiveWithSelectedViewAndDate(
                           model.PreSelectedColumns,
                           model.SelectedColumns,
                           chosenDate,
                           1);
        }
    }
}