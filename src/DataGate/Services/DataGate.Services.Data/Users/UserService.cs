// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Data.Models.Users;
    using DataGate.Web.InputModels.Users;
    using DataGate.Web.ViewModels.Users;

    using Microsoft.AspNetCore.Identity;

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<IEnumerable<UserViewModel>> All()
        {
            var usersViewList = new List<UserViewModel>();
            var users = this.userManager.Users
                .OrderByDescending(u => u.LastLoginTime)
                .ToList();

            foreach (var user in users)
            {
                var roles = await this.userManager.GetRolesAsync(user);
                var userView = new UserViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = roles,
                    LastLogin = user.LastLoginTime,
                };

                usersViewList.Add(userView);
            }

            return usersViewList;
        }

        public async Task<DeleteUserInputModel> ByIdDelete(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            Validator.EntityNotFoundException(user);
            var roles = await this.userManager.GetRolesAsync(user);

            DeleteUserInputModel model = new DeleteUserInputModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                RoleType = roles.FirstOrDefault(),
            };

            return model;
        }

        public async Task<EditUserInputModel> ByIdEdit(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            Validator.EntityNotFoundException(user);
            var roles = await this.userManager.GetRolesAsync(user);

            var model = new EditUserInputModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                RoleType = roles.FirstOrDefault(),
            };

            return model;
        }

        public Task<ApplicationUser> ByUsername(string username)
            => this.userManager.FindByNameAsync(username);

        public async Task<IdentityResult> Create(CreateUserInputModel input)
        {
            var user = new ApplicationUser
            {
                UserName = input.Username,
                Email = input.Email,
            };

            var result = await this.userManager.CreateAsync(user, input.Password);

            if (result.Succeeded)
            {
                await this.AssignRole(input, user);
            }

            return result;
        }

        public async Task<IdentityResult> Delete(DeleteUserInputModel input)
        {
            var user = await this.userManager.FindByIdAsync(input.Id);
            Validator.EntityNotFoundException(user);
            var roles = await this.userManager.GetRolesAsync(user);

            await this.userManager.RemoveFromRoleAsync(user, roles.FirstOrDefault());
            return await this.userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> Edit(EditUserInputModel input)
        {
            var user = await this.userManager.FindByIdAsync(input.Id);
            Validator.EntityNotFoundException(user);
            var roles = await this.userManager.GetRolesAsync(user);

            user.UserName = input.Username;
            user.Email = input.Email;

            var newRole = input.RoleType;
            var oldRole = roles.FirstOrDefault();

            if (await this.roleManager.RoleExistsAsync(newRole))
            {
                if (newRole != oldRole)
                {
                    await this.userManager.RemoveFromRoleAsync(user, oldRole);
                    await this.userManager.AddToRoleAsync(user, newRole);
                }
            }

            var hasher = new PasswordHasher<ApplicationUser>();

            if (user.PasswordHash != input.PasswordHash && input.PasswordHash != null)
            {
                var newPassword = hasher.HashPassword(user, input.PasswordHash);
                user.PasswordHash = newPassword;
            }

            return await this.userManager.UpdateAsync(user);
        }

        public Task<string> GenerateEmailToken(ApplicationUser user)
            => this.userManager.GenerateEmailConfirmationTokenAsync(user);

        public IEnumerable<ApplicationRole> Roles() => this.roleManager.Roles.ToList();

        private async Task AssignRole(CreateUserInputModel input, ApplicationUser user)
        {
            var role = input.RoleType;
            var roleExist = await this.roleManager.RoleExistsAsync(role);

            if (roleExist)
            {
                await this.userManager.AddToRoleAsync(user, role);
            }
        }
    }
}