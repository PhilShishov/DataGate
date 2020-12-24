// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Documents.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IEntitiesDocumentService
    {
        IEnumerable<TDestination> GetDistinctDocuments<TDestination>(string function, int id, DateTime? date);

        IEnumerable<TDestination> GetDistinctAgreements<TDestination>(string function, int id, DateTime? date);

        IEnumerable<TDestination> GetDocuments<TDestination>(string function, int id);

        IEnumerable<TDestination> GetAgreements<TDestination>(string function, int id, DateTime? date);
    }
}
