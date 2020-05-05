namespace DataGate.Web.InputModels.Files
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;

    public class DownloadInputModel
    {
        public IEnumerable<string> Headers { get; set; }

        public List<string[]> Values { get; set; }

        [Required(ErrorMessage = ErrorMessages.ChosenDateIsEmpty)]
        public string ChosenDate { get; set; }

        public string ControllerName { get; set; }

        public string Command { get; set; }
    }
}