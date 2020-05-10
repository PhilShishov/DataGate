namespace DataGate.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DataGate.Common;
    using DataGate.Services.AutoComplete;
    using DataGate.Services.Data.Funds.Contracts;
    using DataGate.Web.InputModels.Autocomplete;

    using Microsoft.AspNetCore.Mvc;

    public class AutoCompleteController : Controller
    {
        private readonly IFundsService fundsService;
        private readonly IFundSubEntitiesService fundSubFundservice;

        public AutoCompleteController(
                            IFundsService fundsService,
                            IFundSubEntitiesService fundSubFundservice)
        {
            this.fundsService = fundsService;
            this.fundSubFundservice = fundSubFundservice;
        }

        [Route("api/autocomplete")]
        public async Task<JsonResult> GetResultAsync(AutoCompleteInputModel input)
        {
            ISet<string> result = null;

            if (!input.Id.HasValue)
            {
                if (input.ControllerToPass == GlobalConstants.ShareClassesControllerName)
                {
                    //result = AutoCompleteService.GetResult(input.SelectTerm, this.fundsService);
                }
                else if (input.ControllerToPass == GlobalConstants.SubFundsControllerName)
                {
                    //result = AutoCompleteService.GetResult(input.SelectTerm, this.service);
                }
                else if (input.ControllerToPass == GlobalConstants.FundsControllerName)
                {
                    result = await AutoCompleteService.GetResult(input.SelectTerm, this.fundsService);
                }

                var modifiedData = result.Select(f => new
                {
                    id = f,
                    text = f,
                });

                return this.Json(modifiedData);
            }

            if (input.ControllerToPass == GlobalConstants.SubFundShareClassesControllerName)
            {
                //result = AutoCompleteService.GetResult(input.SelectTerm, this.fundsService, input.Id);
            }
            else if (input.ControllerToPass == GlobalConstants.FundSubFundsControllerName)
            {
                //result = await AutoCompleteService.GetResult(input.SelectTerm, this.fundSubFundservice, input.Id);
            }

            var modifiedDataId = result.Select(f => new
            {
                id = f,
                text = f,
            });

            return this.Json(modifiedDataId);
        }
    }
}
