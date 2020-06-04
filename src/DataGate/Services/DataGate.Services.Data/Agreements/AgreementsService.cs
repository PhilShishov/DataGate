namespace DataGate.Services.Data.Agreements
{
    using System;
    using System.Collections.Generic;

    public class AgreementsService : IAgreementsService
    {
        public IAsyncEnumerable<string[]> GetAll(string function, DateTime date, int skip = 0)
        {
            throw new NotImplementedException();
        }
    }
}
