namespace DataGate.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Services.AutoComplete;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Web.InputModels.Autocomplete;

    using Microsoft.AspNetCore.Mvc;

    public class AutoCompleteController : Controller
    {
        private readonly IFundsService fundsService;
        //private readonly IFundsService fundsService;
        //private readonly IFundsService fundsService;
        //private readonly IFundsService fundsService;
        //private readonly IFundsService fundsService;

        public AutoCompleteController(
            IFundsService fundsService
            //IFundsService fundsService,
            //IFundsService fundsService,
            //IFundsService fundsService,
            //IFundsService fundsService,
            )
        {
            this.fundsService = fundsService;
        }

        [Route("api/autocomplete")]
        public JsonResult Get(AutoCompleteInputModel input)
        {
            ISet<string> result = null;

            if (input.ControllerToPass == GlobalConstants.FundsControllerName)
            {
                result = AutoCompleteService.GetResult(input.SelectTerm, this.fundsService);
            }

            //else if (input.Controller == GlobalConstants.FundsControllerName)
            //{
            //    result = AutoCompleteService.GetResult(input.SelectTerm, this.service);

            //}
            //else if (input.Controller == GlobalConstants.FundsControllerName)
            //{
            //    result = AutoCompleteService.GetResult(input.SelectTerm, this.service);
            //}

            var modifiedData = result.Select(f => new
            {
                id = f,
                text = f,
            });

            return this.Json(modifiedData);
        }

        //public JsonResult AutoCompleteSubFundList(string selectTerm, int entityId)
        //{
        //    var entitiesToSearch = this.service
        //        .GetEntity_SubEntities(null, entityId)
        //        .Skip(1)
        //        .ToList();

        //    if (selectTerm != null)
        //    {
        //        entitiesToSearch = entitiesToSearch
        //            .Where(sf => sf[GlobalConstants.IndexEntityNameInTable]
        //                .ToLower()
        //                .Contains(selectTerm
        //                .ToLower()))
        //            .ToList();
        //    }

        //    var modifiedData = entitiesToSearch.Select(sf => new
        //    {
        //        id = sf[GlobalConstants.IndexEntityNameInTable],
        //        text = sf[GlobalConstants.IndexEntityNameInTable],
        //    });

        //    return this.Json(modifiedData);
        //}
    }
}
