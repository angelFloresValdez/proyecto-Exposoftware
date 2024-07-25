using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPOO2.Models
{
    /// <summary> Modelo que representa a un jefe dentro del sistema.</summary>
    public class JefeModel
    {
        /// <summary> Id único del jefe.</summary>
        public Guid Id { get; set; }

        /// <summary>Nombre completo del jefe.</summary>
        public string NombreJefe { get; set; }

        /// <summary>Departamento al que pertenece el jefe. </summary>
        public string Departamento { get; set; }

        /// <summary>Sueldo del jefe.</summary>
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int Sueldo { get; set; }
    }
}