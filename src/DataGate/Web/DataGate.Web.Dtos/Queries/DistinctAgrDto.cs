namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class DistinctAgrDto : IDataReaderParser
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public int FileId { get; set; }

        public void Parse(IDataReader reader)
        {
            this.Description = reader["File Description"] as string;
            this.Name = reader["File Name"] as string;
            this.FileId = (int)reader["File Id"];
        }
    }
}
