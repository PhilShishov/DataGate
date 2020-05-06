namespace DataGate.Web.ViewModels.Documents
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class AllDocViewModel : IMapFrom<AllDocDto>
    {
        [Display(Name = "File Description")]
        public string Description { get; set; }

        [Display(Name = "Valid From:")]
        public string ValidFrom { get; set; }

        [Display(Name = "Valid Until: ")]
        public string ValidUntil { get; set; }

        [Display(Name = "File Name")]
        public string Name { get; set; }

        [Display(Name = "File Type")]
        public string Type { get; set; }
    }
}
