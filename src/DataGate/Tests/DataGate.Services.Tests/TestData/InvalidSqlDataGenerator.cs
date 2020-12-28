// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Tests.TestData
{
    using System;

    using Xunit;

    public class InvalidSqlDataGenerator : TheoryData<string, DateTime?, string[]>
    {
        public InvalidSqlDataGenerator()
        {
            this.Add("NOT_A_FUNCTION", DateTime.Now, new[] { "ID" });
            this.Add(null, DateTime.Now, new[] { "ID" });
            this.Add("", DateTime.Now, new[] { "ID" });
            this.Add("           ", DateTime.Now, new[] { "ID" });
            this.Add(SqlFunctionDictionary.AllFund, null, new[] { "ID" });
            this.Add(SqlFunctionDictionary.AllFund, DateTime.Now, new[] { "NOT_A_COLUMN" } );
            this.Add(SqlFunctionDictionary.AllFund, DateTime.Now, new[] { "      " } );
            this.Add(SqlFunctionDictionary.AllFund, null, new[] { "" } );
        }
    }
}