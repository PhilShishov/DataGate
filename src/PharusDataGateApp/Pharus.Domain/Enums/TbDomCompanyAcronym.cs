namespace Pharus.Domain.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomCompanyAcronym
    {
        [Display(Name = "S.A.")]
        SA = 1,
        [Display(Name = "S.E.")]
        SE,
        [Display(Name = "S.à r.l.")]
        Sàrl,
        [Display(Name = "S.C.A.")]
        SCA,
        [Display(Name = "S.C.Sp.")]
        SCSp,
        [Display(Name = "S.C.S.")]
        SCS,
        [Display(Name = "S.Co S.A.")]
        SCoSA,
    }
}
