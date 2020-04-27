namespace DataGate.Web.InputModels.ShareClasses
{
    using System.ComponentModel.DataAnnotations;

    public class EditShareClassInputModel : ShareClassInputModel
    {
        [Required]
        [Display(Name = "Comment Title")]
        public string CommentTitle { get; set; }

        [Display(Name = "Comment Description")]
        public string CommentArea { get; set; }
    }
}
