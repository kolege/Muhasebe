using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Muhasebe
{
    class ProductModel
    {
        public string proCode { get; set; }
        public string description { get; set; }
        public long amount { get; set; }
        public Bitmap image { get; set; }

        public ProductModel(string proCode)
        {
            this.proCode = proCode;
        }
    }
}
