using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPOO2.Models
{
    /// <summary>Modelo que representa las credenciales de inicio de sesión de un encargado.</summary>
    public class LoginEncargadoModel
    {
        /// <summary>Constructor por defecto de la clase LoginEncargadoModel. </summary>
        public LoginEncargadoModel()
        {
        }

        /// <summary>Id único del encargado.</summary>
        public Guid Id { get; set; }

        /// <summary>Correo electrónico del encargado utilizado para iniciar sesión.</summary>
        public string CorreoEnc { get; set; }

        /// <summary>Contraseña del encargado utilizada para iniciar sesión.</summary>
        public string ContraseñaEnc { get; set; }
    }
}