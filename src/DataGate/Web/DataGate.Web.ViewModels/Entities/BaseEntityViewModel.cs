// Abstract model class view entity
// for code reuse

// Created: 11/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.ViewModels.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseEntityViewModel
    {
        [BindProperty]
        public List<string[]> Values { get; set; }

        [BindProperty]
        public List<string[]> Headers { get; set; }

        //public IEnumerable<EntitiesViewModel> Entities { get; set; }

        public IEnumerable<string[]> HeadersSelection { get; set; }

        [Required(ErrorMessage = ErrorMessages.ChosenDateIsEmpty)]
        public string Date { get; set; }

        public string Command { get; set; }

        public int Id { get; set; }

        public string SelectTerm { get; set; }

        public IReadOnlyCollection<string> PreSelectedColumns { get; set; }

        public IEnumerable<string> SelectedColumns { get; set; }
    }
}
