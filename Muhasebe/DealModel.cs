using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe
{
    class DealModel
    {
        public int proCode { get; set; }
        public long date { get; set; }
        public float price { get; set; }
        public long amount { get; set; }
        public string customer { get; set; }
        public int sellerID { get; set; }
        public int type { get; set; }

        public DealModel(int proCode)
        {
            this.proCode = proCode;
        }

    }
}
