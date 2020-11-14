namespace DataGate.Web.ViewModels.Users
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Entities;

    public class UserPanelViewModel
    {
        public IEnumerable<TbPrimeShareClass> ShareClasses { get; set; }
    }
}
