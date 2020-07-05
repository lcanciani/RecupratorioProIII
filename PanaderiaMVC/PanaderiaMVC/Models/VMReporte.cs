using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanaderiaMVC.Models
{
    public class VMReporte
    {
        public ReporteDel Rd { set; get; }
        public List<ReporteDel> ListaRepDelivery { set; get; }
    }
}