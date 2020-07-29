namespace DataGate.Common
{
    public class ErrorMessages
    {
        public const string EmailNotConfirmed = "emailNotConfirmed";
        public const string InvalidLoginAttempt = "invalidLogin";

        public const string UnsuccessfulDelete = "Delete was unsuccessful! Please try again.";
        public const string UnsuccessfulCreate = "Create was unsuccessful! Please try again.";

        public const string ChosenDateIsEmpty = "Date cannot be empty!";
        public const string TableReportNotGenerated = "There was a problem generating your report, please try again.";
        public const string TooManyColumns = "Too many columns! Please make a column selection.";
        public const string TableIsEmpty = "Table is empty! Please make a new selection.";
        public const string UnsuccessfulUpdate = "Update was unsuccessful! Please try again.";
        public const string ExistingEntityName = "Name already exists! Please try another one.";
        public const string ExistingEntityAtDate = "Entity already exists for this time period! Please change Valid From.";
        public const string FileNotChosen = "Please select a file.";
        public const string UnvalidFormat = "Not in correct format!";

        public const string NotFoundEntityMessage = "The required {0} was not found!";
        public const string EndpointErrorMessage = "Some error occurs.";

        public const string ModelUploadErrorMessage = "Inputs are not valid!";
        public const string ModelUploadFileErrorMessage = "The file must be a PDF and less than 2mb!";
    }
}
