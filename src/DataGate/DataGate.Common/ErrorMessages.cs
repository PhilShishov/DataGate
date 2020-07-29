namespace DataGate.Common
{
    public class ErrorMessages
    {
        public const string EmailNotConfirmed = "emailNotConfirmed";
        public const string InvalidLoginAttempt = "invalidLogin";

        public const string UnsuccessfulDelete = "Delete was unsuccessful! Please try again.";
        public const string UnsuccessfulCreate = "Create was unsuccessful! Please try again.";

        public const string TableIsEmpty = "Table is empty! Please make a new selection.";
        public const string UnsuccessfulUpdate = "Update was unsuccessful! Please try again.";
        public const string ExistingEntityName = "Name already exists! Please try another one.";
        public const string ExistingEntityAtDate = "Entity already exists for this time period! Please change Valid From.";

        public const string NotFoundEntity = "The required {0} was not found!";
        public const string EndpointError = "Some error occurs.";

        public const string UploadInvalid = "Inputs are not valid!";
        public const string UploadFileError = "The file must be a PDF and less than 10mb!";
    }
}
