using System;
using System.Collections.Generic;
using System.Text;

namespace Manajemen_Kasir_MCC_Ranur
{
    class DisplayFlex
    {
        public int width { private get; set; }
        public String align { protected get; set; }
        public String type { get; set; }

        public DisplayFlex(int width, String align, string type)
        {
            this.width = width;
            this.align = align;
            this.type = type;
        }

        public DisplayFlex()
        {
            this.width = 20;
            this.align = "left";
            this.type = "space";
        }

    }
}
