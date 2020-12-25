// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Documents
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Services.Mapping;
    using DataGate.Services.Slug;
    using DataGate.Web.Dtos.Queries;

    public class DistinctAgrViewModel : IMapFrom<DistinctAgrDto>
    {
        [Display(Name = "File Description")]
        public string Description { get; set; }

        [Display(Name = "File Name")]
        public string Name { get; set; }

        public int FileId { get; set; }

        public string SluggedName => $"{new SlugGenerator().Get(this.Name)}";
    }
}
