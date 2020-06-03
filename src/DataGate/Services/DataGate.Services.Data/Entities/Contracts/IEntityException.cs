namespace DataGate.Services.Data.Entities
{
    public interface IEntityException
    {
        void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id);
    }
}
