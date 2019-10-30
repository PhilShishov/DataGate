namespace Pharus.Domain.Enums.Funds
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomCompanyAcronym
    {
        [Display(Name = "S.A.")]
        SA = 1,
        [Display(Name = "S.E.")]
        SE = 2,
        [Display(Name = "S.à r.l.")]
        Sàrl = 3,
        [Display(Name = "S.C.A.")]
        SCA = 4,
        [Display(Name = "S.C.Sp.")]
        SCSp = 5,
        [Display(Name = "S.C.S.")]
        SCS = 6,
        [Display(Name = "S.Co S.A.")]
        SCoSA = 7,
    }
}
