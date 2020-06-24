namespace DataGate.Web.InputModels.ShareClasses
{
    using AutoMapper;
    using DataGate.Services.Mapping;
    using DataGate.Web.Infrastructure.Extensions;

    public class ShareClassPostDto : IMapFrom<EditShareClassInputModel>, IMapFrom<CreateShareClassInputModel>, IHaveCustomMappings
    {
        [IgnoreMap]
        public int ContainerId { get; set; }

        public int Id { get; set; }

        public string ShareClassName { get; set; }

        public string InitialDate { get; set; }

        public string EndDate { get; set; }

        public string CSSFCode { get; set; }

        [IgnoreMap]
        public int Status { get; set; }

        public string FACode { get; set; }

        public string TACode { get; set; }

        public string LEICode { get; set; }

        [IgnoreMap]
        public int? InvestorType { get; set; }

        [IgnoreMap]
        public int? ShareType { get; set; }

        public string CurrencyCode { get; set; }

        public string CountryIssue { get; set; }

        public string CountryRisk { get; set; }

        public string EmissionDate { get; set; }

        public string InceptionDate { get; set; }

        public string LastNavDate { get; set; }

        public string ExpiryDate { get; set; }

        public double InitialPrice { get; set; }

        public string AccountingCode { get; set; }

        public bool IsHedged { get; set; }

        public bool IsListed { get; set; }

        public string BloombergMarket { get; set; }

        public string BloombergCode { get; set; }

        public string BloombergId { get; set; }

        public string ISINCode { get; set; }

        public string ValorCode { get; set; }

        public string WKN { get; set; }

        public string DateBusinessYear { get; set; }

        public string ProspectusCode { get; set; }

        public string CommentTitle { get; set; }

        public string CommentArea { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<EditShareClassInputModel, ShareClassPostDto>()
               .ForMember(dto => dto.InitialDate, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.InitialDate)))
               .ForMember(dto => dto.EmissionDate, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.EmissionDate)))
               .ForMember(dto => dto.InceptionDate, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.InceptionDate)))
               .ForMember(dto => dto.LastNavDate, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.LastNavDate)))
               .ForMember(dto => dto.ExpiryDate, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.ExpiryDate)))
               .ForMember(dto => dto.DateBusinessYear, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.DateBusinessYear)));

            configuration.CreateMap<CreateShareClassInputModel, ShareClassPostDto>()
               .ForMember(dto => dto.InitialDate, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.InitialDate)))
               .ForMember(dto => dto.EmissionDate, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.EmissionDate)))
               .ForMember(dto => dto.InceptionDate, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.InceptionDate)))
               .ForMember(dto => dto.LastNavDate, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.LastNavDate)))
               .ForMember(dto => dto.ExpiryDate, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.ExpiryDate)))
               .ForMember(dto => dto.DateBusinessYear, action => action.MapFrom(model => DateTimeParser.ToSqlFormat(model.DateBusinessYear)));
        }
    }
}
