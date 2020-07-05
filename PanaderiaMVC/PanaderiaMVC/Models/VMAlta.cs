using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanaderiaMVC.Models
{
    public class VMAlta
    {
        public AltaPedido Al { set; get; }
        public List<Delivery> ListaDely { set; get; }
        public List<Desayuno> Listadesa { set; get; }
    }
}