// Interface model for bind entity

// Created: 10/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace Pharus.App.Models.BindingModels.Contracts
{
    using System.Collections.Generic;

    public interface IBaseEditEntityBindingModel
    {
        List<string[]> EntityProperties { get; set; }
    }
}
