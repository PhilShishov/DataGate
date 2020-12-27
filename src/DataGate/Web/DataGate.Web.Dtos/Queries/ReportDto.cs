// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class ReportDto : IDataReaderParser
    {
        public string FundName { get; set; }

        public string FundAdminSFCode { get; set; }

        public string SubFundName { get; set; }

        public string CCY { get; set; }

        public string NAVFrequency { get; set; }

        public string EOMNAVDate { get; set; }

        public decimal AuMInEUR { get; set; }

        public int FundId { get; set; }

        public int SubFundId { get; set; }

        public void Parse(IDataReader reader)
        {
            this.FundName = reader["Fund Name"] as string;
            this.FundAdminSFCode = reader["Fund Admin SF Code"] as string;
            this.SubFundName = reader["SubFund Name"] as string;
            this.CCY = reader["CCY"] as string;
            this.NAVFrequency = reader["NAV Frequency"] as string;
            this.EOMNAVDate = reader["EOM NAV date"] as string;
            this.AuMInEUR = (decimal)reader["AuM in EUR"];
            this.FundId = (int)reader["Fund Id"];
            this.SubFundId = (int)reader["SubFund Id"];
        }
    }
}
