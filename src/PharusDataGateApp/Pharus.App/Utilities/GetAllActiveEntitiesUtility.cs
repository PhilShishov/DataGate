﻿// Utility class for retrieving Active table data

// Created: 11/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Utilities
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Pharus.Services.Funds.Contracts;
    using Pharus.Services.SubFunds.Contracts;
    using Pharus.App.Models.ViewModels.Entities;
    using Pharus.Services.ShareClasses.Contracts;

    // _____________________________________________________________
    public class GetAllActiveEntitiesUtility
    {
        // ________________________________________________________
        //
        // Empty and refill funds model
        // with headers and correct data
        // based on "Active" condition
        public static void GetAllActiveFundsWithHeaders(EntitiesViewModel model, IFundsService fundsService)
        {
            model.Entities = new List<string[]>();

            var tableHeaders = fundsService
                .GetAllFunds()
                .Take(1)
                .ToList();
            var tableFundsWithoutHeaders = fundsService
                .GetAllFunds()
                .Skip(1)
                .ToList()
                .Where(f => f.Contains("Active"))
                .ToList();

            model.Entities.AddRange(tableHeaders);
            model.Entities.AddRange(tableFundsWithoutHeaders);
        }       

        // ________________________________________________________
        //
        // Empty and refill subfunds model
        // with headers and correct data
        // based on "Active" condition
        public static void GetAllActiveSubFundsWithHeaders(EntitiesViewModel model, ISubFundsService subFundsService)
        {
            model.Entities = new List<string[]>();

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

            model.Entities.AddRange(tableHeaders);
            model.Entities.AddRange(tableFundsWithoutHeaders);
        }

        // ________________________________________________________
        //
        // Empty and refill shareclasses model
        // with headers and correct data
        // based on "Active" condition
        public static void GetAllActiveShareClassesWithHeaders(EntitiesViewModel model, IShareClassesService shareClassesService)
        {
            model.Entities = new List<string[]>();

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

            model.Entities.AddRange(tableHeaders);
            model.Entities.AddRange(tableFundsWithoutHeaders);
        }
    }
}
