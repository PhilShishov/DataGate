namespace DataGate.Web.Dtos.Queries
{
    using DataGate.Services.SqlClient.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class AllDocDto : IDataReaderParser
    {
        public string Description { get; set; }

        public string ValidFrom { get; set; }

        public string ValidUntil { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public void Parse(IDataReader reader)
        {
            Description = reader["File Description"].ToString();
            ValidFrom = reader["Valid from:"].ToString();
            ValidUntil = reader["Valid until:"].ToString();
            Name = reader["File Name"].ToString();
            Type = reader["File Type"].ToString();
        }
    }
}