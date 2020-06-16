namespace DataGate.Web.InputModels.Files
{
    using DataGate.Services.Mapping;

    public class FeesInputModel : IMapFrom<UploadOnSuccessDto>
    {
        public string AreaName { get; set; }

        public string Date { get; set; }

        public int Id { get; set; }

        public int FileId { get; set; }
    }
}
