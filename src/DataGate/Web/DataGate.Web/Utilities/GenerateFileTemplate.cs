namespace DataGate.Web.Utilities
{
    using System;
    using System.Globalization;
    using System.Linq;

    using DataGate.Common;
    using DataGate.Web.ViewModels.Entities;

    using Microsoft.AspNetCore.Mvc;

    public static class GenerateFileTemplate
    {
        public static FileStreamResult GenerateExcelTemplate(EntitiesViewModel model, string controllerName)
        {
            string typeName = model.GetType().Name;

            FileStreamResult fileStreamResult = ExtractTable.ExtractTableAsExcel(model.Entities.ToList(), typeName, controllerName);

            return fileStreamResult;
        }

        public static FileStreamResult GeneratePdfTemplate(EntitiesViewModel model, string controllerName)
        {
            var chosenDate = DateTime.ParseExact(model.ChosenDate, GlobalConstants.WebDateTimeFormatRequired, CultureInfo.InvariantCulture);
            string typeName = model.GetType().Name;

            FileStreamResult fileStreamResult = ExtractTable
                .ExtractTableAsPdf(model.Entities.ToList(), chosenDate, typeName, controllerName);

            return fileStreamResult;
        }
    }
}
