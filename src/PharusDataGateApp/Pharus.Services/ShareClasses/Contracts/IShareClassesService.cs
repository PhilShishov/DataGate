namespace Pharus.Services.ShareClasses.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IShareClassesService
    {
        List<string[]> GetAllShareClasses();

        List<string[]> GetAllShareClasses(DateTime? chosenDate);

        List<string[]> GetShareClassById(int id);

        List<string[]> GetShareClassById(DateTime? chosenDate, int id);

        List<string[]> GetShareClassWithDateById(int id);

        List<string[]> GetShareClass_SubFundContainer(int id);

        List<string[]> GetShareClass_SubFundContainer(DateTime? chosenDate, int id);
    }
}
