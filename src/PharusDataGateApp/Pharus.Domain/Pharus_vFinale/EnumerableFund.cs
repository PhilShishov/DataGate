using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pharus.Domain.Pharus_vFinale
{
    public class EnumerableFund : IEnumerable<TbHistoryFund>
    {
        private List<TbHistoryFund> funds;

        public EnumerableFund(params TbHistoryFund[] funds)
        {
            this.funds = new List<TbHistoryFund>(funds);
        }
        public IEnumerator<TbHistoryFund> GetEnumerator()
        {
            return this.funds.Select((t, i) => this.funds[i]).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
