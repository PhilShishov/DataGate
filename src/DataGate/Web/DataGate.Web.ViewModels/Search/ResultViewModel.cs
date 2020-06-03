namespace DataGate.Web.ViewModels.Search
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Data.Models.Entities;
    using DataGate.Services.Mapping;

    public class ResultViewModel : IMapFrom<TbHistoryShareClass>
    {
        public string ScId { get; set; }

        [Display(Name = "ISIN")]
        public string ScIsinCode { get; set; }

        [Display(Name = "Share class name")]
        public string ScOfficialShareClassName { get; set; }
    }
}
