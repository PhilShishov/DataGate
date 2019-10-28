namespace Pharus.Domain.Enums
{
    using System.ComponentModel.DataAnnotations;
    public enum TbDomCompanyTypeDesc
    {
        [Display(Name = "Public limited company")]
        PublicLimitedCompany = 1,

        [Display(Name = "European company")]
        EuropeanCompany,

        [Display(Name = "Private limited liability company")]
        PrivateLimitedLiabilityCompany,

        [Display(Name = "Partnership limited by shares")]
        PartnershipLimitedByShares,

        [Display(Name = "Special limited partnership")]
        SpecialLimitedPartnership,

        [Display(Name = "Limited partnership")]
        LimitedPartnership,

        [Display(Name = "Cooperative company organized as a public limited company")]
        CooperativeCompanyOrganizedAsAPublicLimitedCompany
    }
}
