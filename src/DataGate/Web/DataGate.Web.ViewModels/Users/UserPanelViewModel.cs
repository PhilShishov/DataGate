namespace DataGate.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using DataGate.Data.Models.Entities;
    using DataGate.Data.Models.Users;

    public class UserPanelViewModel
    {
        public IEnumerable<TbPrimeShareClass> ShareClasses { get; set; }

        public IEnumerable<RecentlyViewed> RecentlyViewed { get; set; }
    }
}
