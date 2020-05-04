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

    public interface IEntityService
    {
        IEnumerable<string[]> GetAll(DateTime? chosenDate = null, int? take = null, int skip = 0);

        IEnumerable<string[]> GetAllActive(DateTime? chosenDate = null, int? take = null, int skip = 0);

        T GetEntitiesOverview<T>();

        IEnumerable<string[]> GetAllWithSelectedViewAndDate(
                                        IReadOnlyCollection<string> preSelectedColumns,
                                        IEnumerable<string> selectedColumns,
                                        DateTime? chosenDate,
                                        int? take = null,
                                        int skip = 0);

        IEnumerable<string[]> GetAllActiveWithSelectedViewAndDate(
                                        IReadOnlyCollection<string> preSelectedColumns,
                                        IEnumerable<string> selectedColumns,
                                        DateTime? chosenDate,
                                        int? take = null,
                                        int skip = 0);
    }
}
