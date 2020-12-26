// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.InputModels.SubFunds
{
    using AutoMapper;
    using DataGate.Services.Mapping;
    using DataGate.Web.Infrastructure.Extensions;

    public class SubFundPostDto : IMapFrom<EditSubFundInputModel>, IMapFrom<CreateSubFundInputModel>, IHaveCustomMappings
    {
        [IgnoreMap]
        public int ContainerId { get; set; }

        public int Id { get; set; }

        public string SubFundName { get; set; }

        public string InitialDate { get; set; }

        public string EndDate { get; set; }

        public string CSSFCode { get; set; }

        [IgnoreMap]
        public int Status { get; set; }

        public string FACode { get; set; }

        public string TACode { get; set; }

        public string LEICode { get; set; }

        public string DBCode { get; set; }

        public string FirstNavDate { get; set; }

        public string LastNavDate { get; set; }

        public string CSSFAuthDate { get; set; }

        public string ExpiryDate { get; set; }

        [IgnoreMap]
        public int? CesrClass { get; set; }

        [IgnoreMap]
        public int? GeographicalFocus { get; set; }

        [IgnoreMap]
        public int? GlobalExposure { get; set; }

        public string CurrencyCode { get; set; }

        [IgnoreMap]
        public int? NavFrequency { get; set; }

        [IgnoreMap]
        public int? ValuationDate { get; set; }

        [IgnoreMap]
        public int? CalculationDate { get; set; }

        public bool AreDerivatives { get; set; }

        [IgnoreMap]
        public int? DerivMarket { get; set; }

        [IgnoreMap]
        public int? DerivPurpose { get; set; }

        [IgnoreMap]
        public int? PrincipalAssetClass { get; set; }

        [IgnoreMap]
        public int? TypeOfMarket { get; set; }

        [IgnoreMap]
        public int? PrincipalInvestmentStrategy { get; set; }

        public string ClearingCode { get; set; }

        [IgnoreMap]
        public int? SfCatMorningStar { get; set; }

        [IgnoreMap]
        public int? SfCatSix { get; set; }

        [IgnoreMap]
        public int? SfCatBloomberg { get; set; }

        public string CommentTitle { get; set; }

        public string CommentArea { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<EditSubFundInputModel, SubFundPostDto>()
               .ForMember(dto => dto.InitialDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.InitialDate)))
               .ForMember(dto => dto.FirstNavDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.FirstNavDate)))
               .ForMember(dto => dto.LastNavDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.LastNavDate)))
               .ForMember(dto => dto.CSSFAuthDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.CSSFAuthDate)))
               .ForMember(dto => dto.ExpiryDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.ExpiryDate)));

            configuration.CreateMap<CreateSubFundInputModel, SubFundPostDto>()
                .ForMember(dto => dto.InitialDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.InitialDate)))
                .ForMember(dto => dto.FirstNavDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.FirstNavDate)))
                .ForMember(dto => dto.LastNavDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.LastNavDate)))
                .ForMember(dto => dto.CSSFAuthDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.CSSFAuthDate)))
                .ForMember(dto => dto.ExpiryDate, action => action.MapFrom(model => DateTimeExtensions.ToSqlFormat(model.ExpiryDate)));
        }
    }
}
