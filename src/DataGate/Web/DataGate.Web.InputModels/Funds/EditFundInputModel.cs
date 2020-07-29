namespace DataGate.Web.InputModels.Funds
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using DataGate.Common;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Entities;
    using DataGate.Web.Infrastructure.Extensions;

    public class EditFundInputModel : BaseEntityInputModel, IMapFrom<EditFundGetDto>, IHaveCustomMappings
    {
        [Display(Name = "Fund Id Pharus")]
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.FundRequired)]
        [StringLength(200, ErrorMessage = ValidationMessages.FundLength)]
        [RegularExpression(@"^[A-Z-0-9]+(\s[A-Z-0-9]+)*$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "Official Fund Name")]
        public string FundName { get; set; }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        [Display(Name = "Legal Form")]
        public string LegalForm { get; set; }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        [Display(Name = "Legal Vehicle")]
        public string LegalVehicle { get; set; }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        [Display(Name = "Legal Type")]
        public string LegalType { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "Dep. Code")]
        public string DEPCode { get; set; }

        [Required(ErrorMessage = ValidationMessages.NotSelectedValue)]
        [Display(Name = "Company Description")]
        public string CompanyTypeDesc { get; set; }

        [RegularExpression(@"^[0-9]+(\s[0-9]+)*$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "TIN Number")]
        public string TinNumber { get; set; }

        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = ValidationMessages.UnvalidFormat)]
        [Display(Name = "Reg. Number")]
        public string RegNumber { get; set; }

        [Required(ErrorMessage = ValidationMessages.CommentTitleRequired)]
        [Display(Name = "Comment Title")]
        public string CommentTitle { get; set; }

        [Display(Name = "Comment Description")]
        public string CommentArea { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<EditFundGetDto, EditFundInputModel>()
              .ForMember(model => model.InitialDate, action => action.MapFrom(dto => DateTimeParser.FromSqlFormat(dto.InitialDate)));
        }
    }
}
