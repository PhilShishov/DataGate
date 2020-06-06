namespace DataGate.Web.InputModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;
    using DataGate.Web.Infrastructure.Attributes.Validation;

    public class CreateUserInputModel
    {
        [Required]
        [StringLength(ModelConstants.UserUsernameMaxLength, MinimumLength = ModelConstants.UserUsernameMinLength)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(ModelConstants.UserPasswordMaxLength, MinimumLength = ModelConstants.UserPasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = ModelConstants.UserConfirmPasswordDisplayName)]
        [Compare(nameof(Password), ErrorMessage = ErrorMessages.PasswordMismatch)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = ErrorMessages.NotSelectedValue)]
        [Display(Name = ModelConstants.UserRoleDisplayName)]
        public string RoleType { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
