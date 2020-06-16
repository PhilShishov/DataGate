namespace DataGate.Web.Controllers.Files
{
    using System.Threading.Tasks;

    using DataGate.Common;
    using DataGate.Services.Mapping;
    using DataGate.Web.InputModels.Files;
    using Microsoft.AspNetCore.Mvc;

    public class FeesController : BaseController
    {
        [Route("fees/{fileId}")]
        public async Task<IActionResult> Index(UploadOnSuccessDto dto)
        {
            var viewModel = AutoMapperConfig.MapperInstance.Map<FeesInputModel>(dto);

            return this.View(viewModel);



            //return this.ShowInfo(
            //   InfoMessages.FileUploaded,
            //   dto.RouteName,
            //   new { area = dto.AreaName, id = dto.Id, date = dto.Date });
        }
    }
}
