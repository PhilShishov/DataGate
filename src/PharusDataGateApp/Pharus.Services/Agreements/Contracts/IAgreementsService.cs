namespace Pharus.Services.Agreements.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IAgreementsService
    {
        List<string[]> GetAgreementsForAllFunds(DateTime chosenDate);

        List<string[]> GetAgreementsForAllSubFunds(DateTime chosenDate);

        List<string[]> GetAgreementsForAllShareClasses(DateTime chosenDate);
    }
}