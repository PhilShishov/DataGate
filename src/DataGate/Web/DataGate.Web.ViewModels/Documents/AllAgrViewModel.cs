namespace DataGate.Web.ViewModels.Documents
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class AllAgrViewModel : IMapFrom<AllAgrDto>
    {
        [Display(Name = "File Description")]
        public string Description { get; set; }

        [Display(Name = "Contract Date")]
        public string ContractDate { get; set; }

        [Display(Name = "Activation Date")]
        public string ActivationDate { get; set; }

        [Display(Name = "Expiration Date")]
        public string ExpirationDate { get; set; }

        [Display(Name = "File Name")]
        public string Name { get; set; }
    }
}
