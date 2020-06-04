namespace DataGate.Services.Data.Agreements
{
    using System;
    using System.Collections.Generic;

    public interface IAgreementsService
    {
        IAsyncEnumerable<string[]> GetAll(string function, DateTime date, int skip = 0);
    }
}
