namespace DataGate.Web.InputModels.Files
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;

    public class GenerateFileInputModel
    {
        public List<string[]> Entities { get; set; }

        [Required(ErrorMessage = ErrorMessages.ChosenDateIsEmpty)]
        public string ChosenDate { get; set; }

        public int Count => this.Entities.Count;
    }
}