namespace DataGate.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.AutoComplete;
    using DataGate.Services.Data.Funds;
    using DataGate.Services.Data.ShareClasses;
    using DataGate.Services.Data.SubFunds;
    using DataGate.Web.InputModels.Autocomplete;

    using Microsoft.AspNetCore.Mvc;

    public class AutoCompleteController : Controller
    {
        private readonly IFundService fundService;
        private readonly ISubFundService subFundService;
        private readonly IShareClassService shareClassService;

        public AutoCompleteController(
                            IFundService fundService,
                            ISubFundService subFundService,
                            IShareClassService shareClassService)
        {
            this.fundService = fundService;
            this.subFundService = subFundService;
            this.shareClassService = shareClassService;
        }

        [Route("api/autocomplete")]
        public async Task<JsonResult> GetResultAsync(AutoCompleteInputModel input)
        {
            ISet<string> result = null;

            if (!input.Id.HasValue)
            {
                if (input.ControllerToPass == GlobalConstants.ShareClassesControllerName)
                {
                    result = await AutoCompleteService.GetResult(input.SelectTerm, this.shareClassService);
                }
                else if (input.ControllerToPass == GlobalConstants.SubFundsControllerName)
                {
                    result = await AutoCompleteService.GetResult(input.SelectTerm, this.subFundService);
                }
                else if (input.ControllerToPass == GlobalConstants.FundsControllerName)
                {
                    result = await AutoCompleteService.GetResult(input.SelectTerm, this.fundService);
                }

                var modifiedData = result.Select(fund => new
                {
                    id = fund,
                    text = fund,
                });

                return this.Json(modifiedData);
            }

            if (input.ControllerToPass == GlobalConstants.SubFundShareClassesControllerName)
            {
                result = await AutoCompleteService.GetResult(input.SelectTerm, this.subFundService, input.Id);
            }
            else if (input.ControllerToPass == GlobalConstants.FundSubFundsControllerName)
            {
                result = await AutoCompleteService.GetResult(input.SelectTerm, this.fundService, input.Id);
            }

            var modifiedDataId = result.Select(fund => new
            {
                id = fund,
                text = fund,
            });

            return this.Json(modifiedDataId);
        }
    }
}
