//namespace DataGate.Web.Controllers.Funds
//{
//    using System.Linq;

//    using DataGate.Common;
//    using DataGate.Services.Data.Funds.Contracts;
//    using Microsoft.AspNetCore.Authorization;
//    using Microsoft.AspNetCore.Mvc;

//    [Authorize]
//    public class FundSubEntitiesController : BaseController
//    {
//        private readonly IFundSubEntitiesService service;

//        public FundSubEntitiesController(IFundSubEntitiesService fundSubFundsService)
//        {
//            this.service = fundSubFundsService;
//        }

//        public JsonResult AutoCompleteSubFundList(string selectTerm, int entityId)
//        {
//            var entitiesToSearch = this.service
//                .GetEntity_SubEntities(null, entityId)
//                .Skip(1)
//                .ToList();

//            if (selectTerm != null)
//            {
//                entitiesToSearch = entitiesToSearch
//                    .Where(sf => sf[GlobalConstants.IndexEntityNameInSQLTable]
//                        .ToLower()
//                        .Contains(selectTerm
//                        .ToLower()))
//                    .ToList();
//            }

//            var modifiedData = entitiesToSearch.Select(sf => new
//            {
//                id = sf[GlobalConstants.IndexEntityNameInSQLTable],
//                text = sf[GlobalConstants.IndexEntityNameInSQLTable],
//            });

//            return this.Json(modifiedData);
//        }

//        //[HttpPost]
//        //public IActionResult ByIdAndDate()
//        //{
//        //    if (model.Entity != null && model.EntitySubEntities.Count > GlobalConstants.RowNumberOfHeadersInTable)
//        //    {
//        //        this.TempData[GlobalConstants.InfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
//        //        return this.View(model);
//        //    }


//        //    this.SetModelValuesForSpecificView(model);

//        //    if (model.Command == "Reset")
//        //    {
//        //        model.SelectTerm = GlobalConstants.DefaultAutocompleteSelectTerm;
//        //        return this.View(model);
//        //    }

//        //    bool isInSelectionMode = false;

//        //    if (model.SelectedColumns != null && model.SelectedColumns.Count > 0)
//        //    {
//        //        isInSelectionMode = true;
//        //    }

//        //    var chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.RequiredWebDateTimeFormat, CultureInfo.InvariantCulture);

//        //    if (model.SelectTerm == null)
//        //    {
//        //        if (isInSelectionMode)
//        //        {
//        //            this.CallEntitySubEntitiesWithSelectedColumns(model, chosenDate);
//        //        }
//        //        else if (!isInSelectionMode)
//        //        {
//        //            model.EntitySubEntities = this.fundsService.GetFund_SubFunds(chosenDate, model.EntityId).ToList();
//        //        }

//        //        return this.View(model);
//        //    }

//        //    if (isInSelectionMode)
//        //    {
//        //        this.CallEntitySubEntitiesWithSelectedColumns(model, chosenDate);
//        //    }
//        //    else if (!isInSelectionMode)
//        //    {
//        //        model.EntitySubEntities = this.fundsService
//        //            .GetFund_SubFunds(chosenDate, model.EntityId)
//        //            .ToList();
//        //    }

//        //    if (model.SelectTerm != null)
//        //    {
//        //        model.EntitySubEntities = CreateTableView.AddTableToView(model.EntitySubEntities, model.SelectTerm.ToLower());
//        //    }

//        //    if (model.Entity != null && model.EntitySubEntities.Count > GlobalConstants.RowNumberOfHeadersInTable)
//        //    {
//        //        this.TempData[GlobalConstants.InfoMessageDisplay] = InfoMessages.SuccessfullyUpdatedTable;
//        //        return this.View(model);
//        //    }

//        //    this.TempData[GlobalConstants.ErrorMessageDisplay] = ErrorMessages.TableModeIsEmpty;
//        //    this.ModelState.Clear();
//        //    return this.View();
//        //    return this.RedirectToAction();
//        //}
//    }
//}
