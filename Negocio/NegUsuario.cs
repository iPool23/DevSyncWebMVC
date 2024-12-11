using Datos;
using Entidad;

namespace Negocio
{
    public class NegUsuario
    {
        private DatUsuario datUsuario = new DatUsuario();

        public EntUsuario AutenticarUsuario(string nombreUsuario, string contrasenia)
        {
            return datUsuario.AutenticarUsuario(nombreUsuario, contrasenia);
        }

        public bool RegistrarUsuario(EntUsuario usuario)
        {
            return datUsuario.RegistrarUsuario(usuario);
        }

        public EntUsuario ObtenerUsuarioPorCorreo(string correo)
        {
            return datUsuario.ObtenerUsuarioPorCorreo(correo);
        }

    }
}