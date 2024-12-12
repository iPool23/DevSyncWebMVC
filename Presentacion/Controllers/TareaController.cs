using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidad;
using Negocio;

namespace Presentacion.Controllers
{
    public class TareaController : Controller
    {
        private NegTarea negTarea = new NegTarea();
        private NegUsuario negUsuario = new NegUsuario();
        private NegEstado negEstado = new NegEstado();

        public ActionResult Listar(int codigoActividad)
        {
            var tareas = negTarea.ListarPorActividad(codigoActividad);
            ViewBag.CodigoActividad = codigoActividad;
            return View(tareas);
        }

        public ActionResult TareaForm(int codigoActividad, int? codigo)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Auth");
                
            var usuarioActual = (EntUsuario)Session["Usuario"];
            
            EntTarea tarea = codigo.HasValue ?
                negTarea.ObtenerPorCodigo(codigo.Value) :
                new EntTarea
                {
                    eActividad = new EntActividad { iCodigo = codigoActividad },
                    dtFechaInicio = DateTime.Now,
                    iProgreso = 0,
                    eEstado = new EntEstado { iCodigo = 1 },
                    eUsuario = usuarioActual
                };

            ViewBag.Prioridades = new SelectList(new[]
            {
                new { Id = 1, Nombre = "Baja" },
                new { Id = 2, Nombre = "Media" },
                new { Id = 3, Nombre = "Alta" }
            }, "Id", "Nombre");

            return View(tarea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TareaForm(EntTarea tarea)
        {
            if (ModelState.IsValid)
            {
                if (tarea.iCodigo == 0)
                {
                    negTarea.Registrar(tarea);
                }
                else
                {
                    tarea.dtFechaActualizacion = DateTime.Now;
                    negTarea.Actualizar(tarea);
                }
                return RedirectToAction("Listar", new { codigoActividad = tarea.eActividad.iCodigo });
            }
            return View(tarea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Eliminar(int id)
        {
            try
            {
                bool result = negTarea.Eliminar(id);
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