// Abstract model class for bind entity
// for code reuse

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels
{
    using System.Collections.Generic;

    using Pharus.App.Models.BindingModels.Contracts;

    public abstract class BaseEntityBindingModel : IBaseEntityBindingModel
    {
        public List<string[]> EntityProperties { get; set; }
    }
}
