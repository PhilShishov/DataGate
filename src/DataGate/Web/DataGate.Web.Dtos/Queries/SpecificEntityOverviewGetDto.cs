using System;
using System.Collections.Generic;

namespace DataGate.Web.Dtos.Queries
{
    public class SpecificEntityOverviewGetDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<string[]> Entity { get; set; }
    }
}