using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPOO2.Entities
{
  public class Jefe
  {
    /// <summary>Id único del jefe.</summary>
    public Guid Id { get; set; }

    /// <summary>Nombre del jefe. </summary>
    public string? NombreJefe { get; set; }

    /// <summary> Departamento al que pertenece el jefe. </summary>
    public string? Departamento { get; set; }

    /// <summary> Sueldo del jefe.</summary>
    public int Sueldo { get; set; }

    /// <summary>Lista de empleados que están bajo la supervisión de este jefe.</summary>
    public List<RegEmpleado>? Jefes { get; set; }
  }
}