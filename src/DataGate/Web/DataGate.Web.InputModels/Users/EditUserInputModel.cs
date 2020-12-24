// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.InputModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;
    using DataGate.Web.Infrastructure.Attributes.Validation;

    public class EditUserInputModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.FieldRequired)]
        [StringLength(
             ModelConstants.UsernameMaxLength,
             MinimumLength = ModelConstants.UsernameMinLength,
             ErrorMessage = ValidationMessages.FieldLength)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.FieldRequired)]
        [EmailAddress(ErrorMessage = ValidationMessages.EmailValid)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.RoleRequired)]
        public string RoleType { get; set; }

        [StringLength(
            ModelConstants.PasswordMaxLength,
            MinimumLength = ModelConstants.PasswordMinLength,
            ErrorMessage = ValidationMessages.PasswordLength)]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(PasswordHash), ErrorMessage = ValidationMessages.NewPasswordMismatch)]
        public string ConfirmPassword { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
