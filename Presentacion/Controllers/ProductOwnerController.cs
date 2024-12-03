using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidad;
using Negocio;

namespace Presentacion.Controllers
{
    public class ProductOwnerController : Controller
    {
        // GET: ProductOwner
        public ActionResult Proyecto()
        {
            return View();
        }

        public ActionResult EditarProyecto()
        {
            return View();
        }

        public JsonResult ListarProyectos()
        {
            List<EntProyecto> lista = new List<EntProyecto>();

            lista = new NegProyecto().Listar();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}