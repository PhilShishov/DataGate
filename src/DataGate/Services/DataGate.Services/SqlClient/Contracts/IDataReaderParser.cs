// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.SqlClient.Contracts
{
    using System.Data;

    public interface IDataReaderParser
    {
        void Parse(IDataReader reader);
    }
}
