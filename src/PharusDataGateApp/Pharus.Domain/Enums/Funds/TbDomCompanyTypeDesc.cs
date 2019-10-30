namespace Pharus.Domain.Enums.Funds
{
    using System.ComponentModel.DataAnnotations;
    public enum TbDomCompanyTypeDesc
    {
        [Display(Name = "Public limited company")]
        PublicLimitedCompany = 1,

        [Display(Name = "European company")]
        EuropeanCompany = 2,

        [Display(Name = "Private limited liability company")]
        PrivateLimitedLiabilityCompany = 3,

        [Display(Name = "Partnership limited by shares")]
        PartnershipLimitedByShares = 4,

        [Display(Name = "Special limited partnership")]
        SpecialLimitedPartnership = 5,

        [Display(Name = "Limited partnership")]
        LimitedPartnership = 6,

        [Display(Name = "Cooperative company organized as a public limited company")]
        CooperativeCompanyOrganizedAsAPublicLimitedCompany = 7
    }
}
