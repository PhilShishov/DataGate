namespace DataGate.Services.Data.Common
{
    public interface ICustomException
    {
        void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id);
    }
}
