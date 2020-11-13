// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Base service interface for managing services of
// different entities - funds, subfunds, shareclasse

// Created: 05/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data.Entities
{
    using System;
    using System.Collections.Generic;

    using DataGate.Web.ViewModels.Queries;

    public interface IEntityService
    {
        IAsyncEnumerable<string[]> All(
                                    string function,
                                    int? id = null,
                                    DateTime? date = null,
                                    int skip = 0);

        IAsyncEnumerable<string[]> AllSelected(
                                        string function,
                                        AllSelectedDto dto, 
                                        int skip = 0);
    }
}
