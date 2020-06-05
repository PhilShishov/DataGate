namespace DataGate.Services.Data.Agreements
{
    using System;
    using System.Collections.Generic;

    public interface IAgreementsService
    {
        IEnumerable<T> GetAll<T>(string function, DateTime date);
    }
}
