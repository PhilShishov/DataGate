namespace DataGate.Web.ViewModels.Documents
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Queries;

    public class DistinctAgrViewModel : IMapFrom<DistinctAgrDto>
    {
        [Display(Name = "File Description")]
        public string Description { get; set; }

        [Display(Name = "File Name")]
        public string AgreementName { get; set; }

        public int FileId { get; set; }
    }
}
