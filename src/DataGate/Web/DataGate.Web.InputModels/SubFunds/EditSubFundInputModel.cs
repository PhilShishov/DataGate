﻿namespace DataGate.Web.InputModels.SubFunds
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using DataGate.Common;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Entities;
    using DataGate.Web.Infrastructure.Extensions;

    public class EditSubFundInputModel : BaseEntityInputModel, IMapFrom<EditSubFundGetDto>, IHaveCustomMappings
    {
        [Display(Name = "Sub Fund Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.FundRequired)]
        [StringLength(200, ErrorMessage = ValidationMessages.FundLength)]
        [RegularExpression(@"^[A-Za-z-0-9]+(\s[A-Za-z-0-9]+)*$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "Official Sub Fund Name")]
        public string SubFundName { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "Depository Bank Code")]
        public string DBCode { get; set; }

        [Display(Name = "First Nav Date")]
        public DateTime? FirstNavDate { get; set; }

        [Display(Name = "Last Nav Date")]
        public DateTime? LastNavDate { get; set; }

        [Display(Name = "CSSF Auth. Date")]
        public DateTime? CSSFAuthDate { get; set; }

        [Display(Name = "Expiry Date")]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "Cesr Class")]
        public string CesrClass { get; set; }

        [Display(Name = "Geographical Focus")]
        public string GeographicalFocus { get; set; }

        [Display(Name = "Global Exposure")]
        public string GlobalExposure { get; set; }

        [Required(ErrorMessage = ValidationMessages.CurrencyRequired)]
        [Display(Name = "Currency")]
        public string CurrencyCode { get; set; }

        [Display(Name = "NAV Frequency")]
        public string NavFrequency { get; set; }

        [Display(Name = "Valuation Date")]
        public string ValuationDate { get; set; }

        [Display(Name = "Calculation Date")]
        public string CalculationDate { get; set; }

        public string Derivatives { get; set; }

        [Display(Name = "Derivatives")]
        public bool AreDerivatives { get; set; } = false;

        [Display(Name = "Deriv. Market")]
        public string DerivMarket { get; set; }

        [Display(Name = "Deriv. Purpose")]
        public string DerivPurpose { get; set; }

        [Display(Name = "Principal Asset Class")]
        public string PrincipalAssetClass { get; set; }

        [Display(Name = "Type Of Market")]
        public string TypeOfMarket { get; set; }

        [Display(Name = "Principal Investment Strategy")]
        public string PrincipalInvestmentStrategy { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "Clearing Code")]
        public string ClearingCode { get; set; }

        [Display(Name = "Morning Star Category")]
        public string SfCatMorningStar { get; set; }

        [Display(Name = "Six Category")]
        public string SfCatSix { get; set; }

        [Display(Name = "Bloomberg Category")]
        public string SfCatBloomberg { get; set; }

        [Required(ErrorMessage = ValidationMessages.CommentTitleRequired)]
        [Display(Name = "Comment Title")]
        public string CommentTitle { get; set; }

        [Display(Name = "Comment Description")]
        public string CommentArea { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<EditSubFundGetDto, EditSubFundInputModel>()
              .ForMember(model => model.InitialDate, action => action.MapFrom(dto => DateTimeParser.FromSqlFormat(dto.InitialDate)))
              .ForMember(model => model.CSSFAuthDate, action => action.MapFrom(dto => DateTimeParser.FromSqlFormat(dto.CSSFAuthDate)))
              .ForMember(model => model.ExpiryDate, action => action.MapFrom(dto => DateTimeParser.FromSqlFormat(dto.ExpiryDate)))
              .ForMember(model => model.FirstNavDate, action => action.MapFrom(dto => DateTimeParser.FromSqlFormat(dto.FirstNavDate)))
              .ForMember(model => model.LastNavDate, action => action.MapFrom(dto => DateTimeParser.FromSqlFormat(dto.LastNavDate)));
        }
    }
}
