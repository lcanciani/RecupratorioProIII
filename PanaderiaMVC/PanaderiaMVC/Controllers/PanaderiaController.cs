using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PanaderiaMVC.APP_Data;
using PanaderiaMVC.Models;

namespace PanaderiaMVC.Controllers
{
    public class PanaderiaController : Controller
    {
        // GET: Panaderia
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Alta()
        {
            GestorBD gestor = new GestorBD();
            VMAlta vma = new VMAlta();
            vma.ListaDely = gestor.cargarComboDelivery();
            vma.Listadesa = gestor.cargarComboDesayuno();
            return View(vma);
        }

        [HttpPost]
        public ActionResult Alta(AltaPedido al)
        {
            GestorBD gestor = new GestorBD();
            gestor.insertarPedido(al);
            return View("ListadoFacturacion",gestor.listaFacturacion());
        }
        public ActionResult Reporte(VMReporte vmr)
        {
            GestorBD gestor = new GestorBD();
            VMReporte vmr1 = new VMReporte();
            vmr1.ListaRepDelivery = gestor.ReporteDelivery();
            return View(vmr1);
        }
        public ActionResult ListadoFacturacion()
        {
            GestorBD gestor = new GestorBD();

            return View();
        }
    }
}