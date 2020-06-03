namespace DataGate.Services.Data.Common
{
    using System;

    using DataGate.Web.Dtos.Queries;

    public interface IContainerService
    {
        ContainerDto GetContainer(int id, DateTime? date);
    }
}
