// Model class for view user

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.ViewModels.Users
{
    using System.Collections.Generic;

    public class UserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string LastLogin { get; set; }

        public bool IsLogged { get; set; }
    }
}
