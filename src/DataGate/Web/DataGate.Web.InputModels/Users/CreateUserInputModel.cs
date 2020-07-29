namespace DataGate.Web.InputModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;
    using DataGate.Web.Infrastructure.Attributes.Validation;

    public class CreateUserInputModel
    {
        [Required(ErrorMessage = ValidationMessages.UsernameRequired)]
        [StringLength(
            ModelConstants.UserUsernameMaxLength,
            MinimumLength = ModelConstants.UserUsernameMinLength,
            ErrorMessage = ValidationMessages.UsernameLength)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.EmailRequired)]
        [EmailAddress(ErrorMessage = ValidationMessages.EmailValid)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.PasswordRequired)]
        [StringLength(
            ModelConstants.UserPasswordMaxLength,
            MinimumLength = ModelConstants.UserPasswordMinLength,
            ErrorMessage = ValidationMessages.PasswordLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = ValidationMessages.PasswordMismatch)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        public string RoleType { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
