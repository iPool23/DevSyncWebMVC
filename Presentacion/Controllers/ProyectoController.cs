using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using Negocio;
using Entidad;
using System.Linq;

namespace Presentacion.Controllers
{
    public class ProyectoController : Controller
    {
        private NegProyecto negProyecto = new NegProyecto();
        private NegUsuario negUsuario = new NegUsuario();

        private NegRol negRol = new NegRol();

        // GET: Proyecto/Listar
        public ActionResult Listar()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Auth");

            var usuario = (EntUsuario)Session["Usuario"];
            List<EntProyecto> proyectos = negProyecto.ObtenerProyectosPorUsuario(usuario.iCodigo);

            return View(proyectos);
        }

        // GET: Proyecto/CrearProyecto
        public ActionResult CrearProyecto()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Auth");

            return View("ProyectoForm", new EntProyecto());
        }

        // POST: Proyecto/CrearProyecto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearProyecto(EntProyecto proyecto, string NombreEquipo)
        {
            if (ModelState.IsValid)
            {
                var usuario = (EntUsuario)Session["Usuario"];
                proyecto.eCodigoLider = usuario;

                if (proyecto.ImgFile != null && proyecto.ImgFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(proyecto.ImgFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    proyecto.ImgFile.SaveAs(path);
                    proyecto.sImgUrl = "/Images/" + fileName;
                }

                negProyecto.CrearProyecto(proyecto, NombreEquipo);
                return RedirectToAction("Listar");
            }

            return View("ProyectoForm", proyecto);
        }

        // GET: Proyecto/EditarProyecto/5
        public ActionResult EditarProyecto(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Auth");

            var proyecto = negProyecto.ObtenerProyectoPorId(id);
            if (proyecto == null)
                return HttpNotFound();

            return View("ProyectoForm", proyecto);
        }

        // POST: Proyecto/EditarProyecto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProyecto(EntProyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                if (proyecto.ImgFile != null && proyecto.ImgFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(proyecto.ImgFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    proyecto.ImgFile.SaveAs(path);
                    proyecto.sImgUrl = "/Images/" + fileName;
                }

                negProyecto.ActualizarProyecto(proyecto);
                return RedirectToAction("Listar");
            }

            return View("ProyectoForm", proyecto);
        }

        // POST: Proyecto/EliminarProyecto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EliminarProyecto(int id)
        {
            var proyecto = negProyecto.ObtenerProyectoPorId(id);
            if (proyecto == null)
                return Json(new { success = false, message = "Proyecto no encontrado" });

            negProyecto.EliminarProyecto(id);
            return Json(new { success = true });
        }

        // GET: Proyecto/EditarEquipo/5
        [HttpGet]
        public ActionResult EditarEquipo(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Auth");

            var proyecto = negProyecto.ObtenerProyectoPorId(id);
            if (proyecto == null)
                return HttpNotFound();

            return View(proyecto);
        }

        // POST: Proyecto/EditarEquipo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEquipo(int id, string nombreEquipo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombreEquipo))
                {
                    ModelState.AddModelError("", "El nombre del equipo es requerido");
                    var proyecto = negProyecto.ObtenerProyectoPorId(id);
                    return View(proyecto);
                }

                var proyectoExistente = negProyecto.ObtenerProyectoPorId(id);
                if (proyectoExistente == null)
                    return HttpNotFound();

                negProyecto.ActualizarEquipoProyecto(id, nombreEquipo);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al actualizar el equipo: " + ex.Message);
                var proyecto = negProyecto.ObtenerProyectoPorId(id);
                return View(proyecto);
            }
        }

        // GET: Proyecto/EditarUsuariosEquipo/5
        public ActionResult EditarUsuariosEquipo(int id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Auth");

            var proyecto = negProyecto.ObtenerProyectoPorId(id);
            if (proyecto == null)
                return HttpNotFound();

            // Obtener usuarios del equipo
            var usuariosEquipo = negProyecto.ObtenerUsuariosPorProyecto(id);
            ViewBag.UsuariosEquipo = usuariosEquipo;

            return View(proyecto);
        }

        // POST: Proyecto/AgregarUsuarioProyecto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarUsuarioProyecto(int iCodigo, string CorreoUsuario)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Auth");

            try
            {
                // Obtener el usuario por correo
                var usuario = negUsuario.ObtenerUsuarioPorCorreo(CorreoUsuario);
                if (usuario == null)
                {
                    TempData["ErrorMessage"] = "Usuario no encontrado.";
                    return RedirectToAction("EditarUsuariosEquipo", new { id = iCodigo });
                }

                // Obtener el proyecto y su equipo
                var proyecto = negProyecto.ObtenerProyectoPorId(iCodigo);
                if (proyecto == null || proyecto.eCodigoEquipo == null)
                {
                    TempData["ErrorMessage"] = "Proyecto no encontrado o no tiene equipo asignado.";
                    return RedirectToAction("EditarUsuariosEquipo", new { id = iCodigo });
                }

                // Verificar si el usuario ya está en el equipo
                if (negUsuario.UsuarioEstaEnEquipo(proyecto.eCodigoEquipo.iCodigo, usuario.iCodigo))
                {
                    TempData["ErrorMessage"] = "El usuario ya es miembro del equipo.";
                    return RedirectToAction("EditarUsuariosEquipo", new { id = iCodigo });
                }

                // Agregar usuario al equipo y asignar rol en el proyecto (rol 7 = User)
                negUsuario.AgregarUsuarioAEquipo(proyecto.eCodigoEquipo.iCodigo, usuario.iCodigo);
                negProyecto.AsignarRolUsuarioEnProyecto(iCodigo, usuario.iCodigo, 7); // Asignamos rol 7 (User)

                TempData["SuccessMessage"] = "Usuario agregado exitosamente al proyecto.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al agregar usuario: " + ex.Message;
            }

            return RedirectToAction("EditarUsuariosEquipo", new { id = iCodigo });
        }

        [HttpPost]
        public ActionResult CambiarRolUsuarioProyecto(int proyectoId, int usuarioId, int nuevoRol)
        {
            try
            {
                negProyecto.AsignarRolUsuarioEnProyecto(proyectoId, usuarioId, nuevoRol);
                return Json(new { success = true, message = "Rol actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult EliminarUsuarioProyecto(int proyectoId, int usuarioId)
        {
            try
            {
                negProyecto.EliminarUsuarioDeProyecto(proyectoId, usuarioId);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}