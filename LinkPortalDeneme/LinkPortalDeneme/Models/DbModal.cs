using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPortalDeneme
{
    public class DbModal
    {
        public int LinkID { get; set; }
        public string LinkAd { get; set; }
        public string LinkProd { get; set; }
        public string LinkPreProd { get; set; }
        public string LinkTest { get; set; }
        public string LinkKategoriAD { get; set; }
        public string LinkOrtamAD { get; set; }
        public string LinkDesc { get; set; }

        public string LinkUrl { get; set; }

        public string ProdUrl { get; set; }
        public string PreProdUrl { get; set; }
        public string TestUrl { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public string message { get; set; }

    }
}
