namespace DataGate.Services.Data.Common
{
    public interface IEntityException
    {
        void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id);
    }
}
