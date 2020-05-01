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

    public interface IEntityService<T>
    {
        IEnumerable<T> GetAll(DateTime? chosenDate);

        IEnumerable<T> GetAllActive();

        IEnumerable<T> GetAllActive(DateTime? chosenDate);

        IEnumerable<T> GetAllWithSelectedViewAndDate(
                        List<string> preSelectedColumns,
                        List<string> selectedColumns,
                        DateTime? chosenDate);

        IEnumerable<T> GetAllActiveWithSelectedViewAndDate(
                        List<string> preSelectedColumns,
                        List<string> selectedColumns,
                        DateTime? chosenDate);
    }
}
