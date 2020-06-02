namespace DataGate.Web.ViewModels.Files
{
    using System.Collections.Generic;

    public class ExtractViewModel
    {
        public List<string> Headers { get; set; }

        public List<string> Names { get; set; }

        public List<string[]> Values { get; set; }
    }
}
