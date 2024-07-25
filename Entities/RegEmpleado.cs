using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPOO2.Entities
{
    /// <summary>
    /// Clase que representa a un empleado registrado en el sistema.
    /// </summary>
    public class RegEmpleado
    {
        /// <summary>Id único del empleado. </summary>
        public Guid Id { get; set; }

        /// <summary> Nombre completo del empleado. </summary>
        public string? NombreCompleto { get; set; }

        /// <summary>Fecha de entrada del empleado a la empresa. </summary>
        public DateTime FechaEntrada { get; set; }

        /// <summary> Fecha de nacimiento del empleado.</summary>
        public DateTime FechaNac { get; set; }

        /// <summary> Nacionalidad del empleado. </summary>
        public string? Nacionalidad { get; set; }

        /// <summary> Estado civil del empleado. </summary>
        public string? EstadoCivil { get; set; }

        /// <summary> CURP (Clave Única de Registro de Población) del empleado. </summary>
        public string? Curp { get; set; }

        /// <summary>RFC (Registro Federal de Contribuyentes) del empleado. </summary>
        public string? Rfc { get; set; }

        /// <summary> Domicilio del empleado. </summary>
        public string? Domicilio { get; set; }

        /// <summary> Turno del empleado.</summary>
        public string? Turno { get; set; }

        /// <summary>Nombre del jefe directo del empleado.</summary>
        public string? Jefe { get; set; }

        /// <summary>Departamento al que pertenece el empleado.</summary>
        public string? Departamento { get; set; }

        /// <summary> Id del jefe del empleado. </summary>
        public Guid? JefeId { get; set; }

        /// <summary> Objeto que representa al jefe del empleado. </summary>
        public Jefe? Jefe1 { get; set; }
    }
}