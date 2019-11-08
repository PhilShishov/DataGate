using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pharus.App.Models.BindingModels.ShareClasses
{
    public class EditShareClassBindingModel : BaseBindingModel
    {
        public SelectList InvestorType { get; set; }
        public SelectList CurrencyCode { get; set; }
        public SelectList ShareStatus { get; set; }
        public SelectList ShareType { get; set; }
    }
}
