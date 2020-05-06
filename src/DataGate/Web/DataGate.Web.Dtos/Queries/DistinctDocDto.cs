using System.Data;

namespace DataGate.Web.Dtos.Queries
{
    public class DistinctDocDto
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public static DistinctDocDto Create(IDataRecord record)
        {
            return new DistinctDocDto
            {
                Description = record["File Description"].ToString(),
                Name = record["File Name"].ToString(),
            };
        }
    }
}