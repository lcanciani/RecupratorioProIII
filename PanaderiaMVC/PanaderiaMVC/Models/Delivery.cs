using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanaderiaMVC.Models
{
    public class Delivery
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public double PrecioEntrega { set; get; }
    }
}