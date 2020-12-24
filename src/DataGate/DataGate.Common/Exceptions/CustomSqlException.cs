// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Common.Exceptions
{
    using System;
    using System.Data.SqlClient;

    public class CustomSqlException : Exception
    {
        public CustomSqlException()
        {
        }

        public CustomSqlException(string message, SqlException innerException)
            : base(message, innerException)
        {
        }
    }
}
