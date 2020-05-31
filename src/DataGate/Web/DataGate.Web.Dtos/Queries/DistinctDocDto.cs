namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class DistinctDocDto : IDataReaderParser
    {
        public string Description { get; set; }

        public string DocumentName { get; set; }

        public int FileId { get; set; }

        public void Parse(IDataReader reader)
        {
            Description = reader["File Description"] as string;
            DocumentName = reader["File Name"] as string;
            FileId = (int)reader["File Id"];
        }
    }
}
