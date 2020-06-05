namespace DataGate.Web.Controllers
{
    using System;

    using DataGate.Common;
    using DataGate.Services.Data.Agreements;
    using DataGate.Web.Helpers;
    using DataGate.Web.ViewModels.Agreements;
    using Microsoft.AspNetCore.Mvc;

    public class AgreementsController : BaseController
    {
        private readonly IAgreementsService service;

        public AgreementsController(
            IAgreementsService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("allagreements")]
        public IActionResult Overview()
        {
            return this.View();
        }

        [HttpGet]
        [Route("agreements/{type}")]
        public IActionResult All(string type)
        {
            string function = FunctionSwapper.GetResult(type,
                                                  QueryDictionary.SqlFunctionAllAgreementsFunds,
                                                  QueryDictionary.SqlFunctionAllAgreementsSubFunds,
                                                  QueryDictionary.SqlFunctionAllAgreementsShareClasses);

            var today = DateTime.Today;
            var agreements = this.service.GetAll<AllAgreementViewModel>(function, today);

            var viewModel = new AllAgreementOverviewViewModel()
            {
                Date = today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
                Agreements = agreements,
            };

            return this.View(viewModel);
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


//private static string GetCorrectTypeName(string controllerName)
//{
//    string typeName = string.Empty;

//    switch (controllerName)
//    {
//        case GlobalConstants.FundsControllerName:
//            typeName = FundsNameDisplay;
//            break;
//        case GlobalConstants.SubFundsControllerName:
//        case GlobalConstants.FundSubFundsControllerName:
//            typeName = SubFundsNameDisplay;
//            break;
//        case GlobalConstants.ShareClassesControllerName:
//        case GlobalConstants.SubFundShareClassesControllerName:
//            typeName = ShareClassesNameDisplay;
//            break;
//    }

//    return typeName;
//}