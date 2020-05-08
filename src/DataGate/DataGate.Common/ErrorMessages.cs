namespace DataGate.Common
{
    public class ErrorMessages
    {
        public const string PasswordMismatch = "The password and confirmation password do not match.";
        public const string NewPasswordMismatch = "The new password and confirmation password do not match.";
        public const string ChosenDateIsEmpty = "Date cannot be empty!";

        public const string TableReportNotGenerated = "Table report not generated! Please make a new selection.";
        public const string TooManyColumns = "Too many columns! Please make a column selection.";
        public const string TableIsEmpty = "Table is empty! Please make a new selection.";
        public const string UnsuccessfulUpdate = "Update was unsuccessful! Please try again.";

        public const string NotFoundEntityMessage = "The required {0} was not found!";
        public const string EndpointErrorMessage = "Some error occurs.";
    }
}
