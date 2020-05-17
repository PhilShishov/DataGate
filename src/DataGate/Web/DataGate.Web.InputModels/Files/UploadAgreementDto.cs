namespace DataGate.Web.InputModels.Files
{
    using System.Globalization;
    using System.IO;

    using AutoMapper;
    using DataGate.Common;
    using DataGate.Services.Mapping;

    public class UploadAgreementDto : IMapFrom<UploadAgreementInputModel>, IHaveCustomMappings
    {
        public string FileName { get; set; }

        public string FileExt { get; set; }

        public int Id { get; set; }

        public string ContractDate { get; set; }

        public string ActivationDate { get; set; }

        public string ExpirationDate { get; set; }

        [IgnoreMap]
        public int AgreementType { get; set; }

        [IgnoreMap]
        public int Status { get; set; }

        [IgnoreMap]
        public int Company { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UploadAgreementInputModel, UploadAgreementDto>()
               .ForMember(dto => dto.ContractDate, action => action.MapFrom(model => model.ContractDate.ToString(GlobalConstants.RequiredSqlDateTimeFormat, CultureInfo.InvariantCulture)))
               .ForMember(dto => dto.ActivationDate, action => action.MapFrom(model => model.ActivationDate.ToString(GlobalConstants.RequiredSqlDateTimeFormat, CultureInfo.InvariantCulture)))
               .ForMember(dto => dto.FileName, action => action.MapFrom(model => model.FileToUpload.FileName))
               .ForMember(dto => dto.FileExt, action => action.MapFrom(model => Path.GetExtension(model.FileToUpload.FileName).ToLowerInvariant()));
        }
    }
}