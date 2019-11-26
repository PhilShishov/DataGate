namespace Pharus.App.Models.BindingModels
{
    using System.Collections.Generic;

    using Pharus.App.Models.BindingModels.Contracts;

    public class BaseBindingModel : IBaseBindingModel
    {
        public List<string[]> EntityProperties { get; set; }
    }
}
