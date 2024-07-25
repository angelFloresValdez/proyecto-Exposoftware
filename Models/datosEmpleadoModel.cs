using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPOO2.Models
{
    /// <summary>
    /// Modelo que representa los datos de un empleado en el sistema.
    /// </summary>
    public class datosEmpleadoModel
    {
        /// <summary>Id único del empleado.</summary>
        public Guid Id { get; set; }

        /// <summary> Nombre completo del empleado. </summary>
        public string Nombre { get; set; }

        /// <summary> Departamento al que pertenece el empleado. </summary>
        public string Departamento { get; set; }

        /// <summary> Turno de trabajo del empleado. </summary>
        public string Turno { get; set; }

        /// <summary>Fecha de entrada del empleado a la empresa. </summary>
        public DateTime FechaEntrada { get; set; }

        /// <summary> Fecha de baja o retiro del empleado de la empresa.</summary>
        public DateTime FechaBaja { get; set; }

        /// <summary>Tiempo activo que lleva el empleado en la empresa (por ejemplo, años, meses, días).</summary>
        public string TiempoActivo { get; set; }
    }
}