namespace DataGate.Services.Data.ViewSetups
{
    using System;
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Data.Agreements;
    using DataGate.Services.Data.Entities;
    using DataGate.Services.Mapping;
    using DataGate.Web.Dtos.Overviews;

    public static class AgreementsVMSetup
    {
        //public static T SetGet<T>(IAgreementsService service, string function)
        //{
        //    var today = DateTime.Today;
        //    var agreements = service.GetAll(function, today, 1).ToList();

        //    var entity = new AllAgreementOverviewDto()
        //    {
        //        Date = today.ToString(GlobalConstants.RequiredWebDateTimeFormat),
        //        agreements = agreements,
        //    };
        //    return AutoMapperConfig.MapperInstance.Map<T>(entity);
        //}

        //public static async Task SetPost(EntitiesViewModel model, IEntityService service, string functionAll, string functionActive)
        //{
        //    var date = DateTimeParser.WebFormat(model.Date);
        //    bool isInSelectionMode = model.SelectedColumns != null ? true : false;

        //    var headers = await service.GetAll(functionActive, null, date).FirstOrDefaultAsync();
        //    model.Headers = headers.ToList();
        //    model.HeadersSelection = headers.ToList();

        //    // ---------------------------------------------------------
        //    //
        //    // Algorithm for getting values and headers based on:
        //    // 1. Date update of table
        //    // 2. Selection mode as columns or not
        //    // 3. Active entities or not
        //    // 4. Selected entity or not
        //    if (isInSelectionMode)
        //    {
        //        var dto = AutoMapperConfig.MapperInstance.Map<GetWithSelectionDto>(model);

        //        if (model.IsActive)
        //        {
        //            headers = await service.GetAllSelected(functionActive, dto).FirstOrDefaultAsync();
        //            model.Headers = headers.ToList();
        //            model.Values = await service.GetAllSelected(functionActive, dto, 1).ToListAsync();
        //        }
        //        else if (!model.IsActive)
        //        {
        //            headers = await service.GetAllSelected(functionAll, dto, 1).FirstOrDefaultAsync();
        //            model.Headers = headers.ToList();
        //            model.Values = await service.GetAllSelected(functionAll, dto, 1).ToListAsync();
        //        }
        //    }
        //    else if (!isInSelectionMode)
        //    {
        //        if (model.IsActive)
        //        {
        //            model.Values = await service.GetAll(functionActive, null, date, 1).ToListAsync();
        //        }
        //        else if (!model.IsActive)
        //        {
        //            model.Values = await service.GetAll(functionAll, null, date, 1).ToListAsync();
        //        }
        //    }

        //    if (model.SelectTerm != null)
        //    {
        //        model.Values = await CreateTableView.AddTableToViewAsync(model.Values, model.SelectTerm.ToLower()).ToListAsync();
        //    }
        //}
    }
}