namespace DataGate.Web.Controllers
{
    using System.Linq;

    using DataGate.Data.Common.Repositories;
    using DataGate.Data.Models.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UserController : BaseController
    {
        private readonly IRepository<TbHistoryShareClass> repository;

        public UserController(IRepository<TbHistoryShareClass> repository)
        {
            this.repository = repository;
        }

        [Route("userpanel")]
        public IActionResult Index()
        {
            var latest = this.repository.All()
                .OrderByDescending(sc => sc.ScInitialDate)
                .Take(10)
                .ToList();

            return this.View(latest);
        }
    }
}
