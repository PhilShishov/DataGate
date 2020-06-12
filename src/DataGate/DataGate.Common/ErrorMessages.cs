namespace DataGate.Common
{
    public class ErrorMessages
    {
        public const string InvalidLoginAttempt = "Wrong username or password have been specified.";
        public const string NotConfirmedEmail = "Your email is not confirmed. Please confirm your email before login!";
        public const string PasswordMismatch = "Password and confirmation password do not match.";
        public const string NewPasswordMismatch = "The new password and confirmation password do not match.";
        public const string PasswordLength = "Must be at least {2} characters.";
        public const string NotSelectedValue = "Please select at least one option!";
        public const string UnsuccessfulDelete = "Delete was unsuccessful! Please try again.";
        public const string UnsuccessfulCreate = "Create was unsuccessful! Please try again.";

        public const string ChosenDateIsEmpty = "Date cannot be empty!";
        public const string TableReportNotGenerated = "There was a problem generating your report, please try again.";
        public const string TooManyColumns = "Too many columns! Please make a column selection.";
        public const string TableIsEmpty = "Inactive/old fund selected! Please make a new selection.";
        public const string UnsuccessfulUpdate = "Update was unsuccessful! Please try again.";
        public const string ExistingEntityName = "Name already exists! Please try another one.";
        public const string ExistingEntityAtDate = "Entity already exists for this time period! Please change Valid From.";
        public const string FileNotChosen = "Please select a file.";

        public const string NotFoundEntityMessage = "The required {0} was not found!";
        public const string EndpointErrorMessage = "Some error occurs.";

        public const string ModelUploadErrorMessage = "Inputs are not valid!";
        public const string ModelUploadFileErrorMessage = "The file must be a PDF and less than 2mb!";
    }
}
