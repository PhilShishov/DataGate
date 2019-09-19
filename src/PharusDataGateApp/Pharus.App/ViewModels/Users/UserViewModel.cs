namespace Pharus.App.ViewModels.Users
{
    using System;
    using System.Collections.Generic;

    public class UserViewModel
    {
        public string Username { get; set; }

        public string Role { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsLogged { get; set; }
    }
}
