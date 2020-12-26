// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.InputModels.Funds
{
    using AutoMapper;
    using DataGate.Services.Mapping;
    using DataGate.Web.Infrastructure.Extensions;

    public class FundPostDto : IMapFrom<EditFundInputModel>, IMapFrom<CreateFundInputModel>, IHaveCustomMappings
    {
        public string InitialDate { get; set; }

        public string EndDate { get; set; }

        public int Id { get; set; }

        public string FundName { get; set; }

        public string CSSFCode { get; set; }

        [IgnoreMap]
        public int Status { get; set; }

        [IgnoreMap]

        public int? LegalForm { get; set; }

        [IgnoreMap]

        public int? LegalVehicle { get; set; }

        [IgnoreMap]

        public int? LegalType { get; set; }

        public string FACode { get; set; }

        public string DEPCode { get; set; }

        public string TACode { get; set; }

        [IgnoreMap]
        public int? CompanyTypeDesc { get; set; }

        public string TinNumber { get; set; }

        public string LEICode { get; set; }

        public string RegNumber { get; set; }

        public string VATRegNumber { get; set; }

        public string VATIdentificationNumber { get; set; }

        public string IBICNumber { get; set; }

        public string CommentTitle { get; set; }

        public string CommentArea { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<EditFundInputModel, FundPostDto>()
                .ForMember(dto => dto.InitialDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.InitialDate)));

            configuration.CreateMap<CreateFundInputModel, FundPostDto>()
                .ForMember(dto => dto.InitialDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.InitialDate)));
        }
    }
}
