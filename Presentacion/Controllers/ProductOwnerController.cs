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

        // Proyectos
        public ActionResult Proyecto()
        {
            return View();
        }

        public ActionResult EditarProyecto()
        {
            return View();
        }

        // Sprints

        public ActionResult ListarSprints()
        {
            return View();
        }

        public ActionResult CrearEditarSprint()
        {
            return View();
        }

        // Insumos

        public ActionResult ListarInsumos()
        {
            return View();
        }

        public ActionResult EditarInsumo()
        {
            return View();
        }

        // Actividades

        public ActionResult ListarActividades()
        {
            return View();
        }

        public ActionResult EditarActividad()
        {
            return View();
        }

        // Tareas

        public ActionResult ListarTareas()
        {
            return View();
        }

        public ActionResult EditarTarea()
        {
            return View();
        }

        // Etiquetas

        public ActionResult ListarEtiquetas()
        {
            return View();
        }

        public ActionResult EditarEtiqueta()
        {
            return View();
        }

        // Comentarios

        public ActionResult ListarComentarios()
        {
            return View();
        }

        public ActionResult EditarComentario()
        {
            return View();
        }

    }
}