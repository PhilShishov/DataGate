// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Dtos.Queries
{
    public class QueriesToPassDto
    {
        public string SqlFunctionById { get; set; }

        public string SqlFunctionActiveSE { get; set; }

        public string SqlFunctionDistinctDocuments { get; set; }

        public string SqlFunctionDistinctAgreements { get; set; }

        public string SqlFunctionContainer { get; set; }
    }
}
