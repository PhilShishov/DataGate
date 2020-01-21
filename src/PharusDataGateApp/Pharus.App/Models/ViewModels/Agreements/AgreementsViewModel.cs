namespace Pharus.App.Models.ViewModels.Agreements
{
    using System.Collections.Generic;

    public class AgreementsViewModel
    {
        public string ChosenDate { get; set; }

        public string SelectedItem { get; set; }

        public string SearchTerm { get; set; }

        public string Command { get; set; }

        public List<string[]> EntityDocuments { get; set; }
    }
}
