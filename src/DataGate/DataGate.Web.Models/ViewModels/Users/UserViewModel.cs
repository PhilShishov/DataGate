// Model class for view user

// Created: 09/2019
// Author:  Philip Shishov

// -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
namespace DataGate.Web.Models.ViewModels.Users
{
    public class UserViewModel
    {
        public string Username { get; set; }

        public string Role { get; set; }

        public string LastLogin { get; set; }

        public bool IsLogged { get; set; }
    }
}
