using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoFinalPOO2.Models
{
    public class RegEmpleadoModel
    {
        /// <summary>Constructor por defecto de la clase RegEmpleadoModel.</summary>
        public RegEmpleadoModel()
        {
        }

        /// <summary>Id único del empleado.</summary>
        public Guid Id { get; set; }

        /// <summary>Nombre completo del empleado.</summary>
        public string NombreCompleto { get; set; }

        /// <summary>Fecha de entrada del empleado. </summary>
        public DateTime FechaEntrada { get; set; }

        /// <summary>Fecha de nacimiento del empleado.</summary>
        public DateTime FechaNac { get; set; }

        /// <summary>Nacionalidad del empleado.</summary>
        public string Nacionalidad { get; set; }

        /// <summary>Estado civil del empleado.</summary>
        public string EstadoCivil { get; set; }

        /// <summary>CURP (Clave Única de Registro de Población) del empleado.</summary>
        public string Curp { get; set; }

        /// <summary>RFC (Registro Federal de Contribuyentes) del empleado.</summary>
        public string Rfc { get; set; }

        /// <summary>Domicilio del empleado.</summary>
        public string Domicilio { get; set; }

        /// <summary>Turno de trabajo del empleado.</summary>
        public string Turno { get; set; }

        /// <summary>Nombre del jefe directo del empleado.</summary>
        public string Jefe { get; set; }

        /// <summary>Departamento al que pertenece el empleado.</summary>
        public string Departamento { get; set; }

        /// <summary>Id del jefe del empleado. </summary>
        public Guid? JefeId { get; set; }

        /// <summary>Modelo del jefe del empleado.</summary>
        public JefeModel? JefeModel { get; set; }

        /// <summary> Nombre del jefe del empleado.</summary>
        public string? NombreJefe { get; set; }

        /// <summary>Lista de elementos seleccionables para los jefes.</summary>
        public List<SelectListItem>? ListJefes { get; set; }
    }
}