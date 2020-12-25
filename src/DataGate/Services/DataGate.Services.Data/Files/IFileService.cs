// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Services.Data.Files
{
    using System.Threading.Tasks;

    using DataGate.Web.InputModels.Files;

    public interface IFileService
    {
        Task UploadDocument(UploadDocumentInputModel model);

        Task DeleteDocument(int fileId, string areaName);

        Task UploadAgreement(UploadAgreementInputModel model);

        Task DeleteAgreement(int fileId, string areaName);
    }
}
