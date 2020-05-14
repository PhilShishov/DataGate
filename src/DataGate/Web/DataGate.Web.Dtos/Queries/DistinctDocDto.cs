using DataGate.Services.SqlClient.Contracts;
using System.Data;

namespace DataGate.Web.Dtos.Queries
{
    public class DistinctDocDto : IDataReaderParser
    {
        public string Description { get; set; }

        public string DocumentName { get; set; }

        public void Parse(IDataReader reader)
        {
            Description = reader["File Description"] as string;
            DocumentName = reader["File Name"] as string;
        }
    }
}