// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;

namespace DataGate.Common
{
    [ExcludeFromCodeCoverage]
    public class ErrorMessages
    {
        public const string EmailNotConfirmed = "emailNotConfirmed";
        public const string AccountLocked = "accountLocked";
        public const string InvalidLoginAttempt = "invalidLogin";

        public const string SettingUserLayout = "Unexpected error occurred setting user layout ({0}) for user with ID '{1}'.";

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
        public const string InvalidKeyName = "Key name cannot be empty!";
        public const string InvalidValue = "Value cannot be empty!";

        public const string EmptyFunction = "Function should be provided!";
        public const string EmptyCommand = "Command has not been provided!";

        public const string InvalidEntity = "Entity is empty or invalid";
        public const string InvalidDocType = "Document type is empty or invalid";
        public const string InvalidAgrType = "Agreement type is empty or invalid";
        public const string InvalidStatus = "Status is empty or invalid";
        public const string InvalidFile = "File Id is empty or invalid";
        public const string InvalidUsername = "Username is empty or invalid";
        public const string InvalidConnectionId = "Connection Id is empty or invalid";
        public const string InvalidMessage = "Message is empty or invalid";
        public const string InvalidLink = "Link is empty or invalid";
        public const string InvalidNotification = "Notification is empty or invalid";

        public const string DbUpload = "Count is higher than 0. Check ids and dates.";
    }
}
