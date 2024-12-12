using System;
using System.Web.Mvc;
using Entidad;
using Negocio;

namespace Presentacion.Controllers
{
    public class ActividadController : Controller
    {
        private NegActividad negActividad = new NegActividad();
        private NegTipoActividad negTipoActividad = new NegTipoActividad();

        // GET: Actividad/Listar
        public ActionResult Listar(int codigoProyecto, int codigoSprint)
        {
            var actividades = negActividad.ListarPorSprint(codigoSprint);
            ViewBag.CodigoProyecto = codigoProyecto;
            ViewBag.CodigoSprint = codigoSprint;
            return View(actividades);
        }

        // GET: Actividad/ActividadForm
        public ActionResult ActividadForm(int codigoProyecto, int codigoSprint, int? codigo)
        {
            EntActividad actividad = codigo.HasValue ? negActividad.ObtenerPorCodigo(codigo.Value) : new EntActividad { eSprint = new EntSprint { codigo = codigoSprint } };
            ViewBag.TiposActividad = new SelectList(negTipoActividad.Listar(), "iCodigo", "sNombre");
            ViewBag.CodigoProyecto = codigoProyecto;
            return View(actividad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActividadForm(EntActividad actividad, int? codigoProyecto)
        {
            if (ModelState.IsValid)
            {
                if (actividad.iCodigo == 0)
                {
                    negActividad.Registrar(actividad);
                }
                else
                {
                    negActividad.Actualizar(actividad);
                }
                return RedirectToAction("Listar", new { codigoProyecto = codigoProyecto, codigoSprint = actividad.eSprint.codigo });
            }
            ViewBag.TiposActividad = new SelectList(negTipoActividad.Listar(), "iCodigo", "sNombre", actividad.eTipoActividad.iCodigo);
            ViewBag.CodigoProyecto = codigoProyecto;
            return View(actividad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Eliminar(int id)
        {
            try
            {
                bool result = negActividad.Eliminar(id);
                return Json(new { success = result });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}