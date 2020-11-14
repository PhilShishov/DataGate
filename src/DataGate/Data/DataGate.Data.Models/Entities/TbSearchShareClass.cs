namespace DataGate.Data.Models.Entities
{
    public partial class TbSearchShareClass
    {
        public int ScId { get; set; }
        public string ScOfficialShareClassName { get; set; }
        public string ScIsinCode { get; set; }

        public virtual TbShareClass Sc { get; set; }
    }
}
