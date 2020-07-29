namespace DataGate.Web.InputModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;
    using DataGate.Web.Infrastructure.Attributes.Validation;

    public class EditUserInputModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.UsernameRequired)]
        [StringLength(
             ModelConstants.UserUsernameMaxLength,
             MinimumLength = ModelConstants.UserUsernameMinLength,
             ErrorMessage = ValidationMessages.UsernameLength)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.EmailRequired)]
        [EmailAddress(ErrorMessage = ValidationMessages.EmailValid)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.RoleRequired)]
        public string RoleType { get; set; }

        [StringLength(
            ModelConstants.UserPasswordMaxLength,
            MinimumLength = ModelConstants.UserPasswordMinLength,
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
