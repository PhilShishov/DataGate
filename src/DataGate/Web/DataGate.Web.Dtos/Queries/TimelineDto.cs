namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class TimelineDto : IDataReaderParser
    {
        public string InitialDate { get; set; }

        public string EndDate { get; set; }

        public string Comment { get; set; }

        public string Title { get; set; }

        public void Parse(IDataReader reader)
        {
            Comment = reader["f_change_comment"] as string;
            Title = reader["f_comment_title"] as string;
            EndDate = reader["f_endDate"] as string;
            InitialDate = reader["f_initialDate"] as string;
        }
    }
}