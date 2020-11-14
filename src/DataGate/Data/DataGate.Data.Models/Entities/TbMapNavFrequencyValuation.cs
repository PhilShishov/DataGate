namespace DataGate.Data.Models.Entities
{
    using System.Collections.Generic;
    using DataGate.Data.Models.Domain;

    public partial class TbMapNavFrequencyValuation
    {
        public TbMapNavFrequencyValuation()
        {
            TbCalendar = new HashSet<TbCalendar>();
        }

        public int IdDomFreq { get; set; }
        public int IdDomValDate { get; set; }

        public virtual TbDomNavFrequency IdDomFreqNavigation { get; set; }
        public virtual TbDomValutationDate IdDomValDateNavigation { get; set; }
        public virtual ICollection<TbCalendar> TbCalendar { get; set; }
    }
}
