using DataGate.Services.SqlClient.Contracts;
using System.Data;

namespace DataGate.Web.Dtos.Queries
{
    public class DistinctDocDto : IDataReaderParser
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public void Parse(IDataReader reader)
        {
            Description = reader["File Description"].ToString();
            Name = reader["File Name"].ToString();
        }
    }
}