// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
// Abstract model class view entity
// for code reuse

// Created: 11/2020
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.ViewModels.Entities
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;

    public abstract class BaseEntityViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.DateRequired)]
        public string Date { get; set; }

        public string Command { get; set; }
    }
}
