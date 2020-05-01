namespace DataGate.Common
{
    using DataGate.Common.Exceptions;

    public static class Validator
    {
        public static void ThrowEntityNotFoundExceptionIfEntityIsNull(object entity, string name)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException(name);
            }
        }
    }
}
