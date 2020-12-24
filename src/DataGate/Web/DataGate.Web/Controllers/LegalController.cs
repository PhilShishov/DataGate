// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    public class LegalController : Controller
    {
        [Route("privacy")]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [Route("cookie")]
        public IActionResult Cookie()
        {
            return this.View();
        }

        [Route("conditions")]
        public IActionResult Conditions()
        {
            return this.View();
        }
    }
}
