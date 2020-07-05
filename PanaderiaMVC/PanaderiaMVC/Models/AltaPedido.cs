using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanaderiaMVC.Models
{
    public class AltaPedido
    {
        public string Cliente { set; get; }
        public int Desayuno { set; get; }
        public int Delivery { set; get; }
        public int Porciones { set; get; }
    }
}