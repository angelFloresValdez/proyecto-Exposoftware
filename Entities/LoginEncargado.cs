using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPOO2.Entities
{
    public class LoginEncargado
    {

        /// <summary>Id único del Login.</summary>
        public Guid Id { get; set; }

        /// <summary>Correo Unico del encargado.</summary>
        public string CorreoEnc { get; set; }

        /// <summary> Contraseña del encargado.</summary>
        public string ContraseñaEnc { get; set; }


    }
}