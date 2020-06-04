namespace DataGate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Agreements;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Agreements;
    using Microsoft.AspNetCore.Mvc;

    public class AgreementsController : BaseController
    {
        private readonly IAgreementsService agreementsService;

        public AgreementsController(
            IAgreementsService agreementsService)
        {
            this.agreementsService = agreementsService;
        }

        [HttpGet]
        [Route("agreements")]
        public async Task<IActionResult> All()
        {
            var today = DateTime.Today;

            var model = new AgreementsViewModel
            {
                Date = today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
            };

            //model.Agreements = await this.agreementsService.GetAll(QueryDictionary.SqlFunctionAllAgreementsFunds, today).ToListAsync();

            return this.View(model);
        }

        //[HttpPost]
        //public IActionResult All(AgreementsViewModel model)
        //{
        //    if (model.ChosenDate != null)
        //    {
        //        var chosenDate = DateTime.ParseExact(model.ChosenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        //        model.Agreements = this.agreementsService.GetAgreementsForAllFunds(chosenDate);
        //        model.SubFundAgreements = this.agreementsService.GetAgreementsForAllSubFunds(chosenDate);
        //        model.ShareClassAgreements = this.agreementsService.GetAgreementsForAllShareClasses(chosenDate);
        //    }

        //    if (model.FundAgreements != null)
        //    {
        //        return this.View(model);
        //    }

        //    return this.RedirectToPage("/Agreements/All");
        //}
    }
}