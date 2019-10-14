namespace Pharus.Services
{
    using System;
    using System.Collections.Generic;

    using Pharus.Domain.Pharus_vFinale;
    using Pharus.Services.Contracts;

    public class ShareClassesService : IShareClassesService
    {
        public List<string[]> GetAllActiveShareClasses()
        {
            throw new NotImplementedException();
        }

        public List<string[]> GetAllActiveShareClasses(DateTime? chosenDate)
        {
            throw new NotImplementedException();
        }

        public List<TbHistoryShareClass> GetAllShareClasses()
        {
            throw new NotImplementedException();
        }

        public TbHistoryShareClass GetShareClass(string fundName)
        {
            throw new NotImplementedException();
        }
    }
}
