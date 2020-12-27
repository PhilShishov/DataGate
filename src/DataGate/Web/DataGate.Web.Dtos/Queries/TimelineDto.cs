// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class TimelineDto : IDataReaderParser
    {
        public int Id { get; set; }

        public string InitialDate { get; set; }

        public string EndDate { get; set; }

        public string Comment { get; set; }

        public string Title { get; set; }

        public void Parse(IDataReader reader)
        {
            this.Id = (int)reader["ID"];
            this.Comment = reader["COMMENT"] as string;
            this.Title = reader["COMMENT TITLE"] as string;
            this.EndDate = reader["END DATE"] as string;
            this.InitialDate = reader["INITIAL DATE"] as string;
        }
    }
}
