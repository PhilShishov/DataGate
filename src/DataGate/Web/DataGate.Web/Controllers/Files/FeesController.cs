namespace DataGate.Web.Controllers.Files
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Web.InputModels.Files;
    using Microsoft.AspNetCore.Mvc;

    public class FeesController : BaseController
    {
        [HttpGet]
        [Route("fees/{fileId}")]
        public async Task<IActionResult> Index(UploadOnSuccessDto dto)
        {
            return this.View();



            //return this.ShowInfo(
            //   InfoMessages.FileUploaded,
            //   dto.RouteName,
            //   new { area = dto.AreaName, id = dto.Id, date = dto.Date });
        }
    }
}
