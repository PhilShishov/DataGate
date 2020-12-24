// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class CountryDistDto : IDataReaderParser
    {
        public int Id { get; set; }

        public string IsoCountry { get; set; }

        public string LocalRepresentative { get; set; }

        public string PayingAgent { get; set; }

        public string LegalSupport { get; set; }

        public string Language { get; set; }

        public void Parse(IDataReader reader)
        {
            this.Id = (int)reader["ID"];
            this.IsoCountry = reader["Country of Distribution"] as string;
            //this.LocalRepresentative = reader["Local Representative"] as string;
            //this.PayingAgent = reader["Paying Agent"] as string;
            //this.LegalSupport = reader["Legal Support"] as string;
            this.Language = reader["Language"] as string;
        }
    }
}
