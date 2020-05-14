namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class DocumentDto : IDataReaderParser
    {
        public string Description { get; set; }

        public string ValidFrom { get; set; }

        public string ValidUntil { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public void Parse(IDataReader reader)
        {
            Description = reader["File Description"] as string;
            ValidFrom = reader["Valid from:"] as string;
            ValidUntil = reader["Valid until:"] as string;
            Name = reader["File Name"] as string;
            Type = reader["File Type"] as string;
        }
    }
}