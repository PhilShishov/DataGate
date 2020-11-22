namespace DataGate.Services.Data.Common
{
    public interface IEntityException
    {
        bool DoesEntityExist(int id);
    }
}
