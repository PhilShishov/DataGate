// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.InputModels.Files
{
    using System.IO;

    using AutoMapper;
    using DataGate.Services.Mapping;
    using DataGate.Web.Infrastructure.Extensions;

    public class UploadDocumentDto : IMapFrom<UploadDocumentInputModel>, IHaveCustomMappings
    {
        public string FileName { get; set; }

        public int Id { get; set; }

        public string StartConnection { get; set; }

        public string EndConnection { get; set; }

        public string FileExt { get; set; }

        [IgnoreMap]
        public int DocumentType { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UploadDocumentInputModel, UploadDocumentDto>()
               .ForMember(dto => dto.StartConnection, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.StartConnection)))
               .ForMember(dto => dto.FileName, action => action.MapFrom(model => model.FileToUpload.FileName))
               .ForMember(dto => dto.FileExt, action => action.MapFrom(model => Path.GetExtension(model.FileToUpload.FileName).ToLowerInvariant()));
        }
    }
}
