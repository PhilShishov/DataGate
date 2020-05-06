namespace DataGate.Services.SqlClient.Contracts
{
    using System.Data;

    public interface IDataReaderParser
    {
        void Parse(IDataReader reader);
    }
}
