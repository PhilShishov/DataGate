namespace DataGate.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using DataGate.Services.AutoComplete;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class AutoCompleteController : Controller
    {
        //public JsonResult AutoCompleteList(string selectTerm)
        //{
        //    ISet<string> result = AutoCompleteService.GetResult(selectTerm, this.service);

        //    var modifiedData = result.Select(f => new
        //    {
        //        id = f,
        //        text = f,
        //    });

        //    return this.Json(modifiedData);
        //}

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
