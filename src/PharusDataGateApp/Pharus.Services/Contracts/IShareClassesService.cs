namespace Pharus.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IShareClassesService
    {
        List<string[]> GetAllActiveShareClasses();

        List<string[]> GetAllActiveShareClasses(DateTime? chosenDate);

        List<string[]> GetActiveShareClassById(int Id);

        List<string[]> GetActiveShareClassById(DateTime? chosenDate, int Id);

        List<string[]> GetActiveShareClassWithDateById(int Id);
    }
}
