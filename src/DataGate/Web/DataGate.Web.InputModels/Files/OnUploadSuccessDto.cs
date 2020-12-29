// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.InputModels.Files
{
    using DataGate.Services.Mapping;

    public class OnUploadSuccessDto : IMapFrom<UploadDocumentInputModel>
    {
        public string AreaName { get; set; }

        public string Date { get; set; }

        public int Id { get; set; }

        public string RouteName { get; set; }

        public int FileId { get; set; }

        public bool IsFee { get; set; }
    }
}
