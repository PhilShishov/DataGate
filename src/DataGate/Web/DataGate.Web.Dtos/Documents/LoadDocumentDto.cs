namespace DataGate.Web.Dtos.Documents
{
    using System;

    public class LoadDocumentDto
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public DateTime StartConnection { get; set; }

        public DateTime? EndConnection { get; set; }

        public string RouteName { get; set; }

        public string AreaName { get; set; }
    }
}
