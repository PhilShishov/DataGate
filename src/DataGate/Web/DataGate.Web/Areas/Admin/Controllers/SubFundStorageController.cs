namespace DataGate.Web.Areas.Admin.Controllers
{
    using System.Globalization;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Web.Controllers;
    using DataGate.Web.InputModels.SubFunds;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class SubFundStorageController : BaseController
    {
        private readonly ISubFundStorageService service;
        private readonly ISubFundSelectListService serviceSelect;

        public SubFundStorageController(
                        ISubFundStorageService service,
                        ISubFundSelectListService serviceSelect)
        {
            this.service = service;
            this.serviceSelect = serviceSelect;
        }

        [Route("sf/edit/{id}/{date}")]
        public async Task<IActionResult> Edit(int id, string date)
        {
            var model = await this.service.GetByIdAndDate<EditSubFundInputModel>(id, date);

            this.SetViewDataValues();

            return this.View(model);
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //[Route("sf/edit/{id}/{date}")]
        //public async Task<IActionResult> Edit(EditSubFundInputModel model)
        //{
        //}

        private void SetViewDataValues()
        {
            this.ViewData["Status"] = this.serviceSelect.GetAllTbDomSFStatus();
            this.ViewData["CesrClass"] = this.serviceSelect.GetAllTbDomCesrClass();
            this.ViewData["GeographicalFocus"] = this.serviceSelect.GetAllTbDomGeographicalFocus();
            this.ViewData["GlobalExposure"] = this.serviceSelect.GetAllTbDomGlobalExposure();
            this.ViewData["CurrencyCode"] = this.serviceSelect.GetAllTbDomCurrencyCode();
            this.ViewData["NavFrequency"] = this.serviceSelect.GetAllTbDomFrequency();
            this.ViewData["ValuationDate"] = this.serviceSelect.GetAllTbDomValuationDate();
            this.ViewData["CalculationDate"] = this.serviceSelect.GetAllTbDomCalculationDate();
            this.ViewData["DerivMarket"] = this.serviceSelect.GetAllTbDomDerivMarket();
            this.ViewData["DerivPurpose"] = this.serviceSelect.GetAllTbDomDerivPurpose();
            this.ViewData["PrincipalAssetClass"] = this.serviceSelect.GetAllTbDomPrincipalAssetClass();
            this.ViewData["TypeOfMarket"] = this.serviceSelect.GetAllTbDomTypeOfMarket();
            this.ViewData["PrincipalInvestmentStrategy"] = this.serviceSelect.GetAllTbDomPrincipalInvestmentStrategy();
            this.ViewData["SfCatMorningStar"] = this.serviceSelect.GetAllTbDomSfCatMorningStar();
            this.ViewData["SfCatSix"] = this.serviceSelect.GetAllTbDomSfCatSix();
            this.ViewData["SfCatBloomberg"] = this.serviceSelect.GetAllTbDomSfCatBloomberg();

            //this.ViewData["FundContainer"] = await this.context.TbHistoryFund.Select(f => f.FOfficialFundName).ToList();
        }
    }
}
