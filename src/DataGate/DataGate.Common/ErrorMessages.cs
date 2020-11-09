namespace DataGate.Common
{
    public class ErrorMessages
    {
        public const string EmailNotConfirmed = "emailNotConfirmed";
        public const string InvalidLoginAttempt = "invalidLogin";

        public const string UnsuccessfulUpdate = "unsuccessfulUpdate";
        public const string UnsuccessfulDelete = "Delete was unsuccessful! Please try again.";
        public const string UnsuccessfulCreate = "Create was unsuccessful! Please try again.";

        public const string ExistingEntityName = "existingEntityName";
        public const string ExistingEntityAtDate = "existingEntityAtDate";

        public const string NotFoundEntity = "The required {0} was not found!";
        public const string EndpointError = "Some error occurs.";

        public const string UploadInvalid = "Inputs are not valid!";
        public static string UploadFileError = $"The file must be a PDF and less than {GlobalConstants.FileSizeLimit} MB.";

        public const string InvalidSearchKeyword = "Search term must be at least one symbol long!";
    }
}
