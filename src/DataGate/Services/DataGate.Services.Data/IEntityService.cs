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

    public interface IEntityService<T, TS>
    {
        IEnumerable<T> GetAll(DateTime? chosenDate = null, int? take = null, int skip = 0);

        IEnumerable<T> GetAllActive(DateTime? chosenDate = null, int? take = null, int skip = 0);

        IEnumerable<T> GetAllWithSelectedViewAndDate(
                        IReadOnlyCollection<TS> preSelectedColumns,
                        IEnumerable<TS> selectedColumns,
                        DateTime? chosenDate);

        IEnumerable<T> GetAllActiveWithSelectedViewAndDate(
                        IReadOnlyCollection<TS> preSelectedColumns,
                        IEnumerable<TS> selectedColumns,
                        DateTime? chosenDate);
    }
}
