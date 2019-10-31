namespace Pharus.Domain.Enums.SubFunds
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomGeographicalFocus
    {
        [Display(Name = "Africa")]
        Africa = 1,

        [Display(Name = "Asia Pacific")]
        AsiaPacific = 2,

        [Display(Name = "Europe")]
        Europe = 3,

        [Display(Name = "North America")]
        NorthAmerica = 4,

        [Display(Name = "Central and South America")]
        CentralAndSouthAmerica = 5,

        [Display(Name = "Multiple Region")]
        MultipleRegion = 6
    }
}
