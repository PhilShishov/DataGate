namespace DataGate.Web.Models.BindingModels.ShareClasses
{
    using System.ComponentModel.DataAnnotations;

    public class EditShareClassBindingModel : ShareClassBindingModel
    {
        [Required]
        [Display(Name = "Comment Title")]
        public string CommentTitle { get; set; }

        [Display(Name = "Comment Description")]
        public string CommentArea { get; set; }
    }
}
