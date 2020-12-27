// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class ContainerDto : IDataReaderParser
    {
        public string ContainerName { get; set; }

        public int ContainerId { get; set; }

        public void Parse(IDataReader reader)
        {
            this.ContainerName = reader["NAME"] as string;
            this.ContainerId = (int)reader["ID"];
        }
    }
}
