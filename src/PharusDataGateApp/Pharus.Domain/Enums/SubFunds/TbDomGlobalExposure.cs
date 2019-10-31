namespace Pharus.Domain.Enums.SubFunds
{
    using System.ComponentModel.DataAnnotations;

    public enum TbDomGlobalExposure
    {
        [Display(Name = "VaR Absolute")]
        VaRAbsolute = 1,

        [Display(Name = "Var Relative")]
        VarRelative = 2,

        [Display(Name = "Commitment")]
        Commitment = 3
    }
}
