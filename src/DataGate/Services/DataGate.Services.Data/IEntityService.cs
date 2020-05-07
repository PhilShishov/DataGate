// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Base service interface for managing services of
// different entities - funds, subfunds, shareclasse

// Created: 05/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Services.Data
{
    using System;
    using System.Collections.Generic;

    using DataGate.Web.ViewModels.Queries;

    public interface IEntityService
    {
        IEnumerable<string[]> GetAll(DateTime? date = null, int? take = null, int skip = 0);

        ISet<string> GetNames();

        IEnumerable<string> GetHeaders();

        IEnumerable<string[]> GetAllActive(DateTime? date = null, int? take = null, int skip = 0);

        IEnumerable<string[]> GetAllSelected(
                                        GetWithSelectionDto dto,
                                        int? take = null,
                                        int skip = 0);

        IEnumerable<string[]> GetAllActiveSelected(
                                        GetWithSelectionDto dto,
                                        int? take = null,
                                        int skip = 0);
    }
}
