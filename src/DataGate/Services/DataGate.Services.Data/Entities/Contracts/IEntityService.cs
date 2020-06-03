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
        IAsyncEnumerable<string[]> GetAll(
                                    string function,
                                    int? id = null,
                                    DateTime? date = null,
                                    int skip = 0);

        IAsyncEnumerable<string[]> GetAllSelected(
                                    string function,
                                    GetWithSelectionDto dto,
                                    int skip = 0);
    }
}
