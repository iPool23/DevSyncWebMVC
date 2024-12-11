using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidad;
using Negocio;
using Presentacion.ViewModels;

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
        public ActionResult CrearEditarSprint()
        {
            return View();
        }
        public ActionResult ListarSprints()
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

        // Lógica uwu

        public JsonResult ListarProyectos()
        {
            List<EntProyecto> lista = new List<EntProyecto>();

            lista = new NegProyecto().Listar();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        // Insumos //
        //Obtener Insumos por id de Sprint
        public JsonResult Insumo(int codigo)
        {
            List<EntInsumo> lista = new NegInsumo().listar(codigo);


            var resultado = lista.Select(s => new
            {
                codigo = s.codigo,
                nombre = s.nombre,
                descripcion = s.descripcion,
                cantidad = s.cantidad,
                codigoSprint = s.objSprint.codigo,
                nombreSprint = s.objSprint.nombre
            });

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        //Obtener Insumos por id de insumo
        public JsonResult InsumoPorId(int codigo)
        {
            List<EntInsumo> lista = new NegInsumo().ObtenerPorCodigo(codigo);


            var resultado = lista.Select(s => new
            {
                codigo = s.codigo,
                nombre = s.nombre,
                descripcion = s.descripcion,
                cantidad = s.cantidad,
                codigoSprint = s.objSprint.codigo,
                nombreSprint = s.objSprint.nombre
            });

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        //Registrar un nuevo insumo
        [HttpPost]
        public JsonResult GuardarInsumo(EntInsumo objeto)
        {
            object resultado;

            // Si el objeto llega nulo, inicializa objSprint
            if (objeto.objSprint == null)
            {
                objeto.objSprint = new EntSprint { codigo = objeto.objSprint?.codigo ?? 0 };
            }

            if (objeto.codigo == 0)
            {
                resultado = new NegInsumo().registrar(objeto);
            }
            else
            {
                resultado = new NegInsumo().editar(objeto);
            }

            return Json(new { resultado = resultado }, JsonRequestBehavior.AllowGet);
        }
        //Eliminar insumo
        [HttpPost]
        public JsonResult EliminarInsumo(EntInsumo objeto)
        {
            try
            {
                if (objeto != null && objeto.codigo > 0)
                {
                    // Lógica para eliminar el sprint
                    bool resultado = new NegInsumo().Eliminar(objeto.codigo);

                    return Json(new { resultado });
                }
                else
                {
                    return Json(new { resultado = false, mensaje = "Código inválido." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { resultado = false, mensaje = ex.Message });
            }
        }

        // Sprints //
        //Obtener Sprints con id del proyecto
        public JsonResult Sprint(int codigoProyecto)
        {
            List<EntSprint> lista = new NegSprint().listar(codigoProyecto);

            // Mapear a un objeto anónimo con formato de fecha personalizado
            var resultado = lista.Select(s => new
            {
                codigo = s.codigo,
                nombre = s.nombre,
                progreso = s.progreso,
                fechaInicio = s.fechaInicio.ToString("dd-MM-yyyy"),
                fechaFin = s.fechaFin.ToString("dd-MM-yyyy"),
                usuarioCodigo = s.objUsuario.iCodigo,
                usuarioNombre = s.objUsuario.sNombres,
                codigoProyecto = s.objProyecto.iCodigo,
                nombreProyecto = s.objProyecto.sNombre,
            });

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        //Obtener Sprints por ID del sprint
        public JsonResult ObtenerSprintPorId(int codigo)
        {
            List<EntSprint> lista = new NegSprint().ObtenerPorCodigo(codigo);

            // Mapear a un objeto anónimo con formato de fecha personalizado
            var resultado = lista.Select(s => new
            {
                codigo = s.codigo,
                nombre = s.nombre,
                progreso = s.progreso,
                fechaInicio = s.fechaInicio.ToString("dd-MM-yyyy"),
                fechaFin = s.fechaFin.ToString("dd-MM-yyyy"),
                usuarioCodigo = s.objUsuario.iCodigo,
                usuarioNombre = s.objUsuario.sNombres,
                codigoProyecto = s.objProyecto.iCodigo,
                nombreProyecto = s.objProyecto.sNombre,
            });

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        //Registrar Sprint
        [HttpPost]
        public JsonResult GuardarSprint(EntSprint objeto)
        {
            object resultado;
            // Asegurar que objUsuario y objProyecto estén inicializados
            objeto.objUsuario = new EntUsuario { iCodigo = objeto.objUsuario?.iCodigo ?? 0 };
            objeto.objProyecto = new EntProyecto { iCodigo = objeto.objProyecto?.iCodigo ?? 0 };
            if (objeto.codigo == 0)
            {
                resultado = new NegSprint().registrar(objeto);
            }
            else
            {
                resultado = new NegSprint().editar(objeto);
            }
            return Json(new { resultado = resultado }, JsonRequestBehavior.AllowGet);
        }
        //Eliminar Sprint
        [HttpPost]
        public JsonResult EliminarSprint(EntSprint objeto)
        {
            try
            {
                if (objeto != null && objeto.codigo > 0)
                {
                    // Lógica para eliminar el sprint
                    bool resultado = new NegSprint().Eliminar(objeto.codigo);

                    return Json(new { resultado });
                }
                else
                {
                    return Json(new { resultado = false, mensaje = "Código inválido." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { resultado = false, mensaje = ex.Message });
            }
        }


    }
}