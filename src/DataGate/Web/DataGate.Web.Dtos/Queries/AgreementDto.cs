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

        public int FileId { get; set; }

        public void Parse(IDataReader reader)
        {
            this.Description = reader["File Description"] as string;
            this.ContractDate = reader["Contract Date"] as string;
            this.ActivationDate = reader["Activation Date"] as string;
            this.ExpirationDate = reader["Expiration Date"] as string;
            this.Name = reader["File Name"] as string;
            this.FileId = (int)reader["File Id"];
        }
    }
}
