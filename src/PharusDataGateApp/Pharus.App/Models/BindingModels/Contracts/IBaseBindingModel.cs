namespace Pharus.App.Models.BindingModels.Contracts
{
    using System.Collections.Generic;

    public interface IBaseBindingModel
    {
        List<string[]> EntityProperties { get; set; }
    }
}
