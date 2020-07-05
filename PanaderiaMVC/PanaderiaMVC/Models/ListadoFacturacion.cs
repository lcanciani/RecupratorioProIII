using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanaderiaMVC.Models
{
    public class ListadoFacturacion
    {

        public string Cliente { set; get; }
        public string TipoDesayuno { set; get; }
        public string TipoDelivery { set; get; }
        public double PrecioTotal { set; get; }

    }
}