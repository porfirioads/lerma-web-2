using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    /// <summary>
    /// Representa un registro de administrador.
    /// </summary>
    public class Administrador
    {
        private string nombreUsuario;
        private string password;

        /// <summary>
        /// Obtiene o establece el valor de nombreUsuario.
        /// </summary>
        public string NombreUsuario
        {
            get
            {
                return nombreUsuario;
            }

            set
            {
                nombreUsuario = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de password.
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        /// <summary>
        /// Obtiene la representación como cadena del objeto.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("user: {0}, pswd: {1}", nombreUsuario, password);
        }

        /// <summary>
        /// Devuelve la instancia de la entidad con el identificador dado.
        /// </summary>
        /// <param name="nombreUsuario">
        /// Es el valor del campo que identifica al registro.
        /// </param>
        /// <returns>
        /// La instancia de la entidad o null si no se encontró un registro con
        /// el identificador dado.
        /// </returns>
        public static Administrador Find(string nombreUsuario)
        {
            return ConexionBD.GetAdministrador(nombreUsuario);
        }

        /// <summary>
        /// Inserta o actualiza la entidad en la base de datos.
        /// </summary>
        /// <returns>
        /// true si la entidad fue insertada o actualizada correctamente o false
        /// si no se pudo guardar.
        /// </returns>
        public bool Save()
        {
            if (Find(nombreUsuario) == null)
            {
                return ConexionBD.InsertarAdministrador(this);
            }
            else
            {
                // TODO Actualizar el administrador
                return false;
            }
        }

        /// <summary>
        /// Devuelve todas las instancias de la entidad en la base de datos.
        /// </summary>
        /// <returns>
        /// La lista de las entidades.
        /// </returns>
        public List<Administrador> All()
        {
            throw new NotImplementedException();
        }
    }
}