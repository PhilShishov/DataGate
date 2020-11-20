namespace DataGate.Services.Data.Agreements.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IAgreementsService
    {
        IEnumerable<T> All<T>(string function, DateTime date);
    }
}
