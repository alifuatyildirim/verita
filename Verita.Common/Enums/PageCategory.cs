using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verita.Common.Enums
{
    public enum PageCategory
    {
        [Description("Güvenli Gıda")]
        GuvenliGida=0,
        [Description("Merak Ettikleriniz")]
        MerakEttikleriniz=1,
        [Description("B2b Ürünler")]
        B2b=2,
        [Description("Ürünlerimiz")]
        Urunlerimiz=3, 
    }
}
