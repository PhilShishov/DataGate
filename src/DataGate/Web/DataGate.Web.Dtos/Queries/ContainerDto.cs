namespace DataGate.Web.Dtos.Queries
{
    using System.Data;

    using DataGate.Services.SqlClient.Contracts;

    public class ContainerDto : IDataReaderParser
    {
        public string ContainerName { get; set; }

        public int ContainerId { get; set; }

        public void Parse(IDataReader reader)
        {
            this.ContainerName = reader["NAME"] as string;
            this.ContainerId = (int)reader["ID"];
        }
    }
}
