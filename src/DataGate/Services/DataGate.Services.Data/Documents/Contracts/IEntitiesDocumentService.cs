// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Documents.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IEntitiesDocumentService
    {
        IEnumerable<T> GetDistinctDocuments<T>(string function, int id, DateTime? date);

        IEnumerable<T> GetDistinctAgreements<T>(string function, int id, DateTime? date);

        IEnumerable<T> GetDocuments<T>(string function, int id);

        IEnumerable<T> GetAgreements<T>(string function, int id, DateTime? date);
    }
}
