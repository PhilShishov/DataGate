﻿namespace Pharus.Domain.Pharus_vFinale
{
    using System;

    public partial class TbServiceAgreementFund
    {
        public int SaId { get; set; }

        public int SaF { get; set; }

        public int SaActivityType { get; set; }

        public DateTime SaConctractDate { get; set; }

        public DateTime? SaActivationDate { get; set; }

        public DateTime? SaExpirationDate { get; set; }

        public string SaRifCode { get; set; }

        public int? SaCompanyId { get; set; }

        public string SaStatus { get; set; }

        public virtual TbDomActivityType SaActivityTypeNavigation { get; set; }

        public virtual TbDomCompany SaCompany { get; set; }

        public virtual TbFund SaFNavigation { get; set; }
    }
}
