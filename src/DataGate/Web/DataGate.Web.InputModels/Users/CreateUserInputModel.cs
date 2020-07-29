namespace DataGate.Web.InputModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;
    using DataGate.Web.Infrastructure.Attributes.Validation;

    public class CreateUserInputModel
    {
        [Required(ErrorMessage = ValidationMessages.FieldRequired)]
        [StringLength(
            ModelConstants.UsernameMaxLength,
            MinimumLength = ModelConstants.UsernameMinLength,
            ErrorMessage = ValidationMessages.FieldLength)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.FieldRequired)]
        [EmailAddress(ErrorMessage = ValidationMessages.EmailValid)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.FieldRequired)]
        [StringLength(
            ModelConstants.PasswordMaxLength,
            MinimumLength = ModelConstants.PasswordMinLength,
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
