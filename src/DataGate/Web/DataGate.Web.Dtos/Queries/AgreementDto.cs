namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class AgreementDto : IDataReaderParser
    {
        public string Description { get; set; }

        public string ContractDate { get; set; }

        public string ActivationDate { get; set; }

        public string ExpirationDate { get; set; }

        public string Name { get; set; }

        public void Parse(IDataReader reader)
        {
            Description = reader["File Description"] as string;
            ContractDate = reader["Contract Date"] as string;
            ActivationDate = reader["Activation Date"] as string;
            ExpirationDate = reader["Expiration Date"] as string;
            Name = reader["File Name"] as string;
        }
    }
}