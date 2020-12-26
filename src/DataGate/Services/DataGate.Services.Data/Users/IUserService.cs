// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataGate.Data.Models.Users;
    using DataGate.Web.InputModels.Users;
    using DataGate.Web.ViewModels.Users;

    using Microsoft.AspNetCore.Identity;

    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> All();

        IEnumerable<ApplicationRole> Roles();

        Task<IdentityResult> Create(CreateUserInputModel input);

        Task<ApplicationUser> ByUsername(string username);

        Task<string> GenerateEmailToken(ApplicationUser user);

        Task<EditUserInputModel> ByIdEdit(string id);

        Task<IdentityResult> Edit(EditUserInputModel input);

        Task<DeleteUserInputModel> ByIdDelete(string id);

        Task<IdentityResult> Delete(DeleteUserInputModel input);
    }
}
