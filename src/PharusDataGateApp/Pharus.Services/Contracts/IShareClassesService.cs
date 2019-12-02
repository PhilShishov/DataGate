namespace Pharus.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IShareClassesService
    {
        List<string[]> GetAllActiveShareClasses();

        List<string[]> GetAllActiveShareClasses(DateTime? chosenDate);

        List<string[]> GetActiveShareClassById(int id);

        List<string[]> GetActiveShareClassById(DateTime? chosenDate, int id);

        List<string[]> GetActiveShareClassWithDateById(int id);

        List<string[]> GetShareClass_SubFundContainer(int id);

        List<string[]> GetShareClass_SubFundContainer(DateTime? chosenDate, int id);
    }
}
