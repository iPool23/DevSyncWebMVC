using System;
using System.IO;
using System.Web.Mvc;
using Presentacion.Models;
using Negocio;
using Entidad;

namespace Presentacion.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth/Login
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // POST: Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var negUsuario = new NegUsuario();
                EntUsuario usuario = negUsuario.AutenticarUsuario(model.Username, model.Password);

                if (usuario != null)
                {
                    // Guardar la información del usuario en la sesión
                    Session["Usuario"] = usuario;

                    // Redirigir a la página principal o dashboard
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
                }
            }

            return View(model);
        }

        // GET: Auth/Register
        public ActionResult Register()
        {
            return View(new UsuarioModel());
        }

        // POST: Auth/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                string imgPath = null;

                try
                {
                    // Validar y guardar la imagen
                    if (model.ImgFile != null && model.ImgFile.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(model.ImgFile.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                        // Asegurarse de que el directorio existe antes de guardar
                        if (!Directory.Exists(Server.MapPath("~/Content/Images/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Content/Images/"));
                        }

                        model.ImgFile.SaveAs(path);
                        imgPath = "/Content/Images/" + fileName;
                    }

                    // Lógica para registrar el usuario
                    var negUsuario = new NegUsuario();
                    bool isRegistered = negUsuario.RegistrarUsuario(new EntUsuario
                    {
                        sNombreUsuario = model.sNombreUsuario,
                        sCorreo = model.sCorreo,
                        sContrasenia = model.sContrasenia,
                        sNombres = model.sNombres,
                        sApellidos = model.sApellidos,
                        sImgUrl = imgPath,
                        eCodigoRol = new EntRol { iCodigo = 7 } // Código de rol usuario por defecto
                    });

                    if (isRegistered)
                    {
                        // Redirigir a la página de login
                        return RedirectToAction("Login", "Auth");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error al registrar el usuario.");
                    }
                }
                catch (IOException ioEx)
                {
                    ModelState.AddModelError("", "Error al procesar la imagen: " + ioEx.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocurrió un error inesperado: " + ex.Message);
                }
            }

            return View(model);
        }

        // GET: Auth/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}