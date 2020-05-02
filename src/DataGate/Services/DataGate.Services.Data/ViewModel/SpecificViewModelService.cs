//namespace DataGate.Services.Data.ViewModel
//{
//    using System;
//    using System.Globalization;

//    using DataGate.Common;
//    using DataGate.Web.ViewModels.Entities;

//    public static class SpecificViewModelService
//    {
//        private static void SetProperties(SpecificEntityViewModel model, IEntityService<string[]> service)
//        {
//            //ThrowEntityNotFoundExceptionIfLessonDoesNotExist(lessonId);
//            //private void ThrowEntityNotFoundExceptionIfIdDoesNotExist(int id)
//            //{
//            //    if (!this.Exists(id))
//            //    {
//            //        throw new EntityNotFoundException(nameof(TbHistoryFund));
//            //    }
//            //}

//            //private bool Exists(int id) => this.repository.All().Any(x => x.FId == id);
//            //private bool Exists(int id) => this.repository.All().Any(x => x.SFId == id);
//            //private bool Exists(int id) => this.repository.All().Any(x => x.SCId == id);

//            var date = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);
//            int entityId = model.EntityId;

//            model.Entity = this.fundsService.GetFundWithDateById(date, entityId).ToList();
//            model.EntityDistinctDocuments = this.fundsService.
//                GetDistinctFundDocuments(date, entityId).ToList();
//            model.EntityDistinctAgreements = this.fundsService.GetDistinctFundAgreements(date, entityId).ToList();

//            model.EntitySubEntities = this.fundsService.GetFund_SubFunds(date, entityId).ToList();
//            model.EntitiesHeadersForColumnSelection = this.fundsService
//                                                                .GetFund_SubFunds(date, entityId)
//                                                                .Take(1)
//                                                                .ToList();
//            model.EntityTimeline = this.fundsService.GetFundTimeline(entityId).ToList();
//            model.EntityDocuments = this.fundsService.GetAllFundDocuments(entityId).ToList();
//            model.EntityAgreements = this.fundsService.GetAllFundAgreements(date, entityId).ToList();

//            model.StartConnection = DateTime.ParseExact(model.Entity.ToList()[1][0], GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);

//            if (model.EndConnection != null)
//            {
//                model.EndConnection = DateTime.ParseExact(model.Entity.ToList()[1][1], GlobalConstants.SqlDateTimeFormatParsing, CultureInfo.InvariantCulture);
//            }

//            //this.ViewData["ProspectusFileTypes"] = this.fundsSelectListService.GetAllProspectusFileTypes();
//            //this.ViewData["AgreementsFileTypes"] = this.fundsSelectListService.GetAllAgreementsFileTypes();
//            //this.ViewData["AgreementsStatus"] = this.agreementsSelectListService.GetAllTbDomAgreementStatus();
//            //this.ViewData["Companies"] = this.agreementsSelectListService.GetAllTbCompanies();
//        }
//    }
//}