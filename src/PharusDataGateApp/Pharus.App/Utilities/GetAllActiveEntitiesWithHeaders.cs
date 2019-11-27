// Utility class for retrieving Active table data

// Created: 11/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Utilities
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Services.Contracts;
    using Pharus.App.Models.ViewModels.Entities;

    // _____________________________________________________________
    public class GetAllActiveEntitiesWithHeaders
    {
        // ________________________________________________________
        //
        // Empty and refill funds model
        // with headers and correct data
        // based on "Active" condition
        public static void GetAllActiveFundsWithHeaders(ActiveEntitiesViewModel model, IFundsService fundsService)
        {
            model.ActiveEntities = new List<string[]>();

            var tableHeaders = fundsService
                .GetAllActiveFunds()
                .Take(1)
                .ToList();
            var tableFundsWithoutHeaders = fundsService
                .GetAllActiveFunds()
                .Skip(1)
                .ToList()
                .Where(f => f.Contains("Active"))
                .ToList();

            model.ActiveEntities.AddRange(tableHeaders);
            model.ActiveEntities.AddRange(tableFundsWithoutHeaders);
        }

        // ________________________________________________________
        //
        // Empty and refill subfunds model
        // with headers and correct data
        // based on "Active" condition
        public static void GetAllActiveSubFundsWithHeaders(ActiveEntitiesViewModel model, ISubFundsService subFundsService)
        {
            model.ActiveEntities = new List<string[]>();

            var tableHeaders = subFundsService
                .GetAllActiveSubFunds()
                .Take(1)
                .ToList();
            var tableFundsWithoutHeaders = subFundsService
                .GetAllActiveSubFunds()
                .Skip(1)
                .ToList()
                .Where(f => f.Contains("Active"))
                .ToList();

            model.ActiveEntities.AddRange(tableHeaders);
            model.ActiveEntities.AddRange(tableFundsWithoutHeaders);
        }

        // ________________________________________________________
        //
        // Empty and refill shareclasses model
        // with headers and correct data
        // based on "Active" condition
        public static void GetAllActiveShareClassesWithHeaders(ActiveEntitiesViewModel model, IShareClassesService shareClassesService)
        {
            model.ActiveEntities = new List<string[]>();

            var tableHeaders = shareClassesService
                .GetAllActiveShareClasses()
                .Take(1)
                .ToList();
            var tableFundsWithoutHeaders = shareClassesService
                .GetAllActiveShareClasses()
                .Skip(1)
                .ToList()
                .Where(f => f.Contains("Active"))
                .ToList();

            model.ActiveEntities.AddRange(tableHeaders);
            model.ActiveEntities.AddRange(tableFundsWithoutHeaders);
        }
    }
}
