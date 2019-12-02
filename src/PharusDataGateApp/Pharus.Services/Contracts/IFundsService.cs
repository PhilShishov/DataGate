namespace Pharus.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    using Pharus.Domain.Pharus_vFinale;
    public interface IFundsService
    {
        List<string[]> GetAllActiveFunds();

        List<string[]> GetAllActiveFunds(DateTime? chosenDate);

        List<string[]> GetActiveFundById(int id);

        List<string[]> GetActiveFundById(DateTime? chosenDate, int id);

        List<string[]> GetActiveFundWithDateById(int id);

        List<string[]> GetActiveFundWithDateById(DateTime? chosenDate, int id);

        List<string[]> GetFund_SubFunds(int id);

        List<string[]> GetFund_SubFunds(DateTime? chosenDate, int id);

        void EditFund(
                             List<string> fundsProperties,
                             int fundId,
                             DateTime chosenDate,
                             int fStatusId,
                             int fLegalFormId,
                             int fLegalTypeId,
                             int fLegalVehicleId,
                             int fCompanyTypeId);

        void CreateFund(
                        string initialDate,
                        string endDate,
                        string fundName,
                        string cssfCode,
                        int fStatusId,
                        int fLegalFormId,
                        int fLegalTypeId,
                        int fLegalVehicleId,
                        string faCode,
                        string depCode,
                        string taCode,
                        int fCompanyTypeId,
                        string tinNumber,
                        string leiCode,
                        string regNumber);

        string LoadFile();
    }
}
