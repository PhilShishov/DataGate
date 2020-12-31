// Copyright (c) DataGate Project. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DataGate.Web.Controllers.Funds
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Recent;
    using DataGate.Services.Data.Storage.Contracts;
    using DataGate.Services.Notifications.Contracts;
    using DataGate.Web.Hubs;
    using DataGate.Web.Infrastructure.Extensions;
    using DataGate.Web.InputModels.Funds;
    using DataGate.Web.Resources;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;

    [Area(EndpointsConstants.AdminAreaName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.LegalRoleName)]
    public class FundStorageController : BaseController
    {
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly INotificationService notificationService;
        private readonly IRecentService recentService;
        private readonly IFundStorageService service;
        private readonly IFundSelectListService serviceSelect;
        private readonly SharedLocalizationService sharedLocalizer;

        public FundStorageController(
                        IHubContext<NotificationHub> hubContext,
                        INotificationService notificationService,
                        IRecentService recentService,
                        IFundStorageService fundService,
                        IFundSelectListService fundServiceSelect,
                        SharedLocalizationService sharedLocalizer)
        {
            this.hubContext = hubContext;
            this.notificationService = notificationService;
            this.recentService = recentService;
            this.service = fundService;
            this.serviceSelect = fundServiceSelect;
            this.sharedLocalizer = sharedLocalizer;
        }

        [Route("f/new")]
        public async Task<IActionResult> Create()
        {
            await this.recentService.Save(this.User, this.Request.Path);

            this.SetViewDataValues();
            return this.View(new CreateFundInputModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("f/new")]
        public async Task<IActionResult> Create(
                     [Bind("InitialDate", "EndDate", "FundName", "CSSFCode", "Status",
                           "LegalForm", "LegalVehicle", "LegalType", "FACode", "FundAdmin",
                           "DEPCode", "TACode", "CompanyTypeDesc", "TinNumber", "LEICode", "RegNumber",
                           "VATRegNumber", "VATIdentificationNumber", "IBICNumber",  "RecaptchaValue")] CreateFundInputModel model)
        {
            bool doesExist = await this.service.DoesExist(model.FundName);

            if (!this.ModelState.IsValid || doesExist)
            {
                if (doesExist)
                {
                    this.ShowError(this.sharedLocalizer.GetHtmlString(ErrorMessages.ExistingEntityName));
                }

                this.SetViewDataValues();
                return this.View(model);
            }

            var fundId = await this.service.Create(model);
            var date = DateTimeExtensions.ToWebFormat(model.InitialDate.AddDays(1));

            var message = string.Format(InfoMessages.CreateNotification, model.FundName);
            await this.notificationService.Add(this.User, message, this.Request.Path);

            int count = await this.notificationService.Count(this.User);
            await this.hubContext.Clients.All.SendAsync("SendNotification", count);

            return this.ShowInfo(
                this.sharedLocalizer.GetHtmlString(InfoMessages.SuccessfulCreate),
                EndpointsConstants.RouteDetails + EndpointsConstants.FundArea,
                new { area = EndpointsConstants.FundArea, id = fundId, date = date });
        }

        [Route("f/edit/{id}/{date}")]
        public async Task<IActionResult> Edit(int id, string date)
        {
            await this.recentService.Save(this.User, this.Request.Path);

            var model = this.service.ByIdAndDate<EditFundInputModel>(id, date);
            model.InitialDate = model.InitialDate.AddDays(1);

            this.SetViewDataValues();

            return this.View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("f/edit/{id}/{date}")]
        public async Task<IActionResult> Edit(
                     [Bind("Id", "InitialDate", "FundName", "CSSFCode", "Status",
                           "LegalForm", "LegalVehicle", "LegalType", "FACode", "FundAdmin",
                           "DEPCode", "TACode", "CompanyTypeDesc", "TinNumber", "LEICode",
                           "RegNumber", "VATRegNumber", "VATIdentificationNumber", "IBICNumber",
                           "CommentTitle", "CommentArea", "RecaptchaValue")] EditFundInputModel model)
        {
            bool doesExistAtDate = await this.service.DoesExistAtDate(model.FundName, model.InitialDate);

            if (!this.ModelState.IsValid || doesExistAtDate)
            {
                if (doesExistAtDate)
                {
                    this.ShowError(this.sharedLocalizer.GetHtmlString(ErrorMessages.ExistingEntityAtDate));
                }

                this.SetViewDataValues();
                return this.View(model);
            }

            var fundId = await this.service.Edit(model);
            var date = DateTimeExtensions.ToWebFormat(model.InitialDate.AddDays(1));

            return this.ShowInfo(
                this.sharedLocalizer.GetHtmlString(InfoMessages.SuccessfulEdit),
                EndpointsConstants.RouteDetails + EndpointsConstants.FundArea,
                new { area = EndpointsConstants.FundArea, id = fundId, date = date });
        }

        private void SetViewDataValues()
        {
            this.ViewData["Status"] = this.serviceSelect.AllTbDomFStatus();
            this.ViewData["LegalForm"] = this.serviceSelect.AllTbDomLegalForm();
            this.ViewData["LegalVehicle"] = this.serviceSelect.AllTbDomLegalVehicle();
            this.ViewData["LegalType"] = this.serviceSelect.AllTbDomLegalType();
            this.ViewData["CompanyTypeDesc"] = this.serviceSelect.AllTbDomCompanyDesc();
        }
    }
}
