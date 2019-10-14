namespace Pharus.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    using Pharus.Domain.Pharus_vFinale;

    public interface IShareClassesService
    {
        List<TbHistoryShareClass> GetAllShareClasses();

        List<string[]> GetAllActiveShareClasses();

        List<string[]> GetAllActiveShareClasses(DateTime? chosenDate);

        TbHistoryShareClass GetShareClass(string fundName);
    }
}
