namespace DataGate.Web.InputModels.Files
{
    using DataGate.Services.Mapping;

    public class UploadOnSuccessDto : IMapFrom<UploadDocumentInputModel>
    {
        public string AreaName { get; set; }

        public string Date { get; set; }

        public int Id { get; set; }

        public string RouteName { get; set; }

    }
}
