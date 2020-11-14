namespace DataGate.Data.Models.Entities
{
    using System;

    public partial class TbCalendar
    {
        public int IdDomFreq { get; set; }
        public int IdDomValDate { get; set; }
        public DateTime CalendarDate { get; set; }

        public virtual TbMapNavFrequencyValuation IdDom { get; set; }
    }
}
