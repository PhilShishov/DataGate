// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class AgreementLibraryDto : IDataReaderParser
    {
        public string Description { get; set; }

        public string CompanyName { get; set; }

        public string ContractDate { get; set; }

        public string ActivationDate { get; set; }

        public string ExpirationDate { get; set; }

        public string Name { get; set; }

        public int FileId { get; set; }

        public void Parse(IDataReader reader)
        {
            this.Description = reader["File Description"] as string;
            this.CompanyName = reader["Company Name"] as string;
            this.ContractDate = reader["Contract Date"] as string;
            this.ActivationDate = reader["Activation Date"] as string;
            this.ExpirationDate = reader["Expiration Date"] as string;
            this.Name = reader["File Name"] as string;
            this.FileId = (int)reader["File Id"];
        }
    }
}
