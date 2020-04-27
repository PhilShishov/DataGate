namespace DataGate.Web.InputModels.Funds
{
    using System.ComponentModel.DataAnnotations;

    public class EditFundInputModel : FundInputModel
    {
        [Required]
        [Display(Name = "Comment Title")]
        public string CommentTitle { get; set; }

        [Display(Name = "Comment Description")]
        public string CommentArea { get; set; }
    }
}
