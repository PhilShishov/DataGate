namespace DataGate.Web.InputModels.Users
{
    using DataGate.Common;
    using System.ComponentModel.DataAnnotations;

    public class EditUserInputModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = ModelConstants.UserRoleDisplayName)]
        public string RoleType { get; set; }

        [StringLength(ModelConstants.UserPasswordMaxLength, MinimumLength = ModelConstants.UserPasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = ModelConstants.UserNewPasswordDisplayName)]
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = ModelConstants.UserConfirmPasswordDisplayName)]
        [Compare(nameof(PasswordHash), ErrorMessage = ErrorMessages.NewPasswordMismatch)]
        public string ConfirmPassword { get; set; }
    }
}
