// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.ViewModels.Search
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Data.Models.Entities;
    using DataGate.Services.Mapping;

    public class SearchViewModel : IMapFrom<TbPrimeShareClass>
    {
        public int ScId { get; set; }

        [Display(Name = "ISIN")]
        public string ScIsinCode { get; set; }

        [Display(Name = "Share class name")]
        public string ScOfficialShareClassName { get; set; }
    }
}
