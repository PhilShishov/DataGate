namespace DataGate.Web.InputModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using DataGate.Common;
    using DataGate.Web.Infrastructure.Attributes.Validation;

    public class DeleteUserInputModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        [EmailAddress(ErrorMessage = ValidationMessages.EmailValid)]
        public string Email { get; set; }

        public string RoleType { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
