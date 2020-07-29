// Abstract model class view entity
// for code reuse

// Created: 11/2019
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
