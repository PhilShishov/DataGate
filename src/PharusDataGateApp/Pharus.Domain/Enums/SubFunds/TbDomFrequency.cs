namespace Pharus.Domain.Enums.SubFunds
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomFrequency
    {
        [Display(Name = "Daily")]
        Daily = 1,

        [Display(Name = "Weekly")]
        Weekly = 2,

        [Display(Name = "Weekly And Last Monthly Nav")]
        WeeklyAndLastMonthlyNav = 3,

        [Display(Name = "Monthly")]
        Monthly = 4,

        [Display(Name = "Fortnightly")]
        Fortnightly = 5,

        [Display(Name = "Fortnightly And Last Monthly Nav")]
        FortnightlyAndLastMonthlyNav = 6,

        [Display(Name = "Quarterly")]
        Quarterly = 7,

        [Display(Name = "Semiannual")]
        Semiannual = 8,

        [Display(Name = "Annual")]
        Annual = 9
    }
}
